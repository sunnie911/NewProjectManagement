$(document).ready(function () {
    var app = new Vue({
        el: '.nav',
        data: {
            navObject: {

            },
        },
    })
     

    if (!$.cookie('the_cookie')) {
        var lang = "";
        if (navigator.userLanguage) {
            lang = navigator.userLanguage.substring(0, 2).toLowerCase();
        }
        else {
            lang = navigator.language.substring(0, 2).toLowerCase();
        }
        console.log(lang);
        if (lang != "zh") {
            window.location.href = "/english";
        }

        $.cookie('the_cookie', '1', {expires:1,path:'/'});
    }
    


    var lau = $('.nav').find(".chiness").length;
    if (lau == 1) {
        $('.nav .list ul').prepend("<li><a href=\"/english\">index</a></li>")
    }
    else {
        $('.nav .list ul').prepend("<li><a href=\"/home\">首页</a></li>")
    }
    //$('.nav .list ul').prepend("<li><a href=\"#\">首页</a></li>")

    $('.nav .chiness').click(function () {
        window.location.href = "/home";
    })

    $('.nav .english').click(function () {
        window.location.href = "/english";
    })
    $('.nav .list ul li').eq(0).addClass('navStyle')

    $('.nav .list ul li').mouseenter(function () {
        $(this).addClass('navStyle').stop().siblings('li').removeClass('navStyle');
        $(this).find(".navlist_current,.lianxi").slideDown(100)
        $(this).find(".list_box").show();
        $(this).stop().siblings('li').find(".navlist_current,.lianxi").slideUp(100)
        $(this).stop().siblings('li').find(".list_box").hide();

        var navIndex = $(this).index();


        var nav_curNum = 10;/*每页显示的条数*/
        var nav_iNum = 0;/*生成页码*/
        var nav_pageMain = $('.nav .list ul li').eq(navIndex).find('.list_box span').length;
        var navlen = Math.ceil(nav_pageMain / nav_curNum);/*每页显示数*/
        if (navlen > 1) {
            $('.nav_pageMain').css('height', '560px');
        } else {
            $('.nav_pageMain').css('height', 'auto');
        }

        if (navlen <= 1) {
            $('.nav .list ul li').eq(navIndex).find('.nav_pageBox').hide();
        } else {
            $('.nav .list ul li').eq(navIndex).find('.nav_pageBox').show();
        }

        var nav_prev = $('.nav .list ul li').eq(navIndex).find('.nav_prev');
        var nav_next = $('.nav .list ul li').eq(navIndex).find('.nav_next');
        if (nav_iNum == 0) {
            nav_prev.css({ "pointer-events": "none", "cursor": "default", "filter": "grayscale(100%)" })
            nav_next.css({ "pointer-events": "auto", "cursor": "pointer", "filter": "grayscale(0%)" })
        }
        $('.nav .list ul li').eq(navIndex).find('.nav_pageMain span').hide();
        for (var i = 0; i < nav_curNum; i++) {
            $('.nav .list ul li').eq(navIndex).find('.nav_pageMain span').eq(i).show()
        }
        /*上一页*/
        nav_prev.click(function () {
            // console.log('上一页')
            $('.nav .list ul li').eq(navIndex).find('.nav_pageMain span').hide();
            if (nav_iNum != 0) {
                nav_iNum--;
                nav_next.css({ "pointer-events": "auto", "cursor": "pointer", "filter": "grayscale(0%)" })

            }
            if (nav_iNum == 0) {
                nav_prev.css({ "pointer-events": "none", "cursor": "default", "filter": "grayscale(100%)" })
                nav_next.css({ "pointer-events": "auto", "cursor": "pointer", "filter": "grayscale(0%)" })
            }
            for (var i = nav_iNum * nav_curNum; i < (nav_iNum + 1) * nav_curNum; i++) {
                $('.nav .list ul li').eq(navIndex).find('.nav_pageMain span').eq(i).show();
            }

        })
        /*下一页*/
        nav_next.click(function () {
            $('.nav .list ul li').eq(navIndex).find('.nav_pageMain span').hide();
            nav_iNum++;
            if (nav_iNum != navlen - 1) {
                nav_prev.css({ "pointer-events": "auto", "cursor": "pointer", "filter": "grayscale(0%)" })
            } else {
                nav_prev.css({ "pointer-events": "auto", "cursor": "pointer", "filter": "grayscale(0%)" })
                nav_next.css({ "pointer-events": "none", "cursor": "default", "filter": "grayscale(100%)" })
            }
            for (var i = nav_iNum * nav_curNum; i < (nav_iNum + 1) * nav_curNum; i++) {
                $('.nav .list ul li').eq(navIndex).find('.nav_pageMain span').eq(i).show();
            }
        })

    })
    $('.nav .list .navlist_current,.lianxi').mouseleave(function () {
        $(this).slideUp(100);
        $(".list_box").hide();

    })
    // 搜索
    $('.search img').click(function () {
        $('.search_input').show();
    })
    $('.search_zhezhao').click(function () {
        $('.search_input').hide();
    })
    //抖音
    $('.douyin').click(function () {
        $('.douBox').show();
    })
    $('.douBox').click(function () {
        $('.douBox').hide();
    })
    $('.searchgoods').click(function () {
        var text = $("#keyword").val();
        window.location.href = "/product?word=" + text;
        $('.search_input').hide();
    })



})
