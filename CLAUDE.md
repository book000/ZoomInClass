# CLAUDE.md

## Overview

ZoomInClass is a Windows-only tray/background utility that shows a Zoom meeting
as a Discord Rich Presence status ("In Meeting"). It polls running processes
once a second and decides whether a Zoom meeting is active from window titles
and process names. Personal-use tool; accuracy is not guaranteed.

## Tech stack

- C# / .NET Framework 4.8, Windows Forms (`OutputType` is `WinExe`).
- NuGet via the legacy `packages.config` style (not PackageReference):
  - `DiscordRichPresence` 1.0.175 (`DiscordRPC`)
  - `Newtonsoft.Json` 13.0.1
- Single project solution: `ZoomInClass.sln` → `ZoomInClass/ZoomInClass.csproj`.

## Build

- Open `ZoomInClass.sln` in Visual Studio (2019+), or build from the command
  line with MSBuild (the classic `.csproj` does not build with `dotnet build`):
  - `nuget restore ZoomInClass.sln` (restore `packages/` first)
  - `msbuild ZoomInClass.sln /p:Configuration=Release`
- Output: `ZoomInClass/bin/<Configuration>/ZoomInClass.exe`.

## Run / debug

- Run `ZoomInClass.exe`; the form is hidden (`Visible = false`, no taskbar entry)
  and runs in the background.
- `ZoomInClass.exe --debug` calls `AllocConsole()` to open a console window and
  streams `Console.WriteLine` diagnostics. Use this to inspect detection state.
- Discord must be running and its "display current activity" setting enabled,
  otherwise `DiscordRpcClient.Initialize()` fails and the app shows an error.

## Architecture / key files

- `ZoomInClass/Program.cs`: entry point. Registers `Application.ThreadException`
  and `AppDomain.UnhandledException` handlers that show an error dialog and offer
  to open the GitHub issue page. Note it starts the app via `new Form1()` +
  `Application.Run()` (no top-level form), so the process has no visible window.
- `ZoomInClass/Form1.cs`: core logic. Builds the `DiscordRpcClient` (hardcoded
  Discord application ID `762930592865714216`), and `timer1_Tick` runs the
  once-a-second poll: it flags a meeting when a process window title contains
  `Zoom Meeting` / `Zoom Webinar` / `Zoom ミーティング` / `Zoom ウェビナー`, or the
  process name equals `CptHost`, while excluding `ZoomInClass` itself.
- `ZoomInClass/Form1.Designer.cs`: designer-generated; the `timer1` interval
  (1000 ms) lives here. Regenerate via the WinForms designer, do not hand-edit.

## Conventions

- Existing code comments and commit history are in Japanese; match the file you
  are editing.
- Timer interval / detection strings are the main knobs; changing the polling
  cadence means editing `timer1.Interval` in the designer file.
- Swallow-and-log is the existing pattern inside the poll loop (per-process
  `try/catch` writing to the console); keep the loop resilient to a single
  process throwing (e.g. access-denied on `MainWindowTitle`).

## Testing

- No automated tests and no CI build (only `.github/FUNDING.yml` exists).
- Verify manually on Windows: start a Zoom meeting (or rename a window to match a
  detection string) with `--debug`, and confirm the Discord status updates and
  `isZoomClassing: True` is logged.

## Documentation update rules

- User-facing behavior changes (detection rules, requirements, debug flag) must
  be reflected in both `README.md` and `README-ja.md` (they are kept in sync).
- Update this file when the build/run commands, dependencies, or the detection
  logic in `Form1.cs` change.

## Security

- Do not commit secrets. The Discord application ID is a public client
  identifier, not a secret; there is no token stored in the repo.
