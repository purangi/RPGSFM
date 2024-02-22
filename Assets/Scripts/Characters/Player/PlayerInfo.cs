using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI nameTxt;
    [SerializeField] List<Material> materials;
    [SerializeField] List<GameObject> objects;

    private void Start()
    {
        SetPlayerInfo();
    }

    public void SetPlayerInfo()
    {
        SetName();
        SetMaterials(GameManager.instance.materialIndex);
    }

    void SetName()
    {
        nameTxt.text = GameManager.instance.name;
    }

    void SetMaterials(int index)
    {
        for(int i = 0; i < objects.Count; i++)
        {
            objects[i].GetComponent<SkinnedMeshRenderer>().material = materials[index];
        }
    }
}
