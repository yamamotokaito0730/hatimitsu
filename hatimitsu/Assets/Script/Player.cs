/*=====
<Player.cs>
└作成者：yamamoto

＞内容
Playerの挙動を管理するスクリプト

＞注意事項
スコアのデバッグ用プログラムを消すこと


＞更新履歴
Y25   
_M04    
__D     
___11:プログラム作成:yamamoto   
___12:スコアデバック用のプログラムを追加:yamamoto
___22:移動の仕様変更:yamamoto

=====*/

using UnityEngine;

public class Player : MonoBehaviour
{
    // 変数宣言
    [Header("ステータス")] 
    [SerializeField, Tooltip("移動速度")] private float m_fSpeed;
    [SerializeField, Tooltip("加速")] private float m_fBoost;

    private Rigidbody rb;
    private ScoreManager scoreManager;
    private Vector3 moveDir = Vector3.forward; // 現在の進行方向を保持

    /*＞Start関数
    引数：なし
    ｘ
    戻値：なし
    ｘ
    概要:初期化
    */
    void Start()
    {
        rb= GetComponent<Rigidbody>();  // Rigidbodyの取得
        scoreManager=FindAnyObjectByType<ScoreManager>();
    }

    /*＞FixedUpdate関数
    引数：なし
    ｘ
    戻値：なし
    ｘ
    概要:一定間隔で更新
    */
    void FixedUpdate()
    {
        // 向いている方向に進み続ける
        rb.linearVelocity = transform.forward * m_fSpeed;

    }

    /*＞Update関数
    引数：なし
    ｘ
    戻値：なし
    ｘ
    概要:更新関数
    */

    private void Update()
    {
        //////////////////////////////////////////////////////////
        //デバッグ用
        if (Input.GetKeyDown(KeyCode.Q)) scoreManager.AddScore(100, 1); // スコア加算用　*必要か分からん
        if (Input.GetKeyDown(KeyCode.E)) m_fSpeed += m_fBoost; // 加速デバッグ用
        ////////////////////////////////////////////////////
        rotation();
    }

    /*＞回転関数
    引数：なし
    ｘ
    戻値：なし
    ｘ
    概要:プレイヤーの向きを回転させる
    */
    private void rotation()
    {
        // 入力によって進行方向を更新
        Vector3 inputDir = Vector3.zero;
        if (Input.GetKey(KeyCode.W)) inputDir += Vector3.forward;
        if (Input.GetKey(KeyCode.S)) inputDir += Vector3.back;
        if (Input.GetKey(KeyCode.D)) inputDir += Vector3.right;
        if (Input.GetKey(KeyCode.A)) inputDir += Vector3.left;

        if (inputDir != Vector3.zero)
        {
            moveDir = inputDir.normalized;

            // 入力に合わせて向きを変える
            Quaternion targetRot = Quaternion.LookRotation(moveDir);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, 10f * Time.deltaTime);
        }
    }
}
