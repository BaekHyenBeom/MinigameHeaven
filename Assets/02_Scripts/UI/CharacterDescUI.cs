using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterDescUI : MonoBehaviour
{
    public TextMeshProUGUI CharacterNameTxt;
    public TextMeshProUGUI CharacterDescTxt;

    private void OnEnable()
    {
        Debug.Log("�̺�Ʈ ����");
        GameManager.Instance.CharacterDescUI += DescSetting;
    }

    private void OnDisable()
    {
        Debug.Log("�̺�Ʈ ����");
        GameManager.Instance.CharacterDescUI -= DescSetting;
    }

    private void DescSetting()
    {
        CharacterNameTxt.text = GameManager.Instance.curCharacter.characterName;
        CharacterDescTxt.text = "�ſ� �Ϳ����ϴ�";
    }
}