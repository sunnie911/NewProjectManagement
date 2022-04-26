$(function () {
    tabPage({
        pageMain: '#pageMain',
        pageNav: '#pageNav',
        pagePrev: '#prev',
        pageNext: '#next',
        curNum: 10, /*每页显示的条数*/
        activeClass: 'active', /*高亮显示的class*/
        ini: 0/*初始化显示的页面*/
    });
    function tabPage(tabPage) {
        var pageMain = $(tabPage.pageMain);
        /*获取内容列表*/
        var pageNav = $(tabPage.pageNav);
        /*获取分页*/
        var pagePrev = $(tabPage.pagePrev);
        /*上一页*/
        var pageNext = $(tabPage.pageNext);
        /*下一页*/

        var curNum = tabPage.curNum;
        /*每页显示数*/
        var len = Math.ceil(total / curNum);;
        /*计算总页数*/
        // console.log(len);
        var pageList = '';
        /*生成页码*/
        var iNum = 0;

        var selectedPage = 1;
        var url = window.location.href;
        if (url.indexOf("page=") >= 0) {
            var end = url.length;
            var page = url.substring(url.indexOf('=') + 1, end);
            selectedPage = page;
            iNum = page;
        }

        /*当前的索引值*/
        for (var i = 0; i < len; i++) {
            var url1 = pageUrl + "?page=" + parseInt(i + 1);
            pageList += '<a href=' + url1 + '>' + (i + 1) + '</a>';
        }
        pageNav.html(pageList);

        if (iNum == 0) {
            $('#prev').hide();
        } else {
            $('#prev').show();
        }

        /*头一页加高亮显示*/
        pageNav.find("a:first").addClass(tabPage.activeClass);
        /*******标签页的点击事件*******/
        pageNav.find("a").each(function () {
            $(this).click(function () {
                pageNav.find("a").removeClass(tabPage.activeClass);
                $(this).addClass(tabPage.activeClass);
                iNum = $(this).index();

                if (iNum == len - 1) {
                    $('#next').hide();
                    $('#prev').show();
                } else {
                    $('#next').show();
                }
                if (iNum > 0) {
                    $('#prev').show();
                }
                if (iNum == 0) {
                    $('#prev').hide();
                    $('#next').show();
                }
                console.log(123)
                $(pageMain).find("li").hide();
                for (var i = ($(this).html() - 1) * curNum; i < ($(this).html()) * curNum; i++) {
                    $(pageMain).find("li").eq(i).show()
                }

            });
        })


        console.log(selectedPage);
        pageNav.find("a").removeClass(tabPage.activeClass);
        pageNav.find("a").eq(selectedPage).addClass(tabPage.activeClass);

        $(pageMain).find("li").hide();
        /************首页的显示*********/
        for (var i = 0; i < curNum; i++) {
            $(pageMain).find("li").eq(i).show()
        }


        /*下一页*/
        pageNext.click(function () {
            $(pageMain).find("li").hide();
            if (iNum != len - 1) {
                pageNav.find("a").removeClass(tabPage.activeClass);
                iNum++;
                $('#prev').show();
                pageNav.find("a").eq(iNum).addClass(tabPage.activeClass);
            }
            if (iNum == len - 1) {
                $('#next').hide();
            }
            for (var i = iNum * curNum; i < (iNum + 1) * curNum; i++) {
                $(pageMain).find("li").eq(i).show()
            }
        });
        /*上一页*/
        pagePrev.click(function () {
            $(pageMain).find("li").hide();
            if (iNum != 0) {
                pageNav.find("a").removeClass(tabPage.activeClass);
                iNum--;
                pageNav.find("a").eq(iNum).addClass(tabPage.activeClass);
                $('#next').show();
            }
            if (iNum == 0) {
                $('#prev').hide();
                $('#next').show();
            }
            for (var i = iNum * curNum; i < (iNum + 1) * curNum; i++) {
                $(pageMain).find("li").eq(i).show()
            }
        })

    }



})