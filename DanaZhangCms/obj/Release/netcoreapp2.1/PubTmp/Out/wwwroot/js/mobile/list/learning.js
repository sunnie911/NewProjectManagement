$(function(){
	
	var mainWrap=$(".lea_main ul");
	var pullUp=new UpRefresh();
	pullUp.init({"curPage":2,"maxPage":20,"offsetBottom":100},function(curpage){
		var str='';
		str+='<li><a href="#"><div class="img_box"><img src="../images/learning/img.jpg" ><img v-show="item.flag" class="hot" src="../images/sale.png" ></div><div class="jieshao"><p>【工业级】 混凝土（砂浆）3D打印系统混凝土（砂浆）3D打印系统</p><span>2021-12-20 14:33:08</span></div></a></li>'
		mainWrap.append(str);
		
	});		
			
})