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
        //Debug.Log("�̺�Ʈ ����");
        DescInit();
        GameManager.Instance.CharacterDescUI += DescSetting;
        GameManager.Instance.ActiveCharacter();
    }

    private void OnDisable()
    {
        //Debug.Log("�̺�Ʈ ����");
        GameManager.Instance.CharacterDescUI -= DescSetting;
    }

    private void DescSetting()
    {
        CharacterNameTxt.text = GameManager.Instance.curCharacter.characterName;
        CharacterDescTxt.text = "�ſ� �Ϳ����ϴ�";
    }

    private void DescInit()
    {
        CharacterNameTxt.text = "����";
        CharacterDescTxt.text = "ĳ���͸� �����ϼ���.";
    }
}
