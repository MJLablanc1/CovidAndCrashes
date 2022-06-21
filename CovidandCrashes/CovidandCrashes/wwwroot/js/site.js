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
            let color = 'blue';
            let previousDate = "";
            let States = [];
            let covidDeath = 0;
            let crashDeath = 0;

            let output = "<table><tr><th>Date</th><th>State</th><th>Collision type</th><th>Intersection</th><th>Covid deaths</th><th>Crash Deaths</th></tr>";

            for (let entry in data) {
                if (previousDate == "") {
                    previousDate = data[entry].dateShort;
                }
                
                if (data[entry].dateShort == previousDate) {
                    crashDeath += data[entry].crashDeaths
                    if (!States.includes(data[entry].stateName)) {
                        covidDeath += data[entry].covidDeaths
                        States.push(data[entry].stateName)
                    }

                } else {
                    output += `<tr class=${color}><td>${previousDate}</td><td></td><td></td><td></td<td>Total covid and crash deaths</td><td>${covidDeath}</td><td>${crashDeath}</td></tr>`;
                    output += '<tr class="blank_row"> <td colspan="3"></td> </tr>'
                    crashDeath = data[entry].crashDeaths;
                    covidDeath = data[entry].covidDeaths;
                    States.push(data[entry].stateName);
                    previousDate = data[entry].dateShort;
                }
                output += `<tr class=${color}><td>${data[entry].dateShort}</td><td>${data[entry].stateName}</td><td>${data[entry].crashType}</td><td>${data[entry].intersectionType}</td><td>${data[entry].covidDeaths}</td><td>${data[entry].crashDeaths}</td></tr>`;


                if (color == 'blue') {
                    color = 'green'
                } else {
                    color = 'blue'
                }
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