using UnityEngine;
using GoogleMobileAds.Api;

public class Interstitial : MonoBehaviour
{
    private InterstitialAd _interstitial;
    private string _interstitialID = "ca-app-pub-3940256099942544/1033173712";

    private void Start()
    {
        RequestInterstitial();
    }

    private void RequestInterstitial()
    {
        _interstitial = new InterstitialAd(_interstitialID);

        AdRequest request = new AdRequest.Builder().Build();

        _interstitial.LoadAd(request);
    }

    public void ShowInterstitialAd()
    {
        _interstitial.Show();
        RequestInterstitial();
    }
}
