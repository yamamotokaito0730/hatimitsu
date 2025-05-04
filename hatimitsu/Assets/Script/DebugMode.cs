/*=====
<DebugMode.cs>
���쐬�ҁFtooyama

�����e
�f�o�b�O�p�X�N���v�g
���W
���x
�|�����G�̐�
��̌X��

���̏��ɐ��l��\������

�����ӎ���



���X�V����
Y25   
_M04    
__D     
___24:�v���O�����쐬:tooyama
___28:��̌X�΂��v�����\���o����@�\��ǉ�

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
    [SerializeField] private TextMeshProUGUI groundSlopeText;


    [Header("�f�o�b�O�v���n�u")]
    [SerializeField] private GameObject debugPrefab;

    [Header("���C�L���X�g")]
    [SerializeField, Tooltip("���C�̒���")] private float rayLength = 2.0f;
    [SerializeField, Tooltip("���C�̐F")] private Color normalColor = Color.red;

    /*���f�o�b�O�X�V�֐�
    ����1�F_PlayerTransform
    ����2�F_Speed
    ����3�F_KillCount 
    ��
    �ߒl�F�Ȃ�
    ��
    �T�v:��������󂯎�������l�Ɋe�e�L�X�g���X�V����
    */
    public void UpdateDebugUI(Transform _PlayerTransform, float _Speed, int _KillCount)
    {
        Vector3 _PlayerPos = _PlayerTransform.position;

        posText.text = "Pos" + _PlayerPos; // ���W
        speedText.text = "Speed" + _Speed; // ���x
        killCountText.text = "Count" + _KillCount; // �|�����G�̐�


        RaycastHit hit;
        if (Physics.Raycast(_PlayerPos, Vector3.down, out hit, rayLength))
        {
            Debug.DrawRay(hit.point, hit.normal, normalColor);// �n�ʂ̖@���x�N�g��(�Ԃ���)������

            float slopeAngle = Vector3.Angle(hit.normal, Vector3.up);// �X�Ίp�x���v�Z

            groundSlopeText.text = $"Slope{slopeAngle:F1}��";// �v�Z�����X�΂��ۂ߂ĕ\��

            Debug.DrawLine(_PlayerPos, hit.point, Color.yellow);// �v���C���[�̈ʒu�ƒn�ʂ̃q�b�g�_�����F�����łȂ�
        }
        else
        {
            Debug.DrawRay(_PlayerPos, Vector3.down * rayLength, Color.gray);// �n�ʂɓ������Ă��Ȃ����̓O���[�ŕ\��
        }

    }
}
