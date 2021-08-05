# ZoomInClass

[Click here for English README](README.md)

![in-meeting-sample](img/in-meeting.png)

[Zoom](https://zoom.us/) でミーティングを行っている時に、[Discord Rich Presence](https://discord.com/developers/docs/rich-presence/how-to) を使用して表示します。

## Warning

このアプリケーションは、個人的な使用を目的として作成されています。動作の正確性は保証できません。  
また、ミーティングを行っているかどうかは、ウィンドウのタイトルとプロセス名によって 10 秒毎に判断されます。

## Requirements

- Windows 10 (`Version 21H1`, `Build 19043.1110` によって動作確認済)
- .NET Framework 4.8
- Discord 公式クライアント (Tested with `Stable 92214 (db690ab)` によって動作確認済)

## Installation

1. 最新の `ZoomInClass.zip` を [Releases](https://github.com/book000/ZoomInClass/releases) からダウンロードしてください。
2. ダウンロード・展開したファイルを適切なディレクトリに移動します。
3. スタートアップディレクトリ(`shell:startup`)に`ZoomInClass.exe`ファイルへのショートカットを作成します。
4. コンピュータを再起動するか、`ZoomInClass.exe`を起動します。

## Usage

![usage](img/usage.gif)

`ZoomInClass.exe` の実行中に Zoom ミーティングを開始すると、Discord で表示されます。

## Bug Report

- もし、ZoomInClass のバグを見つけた場合は [このリポジトリの GitHub Issue](https://github.com/book000/ZoomInClass/issues/new) で報告してください。
- 報告する際、以下の情報を記載してください:
  - **OS バージョン**: `winver` コマンドで表示されるウィンドウのスクリーンショットまたはテキスト。
  - **Discord クライアントのバージョン**: Discord のユーザー設定の下部にあります。
  - ZoomInClass を起動したとき、Discord はすでに起動させていますか？
  - Discord の設定で、`アクティビティ ステータス` の `最新のアクティビティをステータスに表示する` がオンになっていますか？
  - エラーダイアログが表示されましたか？表示されたなら、そのダイアログのスクリーンショットを撮って添付してください。
- このアプリケーションには、デバッグモードがあります。`ZoomInClass.exe --debug` でコンソールウィンドウを開けます。
- Discord 自体のバグを発見された場合は、[Discord サポート](https://support.discord.com/hc/ja) へご報告ください。

## Disclaimer

開発者は、このプロジェクトを使用するユーザーによって引き起こされた問題について責任を負いません。

## License

このプロジェクトのライセンスは [MIT License](LICENSE) です。
