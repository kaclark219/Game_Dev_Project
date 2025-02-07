
using UnityEngine;
using UnityEngine.UI;

public class NPCPortrait : MonoBehaviour
{
    public NPCPosition Position { get; private set; }

    public NPCName Name { get; private set; }

    public NPCMood Mood { get; private set; }

    public bool IsShowing { get; private set; }

    private NPCMoods _moods;

    private float _offScreenX;

    private float _onScreenX;

    public void Init(NPCName name, NPCPosition position, NPCMood mood, NPCMoods moods)
    {
        Name = name;
        Position = position;
        Mood = mood;

        _moods = moods;

        Show();
    }
    public void Show()
    {
        // Set correct mood sprite
        UpdateSprite();

        gameObject.SetActive(true);
        IsShowing = true;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        IsShowing = false;
    }

    public void ChangeMood(NPCMood mood)
    {
        Mood = mood;
        UpdateSprite();
    }
    private void UpdateSprite()
    {
        var sprite = _moods.GetMoodSprite(Mood);
        var image = GetComponent<Image>();

        image.sprite = sprite;
        image.preserveAspect = true;
    }
}
