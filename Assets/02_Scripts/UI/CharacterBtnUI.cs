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
        //Debug.Log($"{characterSO.characterName}이(가) 선택되었습니다.");
    }
}
