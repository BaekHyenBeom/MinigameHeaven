using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterBtnUI : MonoBehaviour
{
    public CharacterSO characterSO;
    public TextMeshProUGUI nameTxt;
    // ���Ŀ� SO�� �ִϸ����͵� �־���� ��.. (icon, characterIcon.Image, animator)

    private void OnEnable()
    {
        nameTxt.text = characterSO.characterName;
    }

    public void SelectCharacter()
    {
        SoundUtil.SfxSound("ButtonSound");
        GameManager.Instance.curCharacter = characterSO;
        GameManager.Instance.ChangeBtnColor(GetComponent<Image>(), false, null);
        GameManager.Instance.CallCharacterDescUI();
        //Debug.Log($"{characterSO.characterName}��(��) ���õǾ����ϴ�.");
    }
}
