#!/usr/bin/env bash

$nugetConfigPath='${APPCENTER_SOURCE_DIRECTORY}\nuget.config'
echo "${nugetConfigPath}"

if [ -e "$nugetConfigPath" ] 
then
	echo "Attempting rewrite of nuget.config"
	cat $nugetConfigPath
	#sed -i '' 's/package="[^"]*"/package="'YourPassword'"/' $nugetConfigPath
fi