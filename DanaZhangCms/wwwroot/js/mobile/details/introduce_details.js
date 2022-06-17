$(function(){
	$('.introduce_nav ul li').eq(0).addClass('active');
	$('.introduce_nav ul li').click(function(){
		$(this).addClass('active').siblings('li').removeClass('active');
	})
	$('.introduce_video li').eq(0).show();
	$('.video_box div').click(function(){
		$('.introduce_video video').trigger('pause');
		var vIndex=$(this).index();
		$('.introduce_video li').eq(vIndex).show().siblings('li').hide();
	})
	
	var scrollNav=$('.introduce_nav').offset().top;//获取要定位元素距离浏览器顶部的距离
	$(window).on('scroll', function () {
		var scroH = $(this).scrollTop();//获取滚动条的滑动距离
		// 滚动条的距离顶部的高度大于元素距离浏览器顶部的高度时，导航固定到顶部，反之亦然
		if(scroH>scrollNav){
			$('.introduce_nav').addClass('nav_style');
		}else{
			$('.introduce_nav').removeClass('nav_style');
		}
		
		$('.louti').each(function () {
		    var loutitop = $('.louti').eq($(this).index()).offset().top+400;
		    // 楼层的top大于滚动条的距离
		    if (loutitop > scroH) {
		        $('.introduce_nav li').removeClass('active');
		        $('.introduce_nav li').eq($(this).index()).addClass('active');
		        return false;
		    }
		});
		
	})
	
	$('.introduce_nav ul li').click(function(){
		var id=$('.introduce_nav ul li').index(this);
		var b=$('.introduce_content>div').eq(id).offset().top-53;
		$('html,body').animate({
			scrollTop:b,
		})
	
	})
		
})