using UnityEngine;

public class DataHandler : MonoBehaviour
{
    private void Awake()
    {
        DataManager.Instance.LoadData();
    }
}
