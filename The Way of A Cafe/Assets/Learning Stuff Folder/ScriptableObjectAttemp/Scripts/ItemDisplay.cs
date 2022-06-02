using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemDisplay : MonoBehaviour
{

    public ItemAttempt item;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;

    public Image artImage;

    public TextMeshProUGUI amountText;

    // Start is called before the first frame update
    void Start()
    {
        nameText.SetText(item.name);
        descriptionText.SetText(item.description);

        artImage.sprite = item.art;

        amountText.SetText(item.amount.ToString());
    }

}
