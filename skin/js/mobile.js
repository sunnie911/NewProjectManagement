var uaTest = /Android|webOS|Windows Phone|iPhone|ucweb|ucbrowser|iPod|BlackBerry/i.test(navigator.userAgent.toLowerCase());
var touchTest = 'ontouchend' in document;
if(uaTest && touchTest){
    window.location.href='/m';
}