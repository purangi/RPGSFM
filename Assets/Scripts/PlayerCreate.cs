using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerCreate : MonoBehaviour
{
    [SerializeField] GameObject namePanel;
    [SerializeField] GameObject skinPanel;
    [SerializeField] TMP_InputField nameTxt;
    [SerializeField] List<Toggle> toggles;


    public void SetName()
    {
        if(nameTxt.text != "")
        {
            GameManager.instance.name = nameTxt.text;
            namePanel.SetActive(false);
            ShowSkinSelect();
        }
    }

    private void ShowSkinSelect()
    {
        skinPanel.SetActive(true);
    }

    private void SetMaterialIndex()
    {
        for(int i = 0; i < toggles.Count; i++)
        {
            if (toggles[i].isOn) GameManager.instance.materialIndex = i;
        }
    }

    public void OnPlayerCreate()
    {
        SetMaterialIndex();
        SceneManager.LoadScene("MainScene");
    }
}
