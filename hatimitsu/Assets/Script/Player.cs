/*=====
<Player.cs>
���쐬�ҁFyamamoto

�����e
Player�̋������Ǘ�����X�N���v�g

�����ӎ���
�X�R�A�̃f�o�b�O�p�v���O��������������


���X�V����
Y25   
_M04    
__D     
___11:�v���O�����쐬:yamamoto   
___12:�X�R�A�f�o�b�N�p�̃v���O������ǉ�:yamamoto

=====*/
using UnityEngine;

public class Player : MonoBehaviour
{
    //�ϐ��錾
    [Header("�X�e�[�^�X")] 
    [SerializeField, Tooltip("�ړ����x")] private float m_fSpeed;

    private Rigidbody rb;
    private ScoreManager scoreManager;

    /*��Start�֐�
    �����F�Ȃ�
    ��
    �ߒl�F�Ȃ�
    ��
    �T�v:������
    */
    void Start()
    {
        rb= GetComponent<Rigidbody>();  //Rigidbody�̎擾
        scoreManager=FindAnyObjectByType<ScoreManager>();
    }

    /*��Update�֐�
    �����F�Ȃ�
    ��
    �ߒl�F�Ȃ�
    ��
    �T�v:���Ԋu�ōX�V
    */
    void FixedUpdate()
    {
        Move();
        
    }

    //score�̊m�F�p
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) scoreManager.AddScore(100, 1);
    }

    /*���ړ��֐�
    �����F�Ȃ�
    ��
    �ߒl�F�Ȃ�
    ��
    �T�v:�v���C���[�̈ړ��֌W
    */
    private void Move()
    {
        Vector3 moveDir = Vector3.zero; //�ړ��ʕۑ��p

        //�L�[�{�[�h����
        if (Input.GetKey(KeyCode.W)) moveDir += Vector3.forward;
        if (Input.GetKey(KeyCode.S)) moveDir += Vector3.back;
        if (Input.GetKey(KeyCode.D)) moveDir += Vector3.right;
        if (Input.GetKey(KeyCode.A)) moveDir += Vector3.left;

        //�ړ�����
        rb.linearVelocity = moveDir.normalized * m_fSpeed;

        // �i�s�����Ɍ�������
        if (moveDir != Vector3.zero)
        {
            Quaternion targetRot = Quaternion.LookRotation(moveDir);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, 10f * Time.fixedDeltaTime);
        }
    }
}
