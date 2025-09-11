using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grap : MonoBehaviour
{
    //aaaabbccddeee
    [SerializeField] private Transform _pointPrefab;
    [SerializeField][Range(10,100)] private int _resolution;
    [SerializeField]
    private FunctionLibrary.FunctionName _function;
    Transform[] _points;
    private void Start()
    {
        _points = new Transform[_resolution*_resolution];
        float step = 2f / _resolution;
        var position = Vector3.zero;
        var scale = Vector3.one * step;
        for (int i = 0,x=0,z = 0; i < _points.Length; i++,x++) {
            if (x == _resolution)
            {
                x = 0;
                z += 1;
            }
            Transform point =_points[i]= Instantiate(_pointPrefab, transform, false);
            position.x = (x + 0.5f) * step - 1f;
            position.z = (z + 0.5f) * step - 1f;
            point.localPosition = position;
            point.localScale = scale;
        }
    }

    private void Update()
    {
        FunctionLibrary.Function f = FunctionLibrary.GetFunction(_function);
        float time = Time.time;
        float step = 2f / _resolution;
        for (int i = 0, x = 0, z = 0; i < _points.Length; i++, x++) {
            if (x == _resolution) {
                x = 0;
                z += 1;
            }
            float u = (x + 0.5f) * step - 1f;
            float v = (z + 0.5f) * step - 1f;
            _points[i].localPosition = f(u, v,time);
        }
    }
}
