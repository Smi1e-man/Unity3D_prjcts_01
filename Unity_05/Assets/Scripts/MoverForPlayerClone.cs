using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverForPlayerClone : MonoBehaviour
{

    Vector3 _targetLocal;


    // Start is called before the first frame update
    void Start()
    {
        _targetLocal = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (_targetLocal != Vector3.zero && transform.position != _targetLocal)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetLocal, 7f * Time.deltaTime);
        }
    }

    public void     MoverTargetChange(Vector3 newTarget)
    {
        _targetLocal = newTarget;
    }

}
