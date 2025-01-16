using System;
using UnityEngine;
using TMPro;

public class Pin : MonoBehaviour
{
    [SerializeField] private float velocityThreshold = 1f; // کاهش آستانه سرعت
    private bool _hasFallen = false;

    private Ball _ball;
    private TextMeshProUGUI _pointText;

    private void Start()
    {
        // Cache references for performance
        _ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<Ball>();
        _pointText = GameObject.FindGameObjectWithTag("Poing").GetComponent<TextMeshProUGUI>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_hasFallen) return;

        if (other.CompareTag("Ball")) // فقط برخورد با توپ
        {
            Rigidbody pinRigidbody = GetComponent<Rigidbody>();
            if (pinRigidbody != null && pinRigidbody.velocity.magnitude > velocityThreshold)
            {
                _ball.Point++;
                _pointText.text = $"Number of fallen pins: {_ball.Point}";
                _hasFallen = true;
                gameObject.SetActive(false); // غیرفعال کردن پین
            }
        }
    }
}
