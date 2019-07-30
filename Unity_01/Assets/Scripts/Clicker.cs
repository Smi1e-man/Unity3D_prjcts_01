using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    [SerializeField] GameObject _doorOpen;
    [SerializeField] GameObject _doorClose;


    // Start is called before the first frame update
    void Start()
    {
        _doorOpen.SetActive(false);
        _doorClose.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            _doorOpen.SetActive(true);
            _doorClose.SetActive(false);
        }
        else
        {
            _doorOpen.SetActive(false);
            _doorClose.SetActive(true);
        }
    }
}
