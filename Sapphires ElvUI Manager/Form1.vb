Imports System.IO
Imports System.IO.Compression


Public Class Form1

    Public Class GV
        Public Shared DownloadVersion
        Public Shared ExceptionData
    End Class

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Check if we have an install path. 
        If My.Settings.PathToWoW = "" Then
            Dim WoWInstallPath = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Blizzard Entertainment\World of Warcraft", "InstallPath", Nothing)

            ' Check if the path is null, and if so, inform the user, then exit.
            If WoWInstallPath = Nothing Then
                MsgBox("Couldn't find a World of Warcraft install. If World of Warcraft is installed, please verify the data in the Blizzard Launcher.")
                Application.Exit()
            End If

            Debug.WriteLine(WoWInstallPath)
            WoWInstallPath = WoWInstallPath + "interface\addons\"
            Debug.WriteLine(WoWInstallPath)
            My.Settings.PathToWoW = WoWInstallPath
            My.Settings.Save()
        End If

        ' Check if ElvUI is installed.
        If My.Computer.FileSystem.DirectoryExists(My.Settings.PathToWoW + "ElvUI") Then
            Debug.WriteLine("ElvUI is installed to: " & My.Settings.PathToWoW + "ElvUI")
            My.Settings.IsElvUIInstalled = True
            My.Settings.Save()
        Else
            Debug.WriteLine("ElvUI install not detected. Settings flags.")
            My.Settings.IsElvUIInstalled = False
            My.Settings.Save()
        End If

        ' Check what version ElvUI is, if installed.
        Try
            If My.Settings.IsElvUIInstalled = True Then
                Dim SearchWithinThis As String = My.Computer.FileSystem.ReadAllText(My.Settings.PathToWoW + "ElvUI\ElvUI.toc")
                Dim SearchForThis As String = "## Version: "
                Dim FirstCharacter As Integer = SearchWithinThis.IndexOf(SearchForThis)
                Dim VersionInfo = SearchWithinThis.Substring(FirstCharacter + 12, 5)
                Dim ErrorChecking = VersionInfo.Substring(1, 3)
                ' Dim ErrorCheck = "No error."
                ' If ErrorChecking.Contains("#") Then
                '     MsgBox("Something went wrong parsing the version number of ElvUI. This should never happen. Please report this to the developer at SapphireExOne@Gmail.com.")
                '     Application.Exit()
                ' Else
                '     ErrorCheck = "# detected in string."
                ' End If
                Debug.WriteLine("First character of the version information is here: " & FirstCharacter)
                Debug.WriteLine("Version information: " & VersionInfo)
                My.Settings.ElvUIVersion = VersionInfo
                My.Settings.Save()
            Else
                My.Settings.IsElvUIInstalled = False
                My.Settings.Save()
            End If
        Catch ex As Exception
        End Try


        CheckForElvUI_PUBLIC_Update()

    End Sub

    Private Sub CheckForElvUI_PUBLIC_Update()
        If My.Settings.IsElvUIInstalled = True Then

            Dim sourceString As String = New System.Net.WebClient().DownloadString("https://www.tukui.org/download.php?ui=elvui")
            '
            Dim FindStart = (sourceString.IndexOf("/downloads/elvui-"))
            FindStart = FindStart + 1
            Dim DownloadHREF = Mid(sourceString, FindStart, 26)
            Dim SubstringFinal = DownloadHREF.Substring(DownloadHREF.Length - 3)

            Dim LatestPublicVersion = DownloadHREF.Substring(17, 5)
            Debug.WriteLine("Latest public version: " & LatestPublicVersion)

            If LatestPublicVersion = My.Settings.ElvUIVersion Then
                MsgBox("There is no update available for the release branch of ElvUI.")
                My.Settings.IsElvUIUpdateAvailable = False
                My.Settings.Save()
            Else
                MsgBox("An update is available from the release branch of ElvUI.")
                My.Settings.IsElvUIUpdateAvailable = True
                My.Settings.Save()
            End If


        Else
            Dim sourceString As String = New System.Net.WebClient().DownloadString("https://www.tukui.org/download.php?ui=elvui")
            '
            Dim FindStart = (sourceString.IndexOf("/downloads/elvui-"))
            FindStart = FindStart + 1
            Dim DownloadHREF = Mid(sourceString, FindStart, 26)
            Dim SubstringFinal = DownloadHREF.Substring(DownloadHREF.Length - 3)

            Dim LatestPublicVersion = DownloadHREF.Substring(17, 5)
            Debug.WriteLine("Latest public version: " & LatestPublicVersion)
            My.Settings.IsElvUIUpdateAvailable = True
            My.Settings.Save()
        End If

    End Sub

    Private Sub CheckForUpdateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CheckForUpdateToolStripMenuItem.Click
        CheckForElvUI_PUBLIC_Update()
    End Sub

    Private Sub Updater(ByRef IsDevelopment)
        DeletePreviousInstall()

        If IsDevelopment = False Then
            UpdateRelease()
        Else
            UpdateDevelopment()
        End If

    End Sub

    Private Sub DeletePreviousInstall()
        If My.Computer.FileSystem.FileExists("C:\Program Files (x86)\SplitSecond\ElvUI_Updater\Elvui.zip") Then
            My.Computer.FileSystem.DeleteFile("C:\Program Files (x86)\SplitSecond\ElvUI_Updater\Elvui.zip")
        End If
        If My.Computer.FileSystem.FileExists("C:\Program Files (x86)\SplitSecond\ElvUI_Updater\ElvuiDEV.zip") Then
            My.Computer.FileSystem.DeleteFile("C:\Program Files (x86)\SplitSecond\ElvUI_Updater\ElvuiDEV.zip")
        End If
        If My.Computer.FileSystem.DirectoryExists("C:\Program Files (x86)\SplitSecond\ElvUI_Updater\ElvUI") Then
            My.Computer.FileSystem.DeleteDirectory("C:\Program Files (x86)\SplitSecond\ElvUI_Updater\ElvUI", FileIO.DeleteDirectoryOption.DeleteAllContents)
        End If
        If My.Computer.FileSystem.DirectoryExists("C:\Program Files (x86)\SplitSecond\ElvUI_Updater\ElvUI_Config") Then
            My.Computer.FileSystem.DeleteDirectory("C:\Program Files (x86)\SplitSecond\ElvUI_Updater\ElvUI_Config", FileIO.DeleteDirectoryOption.DeleteAllContents)
        End If
        If My.Computer.FileSystem.DirectoryExists(My.Settings.PathToWoW + "ElvUI") Then
            My.Computer.FileSystem.DeleteDirectory(My.Settings.PathToWoW + "ElvUI", FileIO.DeleteDirectoryOption.DeleteAllContents)
        End If

        If My.Computer.FileSystem.DirectoryExists(My.Settings.PathToWoW + "ElvUI_Config") Then
            My.Computer.FileSystem.DeleteDirectory(My.Settings.PathToWoW + "ElvUI_Config", FileIO.DeleteDirectoryOption.DeleteAllContents)
        End If

    End Sub
    Private Sub UpdateRelease()
        Dim sourceString As String = New System.Net.WebClient().DownloadString("https://www.tukui.org/download.php?ui=elvui")
        '
        Dim FindStart = (sourceString.IndexOf("/downloads/elvui-"))
        FindStart = FindStart + 1
        Dim DownloadHREF = Mid(sourceString, FindStart, 26)
        Dim SubstringFinal = DownloadHREF.Substring(DownloadHREF.Length - 3)
        If SubstringFinal = "zip" Then
            GV.DownloadVersion = DownloadHREF
            Console.WriteLine("Ended in .zip.")
        Else
            MsgBox("The URL parsed did not end in .zip. This usually indicates a problem with the server, or this program is out of date with ElvUI's download method.")
            GV.ExceptionData = "DOES NOT END IN ZIP"
            Exit Sub
        End If

        If My.Settings.IsElvUIInstalled = True Then
            Dim IsDownloading = False

            My.Computer.Network.DownloadFile("https://www.tukui.org" + GV.DownloadVersion, "C:\Program Files (x86)\SplitSecond\ElvUI_Updater\Elvui.zip") ' Begin the download, and save to our location.
            IsDownloading = True

            ' This will continuously try to move the file (Rename), and if the file is downloading, it will be blocked, preventing IsDownloading from becoming false. 
            While IsDownloading = True
                Try
                    My.Computer.FileSystem.MoveFile("C:\Program Files (x86)\SplitSecond\ElvUI_Updater\Elvui.zip", "C:\Program Files (x86)\SplitSecond\ElvUI_Updater\ElvuiMOVE.zip")
                    IsDownloading = False
                Catch ex As Exception

                End Try
            End While

            My.Computer.FileSystem.MoveFile("C:\Program Files (x86)\SplitSecond\ElvUI_Updater\ElvuiMOVE.zip", "C:\Program Files (x86)\SplitSecond\ElvUI_Updater\Elvui.zip") ' Move it back to the original name.
            ' Extract the downloaded zip to the addons directory. 
            Dim zipPath As String = "C:\Program Files (x86)\SplitSecond\ElvUI_Updater\Elvui.zip"

            ZipFile.ExtractToDirectory(zipPath, My.Settings.PathToWoW)
            MsgBox("Done updating.")

        Else

            Dim IsDownloading = False

            My.Computer.Network.DownloadFile("https://www.tukui.org" + GV.DownloadVersion, "C:\Program Files (x86)\SplitSecond\ElvUI_Updater\Elvui.zip") ' Begin the download, and save to our location.
            IsDownloading = True

            ' This will continuously try to move the file (Rename), and if the file is downloading, it will be blocked, preventing IsDownloading from becoming false. 
            While IsDownloading = True
                Try
                    My.Computer.FileSystem.MoveFile("C:\Program Files (x86)\SplitSecond\ElvUI_Updater\Elvui.zip", "C:\Program Files (x86)\SplitSecond\ElvUI_Updater\ElvuiMOVE.zip")
                    IsDownloading = False
                Catch ex As Exception

                End Try
            End While

            My.Computer.FileSystem.MoveFile("C:\Program Files (x86)\SplitSecond\ElvUI_Updater\ElvuiMOVE.zip", "C:\Program Files (x86)\SplitSecond\ElvUI_Updater\Elvui.zip") ' Move it back to the original name.
            ' Extract the downloaded zip to the addons directory. 
            Dim zipPath As String = "C:\Program Files (x86)\SplitSecond\ElvUI_Updater\Elvui.zip"

            ZipFile.ExtractToDirectory(zipPath, My.Settings.PathToWoW)
            MsgBox("Done updating.")
        End If
    End Sub

    Private Sub UpdateDevelopment()
        If My.Settings.IsElvUIInstalled = True Then

            Dim IsDownloading = False

            My.Computer.Network.DownloadFile("https://git.tukui.org/elvui/elvui/-/archive/development/elvui-development.zip", "C:\Program Files (x86)\SplitSecond\ElvUI_Updater\ElvuiDEV.zip") ' Begin the download, and save to our location.
            IsDownloading = True

            ' This will continuously try to move the file (Rename), and if the file is downloading, it will be blocked, preventing IsDownloading from becoming false. 
            While IsDownloading = True
                Try
                    My.Computer.FileSystem.MoveFile("C:\Program Files (x86)\SplitSecond\ElvUI_Updater\ElvuiDEV.zip", "C:\Program Files (x86)\SplitSecond\ElvUI_Updater\ElvuiMOVE.zip")
                    IsDownloading = False
                Catch ex As Exception

                End Try
            End While

            My.Computer.FileSystem.MoveFile("C:\Program Files (x86)\SplitSecond\ElvUI_Updater\ElvuiMOVE.zip", "C:\Program Files (x86)\SplitSecond\ElvUI_Updater\ElvuiDEV.zip") ' Move it back to the original name.

            ' Extract the downloaded zip to the addons directory. 
            Dim zipPath As String = "C:\Program Files (x86)\SplitSecond\ElvUI_Updater\ElvuiDEV.zip"

            ZipFile.ExtractToDirectory(zipPath, "C:\Program Files (x86)\SplitSecond\ElvUI_Updater\" + "ElvUI")
            My.Computer.FileSystem.MoveDirectory("C:\Program Files (x86)\SplitSecond\ElvUI_Updater\" + "ElvUI\elvui-development\ElvUI", My.Settings.PathToWoW + "ElvUI")
            MsgBox("Done updating.")

        Else

            Dim IsDownloading = False

            My.Computer.Network.DownloadFile("https://git.tukui.org/elvui/elvui/-/archive/development/elvui-development.zip", "C:\Program Files (x86)\SplitSecond\ElvUI_Updater\ElvuiDEV.zip") ' Begin the download, and save to our location.
            IsDownloading = True

            ' This will continuously try to move the file (Rename), and if the file is downloading, it will be blocked, preventing IsDownloading from becoming false. 
            While IsDownloading = True
                Try
                    My.Computer.FileSystem.MoveFile("C:\Program Files (x86)\SplitSecond\ElvUI_Updater\ElvuiDEV.zip", "C:\Program Files (x86)\SplitSecond\ElvUI_Updater\ElvuiMOVE.zip")
                    IsDownloading = False
                Catch ex As Exception

                End Try
            End While

            My.Computer.FileSystem.MoveFile("C:\Program Files (x86)\SplitSecond\ElvUI_Updater\ElvuiMOVE.zip", "C:\Program Files (x86)\SplitSecond\ElvUI_Updater\ElvuiDEV.zip") ' Move it back to the original name.

            ' Extract the downloaded zip to the addons directory. 
            Dim zipPath As String = "C:\Program Files (x86)\SplitSecond\ElvUI_Updater\ElvuiDEV.zip"

            ZipFile.ExtractToDirectory(zipPath, "C:\Program Files (x86)\SplitSecond\ElvUI_Updater\" + "ElvUI")
            My.Computer.FileSystem.MoveDirectory("C:\Program Files (x86)\SplitSecond\ElvUI_Updater\" + "ElvUI\elvui-development\ElvUI", My.Settings.PathToWoW + "ElvUI")
            My.Computer.FileSystem.MoveDirectory("C:\Program Files (x86)\SplitSecond\ElvUI_Updater\" + "ElvUI\elvui-development\ElvUI_Config", My.Settings.PathToWoW + "ElvUI_Config")
            MsgBox("Done updating.")
        End If
    End Sub

    Private Sub InstallWithoutCheckingVersionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InstallWithoutCheckingVersionToolStripMenuItem.Click
        Updater(False)
    End Sub

    Private Sub InstallLatestBuildToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InstallLatestBuildToolStripMenuItem.Click
        Updater(True)
    End Sub

    Private Sub DeveloperCreditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeveloperCreditToolStripMenuItem.Click
        MsgBox("Written by Jake Jensen, 2019" & vbNewLine & "SapphireStab- Zul'Jin")
    End Sub

    Private Sub UninstallElvUIToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UninstallElvUIToolStripMenuItem.Click
        DialogResult = MsgBox("Are you sure?", MsgBoxStyle.YesNo)
        If DialogResult = DialogResult.Yes Then
            DeletePreviousInstall()
        ElseIf DialogResult = DialogResult.No Then
            ' Just do nothing and exit the sub.
            Exit Sub
        End If
    End Sub
End Class
