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
    // ���丮 ����Ʈ ����
    public List<Story> stories = new List<Story>();

    public StoryData()
    {
        stories.Add(new Story("�κ��� �ݶ�", "�κ��� �ݶ����� ������ �����ǰ�, �η��� ���� ���� ���Ƚ��ϴ�."));
        stories.Add(new Story("����� ����", "��� �η����� ����� ����� ����� ���� ������ ���� HQ�� ���ѳ��� �մϴ�."));
        stories.Add(new Story("������ ����", "����� ��ĥ �� ���� ���� ���̸� ����� ������ ���⸦ ��ġ�ϰ�, �ڿ��� ��� ���׷��̵� �Ͻʽÿ�"));
        stories.Add(new Story("���̸� ��ȣ�϶�", "���� �����̳�, �ΰ��̳� �κ��̳�. ���̸� ���ϴ� ���� �ݱ�� ��Ģ�Դϴ�."));
    }

    
}
