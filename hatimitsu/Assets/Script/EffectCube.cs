/*=====
<EffectCube.cs>
└作成者：yamamoto

＞内容
敵死亡時の仮エフェクト

＞注意事項

＞更新履歴
Y25   
_M04    
__D     
___23:プログラムの作成:yamamoto

=====*/

using UnityEngine;

public class EffectCube : MonoBehaviour
{
    [SerializeField, Tooltip("表示時間")] private float m_fLifeTime = 2.0f;
    [SerializeField, Tooltip("カメラ張り付き距離")] private float m_fStickDistance = 0.2f;  // 手前に来る距離を調整
    [SerializeField, Tooltip("左右への広がり幅")] private float m_fSpreadRange = 0.5f; // 横の広がり

    private bool m_bStickToCamera = false;
    private Transform mainCamera;
    private Vector3 m_vTargetOffset;

    public void SetStickToCamera(bool stick)
    {
        m_bStickToCamera = stick;

        if (stick)
        {
            mainCamera = UnityEngine.Camera.main.transform;

            // カメラに向かって飛んでくる方向
            float horizontalOffset = Random.Range(-m_fSpreadRange, m_fSpreadRange);
            Vector3 forward = mainCamera.forward * m_fStickDistance;  // カメラの前方向にオフセットを適用
            Vector3 rightOffset = mainCamera.right * horizontalOffset;

            // カメラの前にオフセットを加えて配置
            m_vTargetOffset = forward + rightOffset;
        }
    }

    private void Update()
    {
        m_fLifeTime -= Time.deltaTime;

        if (m_bStickToCamera && mainCamera != null)
        {
            // 目標位置
            Vector3 targetPos = mainCamera.position + m_vTargetOffset;

            // オブジェクトがカメラの前に固定されるように、進みすぎないように制御
            if (Vector3.Distance(transform.position, mainCamera.position) > m_fStickDistance)
            {
                // 目標位置に吸い寄せる
                transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * 8f);
            }
            else
            {
                // カメラ前に到達したら停止
                transform.position = targetPos;
            }

            // カメラに向かって回転
            transform.rotation = Quaternion.LookRotation(-mainCamera.forward);
        }

        // 表示時間が終わったら破壊
        if (m_fLifeTime <= 0.0f)
        {
            Destroy(gameObject);
        }
    }
}
