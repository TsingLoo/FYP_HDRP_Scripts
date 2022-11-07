using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoomViewPanel : BasePanel
{
    [SerializeField] Image BoomViewImage;

    public override void OnEnter()
    {
        BoomViewImage.sprite = Blueprint.BoomViewSprite;
        base.OnEnter();
    }
}
