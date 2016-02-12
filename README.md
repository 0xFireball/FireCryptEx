# FireCryptEx

The successor to FireCrypt.
Lots of new features, new UI, fresh updates.
Stay tuned, and contribute!

# Build

- Fetch all submodules
- Open the project in a SLN-compatiable IDE. On Windows, use Visual Studio or SharpDevelop. On OS X or Linux, use MonoDevelop/Xamarin Studio.
- Assembly signing is enabled by default, so in order to build, you must create a file called `PluginCore2SNK.snk` in the Aluminum.PluginCore2 subdirectory, or you can disable signing in ALL projects. Use the `Project Options > Signing` menu, or use `sn.exe`
- Create signing keys as per the build errors relating to signing keys. For example, if `demokey.snk` is missing, create this key (or disable signing).
- Build  the project normally.
