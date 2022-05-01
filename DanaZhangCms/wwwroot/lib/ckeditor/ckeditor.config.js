/**
 * @license Copyright (c) 2003-2013, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.html or http://ckeditor.com/license
 */
ClassicEditor.editorConfig = function (config) {
    // Define changes to default configuration here. For example:
    // config.language = 'fr';
    // config.uiColor = '#AADC6E';
    config.language = 'zh-cn';
    config.toolbar = 'Full';
    config.toolbar_Full = [
        { name: 'document', items: ['Source'] },
        { name: 'clipboard', items: ['Cut', 'Copy', 'Paste', 'PasteText', 'PasteFromWord', '-', 'Undo', 'Redo'] },
        { name: 'basicstyles', items: ['Bold', 'Italic', 'Underline', 'RemoveFormat'] },
        { name: 'insert', items: ['Image', 'Table', 'HorizontalRule'] },
        '/',
        { name: 'styles', items: ['Font', 'FontSize'] },
        { name: 'colors', items: ['TextColor', 'BGColor'] },
        { name: 'paragraph', items: ['NumberedList', 'BulletedList', '-', 'Blockquote', 'CreateDiv', '-', 'JustifyLeft', 'JustifyCenter', 'JustifyRight'] },
        { name: 'links', items: ['Link', 'Unlink'] },
        { name: 'tools', items: ['ShowBlocks', 'Maximize'] }
    ];
    config.toolbar_Basic = [['Source', 'Paste', 'PasteText', 'PasteFromWord', '-', 'Bold', 'Italic', '-', 'TextColor', 'BGColor', '-', 'NumberedList', 'BulletedList', '-', 'Image', '-', 'Link', 'Unlink']];
    config.font_names = '正文/正文;宋体/宋体;黑体/黑体;仿宋/仿宋_GB2312;楷体/楷体_GB2312;隶书/隶书;幼圆/幼圆;微软雅黑/微软雅黑;' + config.font_names;
    config.allowedContent = true;
    config.image_previewText = " ";
};
