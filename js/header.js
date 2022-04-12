
var headerScroll = {
  init: function () {
    // 关闭提示
    this.closeTip()
    // 头部导航固定顶部
    this.affixHeader()
    // 头部搜索
    this.searchHandle()
    // 检查是否显示提示
    this.checkTipShowStatus()
    // 获取来源
    this.setUtmSource()
    this.setUtmCampaign()
    // 分割头部导航
    this.splitNavs()
    // 二级导航固定
    this.affixSubNav('#affix-nav')
    // 锚点滚动
    this.maodianAnimate()
    // 显示各系统入口
    this.showLink()
    // 获取登录信息
    // getUserData()
  },
  // getUserData: function(){
  //   var loginUserId = ''
  //   var profileImage = ''
  //   var authorization = ''
  //   window.auther.getUserProfile().then(res => {
  //     console.log(res)
  //     loginUserId = res.sub
  //     profileImage = res.profileImage
  //   }),
  //   window.auther.getToken().then(res => {
  //     authorization = res
  //         $.ajax({
  //         url: "https://test-gateway.31huiyi.com/api/Party/Sso/GetUserInfo?loginUserId=66eb0000-edae-028e-f172-08d88aa03ecb",
  //         type: "GET",
  //         headers: {
  //           authorization: authorization
  //         },
  //         success: function (result) {
  //           console.log(result);
  //         },
  //         error: function (err) {
  //           console.log(err);
  //         }
  //       });
  //   })
  // },
  showLink: function(){
    // 公用导航右上角登录按钮
    $('.loginBtn__layer').hover(function() {
        $(".loginBtnBox").show()
    }, function() {
      $(".loginBtnBox").hide()
    });
    // 公用导航右上角免费试用按钮
    // $('.freeTrialBtn').hover(function() {
    //   $(".freeTrialBtnBox").show()
    // }, function() {
    //   $(".freeTrialBtnBox").hide()
    // });
  },
  closeTip: function () {
    var tipCloseBtn = document.querySelector('#js-corp__header-tip__close')
		if(tipCloseBtn){
			tipCloseBtn.addEventListener('click', this.closeTipHandle, false)
		}
  },
  maodianAnimate: function() {
    // 页面加载时，
    setTimeout(function() {
      // $('html,body').scrollTop(666)
      var hashName = location.hash
      if (hashName) {
        $('html,body').scrollTop(($(hashName).offset().top - ($('#js-corp__header').outerHeight() || 0)))
      }
    }, 200)
    $('.corp__header-nav a').on('click', function() {
			var link = $(this).attr('href')
			var linkMatch = link.split('#')
			var hashName = ''
			if (linkMatch.length > 1 && linkMatch[0] === location.pathname){
				hashName = '#' + linkMatch[linkMatch.length - 1]
				console.log(hashName)
				if (hashName) {
					$('html,body').animate({
						scrollTop: ($(hashName).offset().top - $('#js-corp__header').outerHeight() || 0) + "px"
					}, 300)
				}
				return false
			}
		})
  },
  affixHeader: function () {
    var unFixedList = [
      '/scene/camp'
    ]
    if ($('meta[name="affixnav"]').length || unFixedList.indexOf(location.pathname) >= 0) {
      return false
    }
    this.handleScroll()
    window.addEventListener('scroll', this.handleScroll, false)
  },
  affixSubNav: function (name) {
    if (!$('#js-affix-nav').length) {
      return false
    }
    $('#js-affix-nav').onePageNav({})
    window.addEventListener('scroll', function () {
      const scrollTop = document.documentElement.scrollTop
      const header = document.querySelector(name)
      const h = header.offsetTop
      console.log(scrollTop)
      if (scrollTop > h) {
        // headerScroll.addClass(header, 'fixed')
        $(header).addClass('fixed')
      } else {
        $(header).removeClass('fixed')
        // headerScroll.removeClass(header, 'fixed')
      }
    }, false)
  },
  hasClass: function (obj, name) {
    return !!obj.className.match(new RegExp('(\\s|^)' + name + '(\\s|$)'))
  },
  addClass: function (obj, name) {
    if (!headerScroll.hasClass(obj, name)) {
      obj.className += ' ' + name
    }
  },
  removeClass: function (obj, name) {
    if (headerScroll.hasClass(obj, name)) {
      obj.className = obj.className.replace(new RegExp('(\\s|^)' + name + '(\\s|$)'), ' ')
    }
  },
  handleScroll: function (e) {
    var scrollTop = document.documentElement.scrollTop
    var header = document.querySelector('#js-corp__header')
	if(header)
	{
		var h = header.clientHeight
		if (scrollTop > h) {
		  headerScroll.addClass(header, 'fixed')
		} else {
		  headerScroll.removeClass(header, 'fixed')
		}
	}
  },
  closeTipHandle: function (e) {
    console.log(e.target)
    e.target.style.display = 'none'
    var tip = document.querySelector('#js-corp__header-tip')
    tip.style.display = 'none'
    localStorage.setItem('hideHeaderTip', true)
    // document.querySelector('#js-corp__header-tip__close').style.display = 'none'
  },
  checkTipShowStatus: function () {
    var hideHeaderTip = localStorage.getItem('hideHeaderTip')
    var tip = document.querySelector('#js-corp__header-tip')
	if(tip)
	{
		tip.style.display = hideHeaderTip === 'true' ? 'none' : 'block'
	}
  },
  eventEntrustCB: function (idName, event, cbout, cbinner) {
    var eventName = event || 'mouseup'
    $(document).on(eventName, function(e){
      e.stopPropagation();
      var _con = $(idName);   // 设置目标区域
      if(!_con.is(e.target) && _con.has(e.target).length === 0){ // Mark 1
        if (typeof cbout === 'function') {
          cbout()
        }
      } else {
        if (typeof cbinner === 'function') {
          cbinner()
        }
      }
    });
  },
  searchHandle: function () {
    $('#js-corp__header-search__input').on('keypress',function (e) {
      var keyword = $(this).val()
      var link = 'https://www.baidu.com/s?wd=' + keyword + ' site:31huiyi.com'
      if (e.which === 13) {
        if (keyword) {
          $('#js-corp__header-search__input-link').attr('href', link)
        } else {
          $('#js-corp__header-search__input-link').removeAttr('href')
        }
        document.getElementById('js-corp__header-search__input-link').click()
      }
    })

    $('.corp__header-search__box').on('click', function() {
      $(this).addClass('active')
      $(this).find('input').focus()
    })
    this.eventEntrustCB('.corp__header-search__box', 'mouseup', function() {
      $('.corp__header-search__box').removeClass('active')
    })
  },
  setUtmSource: function () {
    var utmID = utils.GetQueryString('utm_source')
    if (utmID) {
      utils.setCookie('utm_source', utmID, 3)
    }
  },
  setUtmCampaign: function () {
    var utmID = utils.GetQueryString('utm_campaign')
    console.log(utmID)
    if (utmID) {
      utils.setCookie('utm_campaign', utmID, 3)
    }
  },
  splitArray: function (arr, len) {
    var result = []
    for (var i = 0; i < arr.length; i += len) {
      result.push(arr.slice(i, i + len))
    }
    return result
  },
  splitNavs: function () {
    // 每组导航个数，4个一组
    var len = 3
    $('.corp__subnav-block').each(function () {
      if (!$(this)) {
        return false
      }
      var group = []
      var navs = $(this).find('.corp__subnav-box')

      $(navs).each(function (item) {
        group.push($(navs).eq(item))
      })
      var result = headerScroll.splitArray(group, len)
      var sp = document.createDocumentFragment()
      result.forEach(function (item) {
        var box = $('<div class="corp__subnav-floatblock"></div>')
        item.forEach(function (citem) {
          $(citem).appendTo(box)
        })
        $(box).appendTo(sp)
      })
      $(this).html(sp)
    })

    var box = $('.corp__header-subnav')
    // 自动计算头部二技导航宽度
    $(box).each(function(item) {
      var grids = $(this).find('.grid')
      var gridLen = grids.length
      
      if (gridLen) {
        var w = 40
        $(grids).each(function(citem) {
          w += $(this).outerWidth()
        })
        $(this).css({
          width: w + 'px'
        })
      }

      var items = $(this).find('.corp__header-subnav__item')
      var itemsLen = items.length
      if (itemsLen) {
        var sw = 20
        var itemWidth = $(items).outerWidth()
        var col = Math.ceil(itemsLen / 6)
        $(this).css({
          width: sw + (itemWidth * col) + 'px'
        })
      }
    })
  }
  // geSSOJSONP () {
  //   $.getJSON('http://sso.31huiyi.com/ssouser/GetSSOUserJSONP?ssoUserCallback=ssoUserCallback')
  // }
}

function ssoUserCallback (ssoUser) {
  // var url = location.href
  // var loginUrl = 'https://sso.31huiyi.com/ssouserlogin/login?returl=http%3a%2f%2fwww.31meijia.com%2f';
  // var logoutUrl = 'https://sso.31huiyi.com/ssoExtra/Logout?returl=' + encodeURIComponent(url)
  var html = '';
  var filehost = '';
  var PhotoPath = '';
  if (ssoUser.PhotoPath) {
    PhotoPath = ssoUser.PhotoPath
  } else {
    PhotoPath = '/Static2019/corp/static/img/avatar.svg';
  }
  if (PhotoPath.indexOf('http') < 0) {
    filehost = 'https://file.31huiyi.com';
  }
  // if (ssoUser) {
  //   if (ssoUser.UserId > 0) {
  //     $('.corp__header-logined').show()
  //     $('.corp__header-unlogin').hide()
  //     // $('.corp__header-loginout__btn').attr('href', logoutUrl)
  //     // $('.corp__header-avatar__img').attr('src', filehost + PhotoPath)
  //     $('.corp__header-avatar__img').attr('src', PhotoPath)
  //     $('.corp__header-username').text(ssoUser.UserName)
  //   }
  // }
}
$(function() {
  headerScroll.init()
})
// export default headerScroll