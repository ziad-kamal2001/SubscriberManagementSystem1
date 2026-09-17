"use strict";

var beneficiaryFamily = (function () {

    // تُملأ هذه القيم من الـ View عبر beneficiaryFamily.init(options)
    let wiveIndex = 0;
    let childIndex = 0;
    let genderOptionsHtml = "";
    let healthOptionsHtml = "";

    function addWiveRow() {
        const tbody = document.getElementById("wivesTableBody");
        if (!tbody) return;

        const row = document.createElement("tr");
        row.className = "wive-row";
        row.innerHTML =
            "<td>" +
            "<input type='hidden' name='Wives[" + wiveIndex + "].Id' value='0' />" +
            "<input type='text' name='Wives[" + wiveIndex + "].Name' class='form-control' />" +
            "</td>" +
            "<td><input type='text' name='Wives[" + wiveIndex + "].IDNumber' class='form-control' /></td>" +
            "<td><input type='date' name='Wives[" + wiveIndex + "].DOB' class='form-control' /></td>" +
            "<td class='text-center'><input type='checkbox' name='Wives[" + wiveIndex + "].IsActive' value='true' checked /></td>" +
            "<td><button type='button' class='btn btn-sm btn-danger btnRemoveWiveRow' data-id='0'><i class='bi bi-trash'></i></button></td>";

        tbody.appendChild(row);
        wiveIndex++;
    }

    function addChildRow() {
        const tbody = document.getElementById("childrenTableBody");
        if (!tbody) return;

        const row = document.createElement("tr");
        row.className = "child-row";
        row.innerHTML =
            "<td>" +
            "<input type='hidden' name='ChildrenList[" + childIndex + "].Id' value='0' />" +
            "<input type='text' name='ChildrenList[" + childIndex + "].Name' class='form-control' />" +
            "</td>" +
            "<td><input type='text' name='ChildrenList[" + childIndex + "].IDNumber' class='form-control' /></td>" +
            "<td><input type='date' name='ChildrenList[" + childIndex + "].DOB' class='form-control' /></td>" +
            "<td><select name='ChildrenList[" + childIndex + "].GenderId' class='form-select'><option value=''></option>" + genderOptionsHtml + "</select></td>" +
            "<td><select name='ChildrenList[" + childIndex + "].TheHealthConditionId' class='form-select'><option value=''></option>" + healthOptionsHtml + "</select></td>" +
            "<td><button type='button' class='btn btn-sm btn-danger btnRemoveChildRow' data-id='0'><i class='bi bi-trash'></i></button></td>";

        tbody.appendChild(row);
        childIndex++;
    }

    function handleRemoveClick(e) {
        const wiveBtn = e.target.closest(".btnRemoveWiveRow");
        if (wiveBtn) {
            const id = wiveBtn.getAttribute("data-id");
            if (id && id !== "0") {
                appendDeletedIdInput("deletedWivesContainer", "DeletedWiveIds", id);
            }
            wiveBtn.closest("tr").remove();
            return;
        }

        const childBtn = e.target.closest(".btnRemoveChildRow");
        if (childBtn) {
            const id = childBtn.getAttribute("data-id");
            if (id && id !== "0") {
                appendDeletedIdInput("deletedChildrenContainer", "DeletedChildrenIds", id);
            }
            childBtn.closest("tr").remove();
            return;
        }
    }

    function appendDeletedIdInput(containerId, inputName, value) {
        const container = document.getElementById(containerId);
        if (!container) return;

        const hidden = document.createElement("input");
        hidden.type = "hidden";
        hidden.name = inputName;
        hidden.value = value;
        container.appendChild(hidden);
    }

    function bindEvents() {
        const addWiveBtn = document.getElementById("btnAddWiveRow");
        if (addWiveBtn) {
            addWiveBtn.addEventListener("click", addWiveRow);
        }

        const addChildBtn = document.getElementById("btnAddChildRow");
        if (addChildBtn) {
            addChildBtn.addEventListener("click", addChildRow);
        }

        document.addEventListener("click", handleRemoveClick);
    }

    function init(options) {
        options = options || {};
        wiveIndex = options.wiveIndex || 0;
        childIndex = options.childIndex || 0;
        genderOptionsHtml = options.genderOptionsHtml || "";
        healthOptionsHtml = options.healthOptionsHtml || "";

        bindEvents();
    }

    return {
        init: init
    };

})();