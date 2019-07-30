using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScallerForBlock : MonoBehaviour
{
    //private visual
    [SerializeField]
    float _scaleLimit = 20f;
    [SerializeField]
    float _scaleValue = 1.5f;
    [SerializeField]
    float _scaleDeltaPerfect = 5f;

    [SerializeField]
    GameObject _gobj;

    //private
    Vector3 _scaleStep;
    Vector3 _scaleStart;

    bool _scaleOut = true;
    bool _scaleIn = false;

    bool _Active = true;

    private void Awake()
    {
        _scaleStep = new Vector3(_scaleValue, _scaleValue, 0f);
    }

    // Start is called before the first frame update
    void Start()
    {
        _scaleStart = transform.localScale;
        transform.localScale = new Vector3(30f, 30f, 100f);    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && _Active)
        {
            _Active = false;
            if (Mathf.Abs(transform.localScale.x - _scaleStart.x) < _scaleDeltaPerfect)
            {
                transform.localScale = _scaleStart;
                GetComponent<MeshRenderer>().material.color = _gobj.GetComponent<GameManager>()._gradient.Evaluate(GameManager._indexGradient);
            }
            GameManager._nextBlock = true;
        }

        if (_Active)
        {
            if (transform.localScale.x < _scaleStart.x + _scaleLimit && _scaleOut)
            {
                transform.localScale += _scaleStep;
            }
            else
            {
                _scaleOut = false;
                _scaleIn = true;
            }

            if (transform.localScale.x > _scaleStart.x - _scaleLimit && _scaleIn)
            {
                transform.localScale -= _scaleStep;
            }
            else
            {
                _scaleOut = true;
                _scaleIn = false;
            }
        }

    }
}
