using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverForPlayer : MonoBehaviour
{

    [SerializeField] GameObject _centreRotate;

    [SerializeField] GameObject _centreWeapon;
    [SerializeField] GameObject _weapon;

    [SerializeField] float _speedRotate = 15f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(transform.rotation.z);
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //if (transform.rotation.z > -0.28f)
                //transform.RotateAround(_centreRotate.transform.position, Vector3.back, _speedRotate * Time.deltaTime);
            //if (_weapon.transform.rotation.y < 0.11f)
                _weapon.transform.RotateAround(_centreWeapon.transform.localPosition, Vector3.left, _speedRotate * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (transform.rotation.z < 0.28f)
                transform.RotateAround(_centreRotate.transform.position, Vector3.forward, _speedRotate * Time.deltaTime);
            if (_weapon.transform.rotation.y > -0.32f)
                _weapon.transform.RotateAround(_centreWeapon.transform.localPosition, Vector3.down, _speedRotate * Time.deltaTime);

        }
    }
}
