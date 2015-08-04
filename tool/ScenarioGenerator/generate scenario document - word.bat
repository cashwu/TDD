if not Exist %2 mkdir %2
powershell.exe -ex RemoteSigned "C:\tool\ScenarioGenerator\PicklesViaPowerShell.ps1 '%1' '%2' '%3'"
START "Microsoft Office Word 2007" %2\features.docx