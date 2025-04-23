/*=====
<Enemy.cs>
���쐬�ҁFyamamoto

�����e
Enemy�̋������Ǘ�����X�N���v�g

�����ӎ���

���X�V����
Y25   
_M04    
__D     
___23:�v���O�����쐬:yamamoto

=====*/

using UnityEngine;

public class Enemy : MonoBehaviour
{

    [Header("�G�t�F�N�g")]
    [SerializeField, Tooltip("�v���n�u")] private GameObject m_EffectCube;       // �G�t�F�N�g�L���[�u�v���n�u
    [SerializeField, Tooltip("������")] private int m_nEffectNum;              // �G�t�F�N�g�L���[�u������
    [SerializeField,Tooltip("�͈�")] private float m_fPosRandRange;  // �G�t�F�N�g�L���[�u�𐶐�����|�W�V�����������_���ɐ������邽�߂͈̔�

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*�����Ŋ֐�
    �����F�Ȃ�
    ��
    �ߒl�F�Ȃ�
    ��
    �T�v:���̓G�����ł�����
    */
    public void Die()
    {
        float x, y, z = 0.0f;

        // �G�t�F�N�g�L���[�u����
        for (int i = 0; i < m_nEffectNum; i++)
        {
            x = Random.Range(-m_fPosRandRange, m_fPosRandRange);
            y = Random.Range(-m_fPosRandRange, m_fPosRandRange);
            z = Random.Range(-m_fPosRandRange, m_fPosRandRange);

            Instantiate(m_EffectCube, new Vector3(transform.position.x + x, transform.position.y + y, transform.position.z + z), Quaternion.identity);
        }

        Destroy(gameObject);
    }
}
