# Copilot code review instructions

Guidance for reviewing pull requests in this repository.

## Project context

- C# / .NET Framework 4.8 Windows Forms app. It shows an active Zoom meeting as a
  Discord Rich Presence status by polling processes every 10 seconds.
- Legacy `packages.config` NuGet style. Dependencies: `DiscordRichPresence`,
  `Newtonsoft.Json`. There are no automated tests and no CI build.

## What to check

- Detection logic in `Form1.cs`: window-title/process-name matches must keep the
  existing self-exclusion (`ProcessName != "ZoomInClass"`), and all Zoom title
  variants (English and Japanese: `Zoom Meeting`, `Zoom Webinar`,
  `Zoom ミーティング`, `Zoom ウェビナー`) should stay consistent when one is changed.
- The per-process loop must not let one process throw out of the whole tick;
  accessing `MainWindowTitle` can throw for some processes, so keep it guarded.
- `DiscordRpcClient` lifecycle: ensure `Dispose()` still runs on form close and
  presence is cleared when no meeting is detected, to avoid a stuck status.
- `README.md` and `README-ja.md` must be updated together when user-facing
  behavior (requirements, detection, `--debug`) changes.

## What NOT to flag

- The hardcoded Discord application ID (`762930592865714216`) is a public client
  identifier, not a secret.
- The hidden-window startup (`Visible = false`, `new Form1()` without a top-level
  form in `Program.cs`) is intentional; this is a background app.
- `Console.WriteLine` diagnostics are intentional and only visible under
  `--debug`; do not ask for a logging framework.
- Designer-generated files (`*.Designer.cs`, `*.resx`) are tool-managed; do not
  request style changes there.

## Conventions

- Code comments and PR descriptions are written in Japanese; keep that style.
