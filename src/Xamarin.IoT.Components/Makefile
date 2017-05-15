MONO_FRAMEWORK_PREFIX = /Library/Frameworks/Mono.framework/Versions/Current
XBUILD = $(MONO_FRAMEWORK_PREFIX)/bin/xbuild

.PHONY: all configure  debug release package clean

all: debug

configure:
	if [ ! -f ./tools/nuget.exe ]; then \
		mkdir -p tools; \
		echo "nuget.exe not found! downloading latest version"; \
	    curl -O https://dist.nuget.org/win-x86-commandline/latest/nuget.exe; \
	    mv nuget.exe tools/; \
	fi
	echo "Restoring nugets..."
	mono tools/nuget.exe restore ./Xamarin.IoT.Components.sln

debug: configure
	echo "Building project in debug mode"
	msbuild /p:Configuration=Debug ./Xamarin.IoT.Components.sln 
	echo "Finished."

release: configure
	echo "Building project in release mode"
	msbuild /p:Configuration=Release ./Xamarin.IoT.Components.sln 
	echo "Finished."

package: debug
	echo "Generating package addin..."
	mono tools/nuget.exe pack templates/nuget/Xamarin.IoT.Components.Monodroid.nuspec -outputdirectory templates/nuget/packages/
	mono tools/nuget.exe pack templates/nuget/Xamarin.IoT.Components.Raspbian.nuspec -outputdirectory templates/nuget/packages/

clean:
	$(XBUILD) ./Xamarin.IoT.Components.sln /t:Clean

