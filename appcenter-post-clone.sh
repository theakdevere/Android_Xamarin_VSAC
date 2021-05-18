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
echo "GET: gradle --version"
gradle --version
echo "Done: gradle version"
echo "######################################################"
echo "End appcenter-post-clone.sh"