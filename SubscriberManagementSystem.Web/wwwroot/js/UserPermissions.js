var userPermissions = function () {

    var savePermissions = function (userTypeId, selectedPages) {
        var permissions = [];
        selectedPages.forEach(function (pageId) {
            permissions.push({
                UserTypeId: userTypeId,
                PageId: pageId
            });
        });

        $.ajax({
            url: '/UserPermission/SavePermissions',
            type: 'POST',
            data: { "userTypeId": userTypeId, "permissions": permissions },
            success: function (result) {
                if (result.success) {
                    toastr.success(Messages.AlertMessage, result.message);
                } else {
                    toastr.error(Messages.AlertMessage, result.message);
                }
            }
        });
    };

    var loadPermissions = function (userTypeId) {
        $.ajax({
            type: "POST",
            url: "/UserPermission/GetUserTypePermissions",
            data: { userTypeId: userTypeId },
            success: function (data) {

                // Uncheck all checkboxes first
                $(".cbMP, .cbML, .cbChiled").prop("checked", false);

                $.each(data, function (index, permissionId) {
                    var checkboxSelector = "[data-page-id='" + permissionId + "']";
                    $(checkboxSelector).prop("checked", true);
                });
            }
        });
    };


    var handleUserTypeChange = function () {
        $('#userTypeSelect').change(function () {
            var selectedUserTypeId = parseInt($(this).val());
            loadPermissions(selectedUserTypeId);
        });
    };

    var handleSaveButtonClick = function () {
        $('.btnSubmit').click(function () {
            var selectedUserTypeId = parseInt($('#userTypeSelect').val());
            if (isNaN(selectedUserTypeId) || selectedUserTypeId === 0) {
                toastr.warning(Messages.AlertMessage, Messages.InvalidSelectUserType);
                return;
            }

            var selectedPages = [];

            $(".cbMP:checked, .cbML:checked, .cbChiled:checked").each(function () {
                selectedPages.push($(this).data("page-id"));
            });

            savePermissions(selectedUserTypeId, selectedPages);
        });
    };


    var handleCheckboxes = function () {
        $(".cbMP").click(function () {
            var parent = $(this);
            var pName = $(parent).attr("child");
            if ($(parent).prop("checked")) {
                $(pName).find("input[type=checkbox]").prop("checked", true);
            } else {
                $(pName).find("input[type=checkbox]").prop("checked", false);
            }
        });

        $(".cbML").click(function () {
            var parent = $(this);
            var pName = $(parent).attr("child");
            if ($(parent).prop("checked")) {
                $(pName).find("input[type=checkbox]").prop("checked", true);
            } else {
                $(pName).find("input[type=checkbox]").prop("checked", false);
            }

            var father = $(this).closest(".panel").find(".cbMP");
            if ($(this).prop("checked")) {
                if (!$(father).prop("checked")) {
                    $(father).prop("checked", "true");
                }
            }
        });

        $(".cbChiled").off('click').click(function () {
            var father = $(this).closest(".mainList").find(".cbML");
            var grandFather = $(father).closest(".panel").find(".cbMP");

            if ($(this).prop("checked")) {
                if (!$(father).prop("checked")) {
                    $(father).prop("checked", true);
                }
                if (!$(grandFather).prop("checked")) {
                    $(grandFather).prop("checked", true);
                }
            }
        });
    }

    return {
        init: function () {
            handleSaveButtonClick();
            handleUserTypeChange();
            handleCheckboxes();
        }
    };
}();
