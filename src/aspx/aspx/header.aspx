<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>{$pagetitle} - {$web_title} Powered by JoleYe</title>
<link href="{$WEBPATH}fckeditor/editor/skins/default/fck_editor.css" rel="stylesheet" type="text/css" />
<link href="{$WEBPATH}fckeditor/editor/css/fck_editorarea.css" rel="stylesheet" type="text/css" />
<link href="{$WEBPATH}fckeditor/editor/css/fck_internal.css" rel="stylesheet" type="text/css" />
<link href="{$WEBPATH}{$TEMPLATEPATH}/css/joleye.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="{$WEBPATH}{$TEMPLATEPATH}/javascript/joleye.js"></script>
</head>
<body>
<div class="topnav">
<div class="nav">
{if(!islogin)}
<span><a href="login.aspx">登陆</a></span> <span><a href="register.aspx">注册</a></span>
{else}
<span>您好：{$user_name}</span>&nbsp;&nbsp;<span><a href="member.aspx?app=loginout">退出</a></span>
{/if}
</div>
</div>
<div class="head bd">
    <div class="heng"></div>
    <div class="top">
        <dl>
            <dt><img src="images/logo.jpg" width="200" height="73" /></dt>
            <dd><img src="images/index.jpg" width="730"  height="90"/></dd>
        </dl>
    </div>
    <div class="heng"></div>
    <!--导航部分 start-->
    <div class="nav">
            <ul>
                <li{if(flg_nav=="index")} class="selected"{/if}><a href="index.aspx">首 页</a></li>
                <li{if(flg_nav=="brand")} class="selected"{/if}><a href="brand.aspx">品牌介绍</a></li>
                <li{if(flg_nav=="down")} class="selected"{/if}><a href="down.aspx">下载中心</a></li>
                <li{if(flg_nav=="intro")} class="selected"{/if}><a href="intro.aspx">产品介绍</a></li>
                <li{if(flg_nav=="listinfo")} class="selected"{/if}><a href="listinfo.aspx">在线资料</a></li>
                <li{if(flg_nav=="product")} class="selected"{/if}><a href="productlist.aspx">产品中心</a></li>
                <li{if(flg_nav=="custom")} class="selected"{/if}><a href="custom-zhichi.aspx">技术支持</a></li>
                <li{if(flg_nav=="contact")} class="selected"{/if}><a href="contact.aspx">联系我们</a></li>
            </ul>
    </div>
    <!--导航部分 over-->
    <div class="heng"></div>
</div>
<div class="heng"></div>