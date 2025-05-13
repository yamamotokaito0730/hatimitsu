using UnityEngine;
using System.Collections;

public class FlyToCamera : MonoBehaviour
{
    private Rigidbody rb;
    private UnityEngine.Camera mainCamera;
    private Transform cameraTransform;
    private bool hasReachedTarget = false;

    [Header("�J������O�̋���")]
    [SerializeField] private float stopDistanceFromCamera = 2f;

    [Header("���ł���X�s�[�h")]
    [SerializeField] private float flySpeed = 20f;  // ���x

    [Header("��~���锻�苗��")]
    [SerializeField] private float stopThreshold = 0.2f;

    [Header("��Ԋp�x����")]
    [SerializeField] private float angleOffset = 0.3f;  // ������ɔ�΂����߂̃I�t�Z�b�g

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

        // �J�����̑O���ɏ�����̃I�t�Z�b�g��������
        Vector3 targetPosition = cameraTransform.position + cameraTransform.forward * stopDistanceFromCamera;

        // ������̒���
        targetPosition += cameraTransform.up * angleOffset;

        // ��s�������v�Z
        Vector3 direction = (targetPosition - transform.position).normalized;

        // ��s�J�n
        StartCoroutine(FlyToTarget(targetPosition));
    }

    // �^�[�Q�b�g�ʒu�Ɍ������Ĉړ�����R���[�`��
    private IEnumerator FlyToTarget(Vector3 targetPosition)
    {
        // �I�u�W�F�N�g����s����r����������
        while (Vector3.Distance(transform.position, targetPosition) > stopThreshold)
        {
            Vector3 moveDirection = (targetPosition - transform.position).normalized;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, flySpeed * Time.deltaTime);  // ���x��ύX���Ĉړ�

            yield return null;
        }

        // ���B��̏���
        hasReachedTarget = true;
        transform.position = targetPosition;  // �ڕW�ʒu�Œ�~
        transform.rotation = cameraTransform.rotation;  // �J�����Ɍ�������

        // 1�b��ɃI�u�W�F�N�g���폜
        Destroy(gameObject, 1f);
        Debug.Log("Cube has reached the target and will be destroyed in 1 second.");
    }

    void Update()
    {
        // �ڕW�ʒu�ɓ��B��A�J�����ɒǏ]
        if (hasReachedTarget)
        {
            transform.position = cameraTransform.position + cameraTransform.forward * stopDistanceFromCamera;
            transform.rotation = cameraTransform.rotation;
        }
    }
}
