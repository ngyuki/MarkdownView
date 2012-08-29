
ちょっとしたメモをテキストファイルで作成するとき、独自の記法でいつも書いていましたが（Lv1見出しは "#" Lv2見出しは"=" とか）、なにかマークアップな記法を使いたかったので **Markdown** を使ってみました。

参考にしたサイト
--------------------------------------------------------------------------------

- [Markdownで文章を書こう！ - ゆーすけべー日記](http://yusukebe.com/archives/20120207/103320.html)
- [blog::2310 » Markdown文法の全訳:](http://blog.2310.net/archives/6)



PHP Markdown
--------------------------------------------------------------------------------

PHP Markdown は PHP で Markdown 記法のテキストから HTML を作成するライブラリです。下記からダウンロード出来ます。

 - [PHP Markdown](http://michelf.com/projects/php-markdown/)

*PHP Markdown* と *PHP Markdown Extra* がありますが、*PHP Markdown Extra* は通常の Markdown に PHP Markdown 特有の記述を追加したもののようです（[PHP Markdown Extra](http://michelf.com/projects/php-markdown/extra/)）。

ダウンロードしたアーカイブに含まれる makedowe.php だけがライブラリのソースなので、このファイルだけインクルードすれば使えます。

	<?php
	require_once 'markdown.php';
	$text = file_get_contents('PHP Markdown Readme.text');
	$html = Markdown($text);
	?>
	<html>
	<head>
	<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
	<title></title>
	</head>
	<body>
	<?php echo $html ?>
	</body>


エディタ（Windows）
--------------------------------------------------------------------------------

下記のエディタを試しました。

- [MarkdownPad](http://markdownpad.com/)
	- 日本語の入力時にIMEの変換窓が変な位置に表示される（入力出来ない訳では無い）

- [MarkPad](http://code52.org/DownmarkerWPF/)
	- エディタのフォントが変えられない
	- 日本語の入力時にIMEの変換窓が変な位置に表示される（入力出来ない訳では無い）
	- 見た目が GUI アプリっぽくなくてなんかイヤ・・・

- [DownMarker](https://bitbucket.org/wcoenen/downmarker/overview)
	- エディタのフォントが変えられない
	- インストールすると問答無用で拡張子が関連付けられる（しかもアンインストールしても戻らない）

- [Gonzo](http://savagelook.com/blog/actionscript3/gonzo-an-open-source-markdown-editor)
	- 日本語がまともに扱えない（AIRアプリなのでAIRの問題かも知れない）

MarkdownPad 以外は余りパッとしませんでした。
MarkdownPad でIMEの変換窓が変な位置に表示されるのさえが我慢出来れば使えそうです。
ただし、エディタ窓とプレビュー窓のスクロール位置の同期に癖があるっぽい感じです（キャレット位置では無くエディタ窓のスクロール位置で同期が取られている）。

ただ、MarkdownPad 自体が、プレーンテキストのままでもそれなりに見れる、ので、普通のエディタで編集して 、HTML化したいときだけ PHP Markdown でも良いかもしれません。
