var customerSwiper = {
  banner: function(boxname, config) {
    var conf = {
      loop: true,
      autoplay: 5000,
      // pagination: '#home-banner-swiper-pagination',
      paginationClickable: true
    }
    if (config) {
      conf = $.extend(conf, config)
    }
    new Swiper(boxname, conf)
  },
  thumb: function(boxname, navname, config) {
    var $swiperItem = $(navname).find('.ImgAndTextSwiper-tab__item')
    var conf = {
      loop: true,
      autoplay: 5000,
      // paginationClickable: true,
      onSlideChangeStart: function(e) {
        $swiperItem.removeClass('active')
        $swiperItem.eq(e.activeLoopIndex).addClass('active')
      }
    }
    
    if (config) {
      conf = $.extend(conf, config)
    }
    var tabsSwiper = new Swiper(boxname, conf)
   
    $(boxname+','+navname).on('mouseenter', function() {
      tabsSwiper.stopAutoplay()
    })
    $(boxname+','+navname).on('mouseleave', function() {
      tabsSwiper.startAutoplay()
    })

    $swiperItem.on('touchstart mousedown', function(e) {
      e.preventDefault()
      $swiperItem.removeClass('active')
      $(this).addClass('active')
      tabsSwiper.swipeTo($(this).index())
    })
    $swiperItem.eq(0).addClass('active')
    $swiperItem.click(function(e) {
      console.log('click....')
      e.preventDefault()
    })
    console.log('boxname',boxname)
    $(boxname).find('.corp__swiper-pre')
    .on('click', function(e) {
      e.preventDefault()
      tabsSwiper.swipePrev()
    })
    $(boxname).find('.corp__swiper-next')
    .on('click', function(e) {
      e.preventDefault()
      tabsSwiper.swipeNext()
    })
 
  },
  thumbImg: function(boxname, navname, config) {
    var $swiperItem = $(navname).find('.ImgSwiper-tab__item')
    var conf = {
      loop: true,
      autoplay: 5000,
      // paginationClickable: true,
      onSlideChangeStart: function(e) {
        $swiperItem.removeClass('active')
        $swiperItem.eq(e.activeLoopIndex).addClass('active')
      }
    }
    
    if (config) {
      conf = $.extend(conf, config)
    }
    var tabsSwiper = new Swiper(boxname, conf)
   
    $(boxname+','+navname).on('mouseenter', function() {
      tabsSwiper.stopAutoplay()
    })
    $(boxname+','+navname).on('mouseleave', function() {
      tabsSwiper.startAutoplay()
    })

    $swiperItem.on('touchstart mousedown', function(e) {
      e.preventDefault()
      $swiperItem.removeClass('active')
      $(this).addClass('active')
      tabsSwiper.swipeTo($(this).index())
    })
    $swiperItem.eq(0).addClass('active')
    $swiperItem.click(function(e) {
      console.log('click....')
      e.preventDefault()
    })
  }
}
