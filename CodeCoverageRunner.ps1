$dir = pwd

$testResultsDir = "$dir/TestResults/"
If(!(test-path -PathType container $testResultsDir))
{
    New-Item -ItemType Directory -Path $testResultsDir
}
Remove-Item -Recurse -Force $testResultsDir

$output = [string] (& dotnet test ./CleanArchitecture.sln --collect:"XPlat Code Coverage" 2>&1)
Write-Host "Last Exit Code: $lastexitcode"
Write-Host $output

if ($lastexitcode -ne 0) {
    Write-Host "Tests failed. Exiting."
    exit
}

$coverageReportDir = "$dir/CoverageReport/"
If(!(test-path -PathType container $coverageReportDir))
{
    New-Item -ItemType Directory -Path $coverageReportDir
}
Remove-Item -Recurse -Force $coverageReportDir

reportgenerator -reports:"$dir/**/coverage.cobertura.xml" -targetdir:"$dir/CoverageReport" -reporttypes:Html

$osInfo = Get-CimInstance -ClassName Win32_OperatingSystem
if ($osInfo.ProductType -eq 1) {
    & "$dir/CoverageReport/index.html"
}