// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function SelectAll() {
    var checkBoxes = document.getElementsByClassName("single-check-box");
    if (document.getElementById("CheckBoxGeneral").checked == false) {
        for (let i = 0; i < checkBoxes.length; i++) {
            checkBoxes[i].checked = false;
        }
    }
    else {
        for (let i = 0; i < checkBoxes.length; i++) {
            checkBoxes[i].checked = true;
        }
    }
}

function Select(id) {
    var ids = [];
    var isTrueSelectAll = true;
    var checkBoxes = document.getElementsByClassName("single-check-box");
    for (let i = 0; i < checkBoxes.length; i++) {
        if (checkBoxes[i].checked == false) {
            isTrueSelectAll = false;
        }
        else {
            ids.push(checkBoxes[i].value);
        }
    }
    var sender = document.getElementById("Sender");
    sender.setAttribute("value", ids);
    document.getElementById("CheckBoxGeneral").checked = isTrueSelectAll;
}
