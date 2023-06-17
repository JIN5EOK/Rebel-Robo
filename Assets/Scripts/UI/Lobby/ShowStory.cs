using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;

public class ShowStory : MonoBehaviour
{
    TextMeshProUGUI storyText;
    StoryData storyData;
    [SerializeField] GameObject DataObj;
    private void Start()
    {
        storyText = GetComponent<TextMeshProUGUI>();

        storyData = DataObj.GetComponent<StoryData>();

        

        int randomIndex = Random.Range(0, storyData.stories.Count);
        string randomStory = storyData.stories[randomIndex].Content;

        storyText.text = randomStory;
    }
}
