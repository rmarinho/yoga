#!/bin/sh
if buck --version >/dev/null 2>&1; then true; else
  echo "SKIP: Need to install buck https://buckbuild.com/setup/getting_started.html"
  exit 0
fi
#!/bin/bash

echo "Building Buck!"
brew install ant
cd lib
git clone https://github.com/facebook/buck.git
cd buck
ant
cd ..
cd ..
export ANDROID_NDK=/Users/vagrant/Library/Developer/Xamarin/android-ndk/android-ndk-r11c
lib/buck/bin/buck build //:yoga
lib/buck/bin/buck build //csharp:yoganet-ios
lib/buck/bin/buck build //csharp:yoganet#default,shared
lib/buck/bin/buck build //csharp:yoganet#android-x86,shared
lib/buck/bin/buck build //csharp:yoganet#android-armv7,shared