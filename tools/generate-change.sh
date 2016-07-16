#!/bin/sh

RED='\033[0;31m'
GREEN='\033[0;32m'
NC='\033[0m'

if grep -q $(git tag -l | grep 'v' | tail -1) ChangeLog.md; then    
  echo "${RED}✗ There is no change log to be generated.${NC}"
  exit 1
else  
    LOG_HEADER="$(head -n 4 ChangeLog.md)\n"

    LOG_BODY="\n---\n\n## [$(git tag -l | grep 'v' | tail -1)](https://github.com/benhallouk/syntactic-docs/tree/$(git tag -l | grep 'v' | tail -1)) - $(date +%Y-%m-%d) \n"

    LOG_BODY="$LOG_BODY\n### :bulb: New Features"
    LOG_BODY="$LOG_BODY\n$(git log --pretty=format:'- [%s](https://github.com/benhallouk/syntactic-docs/commit/%H) %b' --grep 'feat(' | awk -F ':' '{print $0}' | sort $1)\n"

    LOG_BODY="$LOG_BODY\n### :beetle: Fixed Issues"
    LOG_BODY="$LOG_BODY\n$(git log --pretty=format:'- [%s](https://github.com/benhallouk/syntactic-docs/commit/%H) %b' --grep 'fix(' | awk -F ':' '{print $0}' | sort $1)\n"

    LOG_BODY="$LOG_BODY\n### :chart_with_upwards_trend: Test Improvment"
    LOG_BODY="$LOG_BODY\n$(git log --pretty=format:'- [%s](https://github.com/benhallouk/syntactic-docs/commit/%H) %b' --grep 'test(' | awk -F ':' '{print $0}' | sort $1)\n"

    LOG_BODY="$LOG_BODY\n### :thought_balloon: Other Improvment"
    LOG_BODY="$LOG_BODY\n$(git log --pretty=format:'- [%s](https://github.com/benhallouk/syntactic-docs/commit/%H) %b' --grep 'build(\|ci(\|refactor(' | awk -F ':' '{print $0}' | sort $1)\n"

    LOG_OLD_CHANGES="\n$(tail -n +5 ChangeLog.md)"

    echo "$LOG_HEADER$LOG_BODY$LOG_OLD_CHANGES" > ChangeLog.md
    echo "${GREEN}✓ The change log has been successfully generated${NC}"
fi