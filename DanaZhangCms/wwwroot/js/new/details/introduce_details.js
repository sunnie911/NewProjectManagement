$(function(){
	$('.introduce_nav ul li').eq(0).addClass('active');
	$('.introduce_nav ul li').click(function(){
		$(this).addClass('active').siblings('li').removeClass('active');
	})

	 
	//var URL = window.URL || window.webkitURL;
	//function saveAs(blob, filename) {
	//	var type = blob.type;
	//	var force_saveable_type = 'application/octet-stream';
	//	if (type && type != force_saveable_type) {
	//		var slice = blob.slice || blob.webkitSlice || blob.mozSlice;
	//		blob = slice.call(blob, 0, blob.size, force_saveable_type);
	//	}
	//	var url = URL.createObjectURL(blob);
	//	var save_link = document.createElementNS('http://www.w3.org/1999/xhtml', 'a');
	//	save_link.href = url;
	//	save_link.download = filename;

	//	var event = new MouseEvent("click", {
	//		bubbles: true,
	//		cancelable: true,
	//		view: window
	//	});
	//	save_link.dispatchEvent(event);
	//	URL.revokeObjectURL(url);
	//}

 

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
 

	//$(".xiazai_icon").click(function (e) {
	//	var path = $(e.target).attr("data-id");
	//	window.location.href ="http://localhost:8618/"+ path;
	//})
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
		
		// $('.louti').each(function () {
		//     var loutitop = $('.louti').eq($(this).index()).offset().top+400;
		//     // 楼层的top大于滚动条的距离
		//     if (loutitop > scroH) {
		//         $('.introduce_nav li').removeClass('active');
		//         $('.introduce_nav li').eq($(this).index()).addClass('active');
		//         return false;
		//     }
		// });
		
	})
	
	// $('.introduce_nav ul li').click(function(){
	// 	var id=$('.introduce_nav ul li').index(this);
	// 	var b=$('.introduce_content>div').eq(id).offset().top-53;
	// 	$('html,body').animate({
	// 		scrollTop:b,
	// 	})
	
	// })
		
})