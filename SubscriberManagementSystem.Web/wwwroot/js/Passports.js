//var passports = function () {
//    const controller = 'Passport';
//    var dt;

//    var initDataTable = function () {
//        dt = $('#Passports').DataTable({
//            processing: true,
//            serverSide: true,
//            autoWidth: false,
//            ajax: {
//                url: `/${controller}/GetAll`,
//                type: "POST",
//                datatype: "json",
//                data: { "search[value]": serializeArrayToObject("SearchForm") }
//            },
//            order: [[2, 'asc']],
//            columnDefs: [{
//                targets: [0],
//                visible: true,
//                searchable: false
//            }],
//            columns: [
//                {
//                    width: "5%", orderable: false,
//                    render: function (data, type, row, meta) {
//                        return meta.settings._iDisplayStart + meta.row + 1;
//                    }
//                },
//                { data: "beneficiary.fullName", name: "beneficiary.fullName", autowidth: true, orderable: false },
//                { data: "passportNumber", name: "PassportNumber", autowidth: true },
//                {
//                    data: "nationality", name: "nationality", autowidth: true,
//                    render: function (data, type, row) {
//                        const lang = $("html").attr("lang");
//                        return lang === "ar" ? data.nameAr : data.nameEn;
//                    }
//                },
//                {data: "type.name", name: "type.name", autowidth: true},
//                {
//                    data: "issueDate",name: "IssueDate",autowidth: true,
//                    render: function (data, type, row) {
//                        if (data) {
//                            return '<span>' + data.split('T')[0] + '</span>';
//                        }
//                        return '';
//                    }
//                },
//                {
//                    data: "expiryDate",name: "ExpiryDate",autowidth: true,
//                    render: function (data, type, row) {
//                        if (data) {
//                            return '<span>' + data.split('T')[0] + '</span>';
//                        }
//                        return '';
//                    }
//                },
//                {
//                    data: "isActive", name: "isActive",
//                    autowidth: true,
//                    render: function (data, type, row) {
//                        return data ? `<u class="text-success">${Messages.Active}</u>` : `<u class="text-danger">${Messages.Expired}</u>`;
//                    }
//                }
//            ],
//            language: Language
//        });

//        dt.on('draw', function () {
//            deleteElement();
//            editElement();
//        });
//    }

//    // delete function
//    var deleteElement = function () {
//        $(".btnDelete").off("click").click(function () {
//            const elementId = $(this).attr("element-id");

//            deleteFunction(`/${controller}/Delete/${elementId}`)
//            .then(function () {
//                dt.destroy();
//                initDataTable();
//            });
//        });
//    };

//    // create or edit
//    var editElement = function () {
//        $(".btnEdit").off("click").click(function () {
//            const elementId = $(this).attr("element-id") || 0;

//            window.open(`${window.location.href}/CreateEdit/${elementId}`, '_blank');
//        });
//    }

//    // search function
//    var searchForm = function () {
//        $(".btnSearch").off("click").click(function () {
//            dt.destroy();
//            initDataTable();
//        });
//    };


//    return {
//        init: function () {
//            initDataTable();
//            searchForm();
//        }
//    }
//}();