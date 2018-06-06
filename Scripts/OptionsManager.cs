using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsManager : MonoBehaviour {

    //bool for Music Active delcared true
    public bool MusicActive = true;
    //sprite for music disabled button
    public Sprite Disabled;
    //sprite for music enabled button
    public Sprite Enabled;
    //image variable for image component on button
    public Image ImageComponent;

    //call this function when go back button is pressed to load main menu
    public void LoadPage(int Page)
    {
        SceneManager.LoadScene(Page);
    }

    //music function to be called when music buttion is pressed
    public void Music()
    {
        //if music is active, disable audio component, change bool to music is false (inactive), and change button sprite to disabled sprite
        if (MusicActive)
        {
            GameObject.FindWithTag("Music").GetComponent<AudioSource>().enabled = false;
            MusicActive = false;
            ImageComponent.sprite = Disabled;
        }
        //else if music is not active, enable audio component, change bool to music is true (active), and change button sprite to enabled sprite
        else if (!MusicActive)
        {
            GameObject.FindWithTag("Music").GetComponent<AudioSource>().enabled = true;
            MusicActive = true;
            ImageComponent.sprite = Enabled;
        }
    }
}
