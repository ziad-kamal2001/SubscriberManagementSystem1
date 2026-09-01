var users = function () {
    const controller = 'User';
    var dt;


    var initDataTable = function () {
        dt = $('#Users').DataTable({
            processing: true,
            serverSide: true,
            autoWidth: false,
            ajax: {
                url: `/${controller}/GetAll`,
                type: "POST",
                datatype: "json",
                data: { "search[value]": serializeArrayToObject("SearchForm") }
            },
            order: [[2, 'asc']],
            columnDefs: [{
                targets: [0],
                visible: true,
                searchable: false
            }],
            columns: [
                {
                    width: "5%",
                    render: function (data, type, row, meta) {
                        return meta.settings._iDisplayStart + meta.row + 1;
                    },
                    orderable: false
                },
                {
                    width: "13%",
                    render: function (data, type, row) {
                        var img = "default_avatar.png";
                        if (row.avatar)
                            img = row.avatar;

                        return `<img class="image-input image-input-circle" width="45" src="/Images/` + img + `"/>`
                    },
                    orderable: false
                },
                { data: "name", name: "Name", autowidth: true },
                { data: "email", name: "Email", autowidth: true },
                { data: "phoneNumber", name: "PhoneNumber", autowidth: true },
                { data: "gender.name", name: "name", autowidth: true },
                { data: "userType.name", name: "name", autowidth: true },
                { 
                    data: "isActive", name: "isActive",
                    autowidth: true,
                    render: function (data, type, row) {
                        return row.isActive ? `<u class="text-success">${Messages.Active}</u>` : `<u class="text-danger">${Messages.Inactive}</u>`;
                    }
                },
                {
                    width: "6%",
                    render: function (data, type, row) {
                        return `<div class="dropdown">
                                    <button class="btn btn-secondary btn-icon btn-sm" type="button" id="dropdownActions" data-bs-toggle="dropdown" aria-expanded="false">
                                        <i class="bi bi-gear-fill fs-5"></i>
                                    </button>
                                    <ul class="dropdown-menu fs-4" aria-labelledby="dropdownActions">
                                        <li><a class="dropdown-item btn btnEdit" element-id="${row.id}"><i class="bi bi-pencil-square"></i>${Messages.Edit}</a></li>
                                        <li><a class="dropdown-item btn btnDelete" element-id="${row.id}"><i class="bi bi-trash-fill"></i>${Messages.Delete}</a></li>
                                    </ul>
                                </div>`
                    },
                    orderable: false
                }
            ],
            rowCallback: function (row, data, index) {
                $(row).on('dblclick', function () {
                    getModal(data.id);
                });
            },
            language: Language
        });

        dt.on('draw', function () {
            deleteElement();
            openModal();
        });
    }

    // delete function
    var deleteElement = function () {
        $(".btnDelete").off("click").click(function () {
            const elementId = $(this).attr("element-id");

            deleteFunction(`/${controller}/Delete/${elementId}`)
            .then(function () {
                dt.destroy();
                initDataTable();
            });
        });
    };

    // open create or edit modal
    var openModal = function () {
        $(".openModal, .btnEdit").off("click").click(function () {
            const elementId = $(this).attr("element-id") || 0;

            getModal(elementId);
        });
    }

    // get modal
    var getModal = function (elementId) {
        $.ajax({
            url: `/${controller}/CreateEditModal/${elementId}`,
            type: 'GET',
            success: function (result) {
                $('#modal .modal-content').html(result);
                $('#modal').modal('show');
                $('#modal').on('shown.bs.modal', function () {
                    $('input[type="text"]:first', this).focus();
                });
                KTApp.init(); // to init all functions including select2

                uploadImage('UploadAvatar', '/File/UploadFile', 'Images', "input[name='Avatar']", "input[name='OldAvatar']");
                submitForm();
            }
        });
    }

    // submit form to create or edit
    var submitForm = function () {
        $("#form").on("submit", function (e) {
            e.preventDefault();
            const form = $(this);

            const data = form.serialize();
            
            saveOrUpdate(`/${controller}/CreateEdit/`, data, form)
            .then(function (result) {
                if (result.isNameChanged) {
                    $("#userName").text(result.newName);
                }

                if (result.isAvatarChanged) {
                    $(".userAvatarUrl").attr("src", `/Images/${result.newAvatar}`);
                }

                $('#modal').modal('hide');
                dt.destroy();
                initDataTable();
            })
            .catch(function () {
                return;     
            });
        });
    }

    var searchForm = function () {
        $(".btnSearch").off("click").click(function () {
            dt.destroy();
            initDataTable();
        });
    };

    return {
        init: function () {
            initDataTable();
            searchForm();
            openModal();          

        }
    }
}();