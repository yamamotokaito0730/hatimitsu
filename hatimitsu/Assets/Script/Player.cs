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
___22:�ړ��̎d�l�ύX:yamamoto

=====*/

using UnityEngine;

public class Player : MonoBehaviour
{
    // �ϐ��錾
    [Header("�X�e�[�^�X")] 
    [SerializeField, Tooltip("�ړ����x")] private float m_fSpeed;
    [SerializeField, Tooltip("����")] private float m_fBoost;
    [Header("�f�o�b�O")]
    [SerializeField, Tooltip("�f�o�b�O�\��")] private bool m_bDebugView = false;

    private Rigidbody rb;
    private ScoreManager scoreManager;
    private DebugMode debugMode;
    private Vector3 moveDir = Vector3.forward; // ���݂̐i�s������ێ�
    private int nEnemyKillCount = 0; // �|�����G�̐�


    /*��Start�֐�
    �����F�Ȃ�
    ��
    �ߒl�F�Ȃ�
    ��
    �T�v:������
    */
    void Start()
    {
        rb= GetComponent<Rigidbody>();  // Rigidbody�̎擾
        scoreManager=FindAnyObjectByType<ScoreManager>();
        debugMode = FindAnyObjectByType<DebugMode>(); // �f�o�b�O�N���X�̎擾

        debugMode.ToggleDebugText(m_bDebugView); // �ŏ��͔�\���ɂ���
    }

    /*��FixedUpdate�֐�
    �����F�Ȃ�
    ��
    �ߒl�F�Ȃ�
    ��
    �T�v:���Ԋu�ōX�V
    */
    void FixedUpdate()
    {
        // �����Ă�������ɐi�ݑ�����
        rb.linearVelocity = transform.forward * m_fSpeed;
    }

    /*��Update�֐�
    �����F�Ȃ�
    ��
    �ߒl�F�Ȃ�
    ��
    �T�v:�X�V�֐�
    */

    private void Update()
    {
        //////////////////////////////////////////////////////////
        //�f�o�b�O�p
        if (Input.GetKeyDown(KeyCode.Q)) scoreManager.AddScore(100, 1); // �X�R�A���Z�p�@*�K�v���������
        if (Input.GetKeyDown(KeyCode.E)) m_fSpeed += m_fBoost; // �����f�o�b�O�p

        // �f�o�b�OUI�\��
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            m_bDebugView = !m_bDebugView; // UI�̕\����\���؂�ւ�
            debugMode.ToggleDebugText(m_bDebugView);
        }

        debugMode.UpdateDebugUI(transform.position, m_fSpeed, nEnemyKillCount); // �f�o�b�OUI�̍X�V

        ////////////////////////////////////////////////////

        rotation();
    }

    /*����]�֐�
    �����F�Ȃ�
    ��
    �ߒl�F�Ȃ�
    ��
    �T�v:�v���C���[�̌�������]������
    */
    private void rotation()
    {
        // ���͂ɂ���Đi�s�������X�V
        Vector3 inputDir = Vector3.zero;
        if (Input.GetKey(KeyCode.W)) inputDir += Vector3.forward;
        if (Input.GetKey(KeyCode.S)) inputDir += Vector3.back;
        if (Input.GetKey(KeyCode.D)) inputDir += Vector3.right;
        if (Input.GetKey(KeyCode.A)) inputDir += Vector3.left;

        if (inputDir != Vector3.zero)
        {
            moveDir = inputDir.normalized;

            // ���͂ɍ��킹�Č�����ς���
            Quaternion targetRot = Quaternion.LookRotation(moveDir);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, 10f * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.Die();
                AddBoost(m_fBoost);
                nEnemyKillCount++; // �L���J�E���g�̑���
            }
        }
    }

    /*�������x�����֐�
   �����F�Ȃ�
   ��
   �ߒl�F�Ȃ�
   ��
   �T�v:�v���C���[�̑��x��������
   */
    public void AddBoost(float _boost)
    {
        m_fSpeed += _boost;
    }
}
