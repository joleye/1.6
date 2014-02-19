/**
	常用脚本
	by JoleYe 2009-5
 */
var $ = function(ObjName){return document.getElementById(ObjName)};
var JOLE= {
	//全选
	checkAll:function(obj,_id)
	{
		var _id = document.getElementsByName(_id);
		for(var i = 0;i<_id.length;i++)
		{
			_id[i].checked = obj.checked;
		}
	},
	//关闭
	Close:function(_id)
	{
		$(_id).style.display = "none";
	},
	//提交选择
	ture_Null:function(_id,obj)
	{
	   var _name = document.getElementsByName(_id);
	   var _str;
	   for(var i=0;i<_name.length;i++)
	   {
		   if(!_name[i].checked)
			   _str = false;
		   else
		   {
			   _str = true;
			   break;
		   }
		   
		   
	   }
	   if(!_str)
	   {
		   alert("您还没有选择，不能进行任何操作");
		   return false;
	   }
	   else
	   	return true
	   
	},
	del:function(_id,obj)
	{
		var _c = this.ture_Null(_id,obj);
		
		if(!_c)
			return false;
		
		if(confirm("确定要删除吗？删除后不可恢复"))
		return true;
		else
		return false;

	},
	//showBOX
	mask:function(_obj)
	{
		$(_obj).style.width = document.body.scrollWidth;
		$(_obj).style.height = document.body.scrollHeight>document.body.clientHeight?document.body.scrollHeight:document.body.clientHeight;
		$(_obj).style.left = (document.body.offsetWidth - $(_obj).offsetWidth) / 2;
		$(_obj).style.top = (document.body.offsetHeight - $(_obj).offsetHeight) / 2;
		
	},
	closeMask:function()
	{
		$(_obj).style.width = "0px";
		$(_obj).style.height = "0px";
	},
	Check:function()
	{
		
		this.alertMessage=function(_name)
		{
			if($(_name).value=="")
			{
				alert("不能为空");
				$(_name).focus();
				return false;
			}
			else
			return true;
		},
		this.strMessage = function(_name,_str)
		{
			if($(_name).value=="")
			{
				alert(_str);
				$(_name).focus();
				return false;
			}
			else
			return true;	
		},
		this.strCheck = function(_name,_str)
		{
			var _tag = document.getElementsByName(_name)
			for(var i=0;i<_tag.length;i++)
			{
				if(!_tag[i].checked)
				{
					$(_name).focus();
					_strF =  false;
				}
				else
				{
					_strF = true;
					break;
				}
			}
			if(!_strF)
			{
				alert(_str);	
			}
			return _strF;
		}
	},
	display:function(_str)
	{
		if($(_str))
		{
			if($(_str).style.display == "")
				$(_str).style.display == "none";
			else
				$(_str).style.display == "";
		}
		
	}
}