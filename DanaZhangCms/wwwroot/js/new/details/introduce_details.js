
$(function () {
	$('.introduce_nav ul li').eq(0).addClass('active');
	$('.introduce_nav ul li').click(function () {
		$(this).addClass('active').siblings('li').removeClass('active');
	})
	$('.introduce_video li').eq(0).show();
	$('.video_box div').click(function () {
		$('.introduce_video video').trigger('pause');
		var vIndex = $(this).index();
		$('.introduce_video li').eq(vIndex).show().siblings('li').hide();
	})

	// console.log($(window).scrollTop())
	// setTimeout(function(){
	// 	var url=window.location.href;
	// 	if(url.indexOf('#')==-1){
	// 		console.log('不包括#')
	// 		$('.introduce_content>div').removeClass('main_Style');
	// 	}else{
	// 		console.log('包括#')
	// 		$('.introduce_content>div').addClass('main_Style');
	// 	}
	// },500)



	var scrollNav = $('.introduce_nav').offset().top; //获取要定位元素距离浏览器顶部的距离
	$(window).on('scroll', function () {
		var scroH = $(this).scrollTop();//获取滚动条的滑动距离
		//  // 滚动条的距离顶部的高度大于元素距离浏览器顶部的高度时，导航固定到顶部，反之亦然
		if (scroH > scrollNav) {
			$('.introduce_nav').addClass('nav_style');
			$('.zhanwei').show();
		} else {
			$('.introduce_nav').removeClass('nav_style');
			$('.zhanwei').hide();
		}

		$('.louti').each(function () {
			var loutitop = $('.louti').eq($(this).index()).offset().top + 200;
			// 楼层的top大于滚动条的距离
			if (loutitop > scroH) {
				$('.introduce_nav li').removeClass('active');
				$('.introduce_nav li').eq($(this).index()).addClass('active');
				return false;
			}
		});

	})


	$('.introduceLi').click(function () {
		var navto = $(this).attr('navto');
		if (navto != "#") {
			var $div = $('#' + navto);
			var top = $div.offset().top || 0;
			$('html,body').animate({
				'scroll-top': top - 128
			}, 500);
		}

	})
	$('.xiazai_icon').on('click', function (e) {
		var fileName = $(e.target).attr("data-name");
		var URLToPDF = $(e.target).attr("data-id");
		var request = new XMLHttpRequest();
		request.responseType = "blob";
		// 传入文件链接
		request.open("GET", URLToPDF);
		request.onload = function () {
			var url = window.URL.createObjectURL(this.response);
			var a = document.createElement("a");
			document.body.appendChild(a);
			a.href = url;
			a.download = fileName
			a.click();
		}
		request.send();
	})
	 

})
 