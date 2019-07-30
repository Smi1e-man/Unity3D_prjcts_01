using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverForPLayer : MonoBehaviour
{

    [SerializeField] GameObject _target;

    [SerializeField] GameObject _pref;
    [SerializeField] GameObject _spawnPlace;

    [SerializeField] GameObject _objects;

    Vector3 _targetLocal;

    bool _spawnActive = false;

    // Start is called before the first frame update
    void Start()
    {
        _targetLocal = _target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            transform.eulerAngles += new Vector3(0f, 90f, 0f);
        }

        if (transform.position != _targetLocal)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetLocal, 7f * Time.deltaTime);
        }
        else
        {
            _targetLocal = _target.transform.position;
            if (_spawnActive)
            {
                _spawnActive = false;

                GameObject obj;

                obj = Instantiate(_pref, _objects.transform, _objects.transform);
                obj.transform.position = _spawnPlace.transform.position;
                obj.transform.rotation = transform.rotation;
            }
            for (int i = 0; i < _objects.transform.childCount; i++)
            {
                if (_objects.transform.GetChild(i).GetComponent<MoverForPlayerClone>())
                    _objects.transform.GetChild(i).GetComponent<MoverForPlayerClone>().MoverTargetChange(transform.position);
            }
        }


    }
    public void     AddObject()
    {
        //GameObject obj;

        ////Instantiate(_objects[0], _spawnPlace.transform.position, Quaternion.identity);
        //obj = Instantiate(_pref, _spawnPlace.transform.position, Quaternion.identity);
        //obj.transform.rotation = transform.rotation;

        _spawnActive = true;

        //_objects.Add(obj);
    }

}
