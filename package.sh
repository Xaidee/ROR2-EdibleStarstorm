#!/usr/bin/env bash

AUTHOR="Xaidee"
PLUGIN="EdibleStarstorm"
PACKAGE_NAME="${AUTHOR}-${PLUGIN}"
BUILD_DIRECTORY="build/${1:-"Release"}"
PACKAGE_DIRECTORY="${BUILD_DIRECTORY}/${PACKAGE_NAME}"

rm -r "${PACKAGE_DIRECTORY}"
mkdir "${PACKAGE_DIRECTORY}"
PATHS_TO_PACKAGE=(
  "${BUILD_DIRECTORY}/${PLUGIN}.dll"
  "manifest.json"
  "LICENSE"
  "README.md"
  "CHANGELOG.md"
  "icon.png"
)
for path in "${PATHS_TO_PACKAGE[@]}"; do
  cp "${path}" "${PACKAGE_DIRECTORY}"
done

#zip "${PACKAGE_NAME}.zip" "${PACKAGE_DIRECTORY}"
