var page = require('webpage').create();
page.open('http://dnes.dir.bg/news/universitet-%D0%A0umen-%D0%A0adev-prezidentat-radev-26371621?nt=4', function(status) {
  console.log("Status: " + status);
  if(status === "success") {
    page.render('example.pdf');
  }
  phantom.exit();
});