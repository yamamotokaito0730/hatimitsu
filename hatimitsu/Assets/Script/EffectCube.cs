using UnityEngine;

public class EffectCube : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float stopDistance = 0.5f;

    private Transform cameraTransform;
    private bool moving = false;

    void Start()
    {
        cameraTransform = UnityEngine.Camera.main.transform;
    }

    public void FlyToCamera()
    {
        moving = true;
    }

    void Update()
    {
        if (!moving || cameraTransform == null) return;

        Vector3 direction = cameraTransform.position - transform.position;
        if (direction.magnitude > stopDistance)
        {
            transform.position += direction.normalized * moveSpeed * Time.deltaTime;
        }
        else
        {
            // �J�����̎�O�ɂ҂�����~�߂ē\��t�����悤�Ɍ�����
            Vector3 offset = cameraTransform.forward * -stopDistance;
            transform.position = cameraTransform.position + offset;
            moving = false;
        }
    }
}
