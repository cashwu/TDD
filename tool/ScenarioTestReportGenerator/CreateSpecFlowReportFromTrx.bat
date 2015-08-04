if Exist TestResult.trx del TestResult.trx 

"%ProgramFiles(x86)%\Microsoft Visual Studio 11.0\Common7\IDE\mstest.exe" /testcontainer:%2 /resultsfile:TestResult.trx 

"C:\tool\ScenarioTestReportGenerator\SpecFlow.Net4\SpecFlow.exe" mstestexecutionreport %1 /testResult:TestResult.trx /out:TestResult.html

START Chrome TestResult.html