// JavaScript Document
		var scrollPhoto = new ScrollPicleft();
		scrollPhoto.scrollContId   = "about"; // ��������ID""
		scrollPhoto.arrLeftId      = "about-left";//���ͷID
		scrollPhoto.arrRightId     = "about-right"; //�Ҽ�ͷID

		scrollPhoto.frameWidth     = 1108;//��ʾ����
	
		scrollPhoto.pageWidth      = 279; //��ҳ���

		scrollPhoto.speed          = 10; //�ƶ��ٶ�(��λ���룬ԽСԽ��)
		scrollPhoto.space          = 10; //ÿ���ƶ�����(��λpx��Խ��Խ��)
		scrollPhoto.autoPlay       = true; //�Զ�����
		scrollPhoto.autoPlayTime   = 3; //�Զ����ż��ʱ��(��)

		scrollPhoto.initialize(); //��ʼ��	
		