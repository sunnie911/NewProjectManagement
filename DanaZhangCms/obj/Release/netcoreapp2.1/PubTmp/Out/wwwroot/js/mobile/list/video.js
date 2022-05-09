$(function(){
	
	$('.goods_video ul li').click(function(){
		$(this).find('.v_shipin,.v_main,.v_main video').show();
	})
	
	$('.v_shipin').on('click',function(e){
		event.stopPropagation(); //组织事件冒泡
		$(this).hide();
		$(this).next('.v_main').children().hide();
		$(this).next('.v_main').hide();
		$('.v_main video').trigger('pause');
	})
	
	var mainWrap=$(".goods_video ul");
	var pullUp=new UpRefresh();
	pullUp.init({"curPage":1,"maxPage":20,"offsetBottom":100},function(curpage){
		var str='';
		str+='<li><img class="goods_img" src="../images/video/img2.jpg" ><div class="img_bj"><img class="play" src="../images/details/video_img.png" ></div><div class="v_shipin"></div><div class="v_main"><video style="width:80%;" controls><source src="../images/details/movie2.mp4" type="video/mp4"></source></video></div><p class="jieshao">产品视频产品视频产品视频</p></li>'
		mainWrap.append(str);
		
	});
	
})