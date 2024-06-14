using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDogTransition
{
    public string MakeTransition(Dictionary<string, object> rules);
    public string Decide(Dictionary<string, object> rules);
}
