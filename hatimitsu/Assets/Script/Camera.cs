using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Camera : MonoBehaviour
{
    [Header("�^�[�Q�b�g")]
    [SerializeField] private Transform m_Target;

    [Header("�J�����̃I�t�Z�b�g")]
    [SerializeField] private Vector3 m_Offset = new Vector3(0f, 5f, -7f);

    [Header("�J�����̒Ǐ]���x")]
    [SerializeField] private float smoothSpeed = 5f;

    private void Start()
    {
        transform.position = m_Target.position;
    }
    void LateUpdate()
    {
        // �ڕW�̈ʒu�i�^�[�Q�b�g�{�I�t�Z�b�g�j
        Vector3 desiredPosition = m_Target.position + m_Offset;

        // �X���[�Y�ɃJ�������ړ�������i��ԁj�_�b�V���̎��g�p
        //Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        //transform.position = smoothedPosition;

        transform.position = desiredPosition;
        // �^�[�Q�b�g����Ɍ��߂�
        transform.LookAt(m_Target.position); // �v���C���[�̓�����������銴��
    }
}
