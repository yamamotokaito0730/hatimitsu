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

    [SerializeField] private TextMeshProUGUI speedText;
    [SerializeField] private TextMeshProUGUI posText;
    [SerializeField] private TextMeshProUGUI killCountText;

    /*＞Update関数
    引数：なし
    ｘ
    戻値：なし
    ｘ
    概要:更新関数
    */
    void Update()
    {
        
    }

    /*＞デバッグ更新関数
    引数1：v3_PlayerPos
    引数2：f_Speed
    引数3：n_KillCount 
    ｘ
    戻値：なし
    ｘ
    概要:引数から受け取った数値に各テキストを更新する
    */
    public void UpdateDebugUI(Vector3 v3_PlayerPos, float f_Speed, int n_KillCount)
    {
        posText.text = "Pos" + v3_PlayerPos;
        speedText.text = "Speed" + f_Speed;
        killCountText.text = "Count" + n_KillCount;

    }
    /*＞デバッグ表示関数
    引数1：v3_PlayerPos
    ｘ
    戻値：なし
    ｘ
    概要:デバッグUIの表示非表示を切り替える
    */
    public void ToggleDebugText(bool show)
    {
        // nullチェックしながら表示/非表示
        if (speedText != null) speedText.enabled = show;
        if (posText != null) posText.enabled = show;
        if (killCountText != null) killCountText.enabled = show;
    }


}
