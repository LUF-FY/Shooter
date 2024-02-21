using UnityEngine;
using UnityEngine.UIElements;

public class Example : MonoBehaviour
{
    void Start()
    {
        int[] mas = { 11, 22, 33, 66, 33, 34 };

        Debug.Log(mas[10]);

        Debug.Log("StartFor");
        for (int i = 0; i < mas.Length; i++)
        {
            Debug.Log(mas[i]);
        }
        Debug.Log("EndFor");
    }
}
