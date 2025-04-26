/*=====
<CodingRule.cs> //�X�N���v�g��
���쐬�ҁFyamamoto

�����e
�R�[�f�B���O�K����L�q

�����ӎ���   // �Ȃ��Ƃ��͏ȗ�OK
���̋K�񏑂ɋL�q�̂Ȃ����͔̂�������A�K�X�ǉ�����

���X�V����
Y25   //'25�N
_M04    //04��
__D       //��
___11:�v���O�����쐬:yamamoto   //���t:�ύX���e:�{�s��
___22://�̌�ɋ󔒂�ǉ�:yamamoto

=====*/
using System;
using UnityEngine;

// ���O��Ԓ�`
namespace Space
{
    // �N���X��`
    public static class CSpace
    {
        // �萔��`
        private const uint CONST = 0;    // ���u����fps�l

        // �ϐ��錾
        public static readonly double ms_Temp = 0.0d;   // readonly�ȕϐ����������͓���
    }
}

// �C���^�[�t�F�[�X��`
public interface IInterface // �C���^�[�t�F�[�X�̓�������I������
{
    // �v���p�e�B��`
    public double Prop { get; set; }    // ���������v���p�e�B�̓n���K���A���L�@�𖳎����Ă悢

    // �v���g�^�C�v�錾
    public void Signaled();
}


//���N���X��`
public class CodingRule : MonoBehaviour
{
    // �񋓒�`
    public enum E_ENUM  // �񋓂͐ړ�����E_�Ƃ���
    {
        E_ENUM_A,   // �񋓖�_XX�Ƒ�����
        E_ENUM_B,
    }

    // �\���̒�`
    private struct Struct
    {
        GameObject m_Object;    // �N���X�^�̃l�[�~���O�̓n���K���A���L�@�ɏ]��Ȃ�
                                // ��m_��s_�Ȃǂ̌^�Ƃ͊֌W�Ȃ������ł͏]��
                                // �ړ����̌��͑啶������n�߂�
        Ray m_Ray;
    }

    [Serializable]
    public struct SerializeStruct
    {
        [Tooltip("�ȈՐ���")] public GameObject m_Member;   //[Tooltip("�ȈՐ���")]:�C���X�y�N�^�[�ŃJ�[�\�������킹����("")�̒��g���\�������
    }

    // �ϐ��錾
    [Space] // ��s�����p�����₷������
    [Header("������")] // �ϐ��𕪗ނ��Ƃɕ����ċL�q
    [SerializeField, Tooltip("�����o�[�ϐ�")] private uint m_uMember;
    private int m_nInt; // �ʏ�̌^�̓n���K���A���L�@�ɏ]��[�����o�ϐ���m_�ƕt����]
    [SerializeField, Tooltip("�\����")] private SerializeStruct m_Struct;   // ���̕ϐ������Ȃ̂��C���X�y�N�^����킩��悤�ɂ���


    //���v���p�e�B��`
    public double PriProp { get; private set; } // readonly�Ȍ`���ł��L�@�͖���


    /*��֐�
    �����P�Fdouble _dDouble�F���l   // �����F���e�̌`�ŋL�q
    �����Q�FGameObject _GameObject�F����   // ������_����n�߂�
    ��
    �ߒl�F����   // ���e�̂݋L�q
    ��
    �T�v�F�֐��L�q��
    */
    private int Example(double _dDouble, GameObject _GameObject)
    {
        //���ϐ��錾
        float _fFloat = 0.0f;    // �����o�[�ϐ���_����n�߂�
        GameObject _Object = _GameObject;  // �ړ����������ꍇ�A��������啶���ɂ���

        //���Z�o
        m_nInt = (int)((float)_dDouble * _fFloat);  // �Ȃ�ׂ��S�����ɃR�����g������

        //����
        return m_nInt;
    }

    /*��xx�֐�
    �����F�Ȃ�   // �������Ȃ��ꍇ�͂P���ȗ����Ă��悢
    ��
    �ߒl�F�Ȃ�
    ��
    �T�v�F�֐���
    */
    public void Function()
    {
    }
}