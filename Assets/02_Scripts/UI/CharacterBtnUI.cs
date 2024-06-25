using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterBtnUI : MonoBehaviour
{
    public CharacterSO characterSO;
    public TextMeshProUGUI nameTxt;
    // 추후에 SO에 애니메이터도 넣어야할 듯.. (icon, characterIcon.Image, animator)
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
            nameTxt.text = "개발 예정";
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
            //Debug.Log($"{characterSO.characterName}이(가) 선택되었습니다.");
        }
        else
        {
            SoundUtil.SfxSound("ErrorSound");
        }
    }
}
