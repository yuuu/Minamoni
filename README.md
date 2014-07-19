# Minamoni みんなのモニタリングツール

![スクリーンショット](https://raw.githubusercontent.com/yuuu/Minamoni/master/screenshot/screenshot.png)

## はじめに

- 「Minamoni みんなのモニタリングツール」はETロボコンにおいて走行体の入出力をモニタリングするためのツールです。
- ETロボコンの入門者が走行結果を分析することを想定し、必要最低限のモニタリング機能を実現しました。
- 機能を拡張しやすいようパッケージ間の依存関係を削減する等、工夫しています。

## 動作環境

下記環境にて動作確認済です。

### OS

- Windows 7 Home Premium 64bit

### .Net Framework

- 4.0

### 開発環境

- Microsoft Visual Studio Express 2013 for Windows Desktop
- NUnit 2.6.3

## 使い方

### PC側の準備

1. 「/Minamoni/src/Minamoni.sln」をVisual Studioにて開いてください。
2. 「Tool」プロジェクトをビルドしてください。
3. 「/Minamoni/src/Tool/bin/Debug」に生成される「Minamoni.exe」を起動してください。

### 走行体側の準備

1. 「/Minamoni/lib/MonitorSample」をmakeしてください。
2. 生成されたバイナリを走行体に転送してください。

### PCと走行体の接続

1. 走行体の電源をONしてください。走行体のBluetoothアドレスが表示される画面としてください。(プログラムは起動しない)
2. 「Minamoni.exe」を起動後画面左上の「ポート」ドロップダウンリストから使用するポートを選択ください。
3. 「接続」ボタンをクリックし、数秒待ってください。走行体側に[BT]と表示されるはずです。
4. 走行体のプログラムを起動してください。

### PC側テストコードの実行

走行体側プログラムにはテストコードを付属しています。機能拡張時のデグレ防止に役立ててください。

1. 「/Minamoni/src/Minamoni.sln」をVisual Studioにて開いてください。
2. 「Test」プロジェクトをビルドしてください。
3. 「/Minamoni/src/MInamoniTest.nunit」をNUnitにて開いてください。
4. 「Run」ボタンをクリックしてください。テストが実行されます。

## ライセンス

- 本ツールは無料でお使いいただけます。

- 本ツールによって発生した損害に対して、作者は一切の責任を負いません。

- 本ツールを改編することは自由です。再配布も自由ですが、本ページを紹介いただけると嬉しいです。

## 連絡先

ツールの使い方に関して何か問題・要望などあれば、Issuesへお願い致します。
