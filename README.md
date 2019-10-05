# StubbFramework
 Some framework for the games.. will define later. 
 Project will be added as a submodule with the all dependencies to you project.

**To install the framework use**: 

- *git submodule add git@github.com:VirtualMaestro/StubbFramework.git <path/name>*
  
- *git submodule update --init --recursive*

 **To update the framework and all it dependencies use:**
- *git submodule update --recursive*

 **To remove the framework use:**
- *git submodule deinit -f <path/name>;*
- *git rm -f <path/name>;* 
- *git commit -m 'Removed submodule';* 
- *rm -rf .git/modules/<path/name>;*

**Shortcuts for Git** 

You can add these shortcuts to your **.gitconfig**
(under the [alias]) in order to simplify daily routine with submodules:

- *subst = "!f() { git submodule status --recursive;}; f"*
- *suba = "!f() { git submodule add $1 $2; git submodule update --init --recursive;}; f"* 
- *subu = "!f() { git submodule update;}; f"* 
- *subur = "!f() { git submodule update --remote --merge --recursive --force;}; f"* 
- *subrm = "!f() { git submodule deinit -f $1; git rm -f $1; git commit -m 'Removed submodule'; rm -rf .git/modules/$1;}; f"*

**Examples** 

Let's take a look at scenario how to handle all of these
manipulations with shortcuts. Let's say you want to install this
framework for your Unity project (we assume it is under the git), then
you have to place it somewhere in Assets folder. Navigate to your root
folder (one above Assets) and do the following command:

- *git suba git@github.com:VirtualMaestro/StubbFramework.git Assets/Libs/Stubb*

Or just via clone (open git in folder Assets/Libs):
- *git clone --recurse-submodules git@github.com:VirtualMaestro/StubbFramework.git*


That's it. The framework will be added to this folder
'Assets/Libs/Stubb' and all dependencies will be downloaded.

When there is a new version of the Stubbframework and you want to update
it:
- *git subur* 

When there is no needs anymore in this framework you can remove it:
- *git subrm Assets/Libs/Stubb*


**Scenes** 

In order to load scenes need to invoke: 

`World.LoadScenes`