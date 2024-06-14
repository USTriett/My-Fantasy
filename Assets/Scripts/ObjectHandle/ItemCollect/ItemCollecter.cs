using UnityEngine;

public class ItemCollecter : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject _target;

    [SerializeField]
    private ItemCollectedObserveSO _hatCollectObserveSO;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _target)
        {
            _hatCollectObserveSO.Notify(gameObject.name);
            gameObject.SetActive(false);
        }
    }
}
