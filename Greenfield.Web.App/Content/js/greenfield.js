(function (document, greenfield, $) {
    "use strict";
    $(document).on('click', 'input[type=text]', function () { this.select(); });

    greenfield.progressbar = (function () {
        // Setup 
        var dom = $(document.getElementById("global-progress-bar")).progressbar();

        // Set Progress
        var progress = function (value) {
            dom.progressbar("value", value);

            // It isnt a JS Lib if it isnt buggy
            // Hack to see if it really resized the DOM
            setTimeout(function () {
                if (dom.children()[0].style.width !== (value + "%")) {
                    dom.progressbar("value", value); // if not, set it again
                }
            }, 600);
        }

        var finish = function () {
            progress(100);

            // Reset it after 1s
            setTimeout(function () {
                progress(0);
            }, 1000);
        }

        var fail = function () {
            dom.progressbar("color", "#a20025");
            progress(100);

            // Reset it after 1s
            setTimeout(function () {
                progress(0);
                dom.progressbar("color", "#1BA1E2");
            }, 2000);
        }

        return {
            progress: progress,
            finish: finish,
            fail: fail
        };

    }());

    window.greenfield = greenfield;

}(document, window.greenfield || {}, $));
