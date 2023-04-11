mklink /j Packages ..\WhenTheVersion\Packages
del ..\WhenTheVersion\Packages\Net4x.Serilog.Extensions.Logging.*
rmdir /s /q %userprofile%\.nuget\Packages\Net4x.Serilog.Extensions.Logging
del "src\Serilog.Extensions.Logging\bin\%Configuration%\Net4x.Serilog.Extensions.Logging.*"
MSBuild.exe serilog-extensions-logging.sln -t:clean
MSBuild.exe serilog-extensions-logging.sln -t:restore -p:RestorePackagesConfig=true
MSBuild.exe serilog-extensions-logging.sln -m /property:Configuration=%Configuration% 
git add -A
git commit -a --allow-empty-message -m ''
git push
