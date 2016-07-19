$NewLine = [Environment]::NewLine
$ChangeVersion = git tag -l | Where-Object {$_ -like 'v*.*.*'} | select -last 1
$ChangeExist = Get-Content ChangeLog.md | Where-Object {$_ -like "*"+$ChangeVersion+"*"}

if($ChangeExist){
    Write-Host "There is no change log to be generated" -foreground "Yellow"
    exit 1
}
else{
    $LOG_HEADER = Get-Content ChangeLog.md | select -first 4

    $LOG_BODY = $NewLine+"---"+$NewLine+$NewLine+"## ["+$ChangeVersion+"](https://github.com/benhallouk/syntactic-docs/tree/$"+$ChangeVersion+") - " + $(Get-Date -format "yyyy-MM-dd").ToString() + $NewLine
    
    $LOG_BODY += $NewLine + "### :bulb: New Features"
    $LOG_BODY += $NewLine + $(git log --pretty=format:'- [%s](https://github.com/benhallouk/syntactic-docs/commit/%H) %b'  | where {$_ -like '- `[feat(*):*'} | Out-String)

    $LOG_BODY += $NewLine + $NewLine + "### :beetle: Fixed Issues"
    $LOG_BODY += $NewLine + $(git log --pretty=format:'- [%s](https://github.com/benhallouk/syntactic-docs/commit/%H) %b'   | where {$_ -like '- `[fix(*):*'} | Out-String)

    $LOG_BODY += $NewLine + $NewLine + "### :chart_with_upwards_trend: Test Improvment"
    $LOG_BODY += $NewLine + $(git log --pretty=format:'- [%s](https://github.com/benhallouk/syntactic-docs/commit/%H) %b'   | where {$_ -like '- `[test(*):*'} | Out-String)

    $LOG_BODY += $NewLine + $NewLine + "### :thought_balloon: Other Improvment"
    $LOG_BODY += $NewLine + $(git log --pretty=format:'- [%s](https://github.com/benhallouk/syntactic-docs/commit/%H) %b'   | where { ($_ -like '- `[build(*):*') -or ($_ -like '- `[ci(*):*') -or ($_ -like '- `[refactor(*):*') } | Out-String)
    
    
    $LOG_OLD_CHANGES = $NewLine + $(Get-Content ChangeLog.md | select -skip 4 | Out-String)

    $LOG_HEADER+$LOG_BODY+$LOG_OLD_CHANGES > ChangeLog.md

    Write-Host "The change log has been successfully generated"  -foreground "Green"
}
