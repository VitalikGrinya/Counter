using System.Collections;
using TMPro;
using UnityEngine;

public class TimerView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private float _delay = 0.5f;
    private float _number = 0;
    private Coroutine _coroutine;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            WorkCorotine();
    }

    private void WorkCorotine()
    {
        if (_coroutine == null)
        {
            _coroutine = StartCoroutine(Countdown(_delay));
        }
        else
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }

    private void Text(float number)
    {
        _text.text = number.ToString();
    }

    private IEnumerator Countdown(float delay)
    {
        var wait = new WaitForSeconds(delay);

        while (true)
        {
            _number++;
            //Debug.Log(_number);
            Text(_number);
            yield return wait;
        }
    }
}