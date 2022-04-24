var page = 1;
function getData() {
    window.location.href = pageUrl + "?page=" + page;
}
layui.use(['laypage', 'layer'], function () {
    var laypage = layui.laypage
        , layer = layui.layer;
    laypage.render({
        elem: 'page',
        count: total,
        theme: '#1E9FFF',
        limit: 10,
        curr: page,
        jump: function (obj, first) {
            //obj包含了当前分页的所有参数，比如：
            page = (obj.curr);
            //首次不执行
            if (!first) {
                //do something
                getData(page);
            }
            else {
                //getData();
            }
        }

    });
});