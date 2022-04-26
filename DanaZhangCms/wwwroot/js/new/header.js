$(document).ready(function () {
    var app = new Vue({
        el: '.nav',
        data: {
            navObject: {
                yi: [
                    { img: '../images/nav/Hp1.jpeg', text: '【工业级】 混凝土（砂浆）3D打印系统', flag: true },
                    { img: '../images/nav/Hp2.jpeg', text: '【实验室级】混凝土（砂浆）3D打印系统', flag: true },
                    { img: '../images/nav/Hp3.jpeg', text: '【桌面级】混凝土（砂浆）3D打印系统', flag: true },
                    { img: '../images/nav/Hp4.png', text: '【机械臂】混凝土（砂浆）3D打印系统', flag: false }
                ],
                er: [
                    { img: '../images/nav/Hp22.png', text: ' 混凝土快速冻融试验机HC-HDK9', flag: true },
                    { img: '../images/nav/Hp23.png', text: '  混凝土碳化试验箱HC-HTX12', flag: true },
                    { img: '../images/nav/Hp24.jpeg', text: ' 全自动混凝土硫酸盐干湿循环试验机', flag: true },
                    { img: '../images/nav/Hp25.png', text: '混凝土氯离子扩散系数测定仪', flag: false },
                    { img: '../images/nav/Hp26.png', text: '混凝土氯离子扩散系数电通量测定仪 ', flag: false },
                    { img: '../images/nav/Hp21.png', text: '混凝土氯离子扩散系数电通量测定仪 ', flag: false },
                 
                    { img: '../images/nav/Hp21.png', text: '混凝土氯离子扩散系数电通量测定仪 ', flag: false },
                ],
                san: [
                    { img: '../images/nav/Hp31.png', text: ' 多功能建材冻融试验机HC-JCD ', flag: false },
                    { img: '../images/nav/Hp32.jpeg', text: '混凝土硫酸盐-应力耦合试验机 ', flag: false },
                    { img: '../images/nav/Hp33.jpeg', text: '  低温硫酸盐-交流阻抗耦合试验机 ', flag: false },
                    { img: '../images/nav/Hp34.png', text: '混凝土超低温试验箱 ', flag: false },
                    { img: '../images/nav/Hp36.png', text: '硬化混凝土气孔结构分析仪  ', flag: false },
                    { img: '../images/nav/Hp37.png', text: '激光收缩变形测定仪 ', flag: false },
                ],
                si: [
                    { img: '../images/nav/Hp41.png', text: ' 混凝土卧式收缩膨胀测定仪 ', flag: false },
                    { img: '../images/nav/Hp42.jpg', text: '  氯离子含量快速测定仪 ', flag: false },
                    { img: '../images/nav/Hp43.png', text: '混凝土碱含量快速测定仪 ', flag: false },
                    { img: '../images/nav/Hp44.jpg', text: '直读式砂浆含气量测定仪 ', flag: false },
                ],
                wu: [
                    { img: '../images/nav/Hp51.png', text: ' 非接触光学变形测量系统 ', flag: false },
                    { img: '../images/nav/Hp52.png', text: '全自动氯离子电位滴定仪APT ', flag: false },
                    { img: '../images/nav/Hp53.png', text: '  高精度磁共振混凝土微观分析仪 ', flag: false },
                    { img: '../images/nav/Hp51.png', text: ' 非接触光学变形测量系统 ', flag: false },
                    { img: '../images/nav/Hp52.png', text: '全自动氯离子电位滴定仪APT ', flag: false },
                ]
            },
        },
    })
	$('.nav .list ul').prepend("<li><a href=\"#\">首页</a></li>")
	$('.nav .list ul li').eq(0).addClass('navStyle')

	var navHeight = $('.nav').height();
	top.postMessage(navHeight, '*');
	$('.nav .list ul li').mouseenter(function () {
		var navIndex = $(this).index();
		setTimeout(() => {
			navHeight = window.screen.height;
			top.postMessage(navHeight, '*');
		}, 200);

		$(this).addClass('navStyle').stop().siblings('li').removeClass('navStyle');
		$(this).find(".navlist_current,.lianxi").slideDown(100)
		$(this).find(".list_box").show();
		$(this).stop().siblings('li').find(".navlist_current,.lianxi").slideUp(100)
		$(this).stop().siblings('li').find(".list_box").hide();

		var nav_curNum = 5;/*每页显示的条数*/
		var nav_iNum = 0;/*生成页码*/
		var nav_pageMain = $('.nav .list ul li').eq(navIndex).find('.list_box span').length;
		// console.log(nav_pageMain);
		var len = Math.ceil(nav_pageMain / nav_curNum);/*每页显示数*/
		console.log(len);
		if (len <= 1) {
			$('.nav .list ul li').eq(navIndex).find('#nav_pageBox').hide();
		} else {
			$('.nav .list ul li').eq(navIndex).find('#nav_pageBox').show();
		}

		var nav_prev = $('.nav .list ul li').eq(navIndex).find('#nav_prev');
		var nav_next = $('.nav .list ul li').eq(navIndex).find('#nav_next');
		if (nav_iNum == 0) {
			nav_prev.hide();
		} else {
			nav_prev.show();
		}
		/*上一页*/
		$('.nav .list ul li').eq(navIndex).find('#nav_pageMain span').hide();
		for (var i = 0; i < nav_curNum; i++) {
			$('.nav .list ul li').eq(navIndex).find('#nav_pageMain span').eq(i).show()
		}

		nav_prev.click(function () {
			console.log('上一页')
			$('.nav .list ul li').eq(navIndex).find('#nav_pageMain span').hide();
			if (nav_iNum != 0) {
				nav_iNum--;
				nav_next.show();

			}
			if (nav_iNum == 0) {
				nav_prev.hide();
				nav_next.show();
			}
			for (var i = nav_iNum * nav_curNum; i < (nav_iNum + 1) * nav_curNum; i++) {
				$('.nav .list ul li').eq(navIndex).find('#nav_pageMain span').eq(i).show();
			}

		})
		/*下一页*/
		nav_next.click(function () {
			console.log('下一页')
			$('.nav .list ul li').eq(navIndex).find('#nav_pageMain span').hide();
			if (nav_iNum != len - 1) {
				nav_iNum++;
				nav_prev.show();
			}
			if (nav_iNum == len - 1) {
				nav_next.hide();
			}
			for (var i = nav_iNum * nav_curNum; i < (nav_iNum + 1) * nav_curNum; i++) {
				$('.nav .list ul li').eq(navIndex).find('#nav_pageMain span').eq(i).show();
			}
		})

	})
	$('.nav .list .navlist_current,.lianxi').mouseleave(function () {
		$(this).slideUp(100);
		$(".list_box").hide();

		top.postMessage($('.nav').height(), '*');

	})
	// 搜索
	$('.search img').click(function () {
		$('.search input').show();
	})
	$('.search input').mouseleave(function () {
		$('.search img').show();
		$(this).hide();
	})

	$(".search div").hover(function () {
		$('.search img').hide();
		return false;
	}, function () {
		$('.search img').show();
		return false;
	});



})
