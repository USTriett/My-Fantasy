using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "GameDataSO", menuName = "ScriptableObjects/Data", order = 1)]

[Serializable]
public class GameDataSO : ScriptableObject
{
    // Start is called before the first frame update
    [SerializeField] private Texture2D[] images;
    [SerializeField] public int size;

    public Texture2D GetImage(int i){
        try{
            return images[i];
        }
        catch(IndexOutOfRangeException e){
            Debug.Log("Index out of range"+ e);
        }
        return null;
    }
    
    public int GetNumberOfBlock(){
        return images.Length;
    }

    
}
