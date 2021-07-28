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

function Select() {
    var checkBoxes = document.getElementsByClassName("single-check-box");
    for (let i = 0; i < checkBoxes.length; i++) {
        if (checkBoxes[i].checked == false) {
            document.getElementById("CheckBoxGeneral").checked = false;
            return;
        }
    }
    document.getElementById("CheckBoxGeneral").checked = true;
}