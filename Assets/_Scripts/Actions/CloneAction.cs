using System;
using System.Collections;
using UnityEngine;

public class CloneAction : BaseAction
{
    [SerializeField] private GameObject unitClonePrefab;
    public override void TakeAction(Action OnActionComplete)
    {
        _OnActionComplete = OnActionComplete;
        
        // var pos = UnityEngine.Random.insideUnitSphere * 5;
        // Instantiate(unitClonePrefab, new Vector3(pos.x,0,pos.z), Quaternion.identity);

        StartCoroutine(TestCo());
    }

    IEnumerator TestCo()
    {
        print("CLoning");
        yield return new WaitForSeconds(5f);
        print("CLoning done");
        _OnActionComplete?.Invoke();
    }

    public new string ToString()
    {
        return "CloneAction";
    }
}
