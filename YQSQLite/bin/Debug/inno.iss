; �ű��� Inno Setup �ű��� ���ɣ�
; �йش��� Inno Setup �ű��ļ�����ϸ��������İ����ĵ���

#define MyAppName "���鱨��ϵͳ"
#define MyAppVersion "1.2.1"
#define MyAppPublisher "��ɽ�α�����Ƽ����޹�˾"
#define MyAppURL "http://tsxinbao.cn/"
#define MyAppExeName "YQSQLite.exe"

[Setup]
; ע: AppId��ֵΪ������ʶ��Ӧ�ó���
; ��ҪΪ������װ����ʹ����ͬ��AppIdֵ��
; (�����µ�GUID����� ����|��IDE������GUID��)
AppId={{7F3FA1C5-01B9-46B7-A58E-F36893974FD2}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={pf}\���鱨��ϵͳ
DefaultGroupName=���鱨��ϵͳv1.2.1
OutputDir=C:\Users\Administrator\Desktop\yqinstall
OutputBaseFilename=setup
Compression=lzma
SolidCompression=yes

[Languages]
Name: "chinesesimp"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked; OnlyBelowVersion: 0,6.1
Name: "quicklaunchicon"; Description: "{cm:CreateQuickLaunchIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "E:\YQSQLite\YQSQLite\bin\Debug\YQSQLite.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\YQSQLite\YQSQLite\bin\Debug\FSharp.Core.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\YQSQLite\YQSQLite\bin\Debug\FSharp.Core.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\YQSQLite\YQSQLite\bin\Debug\HtmlAgilityPack.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\YQSQLite\YQSQLite\bin\Debug\HtmlAgilityPack.pdb"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\YQSQLite\YQSQLite\bin\Debug\HtmlAgilityPack.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\YQSQLite\YQSQLite\bin\Debug\ScrapySharp.Core.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\YQSQLite\YQSQLite\bin\Debug\ScrapySharp.Core.pdb"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\YQSQLite\YQSQLite\bin\Debug\ScrapySharp.Core.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\YQSQLite\YQSQLite\bin\Debug\ScrapySharp.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\YQSQLite\YQSQLite\bin\Debug\ScrapySharp.pdb"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\YQSQLite\YQSQLite\bin\Debug\Sonic.HtmlEditor.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\YQSQLite\YQSQLite\bin\Debug\WeifenLuo.WinFormsUI.Docking.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\YQSQLite\YQSQLite\bin\Debug\YQSQLite.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\YQSQLite\YQSQLite\bin\Debug\YQSQLite.exe.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\YQSQLite\YQSQLite\bin\Debug\YQSQLite.pdb"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\YQSQLite\YQSQLite\bin\Debug\YQSQLite.vshost.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\YQSQLite\YQSQLite\bin\Debug\YQSQLite.vshost.exe.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\YQSQLite\YQSQLite\bin\Debug\zoyobar.shared.panzer.IEBrowser.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\YQSQLite\YQSQLite\bin\Debug\Data\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
;Source: "E:\YQSQLite\YQSQLite\bin\Debug\Xml\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
; ע��: ��Ҫ���κι���ϵͳ�ļ���ʹ�á�Flags: ignoreversion��

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{group}\{cm:UninstallProgram,{#MyAppName}}"; Filename: "{uninstallexe}"
Name: "{commondesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon
Name: "{userappdata}\Microsoft\Internet Explorer\Quick Launch\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: quicklaunchicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

