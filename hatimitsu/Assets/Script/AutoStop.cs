using UnityEngine;

public class AutoStop : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 stopPosition;
    private float delay;

    public void Init(Vector3 _stopPos, float _delay)
    {
        rb = GetComponent<Rigidbody>();
        stopPosition = _stopPos;
        delay = _delay;

        // カメラ方向に向かって飛ばす
        Vector3 dir = (stopPosition - transform.position).normalized;
        float speed = 10f;
        rb.velocity = dir * speed;

        StartCoroutine(MoveAndStop());
    }

    private System.Collections.IEnumerator MoveAndStop()
    {
        yield return new WaitForSeconds(delay);

        rb.velocity = Vector3.zero;
        rb.isKinematic = true;

        // ピッタリ止めたい位置にスナップ
        transform.position = stopPosition;

        // カメラ方向を向く（視線と逆方向に背を向ける＝貼り付くように）
        Transform cam = UnityEngine.Camera.main.transform;
        transform.forward = cam.forward;

        Destroy(this); // スクリプト自身を削除
    }
}
