# GEMINI.md

## 目的
- Gemini CLI 向けのコンテキストと作業方針を定義する。

## 出力スタイル
- 言語: 日本語
- トーン: 簡潔で事実ベース
- 形式: Markdown

## 共通ルール
- 会話は日本語で行う。
- PR とコミットは Conventional Commits に従う。
- PR タイトルとコミット本文の言語: PR タイトルは Conventional Commits 形式（英語推奨）。PR 本文は日本語。コミットは Conventional Commits 形式（description は日本語）。
- 日本語と英数字の間には半角スペースを入れる。

## プロジェクト概要
Discord Rich Presence integration for Zoom meetings. Displays current Zoom meeting status in Discord by monitoring Zoom window/process activity.

### 技術スタック
- **言語**: C#, .NET Framework
- **フレームワーク**: .NET Framework 4.8, Windows Forms
- **パッケージマネージャー**: NuGet
- **主要な依存関係**:
  - DiscordRichPresence 1.0.175
  - Newtonsoft.Json 13.0.1

## コーディング規約
- フォーマット: 既存設定（ESLint / Prettier / formatter）に従う。
- 命名規則: 既存のコード規約に従う。
- コメント言語: 日本語
- エラーメッセージ: 英語

### 開発コマンド
```bash
# install
Download ZoomInClass.zip from Releases

# dev
Open ZoomInClass.sln in Visual Studio

# build
dotnet build ZoomInClass.sln

# test
Manual testing with Zoom + Discord

```

## 注意事項
- 認証情報やトークンはコミットしない。
- ログに機密情報を出力しない。
- 既存のプロジェクトルールがある場合はそれを優先する。

## リポジトリ固有
- **type**: Desktop Application / Windows Utility
**platforms:**
  - Windows 10+
- **debug_mode**: Supported via --debug flag
- **auto_update**: Built-in auto-update on launch
- **status**: Personal use only - no guarantee of accuracy
- **update_interval**: 10-second polling for window title/process check