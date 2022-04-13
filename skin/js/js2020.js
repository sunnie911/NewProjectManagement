$(function(){
	var timer = null;
	var i = 0;
	$pic = $('.example ul li');
	$num = $('.example ol li');
	var a = $num.length;
	$num.click(function(){
		clearInterval(timer);
		var i = $(this).index();
		$pic.eq(i).fadeIn(700).siblings().fadeOut(1000);
		$(this).addClass('seleted').siblings().removeClass('seleted');
		timer = setInterval(function aa(){
		if(i==a){
			i=0;
			$pic.eq(i).fadeIn(700).siblings().fadeOut(1000);
			$num.eq(i).addClass('seleted').siblings().removeClass('seleted');
			i++;
		}else{
			$pic.eq(i).fadeIn(700).siblings().fadeOut(1000);
			$num.eq(i).addClass('seleted').siblings().removeClass('seleted');
			i++;
		}
	},5000);
	})
	timer = setInterval(function aa(){
		if(i==a){
			i=0;
			$pic.eq(i).fadeIn(700).siblings().fadeOut(1000);
			$num.eq(i).addClass('seleted').siblings().removeClass('seleted');
			i++;
		}else{
			$pic.eq(i).fadeIn(700).siblings().fadeOut(1000);
			$num.eq(i).addClass('seleted').siblings().removeClass('seleted');
			i++;
		}
	},5000);
});

$(".search .xl").click(function(){
	if($('.xl-caidan').css('display') === 'none'){
		$(".xl-caidan").show();
	}else{
		$(".xl-caidan").hide();
	}
})
$(".xl-caidan a").click(function(){
	$(".xl-caidan").hide();
})
/*$(document).on('click',':not(.search .xl)',function(){
    $(".xl-caidan").hide();
    return;
})*/
$(".xl-caidan a").click(function(){
	var val = $(this).html();
	$(".search .xl span").html(val);
})

$("header .nav-btn").toggle(function(){
	$("header .nav3").show();
},function(){
	$("header .nav3").hide();
})

$(".fr-nav-top").click(function() {
    $("html,body").animate({scrollTop:0}, 500);
}); 

function Flnav(){
	var css = {
		
		width:'9px',
		height:'6px',
		marginTop: "19px"
	}
	var csss = {
		
		width:'6px',
		height:'9px',
		marginTop: "20px"
	}
	$(".fl-nav1 ul li").click(function(){
		$(this).find("i").css(css).addClass("active").parent().parent().siblings().find("i").css(csss).removeClass("active");
		$(this).addClass("active").siblings().removeClass("active");
		$(this).find('.fl-nav1-nav').addClass('dis-b').parent().siblings().find(".fl-nav1-nav").removeClass("dis-b");
	})
}
function Flnavs(){
	var a = $(".fl-nav1 ul li").find('.fl-nav1-nav').length;
	if(a!=0){
		Flnav();
	}
}
Flnavs();
function scroll() {
    var hegs = $("header .header-mid").height();
    console.log(hegs)
    $('.mar').css({
        marginTop:hegs+"px"
    })
}
scroll();
$(".fl-nav1-m p a").toggle(function () {
	$(".fl-nav1-m ul").show();
},function () {
    $(".fl-nav1-m ul").hide();
})
$(".fl-nav1-m2 li").toggle(function(){
	$(this).find(".fl-nav1-m3").show();
},function(){
	$(this).find(".fl-nav1-m3").hide();
})
function Frnavs(){
	var heg = $(".header .header-top").height();
	$('.header .nav').css({
		top:heg+"px",
		right:'0px'
	})
}
Frnavs();
function Enav(a){
    var wid = $(".nav3 li").eq(a).find('.nav6').width();
    var wid2 = wid/2;
    console.log(wid)
    $(".nav3 li").eq(a).find('.nav6').css({
        marginLeft:-wid2+"px"
    })
}
Enav(1);
Enav(2);
Enav(3);
Enav(4);
Enav(5);
Enav(6);
Enav(7);
Enav(8);
