/*=====
<EffectCube.cs>
���쐬�ҁFyamamoto

�����e
�G���S���̉��G�t�F�N�g

�����ӎ���

���X�V����
Y25   
_M04    
__D     
___23:�v���O�����̍쐬:yamamoto

=====*/

using UnityEngine;

public class EffectCube : MonoBehaviour
{
    [SerializeField,Tooltip("�\������")] private float m_fLifeTime; // �\������


    /*��Update�֐�
    �����F�Ȃ�
    ��
    �ߒl�F�Ȃ�
    ��
    �T�v:�X�V�֐�
    */
    private void Update()
    {
        m_fLifeTime -= Time.deltaTime;

        if (m_fLifeTime <= 0.0f)
        {
            Destroy(gameObject);
        }
    }
}
