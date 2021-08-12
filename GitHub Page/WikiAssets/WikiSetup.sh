#!/bin/bash

# Wiki Bash Script by John Shull for Automating GitHub/Wiki setup
# chmod +x ~/WikiSetup.sh 
echo VMASC Wiki Setup!
VMASCWIKI="https://github.com/vmasc-capabilities-lab/VMASC-Teams.wiki.git"
VMASCFOLDER="VMASC-Teams.wiki"
PREFIX="origin"
SUFFIX="(fetch)"
REPOPREFIX="https://github.com/vmasc-capabilities-lab/"
REPOSUFFIXADD=".wiki"
GITREMOVE=".git"
GITFIX=".wiki.git"
ROOT=$( cd ../.. && pwd )
FILES=$( cd ../../.. && pwd )
FOLDER="/VMASC-TeamsWiki2020"
DIR="$FILES$FOLDER"
CUSTOMDIR="customWiki"
#Create folder
echo "Create a Directory: $DIR"
if [ ! -d $DIR ]
then
$( mkdir -p $DIR )
fi
GITREMOTE=$( cd $ROOT && git remote -v | head -1)
# fetch/origin remove
GITREMOTE=${GITREMOTE#"$PREFIX"}
GITREMOTE=${GITREMOTE%"$SUFFIX"}
# whitespace before and after remove
GITREMOTE="$(echo -e "${GITREMOTE}" | sed -e 's/^[[:space:]]*//')"
GITREMOTE="$(echo -e "${GITREMOTE}" | sed -e 's/[[:space:]]*$//')"
GITREMOTE=${GITREMOTE%"$GITREMOVE"}
GITLOCAL=${GITREMOTE#"$REPOPREFIX"}
GITLOCAL=$GITLOCAL$REPOSUFFIXADD
GITREMOTE="$GITREMOTE$GITFIX"
echo GIT REMOTE:"$GITREMOTE"
echo GIT LOCAL:"$GITLOCAL"
# Clone the basic wiki repo
$( cd $DIR && git clone $GITREMOTE )
# Create our temp folder
$( cd $DIR && cd $GITLOCAL && mkdir -p $CUSTOMDIR )
$( cd $DIR && cd $GITLOCAL && cd $CUSTOMDIR && git clone $VMASCWIKI)
$( cd $DIR && cd $GITLOCAL && cd $CUSTOMDIR && cd $VMASCFOLDER && rm -r -f .git )
$( cd $DIR && cd $GITLOCAL && $( rm -r -f *.md ) )
$( cd $DIR && cd $GITLOCAL && cd $CUSTOMDIR && cd $VMASCFOLDER && $( mv *.md ../.. ) )
$( cd $DIR && cd $GITLOCAL && $( rm -r -f $CUSTOMDIR ))
$( cd $DIR && cd $GITLOCAL && $( git add . ))
$( cd $DIR && cd $GITLOCAL && $( git commit -m "Cloned VMASC-Teams Wiki into this wiki by magic!" ))
$( cd $DIR && cd $GITLOCAL && $( git push origin))
$( cd && rm -r -f $DIR)
#$SHELL
