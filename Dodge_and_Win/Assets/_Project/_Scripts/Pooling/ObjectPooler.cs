using UnityEngine;
using System.Collections.Generic;

public class ObjectPooler : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _poolSize = 10;

    private Queue<GameObject> _pool;

    private void Start()
    {
        _pool = new Queue<GameObject>();
        for (int i = 0; i < _poolSize; i++)
        {
            GameObject obj = Instantiate(_prefab);
            obj.SetActive(false);
            _pool.Enqueue(obj);
        }
    }

    public GameObject Spawn(Vector3 position, Quaternion rotation)
    {
        GameObject obj = _pool.Dequeue();
        obj.transform.position = position;
        obj.transform.rotation = rotation;
        obj.SetActive(true);
        IPoolable poolable = obj.GetComponent<IPoolable>();
        if (poolable != null)
            poolable.OnSpawn();
        return obj;
    }

    public void Despawn(GameObject obj)
    {
        obj.SetActive(false);
        _pool.Enqueue(obj);

        IPoolable poolable = obj.GetComponent<IPoolable>();
        if (poolable != null)
            poolable.OnDespawn();
    }
}