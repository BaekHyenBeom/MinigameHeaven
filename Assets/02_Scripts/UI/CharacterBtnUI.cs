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
    public Image characterIcon;

    private void OnEnable()
    {
        StartCoroutine(EnableDelay());
    }

    IEnumerator EnableDelay()
    {
        yield return null;
        if (characterSO != null)
        {
            nameTxt.text = characterSO.characterName;
            characterIcon.sprite = characterSO.characterSprite;
        }
        else 
        { 
            nameTxt.text = "���� ����";
            characterIcon.sprite = null;
        }
    }

    public void SelectCharacter()
    {
        if (characterSO != null)
        {
            SoundUtil.SfxSound("ButtonSound");
            GameManager.Instance.curCharacter = characterSO;
            GameManager.Instance.ChangeBtnColor(GetComponent<Image>(), false, null);
            GameManager.Instance.CallCharacterDescUI();
            //Debug.Log($"{characterSO.characterName}��(��) ���õǾ����ϴ�.");
        }
        else
        {
            SoundUtil.SfxSound("ErrorSound");
        }
    }
}
