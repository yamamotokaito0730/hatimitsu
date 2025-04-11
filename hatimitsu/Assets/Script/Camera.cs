using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Camera : MonoBehaviour
{
    [Header("ターゲット")]
    [SerializeField] private Transform m_Target;

    [Header("カメラのオフセット")]
    [SerializeField] private Vector3 m_Offset = new Vector3(0f, 5f, -7f);
    [SerializeField] private float angle;

    [Header("カメラの追従速度")]
    [SerializeField] private float smoothSpeed = 5f;

    private void Start()
    {
        transform.position = m_Target.position;
    }
    void LateUpdate()
    {
        // 目標の位置（ターゲット＋オフセット）
        Vector3 desiredPosition = m_Target.position + m_Offset;

        // スムーズにカメラを移動させる（補間）
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        transform.position = smoothedPosition;

        // ターゲットを常に見つめる
        transform.LookAt(m_Target.position + Vector3.up * angle); // プレイヤーの頭あたりを見る感じ
    }
}
