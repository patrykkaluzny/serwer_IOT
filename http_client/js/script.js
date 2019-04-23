var TimerID;
var IsValid=true;
$(function(){
	$("#conButton").click(function(){
		var URL=document.getElementById("urlField").value;
		
		if(this.value=="Connect")
		{
			if(CheckHttp(URL))
			{
				this.value="Disconnect";
				TimerID=setInterval(() => httpGetAsync(URL),100);
			}
			else{
				alert('Wrong URL');
			}			
		}
		else{
			clearTimeout(TimerID)
			this.value="Connect";
			
		}
		
	});
});

$(function(){
	$("#rgbButton").click(function(){
		var R=document.getElementById("rField").value;
		var G=document.getElementById("gField").value;
		var B=document.getElementById("bField").value;
		if(isNumber(R)&&isNumber(B)&&isNumber(G))
		{
			if(isValid(R)&&isValid(B)&&isValid(G))
			{
				var RGB= "background-color:RGB("+R+","+G+","+B+")";
				document.getElementById("colorField").style=RGB;
				var URL= document.getElementById("urlField").value;
				
				if(URL.length!=0)
				{
					postRGB_JSON(R,G,B,URL)
				}
				else{
					alert("Wrong URL");
				}
			}
			else{
				alert('Invalid RGB values')
			}
		}
		else{
			alert('RGB value must be numeric')
			
		}
		
	});
});


function httpGetAsync(theUrl)   //async http request
{
    var xmlHttp = new XMLHttpRequest();
	xmlHttp.open("GET", theUrl, true); // true for asynchronous 
    xmlHttp.addEventListener('load', function(){
		if(this.status===200){
			var JSONtext=this.responseText;
			var JSONobj = JSON.parse(JSONtext);
			replaceHead(JSONobj);
			replaceTable(JSONobj);
		}
		else{		
			alert('Wrong URL');
			clearTimeout(TimerID)
			document.getElementById("conButton").value="Connect";
			
		}
	});
    xmlHttp.send(null);
}
function replaceHead(JSON)
{
	var old_tHead = document.getElementById("dataTable").tHead;
	var new_tHead = document.createElement('tHead');

	var tableTR=document.createElement('tr');
	for(var i=0;i<JSON.confData.length;i++)
	{
		var newTh=document.createElement('th');
		newTh.innerText=JSON.confData[i];
		tableTR.appendChild(newTh);
	}
	new_tHead.appendChild(tableTR)
	old_tHead.parentNode.replaceChild(new_tHead,old_tHead)
	
}
function replaceTable(JSON)
{
	$(function () {
    var content = '';
    content += '<tbody>';
    for(var j=0; j<JSON.sensorData.length;j++)
	{
		content += '<tr>';
		for(var i=0;i<JSON.sensorData[j].length;i++)
		{
			content += '<td>' + JSON.sensorData[j][i] + '</td>';
		}
		content += '</tr>';
    }
    content += '</tbody>';
    $('table tbody').replaceWith(content);  
	});  	
}
function CheckHttp(URL)
{
	if(URL.search("http://")==0)
	{
		return true;
	}
	else {
		return false;
	}
}	
function isNumber(n) {
  return !isNaN(parseFloat(n)) && isFinite(n);
}

function isValid(n) {
  if(n>0&&n<256)
	  return true;
  else return false;
}
function postRGB_JSON(r,g,b,URL)
{
	
	var json = dataToJSON(r,g,b)
	URL=URL+"?mode="+json;
	var xmlHttp = new XMLHttpRequest();
	console.log(URL);
	xmlHttp.open("GET", URL, true);
	xmlHttp.onreadystatechange = function () {
    if (xmlHttp.readyState === 4 && xmlHttp.status === 200) {
        
		}
	};
	xmlHttp.send(null);
}
function dataToJSON(r,g,b)
{
	var RGB = r+';'+g+';'+b+';'
	var string = '{"colorList":["'+RGB+'"]}'
	
	return string;
	
}

	