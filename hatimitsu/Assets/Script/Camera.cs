/*=====
<Camera.cs>
└作成者：yamamoto

＞内容
Cameraの挙動を管理するスクリプト

＞注意事項
プレイヤーがダッシュ（加速）する仕様が追加されたとき変更必須


＞更新履歴
Y25   
_M04    
__D     
___11:プログラム作成:yamamoto   //日付:変更内容:施行者

=====*/
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Camera : MonoBehaviour
{
    //変数宣言
    [Header("ターゲット")]
    [SerializeField] private Transform m_Target;

    [Header("カメラのオフセット")]
    [SerializeField] private Vector3 m_Offset = new Vector3(0f, 5f, -7f);

    //[Header("カメラの追従速度")]
    //[SerializeField] private float smoothSpeed = 5f;

    /*＞Start関数
    引数：なし
    ｘ
    戻値：なし
    ｘ
    概要:初期化
    */
    private void Start()
    {
        //初期化
        transform.position = m_Target.position;
    }

    /*＞LateUpdate関数
    引数：なし
    ｘ
    戻値：なし
    ｘ
    概要:Update関数の後に更新される関数
    */
    void LateUpdate()
    {
        // 目標の位置（ターゲット＋オフセット）
        Vector3 desiredPosition = m_Target.position + m_Offset;

        // スムーズにカメラを移動させる（補間）ダッシュの時使用
        //Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        //transform.position = smoothedPosition;

        transform.position = desiredPosition;

        // ターゲットを常に見つめる
        transform.LookAt(m_Target.position);
    }
}
