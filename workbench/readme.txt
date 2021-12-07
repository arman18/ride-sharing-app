In order to resolve Could not store password: An AppArmor policy prevents this sender from sending this message to this recipent. Error in mysql 

--------------The simplest way I found is------------------

1) Go to Ubuntu software center.
2) Search for MySQL workbench community.
3) Click on permission

---------------------------- or try one of the followings------------------
1. gnome-keyring-daemon --start --components=pkcs11
   this command should be successful with SSH_AUTH_SOCK=** output. If it fails try step 2

2. Run sudo gnome-keyring-daemon --start --components=pkcs11
   this command should be successful with SSH_AUTH_SOCK=** output.
