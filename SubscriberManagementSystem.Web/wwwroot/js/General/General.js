var serializeArrayToObject = function (form) {
    var array = $("#" + form).serializeArray();
    function assignByPath(obj, path, value) {
        if (path.length == 1) {
            obj[path[0]] = value;
            return obj;
        } else if (obj[path[0]] === undefined) {
            obj[path[0]] = {};
        }
        return assignByPath(obj[path.shift()], path, value);
    }

    var obj = {};

    $.each(array, function (i, o) {
        var n = o.name,
            v = o.value;
        path = n.replace('[', '.').replace('][', '.').replace(']', '').split('.');

        assignByPath(obj, path, v);
    });

    return JSON.stringify(obj);
};

var saveOrUpdate = function (url, data, form) {
    return new Promise(function (resolve, reject) {
        $.ajax({
            url: url,
            type: 'POST',
            data: data,
            success: function (result) {
                // Clear validation messages
                form.find(".validation").empty().removeClass("d-block").addClass("d-none");

                if (result.success) {
                    toastr.success(Messages.AlertMessage, result.message);
                    resolve(result);
                } else {
                    showValidationErrors(form, result.message);
                    reject(result);
                }
            },
            error: function (xhr, status, error) {
                reject(error);
            }
        });
    });
};

var showValidationErrors = function (form, message) {
    var errorHtml = "<div class='p-3'>" + message + "</div>";
    var closeBtn = `
        <button type="button" class="close-btn btn btn-icon ms-sm-auto position-absolute position-sm-relative m-2 m-sm-0 top-0 end-0 btn btn-icon ms-sm-auto">
            <i class="bi bi-x fs-1 text-danger"></i>
        </button>`;

    form.find(".validation").html(errorHtml + closeBtn).removeClass("d-none").addClass("d-block");

    // Attach close button event
    $(".close-btn").off("click").click(function () {
        form.find(".validation").removeClass("d-block").addClass("d-none");
    });
};


var deleteFunction = function (url) {
    return new Promise(function (resolve, reject) {
        Swal.fire({
            html: '<h4>' + Messages.DeleteConfirmation + '</h4>',
            icon: "warning",
            buttonsStyling: false,
            showCancelButton: true,
            confirmButtonText: Messages.Delete,
            cancelButtonText: Messages.Cancel,
            customClass: {
                confirmButton: "btn btn-warning",
                cancelButton: 'btn btn-secondary'
            },
            preConfirm: (login) => {
                $.ajax({
                    url: url,
                    type: 'DELETE',
                    success: function (result) {
                        if (result.success)
                            toastr.success(Messages.AlertMessage, result.message);
                        else
                            toastr.error(Messages.AlertMessage, result.message);
                    
                        resolve();
                    },
                    error: function (error) {
                        reject(error);
                    }
                });
            }
        });
    });
};

// general upload image
var uploadImage = function (fileInput, uploadURL, folderName, hiddenField) {
    // Create BlockUI instance
    var blockUI = new KTBlockUI(document.querySelector(".block_ui"));

    var flag = true;
    $('#' + fileInput).off('change').change(function () {
        if (flag == true) {

            flag = false;
            const imageInput = document.getElementById(fileInput);
            var my_file = imageInput.files[0];

            const size = my_file ? parseInt(my_file.size / 1024) : 0;

            var file = $(this).val();
            var extension = file.substr((file.lastIndexOf('.') + 1)).toLowerCase();

            var type = false;
            if (['jpg', 'jpeg', 'png', 'gif', 'bmp'].includes(extension))
                type = true;

            if (size <= Messages.acceptFileSize && type == true) {
                // Block UI before sending the request
                blockUI.block();

                var formData = new FormData();
                formData.append("file", my_file);
                formData.append("folderName", folderName);

                $.ajax({
                    url: uploadURL,
                    type: 'POST',
                    data: formData,
                    cache: false,
                    contentType: false,
                    processData: false,
                    success: function (data) {
                        flag = true;
                        $(".validation").text("");
                        $(".validation").removeClass("d-block").addClass("d-none");

                        blockUI.release();

                        $(hiddenField).val(data.fileName);
                        $("#img").attr("src", "/Images/" + data.fileName);
                    },
                    error: function () {
                        flag = true;
                        blockUI.release();
                    }
                });
            } else {
                flag = true;
                var message = "";
                if (size > Messages.acceptFileSize) {
                    message = Messages.ImageSizeError;
                }
                else if (type == false && size > 0) {
                    message = Messages.InvalidImageType;
                } else {
                    message = Messages.SelectImageFaild;
                }

                var error = "<div>" + message + "</div>";
                $(".validation").text("").append(error);
                $(".validation").removeClass("d-none").addClass("d-block");

                $(`#${fileInput}`).val("");
                $(hiddenField).val("");
                $("#img").addClass("d-none");
            }
        };
    });
}

var uploadImage = function (fileInput, uploadURL, folderName, hiddenField, oldFileNameField) {
    var blockUI = new KTBlockUI(document.querySelector(".block_ui"));

    var flag = true;
    $('#' + fileInput).off('change').change(function () {
        if (flag == true) {
            flag = false;
            const imageInput = document.getElementById(fileInput);
            var my_file = imageInput.files[0];

            const size = my_file ? parseInt(my_file.size / 1024) : 0;

            var file = $(this).val();
            var extension = file.substr((file.lastIndexOf('.') + 1)).toLowerCase();

            var type = false;
            if (['jpg', 'jpeg', 'png', 'gif', 'bmp'].includes(extension))
                type = true;

            if (size <= Messages.acceptFileSize && type == true) {
                blockUI.block();

                var formData = new FormData();
                formData.append("file", my_file);
                formData.append("folderName", folderName);

                if (oldFileNameField) {
                    formData.append("oldFileName", $(oldFileNameField).val());
                }

                $.ajax({
                    url: uploadURL,
                    type: 'POST',
                    data: formData,
                    cache: false,
                    contentType: false,
                    processData: false,
                    success: function (data) {
                        flag = true;
                        $(".validation").text("");
                        $(".validation").removeClass("d-block").addClass("d-none");

                        blockUI.release();

                        $(hiddenField).val(data.fileName);
                        $("#img").attr("src", "/Images/" + data.fileName);
                    },
                    error: function () {
                        flag = true;
                        blockUI.release();
                    }
                });
            } else {
                flag = true;
                var message = "";
                if (size > Messages.acceptFileSize) {
                    message = Messages.ImageSizeError;
                }
                else if (type == false && size > 0) {
                    message = Messages.InvalidImageType;
                } else {
                    message = Messages.SelectImageFaild;
                }

                var error = "<div>" + message + "</div>";
                $(".validation").text("").append(error);
                $(".validation").removeClass("d-none").addClass("d-block");

                $(`#${fileInput}`).val("");
                $(hiddenField).val("");
                $("#img").addClass("d-none");
            }
        };
    });
}


//  upload Attachment
var uploadAttachment = function (fileInput, uploadURL, folderName, hiddenName, hiddenIcon) {
    var flag = true;

    // Create BlockUI instance
    var blockUI = new KTBlockUI(document.querySelector(".block_ui"));

    $('#' + fileInput).off('change').change(function () {
        if (flag == true) {
            flag = false;
            const fileInputElem = document.getElementById(fileInput);
            var my_file = fileInputElem.files[0];

            const size = my_file ? parseInt(my_file.size / 1024) : 0;

            const file = $(this).val();
            const extension = file.substr((file.lastIndexOf('.') + 1)).toLowerCase();

            let icon = "doc.svg";
            if (['jpg', 'jpeg', 'png', 'gif', 'bmp'].includes(extension)) {
                icon = "blank-image.svg";
            } else if (extension === 'pdf') {
                icon = "pdf.svg";
            }

            if (size <= Messages.acceptFileSize) { 
                // Block UI before sending the request
                blockUI.block();

                var formData = new FormData();
                formData.append("file", my_file);
                formData.append("folderName", folderName);

                $.ajax({
                    url: uploadURL,
                    type: 'POST',
                    data: formData,
                    cache: false,
                    contentType: false,
                    processData: false,
                    success: function (data) {
                        flag = true;
                        $(".validation").text("");
                        $(".validation").removeClass("d-block").addClass("d-none");

                        $(hiddenName).val(data.fileName);
                        $(hiddenIcon).val(icon);

                        blockUI.release();

                        $("#img").attr("src", "/assets/media/svg/files/" + icon);
                        $("#AttachmentDiv").removeClass("d-none");
                    },
                    error: function () {
                        flag = true;
                        blockUI.release();
                    }
                });
            } else {
                flag = true;
                $(hiddenName).val("");
                $(`#${fileInput}`).val("");
                $("#AttachmentDiv").addClass("d-none");

                const message = size > Messages.acceptFileSize
                    ? Messages.FileSizeError
                    : Messages.SelectFileFaild;

                const error = "<div>" + message + "</div>";
                $(".validation").text("").append(error);
                $(".validation").removeClass("d-none").addClass("d-block");
            }
        }
    });
}

var general = function () {

    // menu Search
    var menuSearch = function () {
        $("#inputMenuSearch").off("keyup").on("keyup", function () {
            var filter = $(this).val().trim().toLowerCase();

            $('.sidebar-menu-item').each(function () {
                var menuItemText = $(this).text().trim().toLowerCase();

                if (menuItemText.includes(filter)) {
                    $(this).show();
                    $(this).closest('div.menu-accordion').show();
                    $(this).closest('div.menu-sub').addClass("show");
                } else {
                    $(this).hide();
                    $(this).closest('div.menu-sub').removeClass("show");
                }
            });

            if (filter === "") {
                $('div.menu-accordion').each(function () {
                    $(this).find('div.menu-sub').removeClass("show");
                });
            }
        });
    }

    // get active item and give class show for pearant item 
    var showItemMenuHasActive  = function () {
        document.addEventListener('DOMContentLoaded', function () {
            const activeMenuLink = document.querySelector('.menu-link.active');

            if (activeMenuLink) {
                let parentAccordion = activeMenuLink.closest('.menu-accordion');
                while (parentAccordion) {
                    parentAccordion.classList.add('show');
                    parentAccordion = parentAccordion.parentElement.closest('.menu-accordion');
                }
            }
        });
    }

    // open myProfile modal
    var myProfileModal = function () {
        $("#myProfileModal").off("click").click(function () {

            $.ajax({
                url: `/User/MyProfileModal`,
                type: 'GET',
                success: function (result) {
                    $('#modal .modal-content').html(result);
                    $('#modal').modal('show');
                    $('#modal').on('shown.bs.modal', function () {
                        $('input[type="text"]:first', this).focus();
                    });
                    KTApp.init(); // to init all functions including select2

                    uploadImage('UploadAvatar', '/File/UploadFile', 'Images', "input[name='Avatar']", "input[name='OldAvatar']");

                    submitMyProfileForm();
                }
            });
        });
    }

    // submit MyProfile Form
    var submitMyProfileForm = function () {
        $("#myProfileForm").on("submit", function (e) {
            e.preventDefault();
            const form = $(this);

            const data = form.serialize();

            saveOrUpdate(`/User/MyProfile`, data, form)
                .then(function (result) {
                    if (result.isNameChanged) {
                        $("#userName").text(result.newName);
                    }

                    if (result.isAvatarChanged) {
                        $(".userAvatarUrl").attr("src", `/Images/${result.newAvatar}`);
                    }
                })
                .catch(function () {
                    return;
                });
        });
    }
    

    // email Changed function
    var emailChanged = function () {
        $.ajax({
            url: '/Auth/EmailChanged',
            type: 'GET',
            success: function () {
                window.location.href = '/Auth/EmailChanged';
            },
            error: function () {
                return;
            }
        });
    };

    // open  change Password modal
    var changePasswordModal = function () {
        $("#changePasswordModal").off("click").click(function () {

            $.ajax({
                url: `/User/ChangePasswordModal`,
                type: 'GET',
                success: function (result) {
                    $('#modal .modal-content').html(result);
                    $('#modal').modal('show');
                    $('#modal').on('shown.bs.modal', function () {
                        $('input[type="text"]:first', this).focus();
                    });

                    submitChangePasswordForm();
                }
            });
        });
    }

    // submit Change Password Form
    var submitChangePasswordForm = function () {
        $("#changePasswordForm").on("submit", function (e) {
            e.preventDefault();
            const form = $(this);

            const data = form.serialize();

            saveOrUpdate(`/User/ChangePassword`, data, form)
                .then(function () {
                    //$('#modal').modal('hide');
                })
                .catch(function () {
                    return;
                });
        });
    }

    var shortcutsModal = function () {
        $("#btnshortcutsModal").off("click").click(function () {
            $('#shortcutsModal').modal('show');
        });
    }

    //********** HotKeys keyboard shortcuts ***************

    // shortcuts F1 => f1
    var hk_f1 = function () {
        hotkeys('f1', function (event) {
            event.preventDefault();
            $('#btnshortcutsModal').click();
        });
    }

    // close widnow => Esc
    var hk_esc = function () {
        hotkeys('Esc', function () {

        });
    }

    // add => +
    var hk_add = function () {
        hotkeys('num_add', function () {
            $('.btnAdd').click();
        });
    }

    // search => ctrl+f
    var hk_search = function () {
        hotkeys('ctrl+f', function (event) {
            event.preventDefault();
            $('#searchInput').focus();
        });
    }

    // up
    var hk_up = function () {
        hotkeys('ctrl+up', function (event, handler) {
            alert('press ctrl + up');
        });
    }

    return {
        init: function () {
            menuSearch();
            showItemMenuHasActive();

            myProfileModal();
            changePasswordModal();

            shortcutsModal();
            hk_f1();
            //hk_esc();
            hk_add();
            hk_search();
            hk_up();

        }
    }
}();

general.init();