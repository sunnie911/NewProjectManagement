        $(function() {
            navClick('.fdh-01-nav-one h3', 'dl');
            navClick('.fdh-01-nav dt', 'dd');

            function navClick(clickDom, showDom) {
                $(clickDom).on('click', function() {
                    if ($(this).hasClass('sidenavcur')) {
                        $(this).next(showDom).hide();
                        $(this).removeClass('sidenavcur');
                    } else {
                        $(this).addClass('sidenavcur');
                        $(this).next(showDom).show();
                        $(this).addClass('sidenavcur');
                    }
                });
            }

        });
    

        
    
