using UnityEngine;
using GoogleMobileAds.Api;

public class Interstitial : MonoBehaviour
{
    private InterstitialAd _interstitial;
    private string _interstitialID = "ca-app-pub-3499239843570584/6064205698";

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
