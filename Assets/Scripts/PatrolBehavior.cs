using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolBehavior : MonoBehaviour
{
    [SerializeField]
    private List<Transform> _points;
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _waitingTime;

    private int _nextPointIndex = 0;
    private float _currentTime = 0f;
    private bool _isWaiting;
    private float _timer;

    private void Start()
    {
    }
    // Update is called once per frame
    private void Update()
    {
        if (!_isWaiting)
        {
            var currentPoint = transform.position;
            var destinationPoint = _points[_nextPointIndex].position;
            var distance = Vector3.Distance(currentPoint, destinationPoint);
            var travelTime = distance / _speed;

            transform.position = Vector3.MoveTowards(currentPoint, destinationPoint, _speed * Time.deltaTime);

            if(transform.position == destinationPoint)
            {
                _timer -= travelTime;
                _isWaiting = true;
            }
        }
        else
        {
            if (_timer < _waitingTime)
            {
                _timer += Time.deltaTime;
            }
            else
            {
                SetNextPoint();
                _isWaiting = false;
            }
        }
    }
    private void SetNextPoint()
    {
        _nextPointIndex++;
        if(_nextPointIndex >= _points.Count)
        {
            _nextPointIndex = 0;
        }
    }
    private void MoveToNextPoint()
    {

    }
}
