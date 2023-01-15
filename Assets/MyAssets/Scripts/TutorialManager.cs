using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public Image image;
    public TMP_Text description;
    public GameObject nextArrow;
    public GameObject previousArrow;
    public List<TutorialImage> tutorialImages;

    private int currentTutorialIndex = 0;

    private void OnEnable()
    {
        AssignImage();
    }

    public void Next()
    {
        currentTutorialIndex++;
        AssignImage();
    }

    public void Previous()
    {
        currentTutorialIndex--;
        AssignImage();
    }

    private void AssignImage()
    {
        if (currentTutorialIndex >= tutorialImages.Count || currentTutorialIndex < 0)
        {
            Debug.LogError("Wrong tutorial index");
            return;
        }

        image.sprite = tutorialImages[currentTutorialIndex].sprite;
        description.text = tutorialImages[currentTutorialIndex].description;

        nextArrow.SetActive(currentTutorialIndex < tutorialImages.Count - 1);
        previousArrow.SetActive(currentTutorialIndex > 0);
    }
}

[System.Serializable]
public class TutorialImage
{
    public Sprite sprite;
    [TextArea(15, 20)]
    public string description;
}
