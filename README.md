MarkdownView
====================================================================================================

これは何？
----------------------------------------------------------------------------------------------------

Markdown ファイルのプレビューを行う .NET アプリです。


ダウンロード
----------------------------------------------------------------------------------------------------

### 最新版

- [MarkdownView-0.0.3.zip](http://sdrv.ms/106rku7)


### アーカイブ

- [MarkdownView - SkyDrive](http://sdrv.ms/18ftDRY)


### アーカイブ(旧)

- [MarkdownView - GitHub](https://github.com/ngyuki/MarkdownView/downloads)


インストール
----------------------------------------------------------------------------------------------------

適当なフォルダにダウンロードした zip ファイルを解凍してください。


動作環境
----------------------------------------------------------------------------------------------------

 - Windows 7
 - Internet Explorer 9
 - .NET Framework 3.5

※ これ以外の環境でも動作するかもしれませんが動作確認はしていません


ファイルの開き方
----------------------------------------------------------------------------------------------------

下記のいずれかの方法でファイルを開くことが出来ます。

 - アプリのウィンドウにファイルをドラッグアンドドロップする
 - アプリのコマンドライン引数にファイル名を指定する


主な機能
----------------------------------------------------------------------------------------------------

### 自動リロード
ファイルの更新を監視して自動的に再読み込みします。

### エクスポート
開いているファイルを HTML に変換して保存します。

### リロード
ファイルを再読み込みします。自動リロードとは異なり CSS も再読み込みします。

### 関連付けを開く
開いているファイルを関連付けられたアプリで開きます。
エディタとかを関連付けておくと便利です。

### ブラウザで表示
開いているファイルを HTML に変換してブラウザで開きます。

### API
ON にすると Markdown ファイルの変換に WebAPI が使用されます。
「ファイル」メニューの「WebAPI の URL」で WebAPI のURL を設定しておく必要があります。


CSS ファイルの利用
----------------------------------------------------------------------------------------------------

アプリのインストール先の css フォルダから次の優先順位で CSS を検索し、最初に見つかった CSS を使用します。

 1. style.css
 2. style.default.css

style.default.css はアプリにバンドルされているため、バージョンアップで上書きされます。
独自の CSS を使う場合は style.css を手動で作成してください。


WebAPI の利用
----------------------------------------------------------------------------------------------------

### WebAPI の URL

[GitHub Markdown API](http://developer.github.com/v3/markdown/) が使えたかもしれません。
ただしファイルの保存毎に API を呼ぶのですぐにリクエスト上限になります。

[redcarpet-preview](https://github.com/ngyuki/redcarpet-preview) を自分でどこかにホストして使うといいかもしれません。

Heroku でホストしたものがあるので、この URL を設定すればそのまま使うことが出来ます（ただし遅いです）。

```
http://redcarpet-preview.herokuapp.com/markdown/raw
```

### WebAPI 使用時の CSS ファイル

WebAPI 使用時は通常の CSS とは別の CSS が使用されます。次の優先順位でインストール先の css フォルダから読み込みます。

 1. webapi.css
 2. webapi.default.css
