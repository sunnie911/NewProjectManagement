
/* eslint-disable */
var utils = {
  /**
   * 存储localStorage
   */
  setStore: function (name, content) {
    if (!name) return
    if (typeof content !== 'string') {
      content = JSON.stringify(content)
    }
    window.localStorage.setItem(name, content)
  },
  /**
   * 获取localStorage
   */
  getStore: function (name) {
    if (!name) return
    return window.localStorage.getItem(name)
  },
  /**
   * 删除localStorage
   */
  removeStore: function (name) {
    if (!name) return
    window.localStorage.removeItem(name)
  },

  /**
   * 设置cookie
   */
  setCookie: function (name, value, expiredays) {
    var exdate = new Date()
    exdate.setDate(exdate.getDate() + expiredays)
    document.cookie = name + '=' + escape(value) +
    ((expiredays == null) ? '' : ';expires=' + exdate.toGMTString()) + ';path=/;'
  },
  /**
   * 读取cookie
   */
  getCookie: function (name) {
    var arr; var reg = new RegExp('(^| )' + name + '=([^;]*)(;|$)')
    if (arr = document.cookie.match(reg)) { return unescape(arr[2]) } else { return null }
  },
  /**
   * 删除cookie
   */
  delCookie: function (name) {
    var exp = new Date()
    exp.setTime(exp.getTime() - 1)
    var cval = getCookie(name)
    if (cval != null) { document.cookie = name + '=' + cval + ';expires=' + exp.toGMTString() }
  },

  /**
   * url = http://localhost:8888/static/corp/apps/home?uid=123123
   * 获取地址栏参数   GetQueryString('uid')  得到123123
   */
  GetQueryString: function (name) {
    var reg = new RegExp('(^|&)' + name + '=([^&]*)(&|$)')
    var r = window.location.search.substr(1).match(reg)
    if (r != null) {
      return decodeURI(r[2])
    }
    return null
  },
  /**
   * 将地址栏search 参数转换为json
   * parseQueryString('?type=0&industry=0')
   * {type: "0", industry: "0"}
   */
  parseQueryString: function (url) {
    var obj = {}
    var keyvalue = []
    var key = ''; var value = ''
    var paraString = url.substring(url.indexOf('?') + 1, url.length).split('&')
    for (var i in paraString) {
      keyvalue = paraString[i].split('=')
      key = keyvalue[0]
      value = keyvalue[1]
      obj[key] = value
    }
    return obj
  },

  /* 格式化时间 */

  formatData: function (date, format) {
    if (date) {
      var date = date.replace('Date', '').replace('(', '').replace(')', '').replace(/\//g, '')
      var d = new Date(parseInt(date))

      var o = {
        'M+': d.getMonth() + 1, // month
        'd+': d.getDate(), // day
        'h+': d.getHours(), // hour
        'm+': d.getMinutes(), // minute
        's+': d.getSeconds(), // second
        'q+': Math.floor((d.getMonth() + 3) / 3), // quarter
        'S': d.getMilliseconds() // millisecond
      }
      if (/(y+)/.test(format)) {
        format = format.replace(RegExp.$1,
          (d.getFullYear() + '').substr(4 - RegExp.$1.length))
      }
      for (var k in o) {
        if (new RegExp('(' + k + ')').test(format)) {
          format = format.replace(RegExp.$1,
            RegExp.$1.length == 1 ? o[k]
              : ('00' + o[k]).substr(('' + o[k]).length))
        }
      }
      return format
    }
  },

  /* 格式化 new Date() Thu Nov 09 2017 09:41:27 GMT+0800 (中国标准时间)*/
  formatGTDate: function (date, format) {
    var o = {
      'M+': date.getMonth() + 1, // month
      'd+': date.getDate(), // day
      'h+': date.getHours(), // hour
      'm+': date.getMinutes(), // minute
      's+': date.getSeconds(), // second
      'q+': Math.floor((date.getMonth() + 3) / 3), // quarter
      'S': date.getMilliseconds() // millisecond
    }
    if (/(y+)/.test(format)) {
      format = format.replace(RegExp.$1,
        (date.getFullYear() + '').substr(4 - RegExp.$1.length))
    }
    for (var k in o) {
      if (new RegExp('(' + k + ')').test(format)) {
        format = format.replace(RegExp.$1,
          RegExp.$1.length == 1 ? o[k]
            : ('00' + o[k]).substr(('' + o[k]).length))
      }
    }
    return format
  },

  /* 数组去重 */
  array_remove_repeat: function (a) { // 去重
    var r = []
    for (var i = 0; i < a.length; i++) {
      var flag = true
      var temp = a[i]
      for (var j = 0; j < r.length; j++) {
        if (temp === r[j]) {
          flag = false
          break
        }
      }
      if (flag) {
        r.push(temp)
      }
    }
    return r
  },

  /* 数组交集 */
  array_intersection: function (a, b) {
    var result = []
    for (var i = 0; i < b.length; i++) {
      var temp = b[i]
      for (var j = 0; j < a.length; j++) {
        if (temp === a[j]) {
          result.push(temp)
          break
        }
      }
    }
    return array_remove_repeat(result)
  },

  /* 数组并集 */
  array_union: function (a, b) {
    return array_remove_repeat(a.concat(b))
  },

  /* 数组差集 a - b */
  array_difference: function (a, b) {
    // clone = a
    var clone = a.slice(0)
    for (var i = 0; i < b.length; i++) {
      var temp = b[i]
      for (var j = 0; j < clone.length; j++) {
        if (temp === clone[j]) {
          // remove clone[j]
          clone.splice(j, 1)
        }
      }
    }
    return array_remove_repeat(clone)
  },

  createStyle: function (code, id) {
    var head = document.getElementsByTagName('head')[0]
    var styleElem = document.createElement('style')
    styleElem.setAttribute('type', 'text/css')
    if (id) {
      styleElem.setAttribute('id', id)
    }
    styleElem.innerHTML = code
    head.appendChild(styleElem)
  },
  addScriptBlock: function (code, id) {
    var head = document.getElementsByTagName('head')[0]
    var script = document.createElement('script')
    script.type = 'text/javascript'
    if (id) {
      script.setAttribute('id', id)
    }
    script.setAttribute('id', id)
    script.innerHTML = code
    head.appendChild(script)
  }
}