/*=====
<ScoreManager.cs>
���쐬�ҁFyamamoto

�����e
�X�R�A���v�Z����X�N���v�g

�����ӎ���
�G���������Ă��Ȃ��̂ő��݂͂��Ă邾��
ScoreUI���������Ă��Ȃ��̂Ŏ���������X�V���K�v


���X�V����
Y25   
_M04    
__D     
___12:�v���O�����쐬:yamamoto

=====*/
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    static private float m_Score;
    [SerializeField] private TextMeshProUGUI scoreText;

    /*��Start�֐�
    �����F�Ȃ�
    ��
    �ߒl�F�Ȃ�
    ��
    �T�v:������
    */
    void Start()
    {
        // ������
        m_Score = 0;
        UpdateScoreUI();
    }

    /*���X�R�A���Z�֐�
    ����1�Fint _score:���Z����l
    ����1�Ffloat _rate:���Z�{��
    ��
    �ߒl�F�Ȃ�
    ��
    �T�v:�X�R�A���Z���s��
    */
    public void AddScore(int _score,float _rate)
    {
        m_Score += _score * _rate;
        // ScoreUI���Ăяo���X�V������
        UpdateScoreUI();

    }

    /*���X�R�A���Z�֐�
   �����Fint _score:���Z����l
   ��
   �ߒl�F�Ȃ�
   ��
   �T�v:�X�R�A���Z���s��
   */
    public void SubScore(int _score)
    {
        m_Score -= _score;
        // ScoreUI���Ăяo���X�V������
        UpdateScoreUI();
    }

    /*���X�R�AUI�X�V�֐�
   �����F�Ȃ�
   ��
   �ߒl�F�Ȃ�
   ��
   �T�v:UI���X�V����
   */
    private void UpdateScoreUI()
    {
        scoreText.text = "score:"+ m_Score;
    }
}
