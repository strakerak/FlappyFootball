using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class SkinManager : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteRenderer sr;
    public List<Sprite> skins = new List<Sprite>();
    public static int selectedSkin = 0;
    public GameObject playerskin;
    public void Start()
    {
        
    }
    public void NextOption()
    {
        selectedSkin = selectedSkin + 1;
        if(selectedSkin==skins.Count)
        {
            selectedSkin = 0;
        }
        sr.sprite = skins[selectedSkin];
    }

    public void BackOption()
    {
        selectedSkin = selectedSkin - 1;
        if (selectedSkin < 0)
        {
            {
                selectedSkin = skins.Count - 1;
            }
        }
        sr.sprite = skins[selectedSkin];
    }

    public void PlayGame()
    {
        //PrefabUtility.SaveAsPrefabAsset(playerskin, "Assets/selectedSkin.prefab");
        SceneManager.LoadScene("FlappyBird");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
