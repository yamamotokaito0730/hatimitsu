/*=====
<DebugMode.cs>
└作成者：tooyama

＞内容
デバッグスクリプト

＞注意事項



＞更新履歴
Y25   
_M04    
__D     
___24:プログラム作成:tooyama

=====*/
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DebugMode : MonoBehaviour 
{
    [Header("デバッグテキスト")]
    [SerializeField] private TextMeshProUGUI speedText;
    [SerializeField] private TextMeshProUGUI posText;
    [SerializeField] private TextMeshProUGUI killCountText;

    [Header("デバッグプレハブ")]
    [SerializeField] private GameObject debugPrefab; 

    /*＞デバッグ更新関数
    引数1：_PlayerPos
    引数2：_Speed
    引数3：_KillCount 
    ｘ
    戻値：なし
    ｘ
    概要:引数から受け取った数値に各テキストを更新する
    */
    public void UpdateDebugUI(Vector3 _PlayerPos, float _Speed, int _KillCount)
    {
        posText.text = "Pos" + _PlayerPos;
        speedText.text = "Speed" + _Speed;
        killCountText.text = "Count" + _KillCount;

    }
}
