using UnityEngine;

public class Player : MonoBehaviour
{   
    [Header("ステータス")] 
    [SerializeField, Tooltip("移動速度")] private float m_fSpeed;

    private Rigidbody rb;

    /*＞Start関数
    引数：なし
    ｘ
    戻値：なし
    ｘ
    概要:初期化
    */
    void Start()
    {
        rb= GetComponent<Rigidbody>();
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


    /*＞移動関数
    引数：なし
    ｘ
    戻値：なし
    ｘ
    概要:プレイヤーの移動関係
    */
    private void Move()
    {
        Vector3 moveDir = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) moveDir += Vector3.forward;
        if (Input.GetKey(KeyCode.S)) moveDir += Vector3.back;
        if (Input.GetKey(KeyCode.D)) moveDir += Vector3.right;
        if (Input.GetKey(KeyCode.A)) moveDir += Vector3.left;

        rb.linearVelocity = moveDir.normalized * m_fSpeed;

        // 進行方向に向く（回転）
        if (moveDir != Vector3.zero)
        {
            Quaternion targetRot = Quaternion.LookRotation(moveDir);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, 10f * Time.fixedDeltaTime);
        }
    }
}
