using UnityEngine;
using System.Collections;

public class FlyToCamera : MonoBehaviour
{
    private Rigidbody rb;
    private UnityEngine.Camera mainCamera;
    private Transform cameraTransform;
    private bool hasReachedTarget = false;

    [Header("カメラ手前の距離")]
    [SerializeField] private float stopDistanceFromCamera = 2f;

    [Header("飛んでくるスピード")]
    [SerializeField] private float flySpeed = 20f;  // 速度

    [Header("停止する判定距離")]
    [SerializeField] private float stopThreshold = 0.2f;

    [Header("飛ぶ角度調整")]
    [SerializeField] private float angleOffset = 0.3f;  // 上方向に飛ばすためのオフセット

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = UnityEngine.Camera.main;
        cameraTransform = mainCamera.transform;

        if (mainCamera == null)
        {
            Debug.LogError("Main Camera not found!");
            return;
        }

        // カメラの前方に上向きのオフセットを加える
        Vector3 targetPosition = cameraTransform.position + cameraTransform.forward * stopDistanceFromCamera;

        // 上方向の調整
        targetPosition += cameraTransform.up * angleOffset;

        // 飛行方向を計算
        Vector3 direction = (targetPosition - transform.position).normalized;

        // 飛行開始
        StartCoroutine(FlyToTarget(targetPosition));
    }

    // ターゲット位置に向かって移動するコルーチン
    private IEnumerator FlyToTarget(Vector3 targetPosition)
    {
        // オブジェクトが飛行する途中を見せる
        while (Vector3.Distance(transform.position, targetPosition) > stopThreshold)
        {
            Vector3 moveDirection = (targetPosition - transform.position).normalized;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, flySpeed * Time.deltaTime);  // 速度を変更して移動

            yield return null;
        }

        // 到達後の処理
        hasReachedTarget = true;
        transform.position = targetPosition;  // 目標位置で停止
        transform.rotation = cameraTransform.rotation;  // カメラに向かせる

        // 1秒後にオブジェクトを削除
        Destroy(gameObject, 1f);
        Debug.Log("Cube has reached the target and will be destroyed in 1 second.");
    }

    void Update()
    {
        // 目標位置に到達後、カメラに追従
        if (hasReachedTarget)
        {
            transform.position = cameraTransform.position + cameraTransform.forward * stopDistanceFromCamera;
            transform.rotation = cameraTransform.rotation;
        }
    }
}
