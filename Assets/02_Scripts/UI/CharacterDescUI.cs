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
        //Debug.Log("이벤트 연결");
        DescInit();
        GameManager.Instance.CharacterDescUI += DescSetting;
        GameManager.Instance.ActiveCharacter();
    }

    private void OnDisable()
    {
        //Debug.Log("이벤트 해제");
        GameManager.Instance.CharacterDescUI -= DescSetting;
    }

    private void DescSetting()
    {
        CharacterNameTxt.text = GameManager.Instance.curCharacter.characterName;
        CharacterDescTxt.text = "매우 귀엽습니다";
    }

    private void DescInit()
    {
        CharacterNameTxt.text = "미정";
        CharacterDescTxt.text = "캐릭터를 선택하세요.";
    }
}
