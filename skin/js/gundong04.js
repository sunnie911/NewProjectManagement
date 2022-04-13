// JavaScript Document
		var scrollPhoto = new ScrollPicleft();
		scrollPhoto.scrollContId   = "about"; // 内容容器ID""
		scrollPhoto.arrLeftId      = "about-left";//左箭头ID
		scrollPhoto.arrRightId     = "about-right"; //右箭头ID

		scrollPhoto.frameWidth     = 1108;//显示框宽度
	
		scrollPhoto.pageWidth      = 279; //翻页宽度

		scrollPhoto.speed          = 10; //移动速度(单位毫秒，越小越快)
		scrollPhoto.space          = 10; //每次移动像素(单位px，越大越快)
		scrollPhoto.autoPlay       = true; //自动播放
		scrollPhoto.autoPlayTime   = 3; //自动播放间隔时间(秒)

		scrollPhoto.initialize(); //初始化	
		