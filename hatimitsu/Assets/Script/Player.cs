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
___27:�v���C���[�̈ړ���AD�L�[�݂̂ɕύX:mori
_M05
___01:���x�ɂ��킹�ďd�͂𑝉����鏈����ǉ�:tooyama

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
    [SerializeField, Tooltip("�f�o�b�O�v���n�u�擾")] private GameObject debugPrefab;

    [Header("�d�͊֌W")]
    [SerializeField, Tooltip("�x�[�X�̏d��")]private float baseGravity = 9.81f;

    [SerializeField, Tooltip("�d�͂̑�����")] private float gravityGainPerKill = 3.0f;

    private float extraGravity;

    private Rigidbody rb;
    private ScoreManager scoreManager;
    private DebugMode debugModeInstance;
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
        rb = GetComponent<Rigidbody>();  // Rigidbody�̎擾
        scoreManager = FindAnyObjectByType<ScoreManager>();
        // ������ԂŃf�o�b�O�\��ON�Ȃ�AUI�𐶐����Ă���
        if (m_bDebugView && debugModeInstance == null)
        {
            GameObject obj = Instantiate(debugPrefab, Vector3.zero, Quaternion.identity);
            debugModeInstance = obj.GetComponent<DebugMode>();
        }

        extraGravity = baseGravity;
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
        rb.linearVelocity = new Vector3(
            transform.forward.x * m_fSpeed,
            rb.linearVelocity.y,         
            transform.forward.z * m_fSpeed
            );
        //rb.linearVelocity = transform.forward * m_fSpeed;
        rb.AddForce(Vector3.down * extraGravity, ForceMode.Acceleration);
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
            if (m_bDebugView && debugModeInstance == null)
            {
                // �v���n�u����C���X�^���X�𐶐����ADebugMode���擾
                GameObject obj = Instantiate(debugPrefab, Vector3.zero, Quaternion.identity); // ���W�E��]�̓v���n�u���Őݒ�
                debugModeInstance = obj.GetComponent<DebugMode>();
            }
            else if (!m_bDebugView && debugModeInstance != null)
            {
                Destroy(debugModeInstance.gameObject); // UI���\��(�폜)����
                debugModeInstance = null;
            }
        }

        if (debugModeInstance != null)
            debugModeInstance.UpdateDebugUI(transform, m_fSpeed, nEnemyKillCount); // �f�o�b�OUI�̍X�V

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
        float rotateSpeed = 100f; // ��]���x

        float turn = 0f;

        if (Input.GetKey(KeyCode.A)) turn = -1f; // ����]
        if (Input.GetKey(KeyCode.D)) turn = 1f;  // �E��]

        if (turn != 0f)
        {
            // Y���𒆐S�ɉ�]������
            transform.Rotate(0f, turn * rotateSpeed * Time.deltaTime, 0f);
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
                AddGravity(m_fBoost);
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

    /*���d�͑����֐�
    �����F�Ȃ�
    ��
    �ߒl�F�Ȃ�
    ��
    �T�v:�����x�����ɍ��킹�ďd�͂𑝉�������
    */
    public void AddGravity(float _boost)
    {
        extraGravity += gravityGainPerKill;
        extraGravity = Mathf.Min(extraGravity, 40f); // ����Ő���
    }
}