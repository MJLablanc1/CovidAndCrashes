covidData = LOAD 'all-states-history.csv' using PigStorage(',') AS
(
date:CHARARRAY,
state:CHARARRAY,
death:INT,
deathConfirmed:INT,
deathIncrease:INT,
deathProbable:INT,
hospitalized:INT,
hospitalizedCumulative:INT,
hospitalizedCurrently:INT,
hospitalizedIncrease:INT,
inIcuCumulative:INT,
inIcuCurrently:INT,
negative:INT,
negativeIncrease:INT,
negativeTestsAntibody:INT,
negativeTestsPeopleAntibody:INT,
negativeTestsViral:INT,
onVentilatorCumulative:INT,
onVentilatorCurrently:INT,
positive:INT,
positiveCasesViral:INT,
positiveIncrease:INT,
positiveScore:INT,
positiveTestsAntibody:INT,
positiveTestsAntigen:INT,
positiveTestsPeopleAntibody:INT,
positiveTestsPeopleAntigen:INT,
positiveTestsViral:INT,
recovered:INT,
totalTestEncountersViral:INT,
totalTestEncountersViralIncrease:INT,
totalTestResults:INT,
totalTestResultsIncrease:INT,
totalTestsAntibody:INT,
totalTestsAntigen:INT,
totalTestsPeopleAntibody:INT,
totalTestsPeopleAntigen:INT,
totalTestsPeopleViral:INT,
totalTestsPeopleViralIncrease:INT,
totalTestsViral:INT,
totalTestsViralIncrease:INT
);

covidSubset = FOREACH covidData GENERATE date, state, deathIncrease AS death, hospitalized;

filteredSubset = FILTER covidSubset BY (date is not null) AND (state is not null) AND (death is not null) AND (hospitalized is not null);

stateTable = FOREACH filteredSubset GENERATE state;

d_stateTable = DISTINCT stateTable;

STORE filteredSubset INTO 'Output/newCovidData' using PigStorage(',');

STORE d_stateTable INTO 'Output/newStateData' using PigStorage(',');




