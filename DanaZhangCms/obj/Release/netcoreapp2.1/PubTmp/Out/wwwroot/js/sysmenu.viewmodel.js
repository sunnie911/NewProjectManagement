﻿// Write your JavaScript code.
var sysMenuModel = {
    menus:ko.observableArray([]),
    loadMenus: function(url) {
        this.get(url, {}, function(data) {
            if (data.success == true) {
                sysMenuModel.menus(data.rows);
            } else {
                layer.alert(data.msg, {icon:5});
            }
        });
    },
    get: function(url, data, callback) {
        this.ajax(url, data, "GET", callback);
    },
    post: function(url, data, callback) {
        this.ajax(url, data, "POST", callback);
    },
    ajax: function(url, data, type, callback) {
        $.ajax({
            url: url,
            data: data,
            dataType: "JSON",
            type: type,
            success: callback,
            error: function() {
                layer.alert("网络错误，请稍候再试。", { icon: 5 });
            }
        });
    },
    getMenuIconNoSpan: function(icon, name) {
        return '<i class="' + icon + '"></i> ' + name;
    },
    getMenuIcon: function(icon, name) {
        return '<i class="' + icon + '"></i> <span> ' + name + '</span>';
    },
    getMenuIconExpand: function(icon, name) {
        return '<i class="' +
            icon +
            '"></i> <span> ' +
            name +
            '</span><span class="pull-right-container"><i class="fa fa-angle-left pull-right"></i></span>';
    },
    menuClick: function(id, text, url) {
        $("ul.sidebar-menu").find("li.active").removeClass("active").find("li.menu-open").removeClass("menu-open");
        var current = $("#menu_" + id);
        current.addClass("active");
        var parents = current.parents("li");
        var children = current.find("ul");
        if (parents.length > 0) {
            parents.addClass("active").addClass("menu-open");
        } else {
            if (children.length > 0) {
                current.addClass("menu-open");
            }
        }
        $("#tabContainer").data("tabs")
            .addTab({ id: id, text: text, closeable: true, url: url });
    },
    ajaxSubmit: function(formId) {
        $("#" + formId).ajaxSubmit({
            resetForm: true,
            success: function (rep) {
                if (rep.success == true) {
                    layer.msg("保存成功",
                        function () {
                            window.parent.layer.closeAll();
                        });
                } else {
                    layer.alert(rep.msg, { icon: 5 });
                }
            },
            error: function () {
                layer.alert("网络错误，请稍候再试。", { icon: 5 });
            }
        });
    }
};
