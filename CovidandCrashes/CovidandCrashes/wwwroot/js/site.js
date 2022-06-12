function PopulateStateDropdown(dropdownID) {
    $.getJSON('/State')
        .done(function (data) {
            let output = "";
            for (let entry in data) {
                output += `<option value='${data[entry].stateID}' onclick='PopulateEmployeeDropdown("employee-order", ${data[entry].stateID})'>${data[entry].stateName}</option>`
            }

            const Dropdown = document.getElementById(dropdownID);
            Dropdown.innerHTML = output;
        })
        .fail(function (jqXHR, textStatus, err) {
            outputDiv.innerHTML = output; 'Error: ' + err;
        });
}

function PopulateCrashDropdown(dropdownID) {
    $.getJSON('/CrashType')
        .done(function (data) {
            let output = "";
            for (let entry in data) {
                output += `<option value='${data[entry].crashTypeId}' onclick='PopulateEmployeeDropdown("employee-order", ${data[entry].crashTypeId})'>${data[entry].crashTypeName}</option>`
            }

            const Dropdown = document.getElementById(dropdownID);
            Dropdown.innerHTML = output;
        })
        .fail(function (jqXHR, textStatus, err) {
            outputDiv.innerHTML = output; 'Error: ' + err;
        });
}

function PopulateIntersectionDropdown(dropdownID) {
    $.getJSON('/Intersection')
        .done(function (data) {
            let output = "";
            for (let entry in data) {
                output += `<option value='${data[entry].intersectionID}' onclick='PopulateEmployeeDropdown("employee-order", ${data[entry].intersectionID})'>${data[entry].intersectionTypeName}</option>`
            }

            const Dropdown = document.getElementById(dropdownID);
            Dropdown.innerHTML = output;
        })
        .fail(function (jqXHR, textStatus, err) {
            outputDiv.innerHTML = output; 'Error: ' + err;
        });
}

function PopulateDateDayDropdown(dropdownID) {
    $.getJSON('/Date')
        .done(function (data) {
            let output = "";
            for (let entry in data) {
                output += `<option value='${data[entry].dateDay}'>${data[entry].dateDay}</option>`
            }

            const Dropdown = document.getElementById(dropdownID);
            Dropdown.innerHTML = output;
        })
        .fail(function (jqXHR, textStatus, err) {
            outputDiv.innerHTML = output; 'Error: ' + err;
        });
}

function PopulateDateMonthDropdown(dropdownID) {
    $.getJSON('/Date')
        .done(function (data) {
            let output = "";
            for (let entry in data) {
                output += `<option value='${data[entry].dateMonth}'>${data[entry].dateMonth}</option>`
            }

            const Dropdown = document.getElementById(dropdownID);
            Dropdown.innerHTML = output;
        })
        .fail(function (jqXHR, textStatus, err) {
            outputDiv.innerHTML = output; 'Error: ' + err;
        });
}

$(document).ready(function () {
    PopulateStateDropdown('statedd');
    PopulateCrashDropdown('crashTypedd');
    PopulateIntersectionDropdown('intersectiondd');
    PopulateDateDayDropdown('fDaydd');
    PopulateDateDayDropdown('lDaydd');
    PopulateDateMonthDropdown('fMonthdd');
    PopulateDateMonthDropdown('lMonthdd');
});