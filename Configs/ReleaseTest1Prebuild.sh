#!/bin/bash
projectDirectory=${PWD}
# Copy the Manifest
cd $projectDirectory/Configs/Manifests
cp -R "AndroidManifest_ReleaseTest21.xml" "$projectDirectory/Properties/AndroidManifest.xml"
echo "$projectDirectory/Configs/Manifest/AndroidManifest_ReleaseTest1.xml copied to $projectDirectory/Properties/AndroidManifest.xml"
echo "***** Android Manifest Contents *****"
echo "$(cat $projectDirectory/Properties/AndroidManifest.xml)" 
exit
