/*=====
<Enemy.cs>
└作成者：yamamoto

＞内容
Enemyの挙動を管理するスクリプト

＞注意事項

＞更新履歴
Y25   
_M04    
__D     
___23:プログラム作成:yamamoto

=====*/

using UnityEngine;

public class Enemy : MonoBehaviour
{

    [Header("エフェクト")]
    [SerializeField, Tooltip("プレハブ")] private GameObject m_EffectCube;       // エフェクトキューブプレハブ
    [SerializeField, Tooltip("生成数")] private int m_nEffectNum;              // エフェクトキューブ生成数
    [SerializeField,Tooltip("範囲")] private float m_fPosRandRange;  // エフェクトキューブを生成するポジションをランダムに生成するための範囲

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Die()
    {
        float x, y, z = 0.0f;

        for (int i = 0; i < m_nEffectNum; i++)
        {
            x = Random.Range(-m_fPosRandRange, m_fPosRandRange);
            y = Random.Range(-m_fPosRandRange, m_fPosRandRange);
            z = Random.Range(-m_fPosRandRange, m_fPosRandRange);

            Vector3 spawnPos = transform.position + new Vector3(x, y, z);
            GameObject cube = Instantiate(m_EffectCube, spawnPos, Quaternion.identity);

            // 一部のキューブだけカメラに張り付ける（例：3つだけ）
            if (i < 7)
            {
                EffectCube effect = cube.GetComponent<EffectCube>();
                if (effect != null)
                {
                    effect.SetStickToCamera(true);
                }
            }
        }

        Destroy(gameObject);
    }

    ///*＞消滅関数
    //引数：なし
    //ｘ
    //戻値：なし
    //ｘ
    //概要:この敵を消滅させる
    //*/
    //public void Die()
    //{
    //    float x, y, z = 0.0f;

    //    // エフェクトキューブ生成
    //    for (int i = 0; i < m_nEffectNum; i++)
    //    {
    //        x = Random.Range(-m_fPosRandRange, m_fPosRandRange);
    //        y = Random.Range(-m_fPosRandRange, m_fPosRandRange);
    //        z = Random.Range(-m_fPosRandRange, m_fPosRandRange);

    //        Instantiate(m_EffectCube, new Vector3(transform.position.x + x, transform.position.y + y, transform.position.z + z), Quaternion.identity);
    //    }

    //    Destroy(gameObject);
    //}
}
