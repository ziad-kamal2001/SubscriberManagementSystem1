var beneficiaries = function () {

    // beneficiaries functions
    var dtBeneficiaries;
    var initBeneficiariesDataTable = function () {
        dtBeneficiaries = $('#Beneficiaries').DataTable({
            processing: true,
            serverSide: true,
            autoWidth: false,
            ajax: {
                url: `/Beneficiary/GetAll`,
                type: "POST",
                datatype: "json",
                data: { "search[value]": serializeArrayToObject("SearchForm") }
            },
            //order: [[2, 'asc']],
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
                { data: "fullName", name: "fullName", autowidth: true, orderable: false, orderable: false },
                { data: "beneficiaryType.name", name: "beneficiaryType.name", autowidth: true},
                { data: "iDNumber", name: "IDNumber", autowidth: true, orderable: false },
                { data: "phoneNumber", name: "PhoneNumber", autowidth: true, orderable: false }, 
                { data: "dOB", name: "DOB", autowidth: true, orderable: false },
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
                                        <i class="bi bi-gear-fill fs-4"></i>
                                    </button>
                                    <ul class="dropdown-menu fs-4" aria-labelledby="dropdownActions">
                                        <li><a class="dropdown-item btn btnEditBeneficiary" element-id="${row.id}"><i class="bi bi-pencil-square"></i>${Messages.Edit}</a></li>
                                        <li><a class="dropdown-item btn btnDelete" element-id="${row.id}"><i class="bi bi-trash-fill"></i>${Messages.Delete}</a></li>
                                    </ul>
                                </div>`
                    },
                    orderable: false
                }
            ],
            rowCallback: function (row, data, index) {
                $(row).on('dblclick', function () {

                    var baseUrl = window.location.href;
                    if (baseUrl.toLowerCase().includes("index")) {
                        baseUrl = baseUrl.substring(0, baseUrl.lastIndexOf('/'));
                    }

                    window.open(`${baseUrl}/CreateEdit/${data.id}`, '_blank');
                });
            },
            language: Language
        });

        dtBeneficiaries.on('draw', function () {
            deleteBeneficiary();
            createEditBeneficiaryt();
        });
    }

    // delete Beneficiary function
    var deleteBeneficiary = function () {
        $(".btnDelete").off("click").click(function () {
            const elementId = $(this).attr("element-id");

            deleteFunction(`/Beneficiary/Delete/${elementId}`)
            .then(function () {
                dtBeneficiaries.destroy();
                initBeneficiariesDataTable();
            });
        });
    };

    // create or edit Beneficiary
    var createEditBeneficiaryt = function () {
        $(".btnAdd, .btnEditBeneficiary").off("click").click(function () {
            const elementId = $(this).attr("element-id") || 0;

            var baseUrl = window.location.href;

            if (baseUrl.toLowerCase().includes("index")) {
                baseUrl = baseUrl.substring(0, baseUrl.lastIndexOf('/'));
            }

            window.open(`${baseUrl}/CreateEdit/${elementId}`, '_blank');
        });
    }

    // submit create or edit Beneficiary form
    var submitBeneficiaryForm = function () {
        $("#createEditForm").on("submit", function (e) {
            e.preventDefault();
            const form = $(this);
            var beneficiaryId = form.find('[name="Id"]').val();
            const data = form.serialize();

            saveOrUpdate(`/Beneficiary/SubmitCreateEdit/`, data, form)
                .then(function (result) {
                    if (!beneficiaryId || beneficiaryId == 0) {
                        setTimeout(function () {
                            window.open(`${window.location.origin}/Beneficiary/CreateEdit/${result.returnId}`, '_self');
                        }, 500);
                    } else {
                        const isRelative = form.find('[name="ParentId"]').val();
                        if (isRelative) {
                            $(".span-title").text(`${Messages.RelativeData} : ${form.find('[name="FName"]').val()} ${form.find('[name="SName"]').val()} ${form.find('[name="TName"]').val()} ${form.find('[name="LName"]').val()}`);
                        }else {
                            $(".span-title").text(`${Messages.BeneficiaryData} : ${form.find('[name="FName"]').val()} ${form.find('[name="SName"]').val()} ${form.find('[name="TName"]').val()} ${form.find('[name="LName"]').val()}`);
                        }
                    }
                })
                .catch(function () {
                    return;
                });
        });
    }

    // search Beneficiary function
    var searchBeneficiaryForm = function () {
        $(".btnSearch").off("click").click(function () {
            dtBeneficiaries.destroy();
            initBeneficiariesDataTable();
        });
    };


    // Relatives functions
    var dtRelatives;
    var initRelativesDataTable = function () {
        dtRelatives = $('#Relatives').DataTable({
            processing: true,
            serverSide: true,
            autoWidth: false,
            ajax: {
                url: `/Beneficiary/GetAll`,
                type: "POST",
                datatype: "json",
                data: { "search[value]": serializeArrayToObject("relativeSearchForm") }
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
                { data: "fullName", name: "fullName", autowidth: true, orderable: false },
                {
                    data: "kinship.name", name: "kinship.name", autowidth: true,
                    render: function (data, type, row) {
                        if (data) {
                            return data;
                        }
                        return '';
                    }
                },
                {
                    data: "dob",
                    name: "dob",
                    autowidth: true,
                    render: function (data, type, row) {
                        if (data) {
                            return '<span>' + data.split('T')[0] + '</span>';
                        }
                        return '';
                    }
                },
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
                                        <i class="bi bi-gear-fill fs-4"></i>
                                    </button>
                                    <ul class="dropdown-menu fs-4" aria-labelledby="dropdownActions">
                                        <li><a class="dropdown-item btn btnEditRelative" element-id="${row.id}"><i class="bi bi-pencil-square"></i>${Messages.Edit}</a></li>
                                        <li><a class="dropdown-item btn btnDeleteRelative" element-id="${row.id}"><i class="bi bi-trash-fill"></i>${Messages.Delete}</a></li>
                                    </ul>
                                </div>`
                    },
                    orderable: false
                }
            ],
            rowCallback: function (row, data, index) {
                $(row).on('dblclick', function () {

                    var parentId = $("#beneficiaryId").val();
                    window.open(`${window.location.origin}/Beneficiary/CreateEdit?id=${data.id}&parentId=${parentId}`);
                });
            },
            language: Language
        });

        dtRelatives.on('draw', function () {
            deleteRelative();
            createEditRelative();
        });
    }

    // delete Relative function
    var deleteRelative = function () {
        $(".btnDeleteRelative").off("click").click(function () {
            const elementId = $(this).attr("element-id");

            deleteFunction(`/Beneficiary/Delete/${elementId}`)
                .then(function () {
                    dtRelatives.destroy();
                    initRelativesDataTable();
                });
        });
    };

    // create or edit Relative
    var createEditRelative = function () {
        $(".btnCreateRelative, .btnEditRelative").off("click").click(function () {

            var parentId = $("#beneficiaryId").val();
            if (/^[1-9]\d*$/.test(parentId) && parentId !== 0) {

                const elementId = $(this).attr("element-id") || 0;
                window.open(`${window.location.origin}/Beneficiary/CreateEdit?id=${elementId}&parentId=${parentId}`);
            } else {
                toastr.warning(Messages.AlertMessage, Messages.AddBeneficiaryBeforeAddRelative);
            }
        });
    }

    // search Relative function
    var searchRelativeForm = function () {
        $(".btnRelativeSearch").off("click").click(function () {
            dtRelatives.destroy();
            initRelativesDataTable();
        });
    };


    // Addresses functions
    var dtAddress;
    var initAddressesDataTable = function () {
        dtAddress = $('#Addresses').DataTable({
            processing: true,
            serverSide: true,
            autoWidth: false,
            ajax: {
                url: `/Beneficiary/GetAddresses`,
                type: "POST",
                datatype: "json",
                data: {
                    "search[value]": serializeArrayToObject("SearchForm"),
                    "beneficiaryId": $("#beneficiaryId").val() 
                }
            },
            order: [[7, 'desc']],
            columnDefs: [
                {
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
                { data: "city.name", name: "city.name", autowidth: true },
                { data: "province.name", name: "province.name", autowidth: true },
                { data: "address", name: "Address", width: '33%' },
                { data: "addressType.name", name: "addressType.name", autowidth: true },
                { data: "zipCode", name: "ZipCode", autowidth: true },
                { data: "poBox", name: "POBox", autowidth: true },
                {
                    data: "isDefaultAddress", name: "IsDefaultAddress", autowidth: true,
                    render: function (data, type, row) {
                        if (data === true) {
                            return `<u class="text-success">${Messages.Default}</u>`;
                        } else {
                            return '';
                        }
                    }
                },
                {
                    width: "6%",
                    render: function (data, type, row) {
                        return `<div class="dropdown">
                                    <button class="btn btn-secondary btn-icon btn-sm" type="button" id="dropdownActions" data-bs-toggle="dropdown" aria-expanded="false">
                                        <i class="bi bi-gear-fill fs-4"></i>
                                    </button>
                                    <ul class="dropdown-menu fs-4" aria-labelledby="dropdownActions">
                                        <li><a class="dropdown-item btn btnEditAddress" element-id="${row.id}"><i class="bi bi-pencil-square"></i>${Messages.Edit}</a></li>
                                        <li><a class="dropdown-item btn btnDeleteAddress" element-id="${row.id}"><i class="bi bi-trash-fill"></i>${Messages.Delete}</a></li>
                                    </ul>
                                </div>`
                    },
                    orderable: false
                }
            ],
            rowCallback: function (row, data, index) {
                $(row).on('dblclick', function () {
                    getAddressModal(data.id);
                });
            },
            language: Language
        });

        dtAddress.on('draw', function () {
            deleteAddress();
            openAddressModal();
        });
    }

    // delete Address function
    var deleteAddress = function () {
        $(".btnDeleteAddress").off("click").click(function () {
            const elementId = $(this).attr("element-id");

            deleteFunction(`/Beneficiary/DeleteAddress/${elementId}`)
                .then(function () {
                    dtAddress.destroy();
                    initAddressesDataTable();
                });
        });
    };

    // open create or edit Address modal
    var openAddressModal = function () {
        $(".openAddressModal, .btnEditAddress").off("click").click(function () {

            var beneficiaryId = $("#beneficiaryId").val();
            if (/^[1-9]\d*$/.test(beneficiaryId) && beneficiaryId !== 0) {

                const elementId = $(this).attr("element-id") || 0;
                getAddressModal(elementId);
            } else {
                toastr.warning(Messages.AlertMessage, Messages.AddBeneficiaryBeforeAddAddress);
            }
        });
    }

    // get Address modal
    var getAddressModal = function (elementId) {
        $.ajax({
            url: `/Beneficiary/CreateEditAddressModal/${elementId}`,
            type: 'GET',
            success: function (result) {
                $('#modal .modal-content').html(result);
                $('#modal').modal('show');
                $('#modal').on('shown.bs.modal', function () {
                    $('input[type="text"]:first', this).focus();
                });
                KTApp.init(); // to init all functions including select2
                
                $("#addressBeneficiaryId").val($("#beneficiaryId").val())

                submitAddressForm();
                getCitiesByCountry();
                getProvincesByCity();
            }
        });
    }
   
    // submit create or edit Address form
    var submitAddressForm = function () {
        $("#form").on("submit", function (e) {
            e.preventDefault();
            const form = $(this);
            const data = form.serialize();

            saveOrUpdate(`/Beneficiary/CreateEditAddress/`, data, form)
                .then(function () {
                    $('#modal').modal('hide');
                    dtAddress.destroy();
                    initAddressesDataTable();
                })
                .catch(function () {
                    return;
                });
        });
    }

    // Refresh Address 
    var refreshAddresses = function () {
        $(".btnRefreshAddresses").off("click").click(function () {
            dtAddress.destroy();
            initAddressesDataTable()
        });
    }

    // get Cities by Country
    var getCitiesByCountry = function () {
        $('#CountryId').change(function () {
            var countryId = $(this).val();
            if (countryId) {
                $.ajax({
                    url: `/Beneficiary/GetCitiesByCountry?countryId=${countryId}`,
                    type: 'GET',
                    success: function (result) {
                        var cityDropdown = $('#CityId');
                        cityDropdown.empty();
                        cityDropdown.append(`<option value="" disabled selected>${Messages.City}</option>`);
                        $.each(result, function (index, item) {
                            cityDropdown.append('<option value="' + item.id + '">' + item.name + '</option>');
                        });
                        cityDropdown.trigger('change'); // trigger change to load provinces
                    }
                });
            }
        });
    }

    // get Provinces by Cities
    var getProvincesByCity = function () {
        $('#CityId').change(function () {
            var cityId = $(this).val();
            if (cityId) {
                $.ajax({
                    url: `/Beneficiary/GetProvincesByCity?cityId=${cityId}`,
                    type: 'GET',
                    success: function (data) {
                        var provinceDropdown = $('#ProvinceId');
                        provinceDropdown.empty();
                        provinceDropdown.append(`<option value="" disabled selected>${Messages.Province}</option>`);
                        $.each(data, function (index, item) {
                            provinceDropdown.append('<option value="' + item.id + '">' + item.name + '</option>');
                        });
                    }
                });
            }
        });
    }

    // Initialize the map
    var initMap = function () {
        // Define the map options (e.g., center, zoom level)
        var mapOptions = {
            center: { lat: 0, lng: 0 }, // Set initial coordinates
            zoom: 10, // Set the initial zoom level
        };

        // Create the map object and associate it with the map container
        var map = new google.maps.Map(document.getElementById("map"), mapOptions);

        // Add an event listener to get the coordinates when the map is clicked
        google.maps.event.addListener(map, "click", function (event) {
            var latitude = event.latLng.lat();
            var longitude = event.latLng.lng();

            // Update your form fields or variables with the latitude and longitude
            $("#Latitude").val(latitude);
            $("#Longitude").val(longitude);
        });
    }


    // Contacts functions
    var dtContact;
    var initContactsDataTable = function () {
        dtContact = $('#Contacts').DataTable({
            processing: true,
            serverSide: true,
            autoWidth: false,
            //scrollY: '184px',
            ajax: {
                url: `/Beneficiary/GetContacts`,
                type: "POST",
                datatype: "json",
                data: {
                    "search[value]": serializeArrayToObject("SearchForm"),
                    "beneficiaryId": $("#beneficiaryId").val()
                }
            },
            order: [[3, 'desc']],
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
                { data: "number", name: "Number", autowidth: true },
                { data: "contactType.name", name: "contactType.name", autowidth: true },
                {
                    data: "isDefaultContact", name: "IsDefaultContact", autowidth: true,
                    render: function (data, type, row) {
                        if (data === true) {
                            return `<u class="text-success">${Messages.Default}</u>`;
                        } else {
                            return '';
                        }
                    }
                },
                {
                    width: "6%",
                    render: function (data, type, row) {
                        return `<div class="dropdown">
                                    <button class="btn btn-secondary btn-icon btn-sm" type="button" id="dropdownActions" data-bs-toggle="dropdown" aria-expanded="false">
                                        <i class="bi bi-gear-fill fs-4"></i>
                                    </button>
                                    <ul class="dropdown-menu fs-4" aria-labelledby="dropdownActions">
                                        <li><a class="dropdown-item btn btnEditContact" element-id="${row.id}"><i class="bi bi-pencil-square"></i>${Messages.Edit}</a></li>
                                        <li><a class="dropdown-item btn btnDeleteContact" element-id="${row.id}"><i class="bi bi-trash-fill"></i>${Messages.Delete}</a></li>
                                    </ul>
                                </div>`
                    },
                    orderable: false
                }
            ],
            rowCallback: function (row, data, index) {
                $(row).on('dblclick', function () {
                    getContactModal(data.id);
                });
            },
            language: Language
        });

        dtContact.on('draw', function () {
            deleteContact();
            openContactModal();
        });
    }

    // delete Contact function
    var deleteContact = function () {
        $(".btnDeleteContact").off("click").click(function () {
            const elementId = $(this).attr("element-id");

            deleteFunction(`/Beneficiary/DeleteContact/${elementId}`)
                .then(function () {
                    dtContact.destroy();
                    initContactsDataTable();
                });
        });
    };

    // open create or edit Contact modal
    var openContactModal = function () {
        $(".openContactModal, .btnEditContact").off("click").click(function () {

            var beneficiaryId = $("#beneficiaryId").val();
            if (/^[1-9]\d*$/.test(beneficiaryId) && beneficiaryId !== 0) {

                const elementId = $(this).attr("element-id") || 0;
                getContactModal(elementId);
            } else {
                toastr.warning(Messages.AlertMessage, Messages.AddBeneficiaryBeforeAddContact);
            }
        });
    }

    // get Contact modal
    var getContactModal = function (elementId) {
        $.ajax({
            url: `/Beneficiary/CreateEditContactModal/${elementId}`,
            type: 'GET',
            success: function (result) {


                $('#modal .modal-content').html(result);
                $('#modal').modal('show');
                $('#modal').on('shown.bs.modal', function () {
                    $('input[type="text"]:first', this).focus();
                });
                KTApp.init(); // to init all functions including select2

                $("#contactBeneficiaryId").val($("#beneficiaryId").val())
                submitContactForm();
            }
        });
    }
    
    // submit create or edit Contact form
    var submitContactForm = function () {
        $("#form").on("submit", function (e) {
            e.preventDefault();
            const form = $(this);

            const data = form.serialize();

            saveOrUpdate(`/Beneficiary/CreateEditContact/`, data, form)
                .then(function () {
                    $('#modal').modal('hide');
                    dtContact.destroy();
                    initContactsDataTable();
                })
                .catch(function () {
                    return;
                });
        });
    }

    // Refresh Contacts
    var refreshContacts = function () {
        $(".btnRefreshContacts").off("click").click(function () {
            dtContact.destroy();
            initContactsDataTable()
        });
    }


    // Passport functions
    var dtPassports;
    var initPassportsDataTable = function () {
        dtPassports = $('#Passports').DataTable({
            processing: true,
            serverSide: true,
            autoWidth: false,
            ajax: {
                url: `/Passport/GetAll`,
                type: "POST",
                datatype: "json",
                data: { "search[value]": serializeArrayToObject("passportSearchForm") }
            },
            order: [[6, 'desc']],
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
                { data: "passportNumber", name: "PassportNumber", autowidth: true },
                { data: "type.name", name: "type.name", autowidth: true },
                {
                    data: "nationality",name: "nationality",
                    autowidth: true,
                    render: function (data, type, row) {
                        const lang = $("html").attr("lang");
                        return lang === "ar" ? data.nameAr : data.nameEn;
                    }
                },
                {
                    data: "issueDate", name: "IssueDate",
                    autowidth: true,
                    render: function (data, type, row) {
                        if (data) {
                            return '<span>' + data.split('T')[0] + '</span>';
                        }
                        return '';
                    }
                },
                {
                    data: "expiryDate", name: "ExpiryDate",
                    autowidth: true,
                    render: function (data, type, row) {
                        if (data) {
                            return '<span>' + data.split('T')[0] + '</span>';
                        }
                        return '';
                    }
                },
                {
                    data: "isActive", name: "isActive",
                    orderable: true,
                    autowidth: true,
                    render: function (data, type, row) {
                        return row.isActive ? `<u class="text-success">${Messages.Active}</u>` : `<u class="text-danger">${Messages.Expired}</u>`;
                    }
                },
                {
                    width: "6%",
                    render: function (data, type, row) {
                        return `<div class="dropdown">
                                    <button class="btn btn-secondary btn-icon btn-sm" type="button" id="dropdownActions" data-bs-toggle="dropdown" aria-expanded="false">
                                        <i class="bi bi-gear-fill fs-4"></i>
                                    </button>
                                    <ul class="dropdown-menu fs-4" aria-labelledby="dropdownActions">
                                        <li><a class="dropdown-item btn btnEditPassport" element-id="${row.id}"><i class="bi bi-pencil-square"></i>${Messages.Edit}</a></li>
                                        <li><a class="dropdown-item btn btnDeletePassport" element-id="${row.id}"><i class="bi bi-trash-fill"></i>${Messages.Delete}</a></li>
                                    </ul>
                                </div>`
                    },
                    orderable: false
                }
            ],
            rowCallback: function (row, data, index) {
                $(row).on('dblclick', function () {
                    getPassportModal(data.id);
                });
            },
            language: Language
        });

        dtPassports.on('draw', function () {
            deletePassport();
            openPassportModal();
        });
    }

    // delete Passport function
    var deletePassport = function () {
        $(".btnDeletePassport").off("click").click(function () {
            const elementId = $(this).attr("element-id");

            deleteFunction(`/Passport/Delete/${elementId}`)
                .then(function () {
                    dtPassports.destroy();
                    initPassportsDataTable();
                });
        });
    };
   
    // open create or edit Passport modal
    var openPassportModal = function () {
        $(".openPassportModal, .btnEditPassport").off("click").click(function () {

            var beneficiaryId = $("#beneficiaryId").val();
            if (/^[1-9]\d*$/.test(beneficiaryId) && beneficiaryId !== 0) {

                const elementId = $(this).attr("element-id") || 0;
                getPassportModal(elementId);
            } else {
                toastr.warning(Messages.AlertMessage, Messages.AddBeneficiaryBeforeAddPassport);
            }
        });
    }

    // get Passport modal
    var getPassportModal = function (elementId) {
        $.ajax({
            url: `/Passport/CreateEditModal/${elementId}`,
            type: 'GET',
            success: function (result) {
                $('#modal .modal-content').html(result);
                $('#modal').modal('show');
                $('#modal').on('shown.bs.modal', function () {
                    $('input[type="text"]:first', this).focus();
                });
                KTApp.init(); // to init all functions including select2

                $("#passportBeneficiaryId").val($("#beneficiaryId").val())
                uploadAttachment('uploadFileInput', '/File/UploadFile', 'Attachments', "input[name='AttachmentAttachmentName']", "input[name='AttachmentIcon']");
                submitPassportForm();
            }
        });
    }

    // submit create or edit Passport form
    var submitPassportForm = function () {
        $("#form").on("submit", function (e) {
            e.preventDefault();
            const form = $(this);
            const data = form.serialize();

            saveOrUpdate(`/Passport/CreateEdit/`, data, form)
                .then(function () {
                    $('#modal').modal('hide');
                    dtPassports.destroy();
                    initPassportsDataTable();
                    attachments.init();
                })
                .catch(function () {
                    return;
                });
        });        
    }

    // search Passport function
    var searchPassportForm = function () {
        $(".btnPassportSearch").off("click").click(function () {
            dtPassports.destroy();
            initPassportsDataTable();
        });
    };


    // Identity functions
    var dtIdentities;
    var initIdentitiesDataTable = function () {
        dtIdentities = $('#Identities').DataTable({
            processing: true,
            serverSide: true,
            autoWidth: false,
            ajax: {
                url: `/Identity/GetAll`,
                type: "POST",
                datatype: "json",
                data: { "search[value]": serializeArrayToObject("identitySearchForm") }
            },
            order: [[7, 'desc']],
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
                { data: "identityType.name", name: "identityType.name", autowidth: true },
                { data: "idNumber", name: "idNumber", autowidth: true },
                { data: "countryOfOrigin.name", name: "countryOfOrigin.name", autowidth: true },
                { data: "religion.name", name: "religion.name", autowidth: true },
                {
                    data: "issueDate",
                    name: "IssueDate",
                    autowidth: true,
                    render: function (data, type, row) {
                        if (data) {
                            return '<span>' + data.split('T')[0] + '</span>';
                        }
                        return '';
                    }
                },
                {
                    data: "expiryDate",
                    name: "ExpiryDate",
                    autowidth: true,
                    render: function (data, type, row) {
                        if (data) {
                            return '<span>' + data.split('T')[0] + '</span>';
                        }
                        return '';
                    }
                },
                {
                    data: "isActive",
                    name: "isActive",
                    orderable: true,
                    autowidth: true,
                    render: function (data, type, row) {
                        return data ? `<u class="text-success">${Messages.Active}</u>` : `<u class="text-danger">${Messages.Expired}</u>`;
                    }
                },
                {
                    width: "6%",
                    render: function (data, type, row) {
                        return `<div class="dropdown">
                                    <button class="btn btn-secondary btn-icon btn-sm" type="button" id="dropdownActions" data-bs-toggle="dropdown" aria-expanded="false">
                                        <i class="bi bi-gear-fill fs-4"></i>
                                    </button>
                                    <ul class="dropdown-menu fs-4" aria-labelledby="dropdownActions">
                                        <li><a class="dropdown-item btn btnEditIdentity" element-id="${row.id}"><i class="bi bi-pencil-square"></i>${Messages.Edit}</a></li>
                                        <li><a class="dropdown-item btn btnDeleteIdentity" element-id="${row.id}"><i class="bi bi-trash-fill"></i>${Messages.Delete}</a></li>
                                    </ul>
                                </div>`
                    },
                    orderable: false
                }
            ],
            rowCallback: function (row, data, index) {
                $(row).on('dblclick', function () {
                    getIdentityModal(data.id);
                });
            },
            language: Language
        });

        dtIdentities.on('draw', function () {
            deleteIdentity();
            openIdentityModal();
        });
    }

    // delete Identity function
    var deleteIdentity = function () {
        $(".btnDeleteIdentity").off("click").click(function () {
            const elementId = $(this).attr("element-id");

            deleteFunction(`/Identity/Delete/${elementId}`)
                .then(function () {
                    dtIdentities.destroy();
                    initIdentitiesDataTable();
                });
        });
    };

    // open create or edit Identity modal
    var openIdentityModal = function () {
        $(".openIdentityModal, .btnEditIdentity").off("click").click(function () {

            var beneficiaryId = $("#beneficiaryId").val();
            if (/^[1-9]\d*$/.test(beneficiaryId) && beneficiaryId !== 0) {

                const elementId = $(this).attr("element-id") || 0;
                getIdentityModal(elementId);
            } else {
                toastr.warning(Messages.AlertMessage, Messages.AddBeneficiaryBeforeAddIdentity);
            }
        });
    }

    // get Identity modal
    var getIdentityModal = function (elementId) {
        $.ajax({
            url: `/Identity/CreateEditModal/${elementId}`,
            type: 'GET',
            success: function (result) {
                $('#modal .modal-content').html(result);
                $('#modal').modal('show');
                $('#modal').on('shown.bs.modal', function () {
                    $('input[type="text"]:first', this).focus();
                });
                KTApp.init(); // to init all functions including select2

                $("#identityBeneficiaryId").val($("#beneficiaryId").val())
                uploadAttachment('uploadFileInput', '/File/UploadFile', 'Attachments', "input[name='AttachmentAttachmentName']", "input[name='AttachmentIcon']");
                submitIdentityForm();
            }
        });
    }

    // submit create or edit Identity form
    var submitIdentityForm = function () {
        $("#form").on("submit", function (e) {
            e.preventDefault();
            const form = $(this);

            const data = form.serialize();

            saveOrUpdate(`/Identity/CreateEdit/`, data, form)
                .then(function () {
                    $('#modal').modal('hide');
                    dtIdentities.destroy();
                    initIdentitiesDataTable();
                    attachments.init();
                })
                .catch(function () {
                    return;
                });
        });
    }

    // search Identity function
    var searchIdentityForm = function () {
        $(".btnIdentitySearch").off("click").click(function () {
            dtIdentities.destroy();
            initIdentitiesDataTable();
        });
    };

    // Attachments functions
    // get Attachments Partial By Record
    var getAttachmentsPartialByRecord = function () {
        var beneficiaryId = $("#beneficiaryId").val();

        $.ajax({
            url: `/Beneficiary/GetAttachments`,
            type: 'POST',
            data: { recordId: beneficiaryId },
            success: function (result) {
                $('#AttachmentsTab').html(result);
                openUploadAttachmentModal();
                deleteAttachment();
            }
        });
    }

    // open Upload Attachment Modal
    var openUploadAttachmentModal = function () {
        $(".UploadAttachmentModal").off("click").click(function () {
            var beneficiaryId = $("#beneficiaryId").val();

            // If Record is Valid and is != 0
            if (/^[1-9]\d*$/.test(beneficiaryId) && beneficiaryId !== 0) {
                getUploadAttachmentModal(beneficiaryId);
            } else {
                toastr.warning(Messages.AlertMessage, Messages.AddBeneficiaryBeforeAttach);
            }
        });
    }

    // get Upload Attachment Modal
    var getUploadAttachmentModal = function (beneficiaryId) {
        $.ajax({
            url: `/Beneficiary/UploadAttachment`,
            type: 'POST',
            data: { recordId: beneficiaryId },
            success: function (result) {
                $('#modal .modal-content').html(result);
                $('#modal').modal('show');
                $('#modal').on('shown.bs.modal', function () {
                    $('input[type="text"]:first', this).focus();
                });
                KTApp.init(); // to init all functions including select2

                uploadAttachment('uploadFileInput', '/File/UploadFile', 'Attachments', "input[name='AttachmentName']", "input[name='Icon']");
                submitUploadAttachmentForm();
            }
        });
    }

    // submit Upload Attachment Form
    var submitUploadAttachmentForm = function () {
        $("#UploadAttachmentForm").on("submit", function (e) {
            e.preventDefault();
            const form = $(this);
            const data = form.serialize();

            saveOrUpdate(`/Beneficiary/SaveAttachment/`, data, form)
                .then(function () {
                    $('#modal').modal('hide');
                    getAttachmentsPartialByRecord();
                })
                .catch(function () {
                    return;
                });
        });
    }

    // delete function
    var deleteAttachment = function () {
        $(".btnDeleteAttachment").off("click").click(function () {
            const elementId = $(this).attr("element-id");

            deleteFunction(`/Beneficiary/DeleteAttachment/${elementId}`)
                .then(function () {

                    getAttachmentsPartialByRecord();
                });
        });
    };

    return {
        init: function () {
            // init Beneficiary functions
            initBeneficiariesDataTable();
            searchBeneficiaryForm();
            submitBeneficiaryForm();

            // init Addresses functions
            initAddressesDataTable();
            openAddressModal();
            refreshAddresses();
            //initMap();

            // init Contacts functions
            initContactsDataTable();
            openContactModal();
            refreshContacts();

            // init Passports functions
            initPassportsDataTable();
            openPassportModal();
            searchPassportForm();

            // init Identities functions
            initIdentitiesDataTable();
            openIdentityModal();
            searchIdentityForm();

            // init Relatives functions
            initRelativesDataTable();
            createEditRelative();
            searchRelativeForm();

            // get Attachments Partial By Record
            getAttachmentsPartialByRecord();
        }
    }
}();