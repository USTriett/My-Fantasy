using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApearanceHandler : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    ItemCollectedObserveSO _itemCollectedObserveSO;

    public void Appear(string name)
    {
        StartCoroutine(Wait(2));
    }

    void OnEnable()
    {
        _itemCollectedObserveSO.AddAction(Appear);
    }

    void OnDisable()
    {
        _itemCollectedObserveSO.Remove(Appear);
    }

    private IEnumerator Wait(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        transform.GetChild(0).gameObject.SetActive(true);
    }
}
