
<?php
if (isset($_GET['mode']))
{
	$data=$_GET['mode'];
	$Path="sudo python /home/pi/PK_MJ/led.py";
	exec("$Path '$data'");
}
//turn off led matrix
{
else if (isset($_GET['clear']))
{
	$Path="sudo python /home/pi/PK_MJ/clear.py";
	exec("$Path");
}	
else
{
	$confArray =array('ID', 'Name', 'Value','Unit','Range');

	// code with 3 python scripts, TESTED
	/*$Path="sudo python3 /home/pi/PK_MJ/temp.py";
	$outputStr1=exec("$Path");
	$dataArray=array('0', 'Temparature', $outputStr1,'C','0-65');
	$sensorArray['0']=$dataArray;
	$Path="sudo python3 /home/pi/PK_MJ/press.py";
	$outputStr2=exec("$Path");
	$dataArray=array('1', 'Pressure', $outputStr2,'hPa','260-1260',);
	$sensorArray['1']=$dataArray;

	$Path="sudo python3 /home/pi/PK_MJ/humid.py";
	$outputStr3=exec("$Path");
	$dataArray=array('2', 'Humidity', $outputStr3,'%','0-100',);
	$sensorArray['2']=$dataArray;*/

	
	//code with "all.py" tested with emulator
	/*$Path="sudo python /home/pi/PK_MJ/all.py";
	$output=exec("$Path");
	$dataArray=array('0', 'Temparature', $output[0],'C','0-65');
	$sensorArray['0']=$dataArray;
	$dataArray=array('1', 'Pressure', $output[1],'hPa','260-1260',);
	$sensorArray['1']=$dataArray;
	$dataArray=array('2', 'Humidity', $output[2],'%','0-100',);
	$sensorArray['2']=$dataArray;*/
	
	//cpp code
	
	$Path="/home/pi/PK_MJ/RTIMULibDrive11/RTIMULibDrive11";
	$output=exec("$Path");
	$dataArray=array('0', 'Temparature', $output[0],'C','0-65');
	$sensorArray['0']=$dataArray;
	$dataArray=array('1', 'Pressure', $output[1],'hPa','260-1260',);
	$sensorArray['1']=$dataArray;
	$dataArray=array('2', 'Humidity', $output[2],'%','0-100',);
	$sensorArray['2']=$dataArray;*/
	
	
	
	$sendObject['confData']=$confArray;
	$sendObject['sensorData']=$sensorArray;


	$json_text=json_encode($sendObject);
	printf("%s", $json_text);
}

?>








