/**
   表单验证控件
   by JoleYe
 */
JoleYe.check = function(c,id){
	if ( window == this ) return new JoleYe.check(d,id);
	var _dom = tcg.g(id);
	return this.init(c,_dom);
}

JoleYe.init = function(c,dom){
		this.conf = c;
		this._dom = dom;
        return this;
}

/*新验证*/
JoleYe.do_check = function(option){
	var conf = this.conf;
	var err = false;
	this._option = option;
	for(var k in conf){
		var f = this._task_key(k);
		if(f) err = true;
	}
	if(err){
		alert('信息填写格式错误或不完整，请检查红色标记部分');
	}
	else{
		if(typeof option.btn!='undefined'){
			T.g(option.btn.name).value = option.btn.text;
			T.g(option.btn.name).disabled = true;
		}
		
		if(option.sucess)
			option.sucess.apply(this);
			
		if(typeof this._dom!='undefined')
			this._dom.submit();
		else if(option.form)
			option.form.submit();			
	}
}

JoleYe._task_key  = function(k){
	var val = this.conf[k];

	eval('var ret = JoleYe._'+val[0]+'("'+k+'")');
	
	var option = this._option;
	var d = T.g(k+'_msg');
	if(!d) return false;
	if(ret){
		d.innerHTML = val[2];
		T.setAttr(d,'class',option.msg.right);
		T.css(T.g(k),{'borderColor':'','backgroundColor':''});
	}else{
		d.innerHTML = val[1];
		T.setAttr(d,'class',option.msg.error);
		T.css(T.g(k),{'borderColor':'#f00',
			'backgroundColor':'#FFCCCC'
		});
		return true;
	}
}

JoleYe._do_blur = function(d){
	JoleYe._task_key(d)
}

/*焦点移开*/
JoleYe.do_blur = function(option){
	this._option = option;
	for(var k in this.conf){
			T.g(k).onblur = function(){
				JoleYe._do_blur(this.id);
			}
	}
}


/*手机号码验证*/
JoleYe._mobile = function(id){
	 if(id=='') return false;
		var d = JoleYe.g(id).value;
		return /^1\d{10}$/.test(d);
}

/*电子邮件验证*/
JoleYe._email = function(id){
		var d = JoleYe.g(id).value;
		return /^(\w|\d|_|\-|\.){1,20}@(\w|\d|-)+\.(com|cn|net|gov\.cn|com\.cn|net\.cn)$/.test(d);
}

/*日期格式验证*/
JoleYe._date = function(id){
	var d = JoleYe.g(id).value;	
	return /^\d{4}\-\d{1,2}-\d{1,2}$/.test(d);
}

/*必填字段*/
JoleYe._require = function(id){
	var d = JoleYe.g(id).value;
	return d=='' ? false : true;
}

/*必填字段 默认为0情况*/
JoleYe._require0 = function(id){
	var d = JoleYe.g(id).value;
	return d=='0' ? false : true;
}

/*性别*/
JoleYe._sex = function(id){
	var tag = document.getElementsByTagName("input");
	for(var i=0;i<tag.length;i++){
		if(tag[i].name == id){
				if(tag[i].checked)
				return true;
		}	
	}
	return false;
}

/*单选*/
JoleYe._radio = function(id){
	var tag = document.getElementsByTagName("input");
	for(var i=0;i<tag.length;i++){
		if(tag[i].name == id){
				if(tag[i].checked)
				return true;
		}	
	}
	return false;
}

/*数字*/
JoleYe._int = function(id){
	var d = JoleYe.g(id).value;
	return /^\d+$/.test(d);
}

/*price*/
JoleYe._price = function(id){
	var d = JoleYe.g(id).value;
	return /^(\d|\.)+$/.test(d);
}

/*电话*/
JoleYe._phone = function(id){
	var d = JoleYe.g(id).value;
	return /(^\d{11}$)|(^\d{3,5}\-\d{7,8}$)|(^\d{3,5}\-\d{7,8}\-\d{4}$)/.test(d);
}

/*手机*/
JoleYe._mobile = function(id){
	var d = JoleYe.g(id).value;
	return /^\d{11}$/.test(d);
}
