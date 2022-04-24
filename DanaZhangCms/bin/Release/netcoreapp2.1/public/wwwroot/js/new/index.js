$(function(){
	var app = new Vue({
	  el: '.whole',
	  data: {
	    titleArry: [
			{chinese:'热卖产品',english:'HOT PRODUCT'},
			{chinese:'公司简介',english:'COMPANY PROFILE'},
			{chinese:'精彩视频',english:'VEDIO'},
			{chinese:'学术交流',english:'ACADEMIC EXCHANGE'},
			{chinese:'合作机构',english:'COOPERATIVE ORGANIZATRON'},
		],
		hotSellArry:[
			{
				img:'images/hot1.jpeg',
				text:'【桌面级】混凝土（砂浆）3D打印系统',
				english:'HC-3Dprt/D',
				flag:true,
				},
			{
				img:'images/hot2.png',
				text:'【混凝土碳化试验箱',
				english:'HC-HTX12',
				flag:true,
				},
			{
				img:'images/hot3.jpeg',
				text:'低温硫酸盐-交流阻抗耦合试验机',
				english:' HC-DL30',
				flag:true,
				},
			{
				img:'images/hot4.png',
				text:'混凝土氯离子扩散系数测定仪',
				english:'HC-RCM6',
				flag:true,
				},
			{
				img:'images/hot5.png',
				text:'混凝土氯离子电通量测定仪',
				english:'HC-RCP9',
				flag:false,
				},
			{
				img:'images/hot6.png',
				text:'硬化混凝土气孔结构分析仪',
				english:'HC-457',
				flag:false,
				},
			{
				img:'images/hot7.png',
				text:'混凝土氯离子扩散系数电通量测定仪',
				english:'HC-RCMP6',
				flag:false,
				},
			{
				img:'images/hot8.jpeg',
				text:'混凝土氯离子扩散系数电通量测定仪',
				english:'HC-HDD',
				flag:false,
				},
		],
		learningArry:[
			{
				img:'images/xueshu1.jpg',
				title:'毒理学研究方法论坛',
				jieshao:'从体外毒理学、计算毒理学、分析毒理学、代谢毒理学等多个维度阐述毒理学研究方法热点研究内div容'
			},{
				img:'images/xueshu2.png',
				title:'安捷伦与新疆新特检测达成合作，赋能西北地区实验',
				jieshao:'双方合作将推动中国新能源事业健步发展。'
			},{
				img:'images/xueshu3.jpg',
				title:'安捷伦科技公司公布2022财年第一季度财务报告',
				jieshao:'2022强劲开局，提升全年业绩预期'
			}
		],
		cooperativeArry:['images/customer1.jpg','images/customer1.png','images/customer2.png','images/customer3.jpg','images/customer3.png','images/customer3.jpg','images/customer3.png','images/customer2.png','images/customer1.jpg','images/customer2.png'],
		vedioArry:[
			{img:'images/vedio1.jpg',text:'中国原创助力冬奥会—清华堆石混凝土技术引发"革命"',time:'2022-02-10'},
			{img:'images/vedio2.jpg',text:'当3D打印的混凝土冰墩墩上了熊猫色',time:'2022-02-21'},
			{img:'images/vedio3.jpg',text:'混凝土3D打印作品案例集（二）',time:'2022-01-22'},
			{img:'images/vedio4.jpg',text:'中国原创助力冬奥会—清华堆石混凝土技术引发"革命"',time:'2022-02-10'}
		]
		
	  }
	})
	// banner
	var swiper = new Swiper('.banner .swiper-container', {
		pagination: '.swiper-pagination',
		nextButton: '.swiper-button-next',
		prevButton: '.swiper-button-prev',
		slidesPerView: 1,
		paginationClickable: true,
		loop: true
	});
	// 学术交流
	$('.learning-box li').mouseenter(function(){
		$(this).find('.mengceng').fadeIn(200);
		$(this).find('.neirong').fadeIn(200);
	});
	 
	$('.learning-box li').mouseleave(function(){
		$(this).find('.mengceng').fadeOut(200);
		$(this).find('.neirong').fadeOut(200);
	});
	
	//无缝轮播的效果
	var jSpeed = 6000 // 定义了播放速度，你想多少速度就多少速度，这里主要是关系到下面的函数调用
	var jointVentureSwiper = new Swiper('.vedio_container',{ // 初始化并存储了轮播器
	  autoplay: 1, // 设置了自动播放
	  speed: jSpeed, // 设置了播放速度
	  freeMode: true, // 设置了是否可以自由运动
	  loop : true, // 设置了是否可以轮播
	  slidesPerView :'auto', // 设置了显示的多少个为自动
	  loopedSlides: 8, // 设置了轮播显示的个数，你的是多少个参与轮播就是多少个
	  noSwiping : true, // 禁止了手滑动
	  noSwipingClass : 'swiper-slide'// 禁止了手滑动的元素
	})
	// 鼠标一上去能不能暂停播放，移开后能继续流畅播放
	/** nextTransForm 移开鼠标后位移到的位置 **/
	var nextTransForm = '' 
	/** nextSpeed 移开鼠标后位移的时间 **/
	var nextSpeed = 0
	/** 监听鼠标移到轮播图的子元素上，停止元素 **/
	$('.vedio .slide_main').on('mouseenter', function () {
	  /** 保存下一次移动的位置 **/
	  nextTransForm = 'transform:' + $('.vedio').find('.swiper-wrapper').eq(0).attr('style').split('transform:')[1].split(';')[0]
	  /** 得到下一次移动到子元素左边的位置 **/
	  var nextS = -1 * parseInt(nextTransForm.split('translate3d(')[1].split('px')[0])
	  /** 得到当前鼠标下子元素上的距离左边的 **/
	  var nowS = -1 * parseInt($('.vedio').find('.swiper-wrapper').eq(0).css('transform').split('1, ')[2].split(',')[0])
	  /** 得到实际上，鼠标移动后，子元素应该移动的时间 **/
	  /** 注意这个280，这是我的元素这么宽，你可以写代码获取，这是我懒了 **/
	  nextSpeed = jSpeed * ((nextS - nowS) / 373)
	  /** transform---设置当前位置；前面的代码是兼容swiper2.0，因为2.0会加点料 **/
	  /** transition-duration:0ms;让元素不移动 **/
	  $('.vedio').find('.swiper-wrapper').eq(0).attr('style', `${$('.vedio').find('.swiper-wrapper').eq(0).attr('style').split('transform: ')[0]}transform: ${$('.vedio').find('.swiper-wrapper').eq(0).css('transform')};transition-duration:0ms;`)
	});
	/** 监听鼠标移开轮播图的子元素，轮播图继续滚动 **/
	$('.vedio .slide_main').on('mouseleave', function () {
	    /** 讲刚刚的内容直接放上去，然后就会发现又动起来了，且无缝，类似上面的暂停代码 **/
	  $('.vedio').find('.swiper-wrapper').eq(0).attr('style', `${$('.vedio').find('.swiper-wrapper').eq(0).attr('style').split('transform: ')[0]}${nextTransForm};transition-duration:${nextSpeed}ms;`)
	  jointVentureSwiper.startAutoplay()
	});
	
	
	
})
