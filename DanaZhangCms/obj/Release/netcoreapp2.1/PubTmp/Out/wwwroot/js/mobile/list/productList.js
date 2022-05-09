
$(function(){
	var mainWrap=$(".pro_main ul");
	var pullUp=new UpRefresh();
	pullUp.init({"curPage":1,"maxPage":8,"offsetBottom":100},function(curpage){
		var str='';
		str+='<li><a href="#"><div class="img_box"><img src="../images/nav/Hp33.jpeg" >	<img v-show="item.flag" class="hot" src="../images/sale.png" ></div><p>【工业级】 混凝土（砂浆）3D打印系统</p></a></li>'
		mainWrap.append(str);
		
	});
	
})