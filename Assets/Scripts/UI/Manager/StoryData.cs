using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Story
{
    public string Title { get; set; }
    public string Content { get; set; }

    public Story(string title, string content)
    {
        Title = title;
        Content = content;
    }


}

public class StoryData : MonoBehaviour
{
    // 스토리 리스트 생성
    public List<Story> stories = new List<Story>();

    public StoryData()
    {
        stories.Add(new Story("로봇의 반란", "로봇의 반란으로 지구는 오염되고, 인류는 벼랑 끝에 몰렸습니다."));
        stories.Add(new Story("어른들의 유산", "방어 인력으로 차출된 당신은 어른들이 남긴 유산을 통해 HQ를 지켜내야 합니다."));
        stories.Add(new Story("강력한 병기", "당신을 해칠 수 없는 적들 사이를 누비며 강력한 병기를 설치하고, 자원을 모아 업그레이드 하십시오"));
        stories.Add(new Story("아이를 보호하라", "예나 지금이나, 인간이나 로봇이나. 아이를 해하는 것은 금기된 원칙입니다."));
    }

    
}
