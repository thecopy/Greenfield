(function (document, greenfield, $) {
    "use strict";

    greenfield.inventory = (function () {
        //// Save Article

        // Submit OK
        var saveNewArticleSuccess = function (response, textStatus, jqXhr) {
            console.log(response);
            greenfield.progressbar.finish();

            $.Notify({
                caption: "New Article Saved",
                content: "Article Number: " + response.id,
                timeout: 10000 
            });
        }

        // On Submit
        var saveNewArticle = function (e) {
            if (e.preventDefault) e.preventDefault();

            greenfield.progressbar.progress(20);

            var formjq = $(this);
            var formData = $(this).serializeObject();
            var json = JSON.stringify(formData);
            formjq.find(":input").prop("disabled", true);
            $.ajax("/api/articles", {
                cache: false,
                contentType: "application/json",
                dataType: "json",
                data: json,
                type: "POST",
                success: saveNewArticleSuccess
            })
            .always(function () {
                formjq.find(":input").prop("disabled", false);
            });

            return false;
        }

        // Setup Listener
        var form = document.getElementById("edit-article-form");
        if (form.attachEvent) {
            form.attachEvent("submit", saveNewArticle);
        } else {
            form.addEventListener("submit", saveNewArticle);
        }
    }());

    window.greenfield = greenfield;

}(document, window.greenfield || {}, $));