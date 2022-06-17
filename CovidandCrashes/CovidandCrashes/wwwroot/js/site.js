function PopulateStateDropdown(dropdownID) {
    $.getJSON('/State')
        .done(function (data) {
            let output = "<option value='-1'>All</option>";
            for (let entry in data) {
                output += `<option value='${data[entry].stateID}'>${data[entry].stateName}</option>`
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
            let output = "<option value='-1'>All</option>";
            for (let entry in data) {
                output += `<option value='${data[entry].crashTypeId}'>${data[entry].crashTypeName}</option>`
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
            let output = "<option value='-1'>All</option>";
            for (let entry in data) {
                output += `<option value='${data[entry].intersectionID}'>${data[entry].intersectionTypeName}</option>`
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

function GenerateTable() {
    $.getJSON(`/Comparison/${date1}/${date2}/${statedd}/${crashTypedd}/${intersectiondd}`)
    console.log(date1.value, date2.value, statedd.value, crashTypedd.value, intersectiondd.value)
        .done(function (data) {
            let output = "<table><tr><th>Date</th><th>State</th><th>Collision type</th><th>Intersection</th><th>Covid deaths</th><th>Crash Deaths</th></tr>";
            for (let entry in data) {
                output += `<tr><td>${data.Date}</td><td>${data.stateName}</td><td>${data.CrashType}</td><td>${data.intersectionType}</td><td>${data.covidDeaths}</td><td>${data.crashDeaths}</td></tr>`;
            }
            output += '</table>'
            const outputDiv = document.getElementById("output-div");
            outputDiv.innerHTML = output;
        })
        .fail(function (jqXHR, textStatus, err) {
            const outputDiv = document.getElementById("output-div");
            outputDiv.innerHTML = output; 'Error: ' + err;
        });
}

$(document).ready(function () {
    PopulateStateDropdown('statedd');
    PopulateCrashDropdown('crashTypedd');
    PopulateIntersectionDropdown('intersectiondd');
});