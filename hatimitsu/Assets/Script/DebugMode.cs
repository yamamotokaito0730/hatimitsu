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

    [SerializeField] private TextMeshProUGUI speedText;
    [SerializeField] private TextMeshProUGUI posText;
    [SerializeField] private TextMeshProUGUI killCountText;

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
    /*���f�o�b�O�\���֐�
    �����F_Show
    ��
    �ߒl�F�Ȃ�
    ��
    �T�v:�f�o�b�OUI�̕\����\����؂�ւ���
    */
    public void ToggleDebugText(bool _Show)
    {
        // null�`�F�b�N���Ȃ���\��/��\��
        if (speedText != null) speedText.enabled = _Show;
        if (posText != null) posText.enabled = _Show;
        if (killCountText != null) killCountText.enabled = _Show;
    }


}
