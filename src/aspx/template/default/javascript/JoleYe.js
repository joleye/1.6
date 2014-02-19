// JavaScript Document
function onclick_qq()
{
	var tempSrc='http://sighttp.qq.com/wpa.js?rantime='+Math.random()+'&apos;amp;apos;amp;apos;amp;apos;sigkey=f9653d52612f95117d0ff0c10f093b20b1a3159a5ba33e85c276719bc8994697';
	var oldscript=document.getElementById('testJs');
	var newscript=document.createElement('script');
	newscript.setAttribute('type','text/javascript'); 
	newscript.setAttribute('id', 'testJs');
	newscript.setAttribute('src',tempSrc);
	if(oldscript == null)
	{
		document.body.appendChild(newscript);
	}
	else
	{
		oldscript.parentNode.replaceChild(newscript, oldscript);
	}
	return false;	
}

//°ó¶¨ËùÓÐ
window.onload = function()
{

}