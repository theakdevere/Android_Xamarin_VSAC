#!/usr/bin/env bash
set -ex
NODE_VERSION="8.3.0"
curl "https://nodejs.org/dist/v${NODE_VERSION}/node-v${NODE_VERSION}.pkg" > "$APPCENTER_SOURCE_DIRECTORY/node-installer.pkg" -v

echo TotalSystemMemory
awk '/MemTotal/ { print $2 }' /proc/meminfo
echo TotalSystemMemoryEnd

