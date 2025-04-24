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
    [Header("デバッグ")]
    [SerializeField, Tooltip("デバッグ表示")] private bool m_bDebugView = false;

    private Rigidbody rb;
    private ScoreManager scoreManager;
    private DebugMode debugMode;
    private Vector3 moveDir = Vector3.forward; // 現在の進行方向を保持
    private int nEnemyKillCount = 0; // 倒した敵の数


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
        debugMode = FindAnyObjectByType<DebugMode>(); // デバッグクラスの取得

        debugMode.ToggleDebugText(m_bDebugView); // 最初は非表示にする
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

        // デバッグUI表示
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            m_bDebugView = !m_bDebugView; // UIの表示非表示切り替え
            debugMode.ToggleDebugText(m_bDebugView);
        }

        debugMode.UpdateDebugUI(transform.position, m_fSpeed, nEnemyKillCount); // デバッグUIの更新

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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.Die();
                AddBoost(m_fBoost);
                nEnemyKillCount++; // キルカウントの増加
            }
        }
    }

    /*＞加速度増加関数
   引数：なし
   ｘ
   戻値：なし
   ｘ
   概要:プレイヤーの速度をあげる
   */
    public void AddBoost(float _boost)
    {
        m_fSpeed += _boost;
    }
}
