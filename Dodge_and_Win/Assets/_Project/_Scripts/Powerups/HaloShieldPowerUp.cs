using System.Threading.Tasks;
using UnityEngine;

public class HaloShieldPowerUp : PowerUp
{
    [SerializeField] private GameObject _playerShield;

    private void OnEnable()
    {
        _playerShield = FindObjectOfType<PlayerLocomotion>().gameObject.transform.GetChild(0).gameObject;
    }

    public override async void Activate()
    {
        _playerShield.SetActive(true);

        await CountdownRoutine();
    }

    public override void Deactivate()
    {
        _playerShield.SetActive(false);
    }

    private async Task CountdownRoutine()
    {
        await Task.Delay(7000);

        Deactivate();
    }
}
