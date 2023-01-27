using UnityEngine;
using GoogleMobileAds.Api;

public class Interstitial : MonoBehaviour
{
    private InterstitialAd _interstitial;

    private void Start()
    {
        RequestInterstitial();
    }

    private void RequestInterstitial()
    {
        string _interstitialID = "ca-app-pub-3499239843570584/6064205698";

        AdRequest request = new AdRequest.Builder().Build();

        InterstitialAd.Load(_interstitialID, request, adLoadCallback);
    }

    void adLoadCallback(InterstitialAd ad, LoadAdError error)
    {
        if (error == null)
        {
            _interstitial = ad;
        }
    }

    public void ShowInterstitialAd()
    {
        _interstitial.Show();
        RequestInterstitial();
    }
}
