/*=====
<Camera.cs>
���쐬�ҁFyamamoto

�����e
Camera�̋������Ǘ�����X�N���v�g

�����ӎ���
�v���C���[���_�b�V���i�����j����d�l���ǉ����ꂽ�Ƃ��ύX�K�{


���X�V����
Y25   
_M04    
__D     
___11:�v���O�����쐬:yamamoto   //���t:�ύX���e:�{�s��
___27:�J�����ړ��������L�[�ōs���悤�ɕύX:mori

=====*/
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Camera : MonoBehaviour
{
    //�ϐ��錾
    [Header("�^�[�Q�b�g")]
    [SerializeField] private Transform m_Target;

    [Header("�J�����̃I�t�Z�b�g")]
    [SerializeField] private Vector3 m_Offset = new Vector3(0f, 5f, -7f);

    [Header("�J�����̉�]���x")]
    [SerializeField] private float m_RotationSpeed = 100f;

    private float m_Yaw = 0f; // ���������̉�]��

    /*��Start�֐�
    �����F�Ȃ�
    ��
    �ߒl�F�Ȃ�
    ��
    �T�v:������
    */
    private void Start()
    {
        // �^�[�Q�b�g�����ݒ�Ȃ�v���C���[��T���Đݒ�
        if (m_Target == null)
        {
            m_Target = GameObject.FindWithTag("Player").transform;
        }

        m_Yaw = transform.eulerAngles.y; // ���݂�Y���p�x���擾
    }

    /*��LateUpdate�֐�
    �����F�Ȃ�
    ��
    �ߒl�F�Ȃ�
    ��
    �T�v:Update�֐��̌�ɍX�V�����֐�
    */
    void LateUpdate()
    {
        // �����L�[���͂ŃJ������Y����]
        float horizontalInput = 0f;
        if (Input.GetKey(KeyCode.LeftArrow)) horizontalInput = -1f;
        if (Input.GetKey(KeyCode.RightArrow)) horizontalInput = 1f;

        m_Yaw += horizontalInput * m_RotationSpeed * Time.deltaTime;

        // �J�����ʒu���^�[�Q�b�g�̈ʒu�{�I�t�Z�b�g�ɐݒ�
        Vector3 targetPosition = m_Target.position + Quaternion.Euler(0f, m_Yaw, 0f) * m_Offset;
        transform.position = targetPosition;

        // �^�[�Q�b�g����Ɍ���
        transform.LookAt(m_Target.position);
    }
}
