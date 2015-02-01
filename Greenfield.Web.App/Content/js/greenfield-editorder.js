(function (document, greenfield, $, model, ko) {
    "use strict";

    greenfield.editorder = (function () {
        // Submit OK
        var saveOrderSuccess = function (response, textStatus, jqXhr) {
            console.log(response);
            greenfield.progressbar.finish();

            $.Notify({
                caption: "Order Saved",
                content: "Article Number: " + response.id,
                timeout: 5000
            });
        }

        // Submit Fail
        var saveOrderFail = function (response, textStatus, jqXhr) {
            console.log(response);
            greenfield.progressbar.fail();

            $.Notify({
                style: { background: "red", color: "white"},
                caption: "Oops!",
                content: "Something went wrong... Could not save document: " + textStatus,
                timeout: 10000
            });
        }

        //// Edit Article
        var saveArticle = function (e) {
            if (e.preventDefault) e.preventDefault();

            greenfield.progressbar.progress(20);
            var formjq = $(this);
            var json = ko.toJSON(model);
            formjq.find(":input").prop("disabled", true);
            $.ajax("/api/salesorders", {
                cache: false,
                contentType: "application/json",
                dataType: "json",
                data: json,
                type: "POST",
                success: saveOrderSuccess,
                error: saveOrderFail
            })
            .always(function () {
                formjq.find(":input").prop("disabled", false);
            });

            return false;
        }
        // Setup Listener On Save Link
        var form = document.getElementById("edit-order-form");
        if (form.attachEvent) {
            form.attachEvent("submit", saveArticle);
        } else {
            form.addEventListener("submit", saveArticle);
        }
        console.log("Greenfield Order Logic Successfully Loaded");
    }());

    window.greenfield = greenfield;

}(document, window.greenfield || {}, $, model, ko));