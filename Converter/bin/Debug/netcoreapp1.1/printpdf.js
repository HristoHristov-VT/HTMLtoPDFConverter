

var system = require('system');
var args = system.args;


var page = require('webpage').create();
//viewportSize being the actual size of the headless browser
page.viewportSize = { width: system.args[3], height: system.args[4] };
//the clipRect is the portion of the page you are taking a screenshot of
page.clipRect = { top: 0, left: 0, width: system.args[3], height: system.args[4] };
//the rest of the code is the same as the previous example
page.paperSize = { format: system.args[5], orientation: system.args[6], border: '1cm' };
page.zoomFactor = 1;
page.open(system.args[1], function () {
    page.render(system.args[2]);
    phantom.exit();
});



