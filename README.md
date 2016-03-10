## AmpanManMarch
2016年度新入生歓迎会のネタ

キネクトで映像と人間の動きを取得し,
Unity上で関節の動きに合わせ,エフェクトとSEをつけるプロジェクトです。

元ネタ
[http://www.nicovideo.jp/watch/sm21804742](url)

##僕の考えたさいきょーのエフェクト

* 炎
手を上にあげたとき（手のyが頭より上に来たとき）手に炎のエフェクト（パーティクル）をかける。（どちらの手にも対応）  
この状態で、手を重ねたとき（手どうしの距離が一定値以下になった時）炎一つにしのエフェクトを2～4倍にする。  
また、手がある程度傾いたら（xz平面で頭との距離が一定以上になったら）このエフェクトを消す。  

* 水
どちらかの手を横に広げたとき（手のyが腰以上でありかつ腰とのxz平面の距離が一定以上の時）手から水のエフェクト（パーティクル）を出す。  
両手を広げたときは手からだけでなく背景からも水が出るようにする。  

* プラズマ
両手をある程度近づけたとき（手のyが腰以上、頭以下であり、かつ腰とのx座標の距離が一定以下の時）手と手の間に雷のエフェクト（どうすんだよこれ）をかける。  
これは水のエフェクトよりも優先される。  
また、両手を合わせたとき（手どうしの距離が一定値以下になった時）どうしようか。  

* ビーム
手を前に出したとき（z座標において肩との距離が一定以上の時）手からｼｮﾎﾞｲﾋﾞｰﾑ（asset_store)を出す。  
また、これが地面と接触したとき（どうしよう）爆発エフェクト(パーティクル）をかける。  
これは、プラズマよりも優先される。  
また、両手を重ねたとき（ry)マスタースパーク（asset_store)  

* 惑星
両手手を腰に当てたとき（手と腰のry)人の周りに惑星（球体にテクスチャを貼り付けたもの）をいくつか出す。  
そして、それぞれを周回させる（vecter3(cos(フレーム数+定数）,腰のy座標,sin(フレーム数+定数)))。  
一定時間、または腰から手を離した段階で惑星を爆発させる。  

* その他
片足を上げたとき…（ネタ切れ）


##SE
体育館での騒音、および説明時に邪魔になるという観点からマスタースパーク以外にSEは推奨されないと考える。（めんどくさいわけではない）  
他に何かアイデア、反論があった場合各自追加してください。
