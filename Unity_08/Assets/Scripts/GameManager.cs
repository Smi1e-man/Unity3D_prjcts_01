using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //visual public
    [SerializeField]
    public Gradient _gradient;

    //public
    public static bool _nextBlock = true;
    public static float _indexGradient = 0f;

    //visual private
    [SerializeField]
    List<GameObject> _perfects;
    [SerializeField]
    List<GameObject> _blocks;
    [SerializeField]
    float _indexGradientStep = 0.05f;


    //private
    int _index;

    private void Awake()
    {
        _index = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_nextBlock && _index < _blocks.Count)
        {
            _nextBlock = false;

            if (_index - 1 >= 0)
                _perfects[_index - 1].SetActive(false);

            _perfects[_index].SetActive(true);
            _blocks[_index].SetActive(true);

            if (_indexGradient + _indexGradientStep < 1)
                _indexGradient += _indexGradientStep;
            else
                _indexGradient = 0f;
            _index += 1;
        }
        if (_index == _blocks.Count && _nextBlock)
            _perfects[_index - 1].SetActive(false);
    }
}
