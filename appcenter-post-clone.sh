echo TDEVERE
#!/usr/bin/env bash

# Updating Info.plist - version

echo "Updating info.plist!"

echo $BUILD_REPOSITORY_LOCALPATH

echo APPCENTER_BUILD_ID

#PLIST=$BUILD_REPOSITORY_LOCALPATH/"Movez/Supporting\ Files/Info.plist"

#/usr/libexec/PlistBuddy -c "Set :CFBundleShortVersionString 0.13.${APPCENTER_BUILD_ID}" $PLIST

# Print out file for reference

#cat $PLIST

echo "Updated info.plist!"

