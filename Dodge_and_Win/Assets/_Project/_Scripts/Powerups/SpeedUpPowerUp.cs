using System.Threading.Tasks;
using UnityEngine;

public class SpeedUpPowerUp : PowerUp
{
    [SerializeField] private float _speedMultiplier;

    private PlayerLocomotion _player;

    private float _basicSpeed;

    private void Awake()
    {
        _player = FindObjectOfType<PlayerLocomotion>();
    }
    public override async void Activate()
    {
        _basicSpeed = _player.Speed;
        _player.SpeedUp(_speedMultiplier);

        await CountdownRoutine();
    }

    public override void Deactivate()
    {
        _player.ReturnBasicSpeed(_basicSpeed);
    }

    private async Task CountdownRoutine()
    {
        await Task.Delay(7000);

        Deactivate();
    }
}
