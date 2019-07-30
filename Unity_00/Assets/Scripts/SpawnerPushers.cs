using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPushers : MonoBehaviour
{
    [SerializeField] List<GameObject> _places;
    [SerializeField] GameObject _prefPusher;
    [SerializeField] GameObject _centrePushRotate;

    GameObject _copy;

    int _iPlace = 0;

    // Start is called before the first frame update
    void Start()
    {
        _copy = null;
        _places[0].GetComponent<MeshRenderer>().material.color = Color.magenta;
        _places[6].GetComponent<MeshRenderer>().material.color = Color.yellow;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (GameManager._active)
            {
                GameManager._active = false;
                if (_iPlace + 1 < _places.Count  && _iPlace + 1 != 6)
                    _places[_iPlace + 1].GetComponent<MeshRenderer>().material.color = Color.magenta;
                _copy = Instantiate(_prefPusher, transform.position, Quaternion.identity);
                _copy.SetActive(true);
                MoveSystemElements();
            }

        }
        else
        {
            Debug.Log(_iPlace);
            if (GameManager._active && _iPlace == 6)
            {
                Debug.Log("MOVE");
                _places[_iPlace + 1].GetComponent<MeshRenderer>().material.color = Color.magenta;
                MoveSystemElements();
            }
        }
    }

    void    MoveSystemElements()
    {
        transform.position += Vector3.left;
        _centrePushRotate.transform.position += (Vector3.down / 2);
        _iPlace += 1;
    }
}
