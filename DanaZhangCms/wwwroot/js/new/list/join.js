$(function(){
	$('.post ul li').eq(0).find('.post_main').show();
	var flag;
	$('.post ul li .bt').click(function(){
		if(flag==true){
			$(this).find('img').addClass('xuanzhuan')
			$(this).next('.post_main').slideDown(200);
			$(this).parent('li').siblings('li').find('.post_main').slideUp(200);
			$(this).parent('li').siblings('li').find('img').removeClass('xuanzhuan')
			flag=false;
		}else{
			$(this).find('img').removeClass('xuanzhuan')
			$(this).next('.post_main').slideUp(200);
			flag=true;
		}
		
	})
})