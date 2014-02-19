// JavaScript Document
//window.onload = function()
//{
//	loadcheckbox();
//}

function loadcheckbox()
{
	$("checkAll").onclick = function()
	{
		ck(this);
	}

}

function ck(o)
{
	var _c = document.getElementsByTagName("input");
	
	for(var i=0;i<_c.length;i++)
	{
		if(_c[i].className == "checkitem")
		{
			_c[i].checked = o.checked;
		}
	}	
}

