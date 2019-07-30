using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperForRampThird : MonoBehaviour
{

    [SerializeField] Material _mtrl;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(transform.localPosition.x, transform.localPosition.y + 1.5f, transform.localPosition.z) * 10f, ForceMode.Impulse);
        gameObject.GetComponent<MeshRenderer>().material = _mtrl;

        GameManager._speedBoost += 0.3f;
    }
}
