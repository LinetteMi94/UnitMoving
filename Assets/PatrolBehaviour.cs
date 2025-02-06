using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolBehaviour : MonoBehaviour
{
    [SerializeField] private Vector3[] _points; //массив точек

    [SerializeField] private float _speed = 10.0f; //скорость движения
    [SerializeField] private float _timeForWaiting = 5f; //время ожидания между движениями

    private int _startIndex = 0; //начальная точка
    private Vector3 _destination; //целевая точка

    private float _currentTime;
    void Start()
    {
        if (_points.Length > 0) _destination = _points[_startIndex];
    }
    void Update()
    {
        _currentTime += Time.deltaTime;
        
        transform.position = Vector3.Lerp(transform.position, _destination, _speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, _destination) < 0.01f)
        {
            if (_currentTime >= _timeForWaiting)
            {
                _currentTime = 0;
                _startIndex++;
                if (_startIndex >= _points.Length) _startIndex = 0;
                _destination = _points[_startIndex];
            }
            
        }
        
    }
}
