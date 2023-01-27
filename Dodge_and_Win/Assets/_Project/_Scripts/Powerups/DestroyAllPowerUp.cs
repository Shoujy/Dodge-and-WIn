using System.Threading.Tasks;
using UnityEngine;

public class DestroyAllPowerUp : PowerUp
{
    [SerializeField] private ParticleSystem _particle;
    [SerializeField] private AudioClip _clip;

    private Color _particleColor;

    private Unit[] _enemies;
    private ObjectPooler _objectPooler;

    public override async void Activate()
    {
        _enemies = FindObjectsOfType<Unit>();
        _objectPooler = FindObjectOfType<ObjectPooler>();

        _particleColor = _enemies[0].GetComponent<SpriteRenderer>().color;
        var main = _particle.main;
        main.startColor = _particleColor;

        for (int i = 0; i < _enemies.Length; i++)
        {
            await DestroyAllEnemy(_enemies[i]);
        }
    }

    public override void Deactivate()
    {
        _particle.Clear();
        Debug.Log("Destroyed Successfully");
    }

    public async Task DestroyAllEnemy(Unit enemy)
    {
        Instantiate(_particle, enemy.transform.position, Quaternion.identity);
        SoundManager.Instance.PlaySound(_clip);
        _objectPooler.Despawn(enemy.gameObject);
        await Task.Delay(150);
    }
}