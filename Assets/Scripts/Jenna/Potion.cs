using UnityEngine;

public class Potion : MonoBehaviour
{
    [SerializeField] private int _id;

    public int GetId()
    {
        return _id;
    }

    public void SetId(int id)
    {
        _id = id;
    }
}