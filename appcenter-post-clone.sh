#!/usr/bin/env bash
echo "VSS_NUGET_EXTERNAL_FEED_ENDPOINTS"
printenv VSS_NUGET_EXTERNAL_FEED_ENDPOINTS

echo "TDEVERE: Install VSAC_Diag"
nuget install VSAC_Diag -OutputDirectory $APPCENTER_SOURCE_DIRECTORY -Source tdevere_nuget