using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillActivate : MonoBehaviour
{
    [SerializeField]
    private List<ItemCollectedObserveSO> _itemCollectedObserveSOs;
    private List<GameObject> _skillsPool;

    private void Start() { }

    void OnEnable()
    {
        _skillsPool = new List<GameObject>();
        int count = transform.childCount;
        for (int i = 0; i < count; i++)
        {
            _skillsPool.Add(gameObject.transform.GetChild(i).gameObject);
            _itemCollectedObserveSOs[i].AddAction(ActivateSkill);
        }
    }

    void OnDisable()
    {
        for (int i = 0; i < _itemCollectedObserveSOs.Count; i++)
        {
            _itemCollectedObserveSOs[i].Remove(ActivateSkill);
        }
    }

    public void AddSkill(ItemCollectedObserveSO itemCollectedObserveSO, GameObject prefabs)
    {
        GameObject spawnObject = Instantiate(prefabs, gameObject.transform);
        _itemCollectedObserveSOs.Add(itemCollectedObserveSO);
        _skillsPool.Add(spawnObject);
    }

    public void ActivateSkill(string skillName)
    {
        Debug.Log(skillName);

        foreach (GameObject skill in _skillsPool)
        {
            if (skill.name == skillName)
            {
                Debug.Log("skill name: " + skill.name);
                skill.SetActive(true);
            }
        }
    }

    public void RemoveSkill(string skillName)
    {
        foreach (GameObject skill in _skillsPool)
        {
            if (skill.name == skillName)
            {
                skill.SetActive(false);
            }
        }
    }
}
