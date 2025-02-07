using UnityEngine;

public class NPCMoods : MonoBehaviour
{
    public NPCName Name;
    public Sprite Fine;
    public Sprite Sad;
    public Sprite Happy;

    public Sprite GetMoodSprite(NPCMood mood)
    {

        switch (mood)
        {
            case NPCMood.Fine:
                return Fine;
            case NPCMood.Sad:
                return Sad;
            case NPCMood.Happy:
                return Happy;
            default:
                Debug.Log($"Didn't find Sprite for character: {Name}, mood: {mood}");
                return Fine;
        }
    }
}
