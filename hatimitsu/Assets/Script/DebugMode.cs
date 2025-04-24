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

    /*��Update�֐�
    �����F�Ȃ�
    ��
    �ߒl�F�Ȃ�
    ��
    �T�v:�X�V�֐�
    */
    void Update()
    {
        
    }

    /*���f�o�b�O�X�V�֐�
    ����1�Fv3_PlayerPos
    ����2�Ff_Speed
    ����3�Fn_KillCount 
    ��
    �ߒl�F�Ȃ�
    ��
    �T�v:��������󂯎�������l�Ɋe�e�L�X�g���X�V����
    */
    public void UpdateDebugUI(Vector3 v3_PlayerPos, float f_Speed, int n_KillCount)
    {
        posText.text = "Pos" + v3_PlayerPos;
        speedText.text = "Speed" + f_Speed;
        killCountText.text = "Count" + n_KillCount;

    }
    /*���f�o�b�O�\���֐�
    ����1�Fv3_PlayerPos
    ��
    �ߒl�F�Ȃ�
    ��
    �T�v:�f�o�b�OUI�̕\����\����؂�ւ���
    */
    public void ToggleDebugText(bool show)
    {
        // null�`�F�b�N���Ȃ���\��/��\��
        if (speedText != null) speedText.enabled = show;
        if (posText != null) posText.enabled = show;
        if (killCountText != null) killCountText.enabled = show;
    }


}
