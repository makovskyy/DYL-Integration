﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    static class JavaScripts
    {
        public static string AlertBlocker =
                @" window.confirm=function () { return true; }; window.close=function () { };";

        public static string OnbeforeunloadBlocker = @"(function () {
            var onbeforeunloadHandler = function (ev) {
                if (ev) {
                    if (ev.stopPropagation)
                        ev.stopPropagation();
                    if (ev.stopImmediatePropagation)
                        ev.stopImmediatePropagation();
                    ev.returnValue = undefined;
                }
                window.event.returnValue = undefined;
            }

            var handler = null;
            var intervalHandler = function () {
                if (handler)
                    window.detachEvent(""onbeforeunload"", onbeforeunloadHandler);          
            handler = window.attachEvent(""onbeforeunload"", onbeforeunloadHandler);          
        };

        window.setInterval(intervalHandler, 100);
        intervalHandler();
    })();";

        public static string ReplaceIFrameContent = @"
var replaceIFrameContent = function () {
    var handler = function () {
        try {           
            var iframe = document.getElementById('ifBdy');
            if (iframe)
                iframe.onload = function () {

                };

            var _oIfBdy =  Owa.UIControls.SubPage.get_Instance()._getDescendant('ifBdy');
            if (!_oIfBdy) 
                return;
           
            var doc = _oIfBdy.get_ContentDocument();
            if (!doc)
                return;

            doc.open();
            doc.write('<html><body>Hello Hello</body></html>');
            doc.close();
            
            clearInterval(interval);
        }
        catch (e) {
            window.alert(e);
        }
    }
    var interval = setInterval(handler, 200);
};";
    }
}
