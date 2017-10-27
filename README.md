# DiceStg-Online

Clientを実装して戦わせるAIシューティングゲーム。

## 概要
マスのあるフィールド上で、与えられるフィールド情報を元にAIがプレイヤーを動かすシューティングゲームです。  
ゲームはターン制で進行し、各プレイヤーは毎ターン何らかのアクションを行います。  
最後まで生き残ったプレイヤーが勝者となります。  
現在Clientが指定できるアクションは以下の6種類です。
* 上下左右にどちらかに一マス移動
* 移動した方向に弾を撃つ
* 何もしない

## デモ
![dice-stgのデモ用gif](https://github.com/Eulerd/DiceStg-Online/blob/develop/media/dice-stg.gif)

## 要件
DXライブラリ <http://dxlib.o.oo7.jp/> を使用しています。  
C# のプロジェクトのフォルダの、実行ファイルが作成されるフォルダ  
(通常は 「プロジェクトのフォルダ\bin\Debug」 か 「プロジェクトのフォルダ\bin\Release」)に DxLib.dll と DxLib_x64.dll をコピーしてください。  
