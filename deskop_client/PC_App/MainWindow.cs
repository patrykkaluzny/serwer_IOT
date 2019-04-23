using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.Linq;
using System.Dynamic;
using System.Net.Http;
using System.Drawing;


namespace PC_App
{
    public partial class MainWindow : Form
    {
        private string URL;
        private static System.Timers.Timer httpRequestTimer;
        private int numberOfSensors;
        private List<ChartData> dataToShow = new List<ChartData>();
        private string buttonClickedTime;
        private string dataFolderPath;
        public delegate void AddListItem();
        public AddListItem addDelegate;
        private Thread uiThread;
        private int timerPeroid;
        Color currentColor;
        public MainWindow()
        {

            InitializeComponent();
            timerPeroid = 100;
            setHttpRequestTimer();
            dataFolderPath = Path.Combine(System.IO.Path.GetDirectoryName(Application.ExecutablePath), "Data").ToString();
            CreateFolder(dataFolderPath);

            urlBox.Text = "http://192.168.1.15/server.php";
            numberOfSensors = 0;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Enabled = false;
            timeText.Text = timerPeroid.ToString();
            SetChart();
            refreshText.Text = timerPeroid.ToString();
            refreshText.Enabled = false;
            currentColor = Color.White;
            colorText.ReadOnly = true;
            setModeComboBox();
            setColoTable(modeComboBox.SelectedItem.ToString());
        }

        private async void connectButton_Click(object sender, EventArgs e)
        {
            if (connectButton.Text.ToString().Equals("Connect"))
            {
                URL = urlBox.Text.ToString();
                bool IsReachable = await CheckIfAddressIsReachable(URL);
                if (IsReachable)
                {
                    SetChart();
                    httpRequestTimer.Start();
                    connectButton.Text = "Disconnect";
                    comboBox1.Enabled = true;
                    buttonClickedTime = DateTime.Now.ToString("HH-mm-ss_yyyy_MM_dd");


                }
                else
                {
                    MessageBox.Show("Address is not reachable");
                }

            }
            else
            {
                comboBox1.Enabled = false;
                comboBox1.SelectedItem = "";
                httpRequestTimer.Stop();
                numberOfSensors = 0;
                dataToShow.Clear();
                connectButton.Text = "Connect";
            }

        }
        private async Task<String> MakeRequestAsync(String url)
        {
            String responseText = await Task.Run(() =>
            {
                try
                {
                    HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                    WebResponse response = request.GetResponse();
                    Stream responseStream = response.GetResponseStream();
                    return new StreamReader(responseStream).ReadToEnd();
                }
                catch (Exception e)
                {
                    Console.Write(e);
                }
                return null;
            });

            return responseText;
        }
        public void setHttpRequestTimer()
        {
            httpRequestTimer = new System.Timers.Timer(timerPeroid);
            httpRequestTimer.AutoReset = true;
            httpRequestTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        }
        private async void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            string response = await MakeRequestAsync(URL);
            if (response != null)
            {

                HttpData requestedData = new HttpData();
                requestedData = JsonConvert.DeserializeObject<HttpData>(response);
                addDelegate = new AddListItem(() => addListItemMethod(requestedData));
                uiThread = new Thread(new ThreadStart(() => threadFunction(requestedData)));
                uiThread.IsBackground = true;
                uiThread.Start();
            }
        }

        private async Task<bool> CheckIfAddressIsReachable(string URL)
        {
            string response = await MakeRequestAsync(URL);
            if (response != null)
            {
                return true;
            }
            return false;
        }


        private void AddLineToList(List<string> data)
        {
            ListViewItem row = new ListViewItem(data.ToArray());
            dataList.Items.Add(row);
        }
        private void configureDataListView(List<String> columnsNames)
        {
            dataList.Clear();
            dataList.View = View.Details;
            int ColumnWith = dataList.Width / columnsNames.Count;
            foreach (string title in columnsNames)
            {
                dataList.Columns.Add(title, ColumnWith, HorizontalAlignment.Left);
            }
        }
        private void addListItemMethod(HttpData data)
        {
            DisplayList(data);
            SaveDataToFiles(data);
            if (numberOfSensors != data.sensorData.Count)
            {
                ChartDataInit(data.sensorData);
                comboBox1.Items.Clear();
                foreach (List<string> l in data.sensorData)
                {
                    comboBox1.Items.Add(l[1]);
                }
                comboBox1.SelectedItem = comboBox1.Items[0];
                numberOfSensors = data.sensorData.Count;
            }
            AddDataToChart(data.sensorData);
            var selected = comboBox1.GetItemText(comboBox1.SelectedItem);
            DisplayDataOnChart(GetDataFromName(dataToShow, selected));
        }
        private void DisplayList(HttpData requestedData)
        {
            configureDataListView(requestedData.confData);
            foreach (List<string> data in requestedData.sensorData)
            {
                AddLineToList(data);
            }
        }
        public void threadFunction(HttpData response)
        {
            dataListThreadClass dataListThreadClassObject = new dataListThreadClass(this, response);
            dataListThreadClassObject.Run();
        }
        public class dataListThreadClass
        {
            MainWindow threadWinodw;
            HttpData mResponse;
            public dataListThreadClass(MainWindow windowForm, HttpData response)
            {
                threadWinodw = windowForm;
                mResponse = response;
            }
            public void Run()
            {
                try
                {
                    threadWinodw.Invoke(threadWinodw.addDelegate);
                }
                catch (ObjectDisposedException e)
                {
                    Console.Write(e);
                    Application.Exit();

                }
            }

        }

        /// data archiving functions ///////////////////////////////////
        private void CreateFolder(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
        private void CreateTextFile(string path, List<string> heading)
        {
            if (!File.Exists(path))
            {
                string line = null;
                foreach (string word in heading)
                {
                    line = line + word + ";";
                }
                File.AppendAllText(path, line + Environment.NewLine);

            }
        }
        private void SaveDataToFiles(HttpData requestedData)
        {
            foreach (List<string> list in requestedData.sensorData)
            {
                string filePath = dataFolderPath + "\\" + buttonClickedTime + "_" + list[0] + ".txt";
                string line = null;
                foreach (string word in list)
                {
                    line = line + word + ";";
                }
                CreateTextFile(filePath, requestedData.confData);
                File.AppendAllText(filePath, line + Environment.NewLine);
            }
        }
        /// charts functions ///////////////////////////////////
        private List<double> GetDataFromName(List<ChartData> l, string name)
        {
            foreach (ChartData c in l)
            {
                if (name.Equals(c.GetName()))
                {
                    return c.GetData();
                }
            }
            return null;
        }
        private void SetChart()
        {
            chart1.ChartAreas[0].AxisX.Maximum = 0;
            chart1.ChartAreas[0].AxisX.Minimum = -60;
            chart1.ChartAreas[0].AxisX.Title = "Last 60 seconds of measurements";
            chart1.ChartAreas[0].AxisX.LabelStyle.Enabled = false;
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
        }
        private void DisplayDataOnChart(List<double> dataList)
        {
            chart1.Series[0].Points.Clear();
            double x = -60;
            foreach (double value in dataList)
            {

                chart1.Series[0].Points.AddXY(x, value);
                x += timerPeroid / 1000.0;
            }

        }
        private void ChartDataInit(List<List<string>> list)
        {
            dataToShow.Clear();
            foreach (List<string> data in list)
            {
                dataToShow.Add(new ChartData(timerPeroid, Int32.Parse(data[0]), data[1]));
            }
        }
        private void AddDataToChart(List<List<string>> list)
        {
            foreach (List<string> data in list)
            {
                var tempInt = Int32.Parse(data[0]);
                double tempDouble;
                try
                {
                    tempDouble = Double.Parse(data[2].Replace('.', ','));
                }
                catch
                {
                    tempDouble = 0;
                }
                dataToShow[tempInt].AddToList(tempDouble);
            }
        }
        ///color tab functions/////////////////////////////
        private void setButton_Click(object sender, EventArgs e)
        {
            int ms;
            bool isNumerical = int.TryParse(timeText.Text.ToString(), out ms);
            if (isNumerical)
            {
                if (ms >= 100)
                {
                    bool isTimerActive = httpRequestTimer.Enabled;
                    if (isTimerActive)
                    {
                        /////// stop timer //////////
                        comboBox1.Enabled = false;
                        comboBox1.SelectedItem = "";
                        httpRequestTimer.Stop();
                        numberOfSensors = 0;
                        dataToShow.Clear();
                        connectButton.Text = "Connect";
                    }
                    ///change time////////
                    timerPeroid = ms;
                    httpRequestTimer.Interval = timerPeroid;
                    timeText.Text = timerPeroid.ToString();
                    refreshText.Text = timerPeroid.ToString();
                    if (isTimerActive)
                    {
                        ///start timer 
                        SetChart();
                        httpRequestTimer.Start();
                        connectButton.Text = "Disconnect";
                        comboBox1.Enabled = true;
                        buttonClickedTime = DateTime.Now.ToString("HH-mm-ss_yyyy_MM_dd");
                    }
                }
                else
                {
                    MessageBox.Show("Wrong value");
                }
            }
            else
            {
                MessageBox.Show("Wrong value");
            }
        }
        private async void sendButton_Click(object sender, EventArgs e)
        {
            string JSON = colorTableToJSON();
            string urlPost;
            urlPost = urlBox.Text.ToString() + "?mode=" + JSON;
            string response = await MakeRequestAsync(urlPost);
        }

        private void chooseButton_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() != System.Windows.Forms.DialogResult.Cancel)
            {
                currentColor = colorDialog.Color;
                colorText.BackColor = currentColor;
                colorTable.DefaultCellStyle.SelectionBackColor = currentColor;
                if(modeComboBox.SelectedItem.Equals("1x1"))
                {
                    DataGridViewCellStyle CellStyle = new DataGridViewCellStyle();
                    CellStyle.BackColor = currentColor;
                    colorTable.Rows[0].Cells[0].Style = CellStyle;
                }
            }
        }
        private void setModeComboBox()
        {
            modeComboBox.Items.Add("1x1");
            modeComboBox.Items.Add("8x8");
            modeComboBox.SelectedIndex = modeComboBox.Items.IndexOf("8x8");
        }
        private void setColoTable(string value)
        {

            colorTable.Columns.Clear();
            colorTable.Rows.Clear();
            colorTable.DefaultCellStyle.SelectionBackColor = Color.White;
            if (value.Equals("8x8"))
            {
                for (int i = 0; i < 8; i++)
                {
                    colorTable.Columns.Add("", "");
                    DataGridViewColumn column = colorTable.Columns[i];
                    column.Width = colorTable.Width/8;
                    colorTable.Rows.Add("", "");
                    DataGridViewRow row = colorTable.Rows[i];
                    row.Height = colorTable.Height/8;
                }
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        DataGridViewCellStyle CellStyle = new DataGridViewCellStyle();
                        CellStyle.BackColor = Color.White;
                        colorTable.Rows[i].Cells[j].Style = CellStyle;
                    }
                }
            }
            else
            {
                colorTable.Columns.Add("", "");
                DataGridViewColumn column = colorTable.Columns[0];
                column.Width = colorTable.Width;
                colorTable.Rows.Add("", "");
                DataGridViewRow row = colorTable.Rows[0];
                row.Height = colorTable.Height;
                DataGridViewCellStyle CellStyle = new DataGridViewCellStyle();
                CellStyle.BackColor = Color.White;
                colorTable.Rows[0].Cells[0].Style = CellStyle;
            }


        }

        private void colorTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            DataGridViewCellStyle CellStyle = new DataGridViewCellStyle();
            CellStyle.BackColor = currentColor;
            colorTable.CurrentCell.Style = CellStyle;
        }
        private string colorTableToJSON()
        {
            ColorsJson colorClass = new ColorsJson();
            for(int i=0;i<colorTable.RowCount;i++)
            {
                for(int j=0;j< colorTable.RowCount; j++)
                {
                    DataGridViewCellStyle CellStyle = colorTable.Rows[i].Cells[j].Style;
                    string color = CellStyle.BackColor.R + ";" + CellStyle.BackColor.G + ";" + CellStyle.BackColor.B + ";";
                    colorClass.colorList.Add(color);
                }
            }
            return JsonConvert.SerializeObject(colorClass);
        }

        private void modeComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            setColoTable(modeComboBox.SelectedItem.ToString());
        }

        private async void turnoffButton_Click(object sender, EventArgs e)
        {
            string urlPost;
            urlPost = urlBox.Text.ToString() + "?clear";
            string response = await MakeRequestAsync(urlPost);
        }
    }
}

