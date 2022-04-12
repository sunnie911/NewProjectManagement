function myCustomForm (conf) {
  var config = {
    formBoxId: '',
    CompanyId: '41089453',
    DataFormId: '1093514546',
    ChannelTitle: '欢迎申请试用',
    ChannelName: '落地页-右侧申请试用',
    fields: [],
    type: 'default'
  }

  var fileAction = '/fileupload/upload'
  var fileMulti = false

  var uploadComps = []

  function getUUID (len) {
    var length = len || 2
    return Number(
      Math.random()
        .toString()
        .substr(3, length) + Date.now()
    ).toString(36)
  }
  // var formBox = null
  var validator = null
  var uuid = getUUID()
  // var boxId = 'corp__box-' + uuid
  var formId = 'corp__form-' + uuid
  var submitBtnName = 'corp__form-submit-' + uuid
  var agreementId = 'corp__agreement-btn-' + uuid
  if (conf) {
    $.extend(config, conf)
  }
  var localStorageFormKey = 'localEvosFormData'
  // 默认类型，预防以后添加试用以外的表单
  // if (config.type === 'default') {

  // }
  // 预留类型
  // if (config.type === 'shiyong') {
  //   $.extend(config, {
  //     CompanyId: '41089453',
  //     DataFormId: '1093514546',
  //   })
  // }

  // if (config.type === 'yulan') {
  //   $.extend(config, {
  //     CompanyId: '41089453',
  //     DataFormId: '1093514546',
  //   })
  // }

  var customForm = {
    init: function () {},
    createFormItem: function (v) {
      return $('<div class="form__item"></div>')
    },
    createFormItemContent: function (v) {
      return $('<div class="form__item-content"></div>')
    },
    createInput: function (v) {
      var input = $(
        '<input type="text" class="corp__input-input" autocomplete="off">'
      )
      customForm.setInputName(input, v)
      $(input).attr({
        placeholder: v.Notes || ''
      })
      return input
    },
    createTextArea: function (v) {
      var input = $(
        '<textarea rows="5" class="corp__input-textarea" autocomplete="off"></textarea>'
      )
      customForm.setInputName(input, v)
      $(input).attr({
        placeholder: v.Notes || ''
      })
      return input
    },
    createdCheckBox: function (v) {
      var group = $('<div class="corp__checkbox-group"></div>')
      v.Options.forEach(function (opt) {
        var item = $(
          '<label class="corp__checkbox-group__item"><i class="corp__checkbox-icon"></i><span class="corp__checkbox-txt">' +
            opt +
            '</span></label>'
        )
        var input = $(
          '<input type="checkbox" class="corp__checkbox-input"  value="' +
            opt +
            '">'
        )

        customForm.setInputName(input, v)
        $(input).prependTo(item)
        $(item).appendTo(group)
      })

      return group
    },
    createRadio: function (v) {
      var group = $('<div class="corp__radio-group"></div>')
      v.Options.forEach(function (opt) {
        var item = $(
          '<label class="corp__radio-group__item"><i class="corp__radio-icon"></i><span class="corp__radio-txt">' +
            opt +
            '</span></label>'
        )
        var input = $(
          '<input type="radio" class="corp__radio-input" value="' + opt + '">'
        )

        customForm.setInputName(input, v)
        $(input).prependTo(item)
        $(item).appendTo(group)
      })
      return group
    },
    createSelect: function (v) {
      var input = $('<select class="corp__input-input"></select>')
      v.Options.forEach(function (opt) {
        var optionItem = $('<option value="' + opt + '"></option')
        $(optionItem).text(opt)
        $(optionItem).appendTo(input)
      })
      customForm.setInputName(input, v)
      return input
    },
    createDate: function (v) {},
    createNumber: function (v) {},
    createUpload: function (v) {
      var inputId = getUUID()
      var idName = 'form-upload-' + inputId
      uploadComps.push(idName)
      // <input id="fileupload" type="file" name="files[]" data-url="server/php/" multiple></input>
      var html = '<span class="corp__input-upload">' +
                  '<div class="corp__input-upload__btn">' +
                  '<i class="icon icon-upload"></i>' +
                  '<span>上传文件</span>' +
                  '<input id="' + idName + '-hideen" name="' + v.FieldName + '">' +
                  '<input id="' + idName + '" type="file" name="files[]">' +
                  '</div>' +
                  '<div class="corp__input-upload__info">' +
                  '</div>' +
                  '<p class="progress">' +
                  '<span class="progress__bar"></span>' +
                  '</p>' +
                  '</span>'
      var input = $(html)
      // var input = $(
      //   '<input id="' + idName + '" type="file" name="files[]" data-url="' + fileAction + '" ' + fileMulti + '>'
      // )
      // customForm.setInputName(input, v)

      return input
    },
    initUploadComponents: function (idName) {
      $(idName).fileupload({
        autoUpload: true,
        // dataType: 'json',
        Type: 'POST',
        url: fileAction,
        multiple: fileMulti,
        maxNumberOfFiles: 1, // 最大上传文件数目
        maxFileSize: 999000,
        acceptFileTypes: /(\.|\/)(gif|jpe?g|png)$/i,
        messages: {// 文件错误信息
          acceptFileTypes: '文件类型不匹配',
          maxFileSize: '文件过大',
          minFileSize: '文件过小'
        },
        add: function (e, data) {
          var uploadErrors = []
          var acceptFileTypes = /^image\/(gif|jpe?g|png)$/i

          
          // 文件类型判断
          if (!data.originalFiles[0].type || !acceptFileTypes.test(data.originalFiles[0].type)) {
            uploadErrors.push('请上传gif、jpg、jpeg或png格式的文件')
          }

          // 文件大小判断
          var fileMaxSize = 5
          if (data.originalFiles[0].size > (fileMaxSize * 1024 * 1024)) {
            uploadErrors.push('请上传不超过'+ fileMaxSize +'M的文件')
          }

          if (uploadErrors.length > 0) {
            alert(uploadErrors.join('\n'))
          } else {
            $(idName).closest('.corp__input-upload').find('.progress').show()
            data.submit()
          }
        },
        progressall: function (e, data) {
          // 上传进度
          $(idName).attr('disabled', true)
          var progress = parseInt(data.loaded / data.total * 100)
          $(idName).closest('.corp__input-upload').find('.progress').show().find('.progress__bar').css({
            width: progress + '%'
          })
        },
        fail: function (e, data) {
          $(idName).closest('.corp__input-upload').find('.progress').hide()
          $(idName).removeAttr('disabled')
        },
        complete: function (e, data) {
          $(idName).closest('.corp__input-upload').find('.progress').hide()
          $(idName).removeAttr('disabled')
          $(idName).closest('.corp__input-upload').find('.progress').hide().find('.progress__bar').css({
            width: 0 + '%'
          })
        },
        success: function (data) {
          var vData = JSON.stringify({
            url: data.urlRelative,
            name: data.fileName
          })
          //var hiddenInput = '#form-upload-3usrc6h498-hideen'

          var hiddenInput = $(idName).siblings('input')
          $(hiddenInput).val(vData)
          $(idName).removeAttr('disabled')
          $(idName).closest('.corp__input-upload').find('.corp__input-upload__info').text(data.fileName)
        },
      })
    },
    createLabel: function (v) {
      var label = $( '<label class="form__item-label">' + v.DisplayName + '</label>' )
      if (v.IsRequired) {
        $(label).addClass('require')
      }
      return label
    },
    createSubmitBtn: function () {
      // var html = '<div class="form-item">' +
      //           '<button class="corp__btn" id="' + submitBtnName + '" type="submit">提交</button>' +
      //           '</div>'

      var html =
        '<div class="form__item form-ctrl-panel">' +
        // '<p>' +
        // '<label class="corp__checkbox-group__item">' +
        // '<input class="corp__checkbox-input" type="checkbox" checked  id="' +
        // agreementId +
        // '"/>' +
        // '<i class="corp__checkbox-icon"></i>' +
        // '<span class="corp__checkbox-txt">我已阅读并同意<a href="/special/termsofservice" target="_blank">《31会议服务协议》</a></span>' +
        // '</label>' +
        // '</p>' +
        '<button class="corp__btn" id="' +
        submitBtnName +
        '" type="submit">' +
        '提交' +
        '</button>' +
        '</div>'
      return $(html)
    },
    setInputName: function (input, v) {
      $(input).attr({
        name: v.FieldName,
      })
    },
    setInputAttr: function (v) {},
    getRuleObj: function (fields) {
      var rules = {}
      fields.forEach(function (item) {
        var ruleItem = (rules[item.FieldName] = {})
        if (item.IsRequired) {
          ruleItem['required'] = true
        }
        if (item.FieldName === 'Email') {
          ruleItem['corpEmail'] = true
        }
        if (item.FieldName === 'Mobile') {
          ruleItem['mobile'] = true
        }
      })
      return rules
    },
    getFormFileds: function () {
      if (config.fields && config.fields.length) {
        customForm.initValidator()
        return false
      }

      $.ajax({
        type: 'POST',
        url: '/api/formdata/GetDataFormListField',
        data: {
          CompanyId: config.CompanyId,
          DataFormId: config.DataFormId
        },
        success: function (res) {
          config.fields = res.data || []
          customForm.initValidator()
        }
      })
      // customForm.createFormContent(config.fields)
    },
    createFormContent: function () {
      //  FieldType: String, // Text(0),TextArea(1),Radio(2),CheckBox(3),DropDown(4),
      //     // Date(5),Number(6),Amount(7),Boolean(8),LongDropDown(9) 图片上传(10)
      var list = []
      var formDom = customForm.createForm()

      var fragment = document.createDocumentFragment() // dom碎片，优化dom渲染
      config.fields.forEach(function (item) {
        if (item.IsHide) {
          return false
        }
        var itemBox = customForm.createFormItem(item)
        var label = customForm.createLabel(item)
        var inputContent = customForm.createFormItemContent()

        var inputComp = null

        switch (item.FieldType) {
          case 0:
            inputComp = customForm.createInput(item)
            break
          case 1:
            inputComp = customForm.createTextArea(item)
            break
          case 2:
            inputComp = customForm.createRadio(item)
            break
          case 3:
            inputComp = customForm.createdCheckBox(item)
            break
          case 4:
            inputComp = customForm.createSelect(item)
            break
          case 10:
            inputComp = customForm.createUpload(item)
            break
        }

        // 单行文本：0  多行文本：1
        var isBoxItem = [0, 1].some(function (v) {
          return v === item.FieldType
        })
        if (isBoxItem) {
          $(itemBox).addClass('box')
          $(itemBox).on('click', function () {
            $(this)
              .find('.corp__input-input')
              .focus()
          })
          $(inputComp).on('focus', function () {
            $(this)
              .closest('.form__item')
              .addClass('focus')
          })
          $(inputComp).on('blur', function () {
            $(this)
              .closest('.form__item')
              .removeClass('focus')
          })
        }
        $(label).appendTo(itemBox)
        $(inputComp).appendTo(inputContent)
        $(inputContent).appendTo(itemBox)

        list.push(itemBox)
      })

      list.forEach(function (item) {
        $(item).appendTo(fragment)
      })
      $(fragment).prependTo(formDom)

      var submitItem = customForm.createSubmitBtn()
      $(submitItem).appendTo(formDom)

      var formBox = customForm.createFormBox()
      var header = customForm.createHeader()
      var boxbody = customForm.createBoxbody()
      var formbody = customForm.createFormbody()
      var formWrap = customForm.createFormWrap()
      var successDom = customForm.createSuccessDom()

      $(formDom).appendTo(formWrap)
      $(formWrap).appendTo(formbody)
      $(successDom).appendTo(formbody)
      $(formbody).appendTo(boxbody)

      $(header).appendTo(formBox)
      $(boxbody).appendTo(formBox)
      // $(formBox).appendTo(config.formBoxId)
      $(config.formBoxId).html(formBox)

      uploadComps.forEach(function (item) {
        var idName = '#' + item
        customForm.initUploadComponents(idName)
      })

      $('.corp__layer .corp__form .layui-layer-close').on('click', function () {
        layer.closeAll('page')
        showLayer = true
      })
      console.log(config.formBoxId)
    },
    createFormBox: function () {
      return $(
        '<div class="corp__form"> <span class="layui-layer-setwin"><a class="layui-layer-ico layui-layer-close layui-layer-close2" href="javascript:;"></a></span> </div>'
      )
    },
    createHeader: function () {
      var html =
        '<div class="corp__form-header">' + config.ChannelTitle + '</div>'
      return $(html)
      // return $('<div class="corp__form-header">' + config.ChannelTitle + '</div>')
    },
    createBoxbody: function () {
      return $('<div class="corp__form-body"></div>')
    },
    createFormbody: function () {
      return $('<div class="corp__form-inner"></div>')
    },
    createForm: function () {
      // var dom = $('<div class="corp__form-inner" id="'+formId+'"></div>')
      return $('<form id="' + formId + '"></form>')
    },
    createFormWrap: function () {
      return $('<div class="corp__form-form"></div>')
    },
    createSuccessDom: function () {
      var successText1 = '您的信息提交成功，客服将在24小时内与您联系'
      var successText2 = ''
      if ('ChannelTitle'in config && config.ChannelTitle.indexOf('下载') > -1) {
        successText1 = '您的信息提交成功，下载资料请注意查看邮件和短信'
        successText2 = '客服将在24小时内与您联系'
      }
      var html = '<div class="corp__form-success">' +
                '<div class="corp__form-success__top">' +
                '<img class="corp__form-success__icon" src="/Static2019/componentSass/imgs/success-img.png" alt="">' +
                '<div class="corp__form-success__title">提交成功</div>' +
                '<div class="corp__form-success__tip">' +
                '<p>' + successText1 + '</p>' +
                '<p>' + successText2 + '</p>' +
                '</div>' +
                '</div>' +
                '<div class="corp__form-success__bottom" style="padding: 20px; height: auto;">' +
                '<p>如要尽早得到回复或随时发起沟通</p>' +
                '<p style="margin-bottom: 10px;">请扫描下方二维码</p>' +
                '<div class="corp__form-success__qrcode"><img id="bdxiaomifengImg" src="https://wework.qpic.cn/wwpic/967122_IgJ7R4xgQUKaq4i_1627607630/0" alt="" style="width: 124px; height: 124px;"></div>' +
                '<div class="corp__form-success__concat">关注客服：31小蜜蜂</div>' +
                '</div>' +
                '</div>'
      return $(html)
    },
    getValues: function () {
      return $('#' + formId).serializeArray()
    },
    initValidator: function () {
      this.createFormContent()
      // this.fillValues()
      this.getFillData()
      var rules = customForm.getRuleObj(config.fields)
      $('#' + formId).on('submit', function (e) {
        e.preventDefault()
      })
      validator = $('#' + formId).validate({
        rules: rules,
        submitHandler: function (form) {
          // if ($())
          // var isAgreement = $('#' + agreementId).is(':checked')
          // if (isAgreement) {
          //   customForm.success()
          // } else {
          //   alert('请先阅读并同意注册相关协议')
          // }
          customForm.success()
        },
        errorPlacement: function (error, element) {
          error.addClass('form__item-error')
          error.appendTo(element.closest('.form__item-content'))
        }
      })
      $('#' + formId).reset = customForm.reset
    },
    getFillData: function () {
      // 兼容处理，谷歌 和 苹果最新浏览器jsonp请求不成功，做下本地存储
      var data = localStorage.getItem(localStorageFormKey)
      if (data) {
        customForm.fillValues(JSON.parse(data))
      }

      // 获取ssodata
      $.ajax({
        url: 'https://www.31meijia.com/Pushings/InformationDataForm/getcookie?',
        type: 'get',
        dataType: 'jsonp', // jsonp格式访问
        jsonpCallback: 'getEvosFormFillData', // 获取数据的函数
        success: function (res) {
          var result = res.dic || ''
          if (result) {
            result = JSON.parse(result)
            customForm.fillValues(result)
          }
        }
      })
    },
    fillValues: function (obj) {
      var form = $('#' + formId)
      // var data = customForm.getFillData()
      var data = obj
      console.log(data)
      console.log(formId)
      var value
      for (i in data) {
        value = data[i]
        var input = $(form).find('[name=' + i + ']')
        $(input).each(function (item) {
          var tagName = $(this)[0].tagName.toLocaleLowerCase()
          var tagType = $(this)[0].type
          if (tagName === 'input') {
            if (tagType === 'radio') {
              $(this).attr('checked', $(this).val() === value)
            } else if (tagType === 'checkbox') {
              arr = value.split(',')
              for (var index = 0; index < arr.length; arr++) {
                if ($(this).val() === arr[index]) {
                  $(this).attr('checked', true)
                }
              }
            } else {
              $(this).val(value)
            }
          }
          if (tagName === 'select' || tagName === 'textarea') {
            $(this).val(value)
          }
        })
      }
    },
    success: function () {
      $('#' + formId).hide()
      $('#' + formId)
        .closest('.corp__form-inner')
        .find('.corp__form-success')
        .show()
      var postData = customForm.getValues()
      var postObj = {}
      postData.forEach(function (item) {
        postObj[item.name] = item.value
      })

      config.fields.forEach(function (item) {
        if (postObj[item.FieldName]) {
          item.DefaultValue = postObj[item.FieldName]
        }
      })
      var utm_source = utils.getCookie('utm_source') || ''
      var utm_campaign = utils.getCookie('utm_campaign') || ''

      $.ajax({
        type: 'POST',
        url: '/api/formdata/CreateInformData',
        data: {
          CompanyId: config.CompanyId,
          DataFormId: config.DataFormId,
          ChannelName: config.ChannelName,
          utm_campaign: utm_campaign,
          utm_source: utm_source,
          Fields: config.fields
        },
        success: function (res) {
          // 2021用户大会查看视频定制开始
          var url = window.location.href;
          if(url.indexOf("2021reevent/Scene") || url.indexOf("2022reevent/Scene") >= 0 ) {
            $('.corp__form-success__tip').hide();
            if(config.ChannelName == "Corp-21用户大会视频万涛"){
              window.open("https://www.31meijia.com/Mobiles/ContentVideo/Video?ContentVideoId=2018174883&CompanyId=41089453","_blank"); 
            }
            if(config.ChannelName == "Corp-21用户大会视频吴一中"){
              window.open("https://www.31meijia.com/Mobiles/ContentVideo/Video?ContentVideoId=2018174884&CompanyId=41089453","_blank"); 
            }
            if(config.ChannelName == "Corp-21用户大会视频程治刚"){
              window.open("https://www.31meijia.com/Mobiles/ContentVideo/Video?ContentVideoId=2018198356&CompanyId=41089453","_blank"); 
            }
            if(config.ChannelName == "Corp-21用户大会视频白桂香"){
              window.open("https://www.31meijia.com/Mobiles/ContentVideo/Video?ContentVideoId=2018198357&CompanyId=41089453","_blank"); 
            }
          }
          // 2021用户大会查看视频定制结束
          var Dictionary = {}
          config.fields.forEach(function (item) {
            Dictionary[item.FieldName] =
              item.FieldType === 10 ? '' : item.DefaultValue
          })
          // $.getJSON('https://www.31meijia.com/Pushings/InformationDataForm/setcookie', Dictionary, function(res) {
          //     console.log(res)
          // })
          // 将数据存储到本地
          localStorage.setItem(localStorageFormKey, JSON.stringify(Dictionary))
          // 发送cookie到sso
          $.ajax({
            url:
              'https://www.31meijia.com/Pushings/InformationDataForm/setcookie?',
            type: 'get',
            dataType: 'jsonp', // jsonp格式访问
            data: {
              Dictionary: Dictionary
            }
          }).done(function () {
            // // 获取ssodata
            // $.ajax({
            //   url:'https://www.31meijia.com/Pushings/InformationDataForm/getcookie?',
            //   type:'get',
            //   dataType:'jsonp',  //jsonp格式访问
            //   jsonpCallback:'getEvosFormFillData',  //获取数据的函数
            // })
          })
        },
        error: function (err) {
          console.log(err)
        }
      })
    },
    reset: function () {
      console.log($('#' + formId))
      validator.resetForm()
      $('#' + formId)[0].reset()
      $('#' + formId).show()
      $('#' + formId)
        .closest('.corp__form-inner')
        .find('.corp__form-success')
        .hide()
    }
  }
  customForm.getFormFileds()
  return customForm
}
function getEvosFormFillData (res) {
  localStorage.setItem('localEvosFormData', res.dic || '')
}
//  <script src="https://www.31meijia.com/Pushings/InformationDataForm/getcookie?callback=getEvosFormFillData"></script>
function getScrollWidth () {
  var scrollDiv = document.createElement("div");
  scrollDiv.style.overflow = 'scroll';
  scrollDiv.innerHTML = '&nbsp;';
  document.body.appendChild(scrollDiv);

  // Get the scrollbar width
  var scrollbarWidth = scrollDiv.offsetWidth - scrollDiv.clientWidth;
  console.warn(scrollbarWidth); // Mac:  15

  // Delete the DIV 
  document.body.removeChild(scrollDiv);
  return scrollbarWidth
}
// layer弹层时 页面抖动处理方法，给html 一个padding，让内容不抖动
function setScrollBarWidth () {
  var barwidth = ''
  var hasScrollBar =
  document.body.scrollHeight >
    (window.innerHeight || document.documentElement.clientHeight)
  $('html').css({
    overflow: 'hidden'
  })
  if (hasScrollBar) {
    barwidth = getScrollWidth() + 'px'
    $('html').css({
      'padding-right': barwidth
    })
    $('body').css({
      'height': 'initial'
    })
    $('.corp__rightmenu').css({
      right: barwidth
    })
    $('.corp__header.fixed').css({
      'paddingRight': barwidth
    })
  }
}
function resetScrollBarWidth () {
  $('html').css({
    overflow: '',
    paddingRight: ''
  })
  $('body').css({
      'height': '100%'
    })
  $('.corp__header').css({
    'paddingRight': 0
  })
  $('.corp__rightmenu').css({
    right: 0
  })
}
function showlayerHandlar() {
  showLayer = true
  if (layerTimer) {
    clearTimeout(layerTimer)
  }
  setScrollBarWidth()
  myCustomForm({
    formBoxId: '#js-corp__layer-shiyong', //
    CompanyId: '41089453',
    DataFormId: '1093514546',
    ChannelTitle: '欢迎申请试用',
    ChannelName: '新corp站-右侧申请试用'
  })
  layer.open({
    type: 1,
    skin: 'layui-layer-demo', // 样式类名
    title: false,
    fixed: true,
    closeBtn: 0,
    area: ['auto', 'auto'],
    offset: '0',
    anim: 2,
    shadeClose: true, // 开启遮罩关闭
    content: $('#js-corp__layer-shiyong'),
    end: function () {
      // todo... 重置表单
      resetScrollBarWidth()
    }
  })
}
$(function () {
  // 申请使用表单
  $('.js-corp__layer-shiyong').on('click', function () {
    var id = $(this).attr('form-target')
    if (!id) { return false }
    showlayerHandlar()
  })

  // 点击带有form-target 属性的dom 弹出对应表单
  // 表单回显失败原因 实例化对象错误
  // 在弹层的地方加属性
  $('*[form-target], *[data-target]').on('click', function () {
    var id = $(this).attr('form-target') || $(this).attr('data-target')
    var CompanyId =
      $(this).attr('form-companyId') || $(this).attr('data-companyId')
    var DataFormId =
      $(this).attr('form-dataFormId') || $(this).attr('data-dataFormId')
    var ChannelTitle =
      $(this).attr('form-channelTitle') || $(this).attr('data-channelTitle')
    var ChannelName =
      $(this).attr('form-channelName') || $(this).attr('data-channelName')

    var formConfig = {
      formBoxId: id, //
      CompanyId: CompanyId,
      DataFormId: DataFormId,
      ChannelTitle: ChannelTitle,
      ChannelName: ChannelName
    }
    for (var i in formConfig) {
      if (!formConfig[i]) {
        delete formConfig[i]
      }
    }
    myCustomForm(formConfig)
    setScrollBarWidth()
    if (id) {
      layer.open({
        type: 1,
        skin: 'layui-layer-demo', // 样式类名
        title: false,
        fixed: false,
        closeBtn: 0,
        area: ['auto', 'auto'],
        offset: '0',
        anim: 2,
        shadeClose: true, // 开启遮罩关闭
        content: $(id),
        end: function () {
          resetScrollBarWidth()
        }
      })
    }
    showLayer = true
    if (layerTimer) {
      clearTimeout(layerTimer)
    }
  })
  
	// 全网申请试用表单提交成功页面
	$.ajax({
		url: "https://scrm-wx.weiling.cn/api/live_code/select?corp_id=wx6d730ac42d44ae3c&code_channel_id=1420915087673270272", success: function (result) {
				$("#bdxiaomifengImg").attr("src", JSON.parse(result).data.qr_code);
		}
	});
})
