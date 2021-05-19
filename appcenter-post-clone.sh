#!/usr/bin/env bash
echo "######################################################"
echo "Begin appcenter-post-clone.sh"
echo "######################################################"
#echo "List all Environment Variables"
echo "######################################################"
#printenv
#echo "######################################################"
#echo "List files in AgentToolsDirectory"
#echo "######################################################"
#ls $AgentToolsDirectory 
echo "######################################################"
#echo "START TCPDUMP"
echo "######################################################"
#sudo tcpdump -G 15 -W 1 -w myfile
echo "######################################################"
#echo "END TCPDUMP"
echo "######################################################"
#echo "GET: gradle --version"
#gradle --version
echo "######################################################"
echo "AppCenter Source directory"
echo $APPCENTER_SOURCE_DIRECTORY
echo "nuget install"
nuget install VSAC_Diag -OutputDirectory $APPCENTER_SOURCE_DIRECTORY -PreRelease -x -Source 'https://www.nuget.org/packages/VSAC_Diag.1.0.0/1.0.0'

echo "End appcenter-post-clone.sh"