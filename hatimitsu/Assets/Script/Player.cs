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

=====*/
using UnityEngine;

public class Player : MonoBehaviour
{
    //変数宣言
    [Header("ステータス")] 
    [SerializeField, Tooltip("移動速度")] private float m_fSpeed;

    private Rigidbody rb;
    private ScoreManager scoreManager;

    /*＞Start関数
    引数：なし
    ｘ
    戻値：なし
    ｘ
    概要:初期化
    */
    void Start()
    {
        rb= GetComponent<Rigidbody>();  //Rigidbodyの取得
        scoreManager=FindAnyObjectByType<ScoreManager>();
    }

    /*＞Update関数
    引数：なし
    ｘ
    戻値：なし
    ｘ
    概要:一定間隔で更新
    */
    void FixedUpdate()
    {
        Move();
        
    }

    //scoreの確認用
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) scoreManager.AddScore(100, 1);
    }

    /*＞移動関数
    引数：なし
    ｘ
    戻値：なし
    ｘ
    概要:プレイヤーの移動関係
    */
    private void Move()
    {
        Vector3 moveDir = Vector3.zero; //移動量保存用

        //キーボード操作
        if (Input.GetKey(KeyCode.W)) moveDir += Vector3.forward;
        if (Input.GetKey(KeyCode.S)) moveDir += Vector3.back;
        if (Input.GetKey(KeyCode.D)) moveDir += Vector3.right;
        if (Input.GetKey(KeyCode.A)) moveDir += Vector3.left;

        //移動処理
        rb.linearVelocity = moveDir.normalized * m_fSpeed;

        // 進行方向に向く処理
        if (moveDir != Vector3.zero)
        {
            Quaternion targetRot = Quaternion.LookRotation(moveDir);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, 10f * Time.fixedDeltaTime);
        }
    }
}
