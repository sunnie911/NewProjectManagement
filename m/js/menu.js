
			$(function() {
				$(".downmenu").click(function() {
					$(".slideMenu").slideToggle("slow");
				})
				$(window).scroll(function() {
					if ($(window).scrollTop() > 220) {
						$(".slideMenu").hide();
					}
				});
			})
		
 
        $("#ftop01").click(function() {
            var scrollTop = document.documentElement.scrollTop || window.pageYOffset || document.body.scrollTop;
            if (scrollTop > 0) {
                $("html,body").animate({
                    scrollTop: 0
                }, "slow");
            }
        });
    
