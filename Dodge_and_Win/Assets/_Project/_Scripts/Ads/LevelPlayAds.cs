using UnityEngine;

public class LevelPlayAds : MonoBehaviour
{

    private void Start()
    {
        IronSource.Agent.init("18d29e645", IronSourceAdUnits.INTERSTITIAL);
        IronSource.Agent.validateIntegration();

        LoadAd();

    }
    private void OnEnable()
    {
        IronSourceEvents.onSdkInitializationCompletedEvent += SdkInitializationCompletedEvent;

        IronSourceEvents.onInterstitialAdReadyEvent += InterstitialAdReadyEvent;
        IronSourceEvents.onInterstitialAdLoadFailedEvent += InterstitialAdLoadFailedEvent;
        IronSourceEvents.onInterstitialAdShowSucceededEvent += InterstitialAdShowSucceededEvent;
        IronSourceEvents.onInterstitialAdShowFailedEvent += InterstitialAdShowFailedEvent;
        IronSourceEvents.onInterstitialAdClickedEvent += InterstitialAdClickedEvent;
        IronSourceEvents.onInterstitialAdOpenedEvent += InterstitialAdOpenedEvent;
        IronSourceEvents.onInterstitialAdClosedEvent += InterstitialAdClosedEvent;

        //Add AdInfo Interstitial Events
        IronSourceInterstitialEvents.onAdReadyEvent += InterstitialOnAdReadyEvent;
        IronSourceInterstitialEvents.onAdLoadFailedEvent += InterstitialOnAdLoadFailed;
        IronSourceInterstitialEvents.onAdOpenedEvent += InterstitialOnAdOpenedEvent;
        IronSourceInterstitialEvents.onAdClickedEvent += InterstitialOnAdClickedEvent;
        IronSourceInterstitialEvents.onAdShowSucceededEvent += InterstitialOnAdShowSucceededEvent;
        IronSourceInterstitialEvents.onAdShowFailedEvent += InterstitialOnAdShowFailedEvent;
        IronSourceInterstitialEvents.onAdClosedEvent += InterstitialOnAdClosedEvent;
    }

    void OnApplicationPause(bool isPaused)
    {
        IronSource.Agent.onApplicationPause(isPaused);
    }

    // Interstitial Load&Show
    public void LoadAd()
    {
        IronSource.Agent.loadInterstitial();
    }

    public void ShowAd()
    {
        if (IronSource.Agent.isInterstitialReady())
        {
            IronSource.Agent.showInterstitial();
        } else
        {
            Debug.Log("AD NOT READY");
        }
    }



    private void SdkInitializationCompletedEvent()
    {
        LoadAd();
    }

    // Interstitial Callbacks

    // Invoked when the initialization process has failed.
    // @param description - string - contains information about the failure.
    void InterstitialAdLoadFailedEvent(IronSourceError error)
    {
    }
    // Invoked when the ad fails to show.
    // @param description - string - contains information about the failure.
    void InterstitialAdShowFailedEvent(IronSourceError error)
    {
    }
    // Invoked when end user clicked on the interstitial ad
    void InterstitialAdClickedEvent()
    {
    }
    // Invoked when the interstitial ad closed and the user goes back to the application screen.
    void InterstitialAdClosedEvent()
    {
    }
    // Invoked when the Interstitial is Ready to shown after load function is called
    void InterstitialAdReadyEvent()
    {
    }
    // Invoked when the Interstitial Ad Unit has opened
    void InterstitialAdOpenedEvent()
    {
    }
    // Invoked right before the Interstitial screen is about to open.
    // NOTE - This event is available only for some of the networks. 
    // You should not treat this event as an interstitial impression, but rather use InterstitialAdOpenedEvent
    void InterstitialAdShowSucceededEvent()
    {
    }

    /************* Interstitial AdInfo Delegates *************/
    // Invoked when the interstitial ad was loaded succesfully.
    void InterstitialOnAdReadyEvent(IronSourceAdInfo adInfo)
    {
    }
    // Invoked when the initialization process has failed.
    void InterstitialOnAdLoadFailed(IronSourceError ironSourceError)
    {
    }
    // Invoked when the Interstitial Ad Unit has opened. This is the impression indication. 
    void InterstitialOnAdOpenedEvent(IronSourceAdInfo adInfo)
    {
    }
    // Invoked when end user clicked on the interstitial ad
    void InterstitialOnAdClickedEvent(IronSourceAdInfo adInfo)
    {
    }
    // Invoked when the ad failed to show.
    void InterstitialOnAdShowFailedEvent(IronSourceError ironSourceError, IronSourceAdInfo adInfo)
    {
    }
    // Invoked when the interstitial ad closed and the user went back to the application screen.
    void InterstitialOnAdClosedEvent(IronSourceAdInfo adInfo)
    {
    }
    // Invoked before the interstitial ad was opened, and before the InterstitialOnAdOpenedEvent is reported.
    // This callback is not supported by all networks, and we recommend using it only if  
    // it's supported by all networks you included in your build. 
    void InterstitialOnAdShowSucceededEvent(IronSourceAdInfo adInfo)
    {
    }
}
