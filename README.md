これは何？
==============================

Markdown 形式のテキストファイルのプレビューを行う .NET アプリです。

[HatenaSharp](https://github.com/ngyuki/HatenaSharp)をコピペして作ってます。


主要な機能
==============================

#### Markdown プレビュー
Markdown 形式で記述されたテキストファイルをプレビュー表示します。

ファイルをフォームにドラッグアンドドロップするか、コマンドライン引数に指定するかで開けます。

#### CSS
アプリのインストールディレクトリの css/style.css が存在すれば CSS として読み込まれます。

このファイルが無ければ代わりに style.default.css が読まれます。

#### 自動リロード
ツールバーの ![](HatenaView/res/icon/auto.png) を ON にすると、ファイルの更新を監視して自動的に再読み込みします。

#### 手動リロード
ツールバーの ![](HatenaView/res/icon/reload.gif) で手動でリロードを行います。自動リロードとは異なり CSS も再読み込みされます。

#### エクスポート
ツールバーの ![](HatenaView/res/icon/export.png) で HTML を出力します。

### 関連付けを開く
ツールバーの ![](HatenaView/res/icon/edit.png) でファイルに関連付けられたアプリで開きます。

エディタとかを関連付けておくといいかもしれません。

### ブラウザ起動
ツールバーの ![](HatenaView/res/icon/browser.png) でブラウザで開きます。
