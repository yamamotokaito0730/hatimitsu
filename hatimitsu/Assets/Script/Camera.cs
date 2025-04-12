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

    //[Header("�J�����̒Ǐ]���x")]
    //[SerializeField] private float smoothSpeed = 5f;

    /*��Start�֐�
    �����F�Ȃ�
    ��
    �ߒl�F�Ȃ�
    ��
    �T�v:������
    */
    private void Start()
    {
        //������
        transform.position = m_Target.position;
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
        // �ڕW�̈ʒu�i�^�[�Q�b�g�{�I�t�Z�b�g�j
        Vector3 desiredPosition = m_Target.position + m_Offset;

        // �X���[�Y�ɃJ�������ړ�������i��ԁj�_�b�V���̎��g�p
        //Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        //transform.position = smoothedPosition;

        transform.position = desiredPosition;

        // �^�[�Q�b�g����Ɍ��߂�
        transform.LookAt(m_Target.position);
    }
}
