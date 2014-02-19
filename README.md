1.6
===

JoleYe 1.6版本开源了


使用方法
===
1.首先克隆到本地，使用命令 git clone git@github.com:joleye/1.6.git

2.打开src目录,用Visual studio 2005打开JoleYe1.6.sln项目文件



各类库介绍：
===
1.JoleYe.Admin 系统后台类库，包含系统后台相关操作

2.JoleYe.Bal 业务逻辑层

3.JoleYe.Dal 数据访问层

4.JoleYe.Data 数据库操作相关库

5.JoleYe.Model 实体层

6.JoleYe.URLRewrite 自定义访问地址相关库

7.JoleYe.View 模板操作层，用于把模板文件转换成aspx文件

8.JoleYe.Web 前台公共库，用于前台页面访问控制

9.aspx 网站相关页面和数据库内容


模板使用介绍
===
模板目录:aspx/template/
	
		system：系统相关模板文件

		default：系统默认模板

添加一个模板文件步骤：

1.到系统后台找到模板管理栏目，选择相关的模板，然后进入模板后可添加页面，待输入好页面信息后，保存，生成即可

2.每个页面都可找到对应的cs文件，对应的位置和在JoleYe.Web这个类库下面，类名称和页面的文件名对应。

3.在系统生成的时候如果没有找到约定的类，那么将继承前端公用的类，即：Frontend

4.各全局参数和模板语法介绍：http://www.joleye.com/viewinfo-519.aspx


二次开发说明
===
详细文档联系：zl#joleye.com邮箱，#改@

