using UnityEngine;

public class Player : MonoBehaviour
{
    // 変数宣言
    [SerializeField] private float m_fSpeed;
    [SerializeField] private float m_fBoost;
    private Rigidbody rb;
    private ScoreManager scoreManager;
    private DebugMode debugModeInstance;
    private int nEnemyKillCount = 0; // 倒した敵の数

    void Start()
    {
        rb = GetComponent<Rigidbody>();  // Rigidbodyの取得
        scoreManager = FindAnyObjectByType<ScoreManager>();
        debugModeInstance = FindAnyObjectByType<DebugMode>();
    }

    void FixedUpdate()
    {
        // 向いている方向に進み続ける
        rb.velocity = transform.forward * m_fSpeed;
    }

    private void Update()
    {
        // デバッグ用処理
        if (Input.GetKeyDown(KeyCode.Q)) scoreManager.AddScore(100, 1);
        if (Input.GetKeyDown(KeyCode.E)) m_fSpeed += m_fBoost;
        rotation();
    }

    private void rotation()
    {
        float rotateSpeed = 100f; // 回転速度
        float turn = 0f;
        if (Input.GetKey(KeyCode.A)) turn = -1f;
        if (Input.GetKey(KeyCode.D)) turn = 1f;
        if (turn != 0f)
        {
            transform.Rotate(0f, turn * rotateSpeed * Time.deltaTime, 0f);
        }
    }

    // プレイヤーと敵が衝突した際の処理
    private void OnCollisionEnter(Collision collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            Debug.Log("プレイヤーが敵と衝突しました");
            enemy.GenerateEffectCubes();  // エフェクト生成
            nEnemyKillCount++;  // キルカウント
            AddBoost(m_fBoost);  // 速度を増加
        }
    }

    public void AddBoost(float _boost)
    {
        m_fSpeed += _boost;
    }

    public void Die()
    {
        Debug.Log("Player is dead!");
    }
}
