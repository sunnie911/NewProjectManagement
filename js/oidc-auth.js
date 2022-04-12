((function () {
  var Oidc = window.Oidc
  var _origin = location.protocol + '//' + location.host
  var config = {
    authority: location.hostname === 'corpbeta.31huiyi.com' ? 'https://test-oauth.31huiyi.com' : 'https://oauth.31huiyi.com',
    client_id: 'corp',
    redirect_uri: `${_origin}/callback.html`,
    response_type: 'code',
    scope: 'openid AppGateway', // 网关的权限code：AppGateway
    automaticSilentRenew: true,
    silent_redirect_uri: `${_origin}/silent.html`,
    accessTokenExpiringNotificationTime: 60,
    revokeAccessTokenOnSignout: true,
    silentRequestTimeout: 10000,
    checkSessionInterval: 2000
  }
  var userManager = new Oidc.UserManager(config) // 实例化一个userManager

  Oidc.Log.logger = window.console
  Oidc.Log.level = Oidc.Log.DEBUG

  function userSignIn() {
    return userManager.signinSilent()
  }

  // 获取token
  function getToken () {
    return new Promise(function (resolve, reject) {
      userSignIn().then(function () {
        return validateToken()
      }).then(function (token) {
        if (typeof token === 'string') {
          resolve(token)
        } else {
          window.sessionStorage.setItem('idsrv:redirect_url', location.href)
          reject(new Error('未登录或token已过期'))
        }
      })
    })
  }

  // 获取用户信息
  function getUserProfile () {
    return new Promise(function (resolve, reject) {
      getToken().then(function () {
        userManager.getUser().then(function (user) {
          user && user.profile ? resolve(user.profile) : reject(user)
        })
      }).catch(function (e) {
        reject(e)
      })
    })
  }

  // 如果token存在，并且没有过期的话就返回token_type + token，否则返回null
  function validateToken () {
    return new Promise(function (resolve) {
     userSignIn().then(function () {
       return userManager.getUser()
     }).then(function (user) {
        if (user && user.access_token && !user.expired) {
          resolve(user.token_type + ' ' + user.access_token) // 字符串
        } else {
          resolve(null)
        }
      }).catch(function () {
        resolve(null)
      })
    })
  }

  window.auther = {
    getToken: getToken,
    validateToken: validateToken,
    getUserProfile: getUserProfile,
    getUserManager: function () {
      return userManager
    }
  }
}))()
