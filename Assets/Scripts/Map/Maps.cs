using UnityEngine;

public class Maps : MonoBehaviour
{
    private bool isMap;

    public void Init(bool isMap)
    {
        this.isMap = isMap;
        if(!isMap) gameObject.SetActive(false);
    }
}
