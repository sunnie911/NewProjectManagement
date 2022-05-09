$(function(){
	// banner
	 var swiper = new Swiper('.swiper-container', {
		pagination: '.swiper-pagination',
		nextButton: '.swiper-button-next',
		prevButton: '.swiper-button-prev',
		slidesPerView: 1,
		paginationClickable: true,
		spaceBetween: 30,
		loop: true
	});
	// return;
	//无缝轮播的效果
	var swiper = new Swiper('.vedio_container',{ // 初始化并存储了轮播器
	  autoplay: 1, // 设置了自动播放
	  slidesPerView: 2,
	  speed: 6000, // 设置了播放速度
	  freeMode: true, // 设置了是否可以自由运动
	  loop : true, // 设置了是否可以轮播
	  // loopedSlides: 8, // 设置了轮播显示的个数，你的是多少个参与轮播就是多少个
	  noSwiping : true, // 禁止了手滑动
	  noSwipingClass : 'swiper-slide'// 禁止了手滑动的元素
	})
	
	
	
})	