var auth = function () {
    var loginForm = function () {
        $("#loginForm").on("submit", function (e) {
            e.preventDefault();
            const form = $(this);
            const data = form.serialize();

            $.ajax({
                url: '/Auth/Login',
                type: 'POST',
                data: data,
                success: function (result) {
                    clearValidationMessages(form);

                    if (result.success) {
                        // Redirect to the URL provided in the result message
                        window.location.href = result.message;
                    } else {
                        showValidationError(form, result.message);
                    }
                },
                error: function (xhr, status, error) {
                    showValidationError(form, "An error occurred. Please try again.");
                    console.error("Login error:", status, error);
                }
            });
        });
    };

    // Helper to clear validation messages
    var clearValidationMessages = function (form) {
        form.find(".validation").empty().removeClass("d-block").addClass("d-none");
    };

    // Helper to display validation error
    var showValidationError = function (form, message) {
        const errorHtml = `<div class='p-3'>${message}</div>`;
        const closeBtn = `
            <button type="button" class="close-btn btn btn-icon ms-sm-auto position-absolute position-sm-relative m-2 m-sm-0 top-0 end-0 btn btn-icon ms-sm-auto">
                <i class="bi bi-x fs-1 text-danger"></i>
            </button>`;
        form.find(".validation").html(errorHtml + closeBtn).removeClass("d-none").addClass("d-block");

        // Attach close button event once using event delegation
        form.find(".validation").on("click", ".close-btn", function () {
            form.find(".validation").removeClass("d-block").addClass("d-none");
        });
    };

    return {
        init: function () {
            loginForm();
        }
    };
}();
