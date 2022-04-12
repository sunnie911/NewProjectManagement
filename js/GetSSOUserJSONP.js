$.ajax({
type: "get",
dataType: "jsonp",
jsonpCallback: "callback",
url: "https://sso.31huiyi.com/ssouser/GetSSOUserByJSONP",
data:"jsoncallback=callback",
success: function (json) {ssoUserCallback(json)},
error: function (e) {console.log(e)}
});