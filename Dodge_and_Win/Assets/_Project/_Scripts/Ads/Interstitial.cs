using UnityEngine;
using GoogleMobileAds.Api;
using System;
using UnityEngine.Events;

public class Interstitial : MonoBehaviour
{
   

    private InterstitialAd interstitialAd;

    public UnityEvent OnAdOpeningEvent;
    public UnityEvent OnAdClosedEvent;

    private void Start()
    {
        RequestAndLoadInterstitialAd();
    }

    #region HELPER METHODS

    private AdRequest CreateAdRequest()
    {
        return new AdRequest.Builder()
            .AddKeyword("gaming")
            .AddKeyword("Pulse Pounder")
            .AddKeyword("hypercasual")
            .AddKeyword("action")
            .AddKeyword("entertainment")
            .AddKeyword("dynamic music")
            .AddKeyword("nice backgrounds")
            .Build();
    }

    #endregion

    #region INTERSTITIAL ADS

    public void RequestAndLoadInterstitialAd()
    {
        PrintStatus("Requesting Interstitial ad.");

#if UNITY_EDITOR
        string adUnitId = "ca-app-pub-3499239843570584/6064205698";
#elif UNITY_ANDROID
        string adUnitId = "ca-app-pub-3499239843570584/6064205698";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-3940256099942544/4411468910";
#else
        string adUnitId = "unexpected_platform";
#endif

        // Clean up interstitial before using it
        if (interstitialAd != null)
        {
            interstitialAd.Destroy();
        }

        // Load an interstitial ad
        InterstitialAd.Load(adUnitId, CreateAdRequest(),
            (InterstitialAd ad, LoadAdError loadError) =>
            {
                if (loadError != null)
                {
                    PrintStatus("Interstitial ad failed to load with error: " +
                        loadError.GetMessage());
                    return;
                }
                else if (ad == null)
                {
                    PrintStatus("Interstitial ad failed to load.");
                    return;
                }

                PrintStatus("Interstitial ad loaded.");
                interstitialAd = ad;

                ad.OnAdFullScreenContentOpened += () =>
                {
                    PrintStatus("Interstitial ad opening.");
                    OnAdOpeningEvent.Invoke();
                };
                ad.OnAdFullScreenContentClosed += () =>
                {
                    PrintStatus("Interstitial ad closed.");
                    OnAdClosedEvent.Invoke();
                };
                ad.OnAdImpressionRecorded += () =>
                {
                    PrintStatus("Interstitial ad recorded an impression.");
                };
                ad.OnAdClicked += () =>
                {
                    PrintStatus("Interstitial ad recorded a click.");
                };
                ad.OnAdFullScreenContentFailed += (AdError error) =>
                {
                    PrintStatus("Interstitial ad failed to show with error: " +
                                error.GetMessage());
                };
                ad.OnAdPaid += (AdValue adValue) =>
                {
                    string msg = string.Format("{0} (currency: {1}, value: {2}",
                                               "Interstitial ad received a paid event.",
                                               adValue.CurrencyCode,
                                               adValue.Value);
                    PrintStatus(msg);
                };
            });
    }

    private void PrintStatus(string v)
    {
        Debug.Log(v);
    }

    public void ShowInterstitialAd()
    {
        if (interstitialAd != null && interstitialAd.CanShowAd())
        {
            interstitialAd.Show();
        }
        else
        {
            PrintStatus("Interstitial ad is not ready yet.");
        }
    }

    public void DestroyInterstitialAd()
    {
        if (interstitialAd != null)
        {
            interstitialAd.Destroy();
        }
    }

    #endregion

    /*
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
   */

}
