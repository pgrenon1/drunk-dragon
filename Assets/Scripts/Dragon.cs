using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class Dragon : MonoBehaviour {

    public ParticleSystem Particles;
    public Image GaugeValue;
    public TextMeshProUGUI GaugeText;
    public GameObject Pointer;
    public float Speed;
    public int Health;
    public int MinToFire;
    public int MaxToFire;
    public AudioSource FireAudio;

    private bool _arduinoConnected;
    private bool _fireing;
    private int _alcLevel;
    private int _lastValue;
    private List<int> _lastValues = new List<int>();
    private ParticleSystem.EmissionModule eModule;
    private ParticleSystem.MainModule mModule;
    private bool _overMin;
    private Vector2 _stageDimensions;
    private SpriteRenderer _sr;

    // Use this for initialization
    void Start () {
        eModule = Particles.emission;
        mModule = Particles.main;
        _stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
        _sr = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        if (!_arduinoConnected)
        {
            AddValueToList(_alcLevel);

            if (Input.GetKey(KeyCode.Space))
            {
                _alcLevel += 2;
            }
            else
            {
                if (_alcLevel > 0)
                {
                    _alcLevel -= 1;
                }
                else
                {
                    _alcLevel = 0;
                }
            }
        }

        GaugeValue.fillAmount = (float)_alcLevel / 1000;
        Pointer.transform.GetComponent<RectTransform>().anchoredPosition = new Vector3(Pointer.transform.GetComponent<RectTransform>().anchoredPosition.x, ((float)_alcLevel * 182 / 1000));
        GaugeText.text = _alcLevel.ToString();

        if (_alcLevel > MinToFire)
        {
            if (_alcLevel > MaxToFire)
            {
                eModule.rateOverTime = _alcLevel / 3;
                if (!FireAudio.isPlaying)
                    FireAudio.Play();
                transform.position = transform.position + Vector3.down * Speed;
            }
            else if (_alcLevel >= Average(_lastValues))
            {
                eModule.rateOverTime = _alcLevel / 3;
                if (!FireAudio.isPlaying)
                    FireAudio.Play();
                transform.position = transform.position + Vector3.down * Speed;
            } else
            {
                eModule.rateOverTime = 0;
                if (FireAudio.isPlaying)
                    FireAudio.Stop();
                transform.position = transform.position + Vector3.up * Speed;
            }
        }
        else
        {
            eModule.rateOverTime = 0;
            if (FireAudio.isPlaying)
                FireAudio.Stop();
            transform.position = transform.position + Vector3.up * Speed;
        }

        if (transform.position.y > _stageDimensions.y - _sr.size.y / 2)
        {
            transform.position = new Vector2(transform.position.x, _stageDimensions.y - _sr.size.y / 2);
        }
        else if (transform.position.y < -_stageDimensions.y + _sr.size.y / 2)
        {
            transform.position = new Vector2(transform.position.x, -_stageDimensions.y + _sr.size.y / 2);
        }

        mModule.startSpeed = _alcLevel / 30;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Building")
        {
            Hurt();
            Destroy(other.transform.parent.gameObject);
        }
    }

    // Invoked when a line of data is received from the serial device.
    void OnMessageArrived(string msg)
    {
        //Debug.Log(msg);
        int newValue;
        if (Int32.TryParse(msg, out newValue))
        {
            _lastValue = _alcLevel;
            _alcLevel = newValue;
            AddValueToList(_alcLevel);
        }
    }

    void AddValueToList(int value)
    {
        if (_lastValues.Count < 10)
        {
            _lastValues.Add(value);
        }
        else
        {
            _lastValues.RemoveAt(0);
            _lastValues.Add(value);
        }
    }

    // Invoked when a connect/disconnect event occurs. The parameter 'success'
    // will be 'true' upon connection, and 'false' upon disconnection or
    // failure to connect.
    void OnConnectionEvent(bool success)
    {
        if (success)
        {
            Debug.Log("Connection established");
            _arduinoConnected = true;
        }
        else
        {
            Debug.Log("Connection attempt failed or disconnection detected");
            _arduinoConnected = false;
        }
    }

    int Average(List<int> ints)
    {
        int avg;
        int sum = 0;

        for (int i = 0; i < ints.Count; i++)
        {
            sum += ints[i];
        }

        avg = sum / ints.Count;

        return avg;
    }


    private void Hurt()
    {
        Health--;
        StartCoroutine(FlashRed());
        if (Health <= 0)
        {
            GameManager.Instance.GameOver();
        }
        GameManager.Instance.ShakeCamera();
    }

    private IEnumerator FlashRed()
    {
        _sr.color = Color.red;
        yield return new WaitForSeconds(0.05f);
        _sr.color = Color.white;
        yield return new WaitForSeconds(0.05f);
        _sr.color = Color.red;
        yield return new WaitForSeconds(0.05f);
        _sr.color = Color.white;
        yield return new WaitForSeconds(0.05f);
        _sr.color = Color.red;
        yield return new WaitForSeconds(0.05f);
        _sr.color = Color.white;
        yield return new WaitForSeconds(0.05f);
        _sr.color = Color.red;
        yield return new WaitForSeconds(0.05f);
        _sr.color = Color.white;
        yield return new WaitForSeconds(0.05f);
        _sr.color = Color.red;
        yield return new WaitForSeconds(0.05f);
        _sr.color = Color.white;
        yield return new WaitForSeconds(0.05f);
        _sr.color = Color.red;
        yield return new WaitForSeconds(0.05f);
        _sr.color = Color.white;
        yield return new WaitForSeconds(0.05f);
    }
}
