using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject prefab;
    public float spawnrate = 1f;
    public float minHeight = -1f;
    public float maxHeight = 1f;
    private void OnEnable()
    {
        InvokeRepeating(nameof(spawn),spawnrate,spawnrate);
    }
    private void OnDisable()
    {
        CancelInvoke(nameof(spawn));
    }
    private void spawn() 
    {
        GameObject pipes = Instantiate(prefab, transform.position, Quaternion.identity);
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }
}
