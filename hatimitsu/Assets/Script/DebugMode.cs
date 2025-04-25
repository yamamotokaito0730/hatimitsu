/*=====
<DebugMode.cs>
���쐬�ҁFtooyama

�����e
�f�o�b�O�X�N���v�g

�����ӎ���



���X�V����
Y25   
_M04    
__D     
___24:�v���O�����쐬:tooyama

=====*/
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DebugMode : MonoBehaviour 
{
    [Header("�f�o�b�O�e�L�X�g")]
    [SerializeField] private TextMeshProUGUI speedText;
    [SerializeField] private TextMeshProUGUI posText;
    [SerializeField] private TextMeshProUGUI killCountText;

    [Header("�f�o�b�O�v���n�u")]
    [SerializeField] private GameObject debugPrefab; 

    /*���f�o�b�O�X�V�֐�
    ����1�F_PlayerPos
    ����2�F_Speed
    ����3�F_KillCount 
    ��
    �ߒl�F�Ȃ�
    ��
    �T�v:��������󂯎�������l�Ɋe�e�L�X�g���X�V����
    */
    public void UpdateDebugUI(Vector3 _PlayerPos, float _Speed, int _KillCount)
    {
        posText.text = "Pos" + _PlayerPos;
        speedText.text = "Speed" + _Speed;
        killCountText.text = "Count" + _KillCount;

    }
}
