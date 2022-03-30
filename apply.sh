#!/bin/sh

# Do NOT change the replacement order!
# project GUID: bc9d47e4-823c-45aa-af25-f052eafee17f
# assembly GUID: 8ddcb5e9-86ba-49f1-9f4b-fe4a8f2a4567
for regexp in 's/VARIABLE_NAMESPACE/Polyipseity.IndiscriminatingSpikeTrap/g' 's/VARIABLE_NAME/Indiscriminating Spike Trap/g' 's/VARIABLE_ASSEMBLY_NAME/IndiscriminatingSpikeTrap/g' 's/VARIABLE_AUTHOR/polyipseity/g' 's/VARIABLE_YEAR/2022/g' 's/VARIABLE_SUPPORTED_VERSION/1.3/g' 's/VARIABLE_DESCRIPTION//g' 's/VARIABLE_URL//g' 's/bc9d47e4-823c-45aa-af25-f052eafee17f/7bd32c01-2cbf-4c26-8fbf-434764a9e72b/g' 's/8ddcb5e9-86ba-49f1-9f4b-fe4a8f2a4567/881fe671-0de5-491e-94b7-68a6e3b3efb7/g'; do
	echo Applying \'$regexp\'…
	find . \( -type f -wholename "$0" \) -o \( -type d -name '.git' -prune \) -o -type f -print0 | xargs -0 sed -i "$regexp"
done
