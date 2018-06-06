using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class MenuManager : MonoBehaviour {

    //declared buttons for level select menu and options menu
    public Button Play, Options;


    //function to be called when play button or options button pressed
    public void LoadPage(int Page)
    {
        //load relative scene
        SceneManager.LoadScene(Page);
    }

    //code adapted from Unity Technologies, 2018
    public void ShowRewardedAd()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            var options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show("rewardedVideo", options);
        }
    }

    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown.");
                LivesManager.Lives = 5;
                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");
                break;
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                break;
        }
    }
    //end of adapted code
}


