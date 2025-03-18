# SharePointSharedLinkDecoder

A SharePoint Links URL decoder by Andrei-Emilian Rachita


A. The first part is the URL of your tenant and is also the already present main site collection URL

B. This part defines the type of document you are sharing.

b – pdf-files
f – folder
o – Onenote file
p – powerpoint file
t – txt-file
u – web page link, audio files, visio, zip, publisher, mail, and all other file types which have no dedicated letter
v – video files
w – word-document
x – excel-file

C. the third part defines the type of sharing which is being used

s – the file being shared is only to be read, there is no distinction whether the file can be downloaded or not
r – restricted sharing with people which already have access to the file.
D. If the shared file resides in a specific site, the name of that site will be shown here. There is not difference made if the file library is in a site collection top level, or in a subsite

E. A 24-character anonymized reference to the file you want to share. If you shared the item with people who already have access, this is replaced with the path to the file (library/filename).

F. An internal character set to define further details regarding the sharing. If the item was shared to one specific user, the set contains less characters, but an extra parameter ‘email’ is added containing the mail-adress to which is was shared.

E. This parameter section is added by default behind each share-link.

d= xxxx – this will help creating a unique URL to allow opening the file in the browser. If you remove this parameter, you’ll get a download request. This parameter is only added when you share with People with existing access.

Csf=1 – added when sharing with People with existing access

Web=1 – opens the file in the browser

E= xxxx – The purpose of this parameter isn’t really known; if you remove it, the Share will work the same way.
