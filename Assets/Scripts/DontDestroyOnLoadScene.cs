using UnityEngine;

public class DontDestroyOnLoadScene : MonoBehaviour
{
    public GameObject[] objects;

    private void Awake()
    {
        foreach (var element in objects)
        {
            DontDestroyOnLoad(element);
        }
    }
}
