if not Exist %2 mkdir %2
powershell.exe -ex RemoteSigned "C:\tool\ScenarioGenerator\PicklesViaPowerShell.ps1 '%1' '%2' '%3'"
START Chrome %2\index.html