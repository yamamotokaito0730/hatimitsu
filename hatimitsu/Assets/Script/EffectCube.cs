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
    [SerializeField, Tooltip("�\������")] private float m_fLifeTime = 2.0f;
    [SerializeField, Tooltip("�J��������t������")] private float m_fStickDistance = 0.2f;  // ��O�ɗ��鋗���𒲐�
    [SerializeField, Tooltip("���E�ւ̍L���蕝")] private float m_fSpreadRange = 0.5f; // ���̍L����

    private bool m_bStickToCamera = false;
    private Transform mainCamera;
    private Vector3 m_vTargetOffset;

    public void SetStickToCamera(bool stick)
    {
        m_bStickToCamera = stick;

        if (stick)
        {
            mainCamera = UnityEngine.Camera.main.transform;

            // �J�����Ɍ������Ĕ��ł������
            float horizontalOffset = Random.Range(-m_fSpreadRange, m_fSpreadRange);
            Vector3 forward = mainCamera.forward * m_fStickDistance;  // �J�����̑O�����ɃI�t�Z�b�g��K�p
            Vector3 rightOffset = mainCamera.right * horizontalOffset;

            // �J�����̑O�ɃI�t�Z�b�g�������Ĕz�u
            m_vTargetOffset = forward + rightOffset;
        }
    }

    private void Update()
    {
        m_fLifeTime -= Time.deltaTime;

        if (m_bStickToCamera && mainCamera != null)
        {
            // �ڕW�ʒu
            Vector3 targetPos = mainCamera.position + m_vTargetOffset;

            // �I�u�W�F�N�g���J�����̑O�ɌŒ肳���悤�ɁA�i�݂����Ȃ��悤�ɐ���
            if (Vector3.Distance(transform.position, mainCamera.position) > m_fStickDistance)
            {
                // �ڕW�ʒu�ɋz���񂹂�
                transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * 8f);
            }
            else
            {
                // �J�����O�ɓ��B�������~
                transform.position = targetPos;
            }

            // �J�����Ɍ������ĉ�]
            transform.rotation = Quaternion.LookRotation(-mainCamera.forward);
        }

        // �\�����Ԃ��I�������j��
        if (m_fLifeTime <= 0.0f)
        {
            Destroy(gameObject);
        }
    }
}
