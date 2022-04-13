
$('.ban').swiper({
	pagination: '.ban .swiper-pagination',/*分页，可删掉*/
    paginationClickable: true,
	loop: true,/*循环播放,无需循环，删除该项*/
	autoplay: 4000,/*自动播放，无需自动，删除该项*/
});

$('.g-honor').swiper({
	pagination: '.g-honor .swiper-pagination',/*分页，可删掉*/
	paginationClickable: true,/*与分页（pagination）配合使用，标签分页的标识是可以点击的*/
	loop: true,/*循环播放,无需循环，删除该项*/
	autoplay: 4000,/*自动播放，无需自动，删除该项*/
	nextButton: '.next1',/*若不需要向前向后翻箭头，可以删掉*/
	prevButton: '.prev1' /*此处无逗号‘，’*/
});

$('.g-par').swiper({loop: true,autoplay: 4000,});


var swipernew = $('.m-new').swiper({
		onSlideChangeEnd: function(swiper) {
			var _index = swipernew.activeIndex;
			$('.tabs a').removeClass('active').eq(_index).addClass('active');
		}
	});
	$(".tabs a").on('touchstart mousedown',function(e){
		e.preventDefault();
		$(".tabs .active").removeClass('active');
		$(this).addClass('active');
		swipernew.slideTo( $(this).index() );
	});
	$(".tabs a").click(function(e){
		e.preventDefault();
	});