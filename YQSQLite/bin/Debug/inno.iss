; 脚本由 Inno Setup 脚本向导 生成！
; 有关创建 Inno Setup 脚本文件的详细资料请查阅帮助文档！

#define MyAppName "舆情报送系统"
#define MyAppVersion "1.2.1"
#define MyAppPublisher "唐山鑫宝网络科技有限公司"
#define MyAppURL "http://tsxinbao.cn/"
#define MyAppExeName "YQSQLite.exe"

[Setup]
; 注: AppId的值为单独标识该应用程序。
; 不要为其他安装程序使用相同的AppId值。
; (生成新的GUID，点击 工具|在IDE中生成GUID。)
AppId={{7F3FA1C5-01B9-46B7-A58E-F36893974FD2}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={pf}\舆情报道系统
DefaultGroupName=舆情报道系统v1.2.1
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
; 注意: 不要在任何共享系统文件上使用“Flags: ignoreversion”

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{group}\{cm:UninstallProgram,{#MyAppName}}"; Filename: "{uninstallexe}"
Name: "{commondesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon
Name: "{userappdata}\Microsoft\Internet Explorer\Quick Launch\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: quicklaunchicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

