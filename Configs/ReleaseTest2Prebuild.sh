#!/bin/bash
projectDirectory=${PWD}
echo "***** TDEVERE: Print Android Manifest Contents Before Copy *****"
echo "$(cat $projectDirectory/Properties/AndroidManifest.xml)" 
# Copy the Manifest
cd $projectDirectory/Configs/Manifests
cp -R "AndroidManifest_ReleaseTest2.xml" "$projectDirectory/Properties/AndroidManifest.xml"
echo "$projectDirectory/Configs/Manifest/AndroidManifest_ReleaseTest1.xml copied to $projectDirectory/Properties/AndroidManifest.xml"
echo "***** TDEVERE: Print Android Manifest Contents AFTER Copy *****"
echo "$(cat $projectDirectory/Properties/AndroidManifest.xml)" 
exit