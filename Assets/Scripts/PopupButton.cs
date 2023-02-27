using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class PopupButton : MonoBehaviour
{
    public Button yourButton;
    public Image img;
    public Sprite spritex;
    public GameObject greenButton;
    public GameObject redButton;
    public TextMeshProUGUI text;
    public File_Manager file;
    

    // Start is called before the first frame update
    void Start()
    {
        
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    void TaskOnClick()
    {
        greenButton.SetActive(false);
        redButton.SetActive(false);
    
        img.sprite = spritex;
        text.text = "Your escape path is: " + file.base_file_path + "\n\nFind the " + "<b>" + "door" + "</b>";
        //SceneManager.LoadScene("MainMenu");
    }
}
