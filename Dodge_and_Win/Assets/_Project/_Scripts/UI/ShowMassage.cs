using TMPro;
using UnityEngine;

public class ShowMassage : MonoBehaviour
{
    [SerializeField] private GameObject _messagePanel;
    [SerializeField] private TextMeshProUGUI _messageText;
    [SerializeField] private Message _message;
    
    public void ShowMessage()
    {
        _messagePanel.SetActive(true);
        _messageText.text = _message.MyMessage;
    }
}
