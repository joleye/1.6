var ye,
JoleYe = ye = JoleYe||{version:"201106"};

/*加载事件*/
JoleYe.ready = function(func){
	if(typeof(window.onload)=="function")
	{
		var ofunc = window.onload;
		window.onload = function(){
			ofunc();func();
		}
	}
	else
	{
		window.onload = function(){
			func();
		}
	}
}

JoleYe.g = function(o){
	if(typeof(o) == "string")
		return document.getElementById(o);	
	else
		return o;
}
JoleYe.gcls = function(){
	
}

JoleYe.dom = function(){}

JoleYe.gname = function(c){
	var tag = document.getElementsByName(c);
	var dom = [];
	var j = 0;
	for(var i=0;i<=tag.length;i++)
	{
		if(ye.getAttr(tag[i],"name")==c)
		{
			dom[j] = tag[i];
			j++;
		}	
	}
	return dom;
}

JoleYe.addEvent = function(elem,eventName,handler){
	if (elem.addEventListener) {
        elem.addEventListener(eventName, handler, userCapture);
    } else if (elem.attachEvent) {
        elem.attachEvent("on" + eventName, handler);
    }
}


JoleYe.setAttr = function(element,key,val){
	element.setAttribute(key,val);
}

JoleYe.getAttr = function(o,key){
	if(o)
	return o.getAttribute(key);
}

/*页面加载通知*/
JoleYe.notify = function(str){
	JoleYe.ready(function(){
		JoleYe.notify.show(str);					 
	});
}


JoleYe.notify.show = function(str,tit,wid,hei,uri){
		lspay.notify.mask();
		if(typeof(wid)=='undefined')
		 wid = 250;
		if(typeof(hei)=='undefined')
		hei = 100;
		if(typeof(tit)=='undefined')
		tit = '系统提示';
		

		if(typeof(uri)!='undefined')
		{
			lspay.ajax.get(uri,function(s){
				lspay.notify.display(tit,wid,hei,s.responseText);
			})
		}
		else
		lspay.notify.display(tit,wid,hei,str);
}

JoleYe.notify.display = function(tit,wid,hei,str){
		var dom = lspay.create("div");
		var str_id;
		if(L.g("PromptBoxForm"))
		str_id = "PromptBoxForm1";
		else
		str_id = "PromptBoxForm";
		
		dom.id = str_id;
		str = "<div style='font-size:14px;color:#ff3300;padding:10px;height:auto;'>"+str+"</div>"
		
		dom.innerHTML = "<div style='height:25px;line-height:25px;background-color: #6FA5D3;'><span style='display:block;float:left;'>"+tit+"</span><a href=\"javascript:;\" onclick=\"lspay.notify.close('"+str_id+"');\"  style=\"display:block;float:right;height:25px;width:50px;float:right;font-size:14px;font-weight: bold;text-align:center;\">关闭</a></div>"+str;
		
		
		
		dom.style.width = wid+"px";
		dom.style.height = "auto";
		dom.style.top = (document.documentElement.scrollTop + document.body.clientHeight/2-hei) + "px";
		dom.style.left = (document.body.clientWidth/2-wid/2)+"px";
		dom.style.margin = "auto";
		dom.style.padding = "0px";
		dom.style.border = "4px solid #6FA5D3";
		dom.style.zIndex = 2;
		dom.style.position = "absolute";
		dom.style.backgroundColor = "#eee";
		document.body.appendChild(dom);
}


JoleYe.notify.mask = function(){
	this.divName = "mask";
	var dom = lspay.create("div");
	dom.id = this.divName;
	dom.style.position = "absolute";
	dom.style.zIndex = "1";
	_scrollWidth = Math.max(document.body.scrollWidth,document.documentElement.scrollWidth);
	_scrollHeight = Math.max(document.body.scrollHeight,document.documentElement.scrollHeight);
	if(_scrollHeight<750)
	_scrollHeight = 750;
	
	dom.style.width = _scrollWidth + "px";
	dom.style.height = _scrollHeight + "px";
	dom.style.top = "0px";
	dom.style.left = "0px";
	dom.style.background = "#33393C";
	dom.style.filter = "alpha(opacity=50)";
	dom.style.opacity = "0.50";
	document.body.appendChild(dom);
}

/*提示信息*/
JoleYe.notify.Alert = function(str,tp,uri){
	var re_type = "";
	if(typeof(tp)!='undefined')
	{
		switch(tp)
		{
			case 'close':
			re_type = "";
			break;
			case 'reload':
			re_type = "parent.location.reload();";
			break;
			case 'url':
			re_type = 'parent.location.href="'+uri+'"';
			break;
			default:
			re_type = "parent.location.reload();";
		}
	}
	else
	{
		re_type = "parent.location.reload();";
	}
	
	var char = "<div style='text-align=center;height:30px;line-height:20px;margin-top:10px;'><button onclick='L.notify.close();"+re_type+"'>确定</button></div>";
	JoleYe.notify.show(str+char);	
}

//关闭新图层和mask遮罩层
JoleYe.notify.close = function(id){
	if(typeof(id)=='undefined')
	id = 'PromptBoxForm';
	
	if(lspay.g("mask"))
		document.body.removeChild(lspay.g("mask"));
	try
	{
		document.body.removeChild(lspay.g(id));
	}
	catch(e)
	{
		if(lspay.g(id))
		JoleYe.g(id).outerHTML = "";
	}
}

JoleYe.attr = function(key,val){
	this.setAttribute(key,val);
}

/*ajax*/
JoleYe.ajax = {};
JoleYe.ajax.get = function(uri,func){
	var xhr = (window.XMLHttpRequest)? new XMLHttpRequest():new ActiveXObject("MSXML2.XMLHTTP");
	xhr.open('GET', uri, true);
	xhr.onreadystatechange = function(){
		if(xhr.readyState == 4)
			func(xhr);
		};
	xhr.setRequestHeader("Content-Type","application/x-www-form-urlencoded;");
	xhr.send(''); 
}


/*排序功能*/
JoleYe.order = {};
JoleYe.order.check = function(name)
{
    var tags = document.getElementsByName(name);
    for(var i=0;i<tags.length;i++)
    {
        tags[i].value = tags[i].valid+"|"+tags[i].value;
    }
}


/*ajax编辑*/
JoleYe.edit = function(){
	if(ye.g("tedit"))
	{
		var o = ye.g("tedit");
		var span = o.getElementsByTagName('span');
		for(var i=0;i<span.length;i++)
		{
			if(span[i].className=="edit")
			{
			  span[i].title = "可编辑";	
			  span[i].onclick = function(){
				JoleYe.edit.click(this);
			  }
			}
		}
	}
}


JoleYe.edit.click = function(o){
	  o.className = 's_edit';
	  if(ye.getAttr(o,"type")=="bool")
	  {
		  	var dom = document.createElement("input");
			ye.setAttr(dom,"type","checkbox");
			if(o.innerHTML=="是")
			{
				dom.value = "1";
			}
			else
			{
				dom.value = "0";
				ye.setAttr(dom,"checked","");
			}
			dom.onclick = function(){
				if(this.checked)
					this.value = "1";
				else
					this.value = "0";	
			}
	  }
	  else
	  {
		  if(ye.len(o.innerHTML)<30)
		  {
			  var dom = document.createElement("input");
			  dom.className = "input";
			  dom.value = o.innerHTML;
		  }
		  else
		  {
			  var dom = document.createElement("textarea");
			  dom.className = "textarea";
			  o.setAttribute("width",500);
			  if(ye.len(o.innerHTML)<100)
			  o.setAttribute("height",50);
			  else
			  o.setAttribute("height",100);
			  
			  dom.value = o.innerHTML;
		  }
		  
		  if(typeof(o.getAttribute('width'))=='object')
		  dom.style.width = "220px";
		  else
		  dom.style.width = o.getAttribute('width')+"px";
	  }
	  o.innerHTML = "";
	  o.appendChild(dom);
	  
	  if(ye.getAttr(o,'type')=='bool')
	  {
		  if(dom.value=="1")
			dom.checked = true;
		  else
			dom.checked = false;
	  }
/*	  if (event.keyCode == 13){
        	o.firstChild.onblur();
      }*/
	  o.firstChild.onblur = function(){
		var valid = this.parentNode.getAttribute('valid');
		var table = this.parentNode.getAttribute('table');
		var field = this.parentNode.getAttribute('field');
		var type = this.parentNode.getAttribute('type');
		if(type=="int")
		{
			if(!/^\d+$/.test(this.value))
			{
				alert("数据类型错误");
				return;
			}
		}
		else if(type=="bool")
		{
			if(!/^0|1$/.test(this.value))
			{
				alert("数据类型错误");
				return;
			}
		}
		
		var val = this.value;
		this.parentNode.onclick = function(){JoleYe.edit.click(this);}
		if(ye.getAttr(o,'type')=='bool')
			if(val=="1")
				this.parentNode.innerHTML = "是";
			else
				this.parentNode.innerHTML = "否";
		else
			this.parentNode.innerHTML = val;

		JoleYe.ajax.get("../global/ajax.aspx?table="+table+"&field="+field+"&id="+valid+"&val="+escape(val),
			function(o){
				if(o.responseText=="ok")
				_obj.className = "edit";
				else
				{
					alert(o.responseText);
					_obj.className = "edit";
				}
			}); 
	  }
	  
	  o.onclick = "";
	  o.firstChild.focus();
	  _obj = o;
}

JoleYe.len = function(s) {
	 var l = 0;
	 var a = s.split("");
	 for (var i=0;i<a.length;i++) {
	  if (a[i].charCodeAt(0)<299) {
	   l++;
	  } else {
	   l+=2;
	  }
	 }
	 return l;
}

function G(o)
{
	return ye.g(o);	
}

function loadinput(_tag)
{
	var _t = document.getElementsByTagName(_tag);
	if(_t)
	{
		for(var i in _t)
		{
			if(_t[i].className!="" && _t[i].className!=undefined)
			{
				if(_t[i].className=="input" || _t[i].className.indexOf("input")>=0)
				{
					addEventClick(_t[i]);
				}
			}
		}
	}
}

//tbale->tr
function loadtr(o)
{
	if(o)
	{
		for(var i=0;i<o.length;i++)
		{
			if(o[i].getAttribute("joletype")=="mouse")
			{
			
	 			o[i].onmouseout = function(){this.style.backgroundColor='';};
	 			o[i].onmouseover = function(){this.style.backgroundColor='#BFDFFF'};
			}
		}
	}
}


var _cliobj;
function addEventClick(o)
{
	o.onclick = function(){
		this.className="inputOnclick In";
		_cliobj=this;
	};
	o.onfocus = function(){this.className="inputOnclick";}; 
	o.onblur = function(){this.className="input"};
	o.onmouseover = function(){
		var clsName = this.className;
		if(!/In$/.test(clsName))
		this.className = 'inputOnclick';
	}
	o.onmouseout = function(){if(this!=_cliobj) this.className = 'input';}
}

function loadcheckbox()
{
	if(ye.g("checkAll"))
	{
		ye.g("checkAll").onclick = function()
		{
			ck(this);
		}
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



//确认删除
function confirm_box(str)
{
	if(!confirm(str))
	    return false;
	else
	    return true;
}

function addContent(iname)
{
	try
	{
		if(document.getElementById(iname))
			var dom = document.getElementById(iname);
		else
			var dom = document.all.insertImg;
		

		
		var text = dom.value;
		var cont_name = "content";

		if(typeof(dom.getAttribute('val_name'))!="undefined" && typeof(dom.getAttribute('val_name')) != "object")
			cont_name = dom.getAttribute('val_name');
		
		if(FCKeditorAPI.GetInstance(cont_name))
		{
			if(/\.(jpg)|(gif)|(png)|(JPG)|(GIF)|(PNG)/.test(text))
			{
				var url = "<p align=\"center\"><img src="+text+" /></p>";
				FCKeditorAPI.GetInstance(cont_name).InsertHtml(url);//插入代码
			}
			else
			{
				var url = "<a href="+text+" target=\"_blank\">"+text+"</a>";
				FCKeditorAPI.GetInstance(cont_name).InsertHtml(url);//插入代码

			}
		}
		else
		{
			alert("none");	
		}
	}
	catch(e)
	{
		alert(e.message);
	}
}

/*绑定事件*/
JoleYe.ready(function(){
	loadinput("input");
	loadinput("textarea");
	var _o = document.getElementsByTagName("tr");
	loadtr(_o);
	loadcheckbox();
	JoleYe.edit();
})