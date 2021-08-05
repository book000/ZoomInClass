# ZoomInClass

[日本語の README はこちらから](README-ja.md)

![in-meeting-sample](img/in-meeting.png)

If you are having a meeting in [Zoom](https://zoom.us/), use [Discord Rich Presence](https://discord.com/developers/docs/rich-presence/how-to) to view it in Discord.

## Warning

This application was created for personal use only. We cannot guarantee the accuracy of operation.  
Also, whether or not you are having a meeting is determined every 10 seconds based on the window title and process name.

## Requirements

- Windows 10 (Tested with `Version 1909`, `Build 18363.1316`)
- .NET Framework 4.8
- Discord Official Client (Tested with `Stable 92214 (db690ab)`)

## Installation

1. Download latest `ZoomInClass.zip` from [Releases](https://github.com/book000/ZoomInClass/releases)
2. Move the downloaded / extracted file to an suitable directory.
3. Create a shortcut to the `ZoomInClass.exe` file in your startup directory (`shell:startup`).
4. Restart your Computer or start `ZoomInClass.exe`.

## Usage

![usage](img/usage.gif)

If you start a Zoom Meeting while `ZoomInClass.exe` is running, it will be displayed in Discord.

## Bug Report

- If you find a bug in ZoomInClass, please report it to [GitHub Issues of this repository](https://github.com/book000/ZoomInClass/issues/new).
- When reporting, please provide the following information:
  - **OS version**: Screenshot or text of the window displayed by the `winver` command.
  - **Discord client version**: You can find it at the bottom of Discord user settings.
  - When you start ZoomInClass, is Discord running?
  - In Discord settings, under Activity Status, is Display currect activity as a status message. turned on?
  - Did you see the error dialog? If so, please take a screenshot of the dialog and attach it.
- This application has a debug mode. You can use `ZoomInClass.exe --debug` to open a console window.
- If you find a bug in Discord itself, please report it to [Discord support](https://support.discord.com/hc/en-us).

## Disclaimer

The developer is not responsible for any problems caused by the user using this project.

## License

The license for this project is [MIT License](LICENSE).
