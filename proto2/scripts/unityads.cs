// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.Advertisements;

// public class unityads : MonoBehaviour
// {
//     string gameId = "4829807p";

//     ///...set this to false when building
//     bool testMode = true;

//     // Initialize the Ads service:
//     void Start () {
//         Advertisement.Initialize (gameId, testMode);
//     }
//     public void showAD()
//     {
//         Advertisement.Show(gameId); 
//     }
// }
using UnityEngine;
using UnityEngine.Advertisements;
 
public class unityads : MonoBehaviour, IUnityAdsInitializationListener
{
    [SerializeField] string _androidGameId;
    [SerializeField] string _iOSGameId;
    [SerializeField] bool _testMode = true;
    private string _gameId;
    public  interAD interADscript;
    public rewardAD rewardADscript;
 
    void Awake()
    {
        InitializeAds();
    }
 
    public void InitializeAds()
    {
        _gameId = (Application.platform == RuntimePlatform.IPhonePlayer)
            ? _iOSGameId
            : _androidGameId;
        Advertisement.Initialize(_gameId, _testMode, this);
    }
 
    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete.");
        interADscript.LoadAd();
        rewardADscript.LoadAd();
    }
 
    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }
}