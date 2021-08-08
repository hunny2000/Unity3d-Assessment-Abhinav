using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UI : MonoBehaviour
{
    [SerializeField] RectTransform Reset_Panel;
    [SerializeField] RectTransform ExitPanelButton;
    [SerializeField] GameObject Base;

    [SerializeField] Button Character_Reset_Button;
    [SerializeField] Button Projectile_Reset_Button;


    private void OnEnable()
    {
        Actions.OnCharaterEffected += If_Charcater_Effected;
        Actions.OnProjectileEffected += If_Projectile_Effected;
    }
    private void OnDisable()
    {
        Actions.OnCharaterEffected -= If_Charcater_Effected;
        Actions.OnProjectileEffected -= If_Projectile_Effected;
    }


    public void Reload_Projectile()
    {
        Projectile_Reset_Button.interactable = false;
        Actions.OnProjectileReset();
    }

    public void Reload_Characters()
    {
        Character_Reset_Button.interactable = false;
        Actions.OnCharacterReset();
    }

    public void ClearPlatform()
    {
        Base.transform.DOPunchRotation(new Vector3(180f, 0, 0f), 1f, 2, .5f);
    }

    public void Reset_Panel_Open_Close()
    {
        if (ExitPanelButton.rotation.z == 0)
        {
            Reset_Panel.DOAnchorPosX(-Reset_Panel.anchoredPosition.x, .3f);
            ExitPanelButton.DORotate(new Vector3(0, 0, 180), .2f);
        }
        else
        {
            Reset_Panel.DOAnchorPosX(-Reset_Panel.anchoredPosition.x, .4f);
            ExitPanelButton.DORotate(new Vector3(0, 0, 0), .2f);
        }
        
    }
    
    void If_Charcater_Effected()
    {
        Character_Reset_Button.interactable = true;
    }
    void If_Projectile_Effected()
    {
        Projectile_Reset_Button.interactable = true;
    }
}
