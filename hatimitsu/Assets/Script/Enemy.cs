using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("エフェクトCubeのプレハブ")]
    [SerializeField] private GameObject cubePrefab;

    [Header("生成するCubeの数")]
    [SerializeField] private int cubeCount = 5;

    [Header("Cubeの出現範囲")]
    [SerializeField] private float spawnRadius = 1.0f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GenerateEffectCubes();
            Destroy(gameObject); // 敵自身を破壊
            Debug.Log("プレイヤーに当たった！");
        }
    }

    public void GenerateEffectCubes()
    {
        for (int i = 0; i < cubeCount; i++)
        {
            Vector3 randomOffset = Random.insideUnitSphere * spawnRadius;
            Vector3 spawnPos = transform.position + randomOffset;

            GameObject cube = Instantiate(cubePrefab, spawnPos, Quaternion.identity);

            // Rigidbody が付いていない場合は追加（念のため）
            if (!cube.TryGetComponent(out Rigidbody rb))
            {
                rb = cube.AddComponent<Rigidbody>();
            }
        }
    }
}
