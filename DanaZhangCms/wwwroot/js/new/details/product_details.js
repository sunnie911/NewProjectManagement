$(function () {
	var app = new Vue({
		el: '.list_details',
		data: {
			bannerArry: ['../images/details/banner1.jpg', '../images/details/banner2.jpg', '../images/details/banner1.jpg'],
		},
	})

	var swiper = new Swiper('.det_banner .swiper-container', {
		nextButton: '.swiper-button-next',
		prevButton: '.swiper-button-prev',
		slidesPerView: 1,
		paginationClickable: true,
		spaceBetween: 30,
		loop: true,
		autoplay: 2500
	});

	$('.goods_video ul li').click(function () {
		$(this).find('.v_shipin,.v_main,.v_main video').show();
	})

	$('.v_shipin').on('click', function (e) {
		event.stopPropagation(); //组织事件冒泡
		$(this).hide();
		$(this).next('.v_main').children().hide();
		$(this).next('.v_main').hide();
		$('.v_main video').trigger('pause');
	})

	var scrollNav = $('.details_nav').offset().top;//获取要定位元素距离浏览器顶部的距离	
	$('#loutinav li').eq(0).addClass('active');
	$(window).on('scroll', function () {
		var scroH = $(this).scrollTop();//获取滚动条的滑动距离
		// 滚动条的距离顶部的高度大于元素距离浏览器顶部的高度时，导航固定到顶部，反之亦然
		if (scroH > scrollNav) {
			$('.details_nav').addClass('nav_style');
		} else {
			$('.details_nav').removeClass('nav_style');
		}

		$('.louti').each(function () {
			var loutitop = $('.louti').eq($(this).index()).offset().top + 400;
			// 楼层的top大于滚动条的距离
			if (loutitop > scroH) {
				$('#loutinav li').removeClass('active');
				$('#loutinav li').eq($(this).index()).addClass('active');
				return false;
			}
		});

	})
	// 获取每个楼梯的offset().top,点击楼层让对应的内容模块移动到对应的位置
	$('#loutinav li').click(function () {
		$(this).addClass('active').siblings('li').removeClass('active');
		var loutitop = $('.louti').eq($(this).index()).offset().top - 115;
		// 获取每个楼梯的offsetTop值
		// $('html,body')兼容问题body属于chrome
		$('html,body').animate({
			scrollTop: loutitop
		})
	});

})