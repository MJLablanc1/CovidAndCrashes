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
}

function PopulateCrashDropdown(dropdownID) {
    $.getJSON('/CrashType')
        .done(function (data) {
            let output = "<option value='-1'>All</option>";
            for (let entry in data) {
                output += `<option value='${data[entry].crashTypeID}'>${data[entry].crashTypeName}</option>`
            }

            const Dropdown = document.getElementById(dropdownID);
            Dropdown.innerHTML = output;
        })
}

function PopulateIntersectionDropdown(dropdownID) {
    $.getJSON('/Intersection')
        .done(function (data) {
            let output = "<option value='-1'>All</option>";
            for (let entry in data) {
                output += `<option value='${data[entry].intersectionTypeID}'>${data[entry].intersectionTypeName}</option>`
            }

            const Dropdown = document.getElementById(dropdownID);
            Dropdown.innerHTML = output;
        })
}

function GenerateTable() {
    $.getJSON(`/Comp/${date1.value}/${date2.value}/${statedd.value}/${crashTypedd.value}/${intersectiondd.value}`)
        .done(function (data) {
            console.log(`/Comp/${date1.value}/${date2.value}/${statedd.value}/${crashTypedd.value}/${intersectiondd.value}`);
            let output = "<table><tr><th>Date</th><th>State</th><th>Collision type</th><th>Intersection</th><th>Covid deaths</th><th>Crash Deaths</th></tr>";
            for (let entry in data) {
                output += `<tr><td>${data[entry].date}</td><td>${data[entry].stateName}</td><td>${data[entry].crashType}</td><td>${data[entry].intersectionType}</td><td>${data[entry].covidDeaths}</td><td>${data[entry].crashDeaths}</td></tr>`;
            }
            output += '</table>'
            const outputDiv = document.getElementById("output-div");
            outputDiv.innerHTML = output;
        })
}

$(document).ready(function () {
    PopulateStateDropdown('statedd');
    PopulateCrashDropdown('crashTypedd');
    PopulateIntersectionDropdown('intersectiondd');
});