crashData = LOAD 'CrashData2020.csv' using PigStorage(',') AS
(
STATE:INT,
STATENAME:CHARARRAY,
ST_CASE:INT,
VE_TOTAL:INT,
VE_FORMS:INT,
PVH_INVL:INT,
PEDS:INT,
PERSONS:INT,
PERMVIT:INT,
PERNOTMVIT:INT,
COUNTY:INT,
COUNTYNAME:CHARARRAY,
CITY:INT,
CITYNAME:CHARARRAY,
DAY:INT,
DAYNAME:CHARARRAY,
MONTH:INT,
MONTHNAME:CHARARRAY,
YEAR:INT,
DAY_WEEK:INT,
DAY_WEEKNAME:CHARARRAY,
HOUR:INT,
HOURNAME:CHARARRAY,
MINUTE:INT,
MINUTENAME:CHARARRAY,
NHS:INT,
NHSNAME:CHARARRAY,
ROUTE:INT,
ROUTENAME:CHARARRAY,
TWAY_ID:CHARARRAY,
TWAY_ID2:CHARARRAY,
RUR_URB:INT,
RUR_URBNAME:CHARARRAY,
FUNC_SYS:INT,
FUNC_SYSNAME:CHARARRAY,
RD_OWNER:INT,
RD_OWNERNAME:CHARARRAY,
MILEPT:INT,
MILEPTNAME:CHARARRAY,
LATITUDE:FLOAT,
LATITUDENAME:CHARARRAY,
LONGITUD:FLOAT,
LONGITUDNAME:CHARARRAY,
SP_JUR:INT,
SP_JURNAME:CHARARRAY,
HARM_EV:INT,
HARM_EVNAME:CHARARRAY,
MAN_COLL:INT,
MAN_COLLNAME:CHARARRAY,
RELJCT1:INT,
RELJCT1NAME:CHARARRAY,
RELJCT2:INT,
RELJCT2NAME:CHARARRAY,
TYP_INT:INT,
TYP_INTNAME:CHARARRAY,
WRK_ZONE:INT,
WRK_ZONENAME:CHARARRAY,
REL_ROAD:INT,
REL_ROADNAME:CHARARRAY,
LGT_COND:INT,
LGT_CONDNAME:CHARARRAY,
WEATHER:INT,
WEATHERNAME:CHARARRAY,
SCH_BUS:INT,
SCH_BUSNAME:CHARARRAY,
RAIL:INT,
RAILNAME:CHARARRAY,
NOT_HOUR:INT,
NOT_HOURNAME:CHARARRAY,
NOT_MIN:INT,
NOT_MINNAME:CHARARRAY,
ARR_HOUR:INT,
ARR_HOURNAME:CHARARRAY,
ARR_MIN:INT,
ARR_MINNAME:CHARARRAY,
HOSP_HR:INT,
HOSP_HRNAME:CHARARRAY,
HOSP_MN:INT,
HOSP_MNNAME:CHARARRAY,
FATALS:INT,
DRUNK_DR:INT
);

subset = FOREACH crashData GENERATE STATENAME as StateName, DAY as Day, MONTH as Month, YEAR as Year, 
FATALS as Deaths, TYP_INTNAME as IntersectionName, HARM_EVNAME as CrashTypeName;

filteredSubset = FILTER subset BY (StateName is not null) AND (Day is not null) AND (Month is not null)
AND (Year is not null) AND (Deaths is not null) AND (IntersectionName is not null) AND (CrashTypeName is not null);

date = FOREACH filteredSubset GENERATE Day, Month, Year;

d_date = DISTINCT date;

collision = FOREACH filteredSubset GENERATE CrashTypeName;

d_collision = DISTINCT collision;

intersection = FOREACH filteredSubset GENERATE IntersectionName;

d_intersection = DISTINCT intersection;

STORE filteredSubset INTO 'Output/newCrashData' using PigStorage(',');

STORE d_date INTO 'Output/newDate' using PigStorage(',');

STORE d_collision INTO 'Output/newCollision' using PigStorage(',');

STORE d_intersection INTO 'Output/newIntersection' using PigStorage(',');


