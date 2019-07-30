using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperForTrampline : MonoBehaviour
{

    [SerializeField] GameObject _target;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(GameManager._speedBoost);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // ramp variant
        collision.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(transform.localPosition.x, transform.localPosition.y + 7f, transform.localPosition.z + 1.7f) * (2f + GameManager._speedBoost), ForceMode.Impulse);
        GameManager._speedBoost = 0f;

        // jump variant
        //collision.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(transform.localPosition.x, transform.localPosition.y + 7f, transform.localPosition.z + 1.7f) * 3f, ForceMode.Impulse);
    }

}
