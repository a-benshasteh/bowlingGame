using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    public Rigidbody rb; // Reference to the Rigidbody component of the ball
    [SerializeField] private float startSpeed = 40f; // The speed at which the ball starts moving

    private Transform _arrow;
    private bool _ballMoving;
    private Vector3 _startPosition;
    private BallSound ballSound;
    private List<GameObject> _pins = new();
    private readonly Dictionary<GameObject, Vector3> _pinsDefaultPositions = new();
    public int Point { get; set; }

    [SerializeField] private Animator cameraAnim;
    private TextMeshProUGUI feedBack;
    private int pinsHitCount = 0; // شمارش پین‌هایی که برخورد کرده‌اند

    private void Start()
    {
        Application.targetFrameRate = 60;

    
        rb = GetComponent<Rigidbody>();
        _startPosition = transform.position;

        _pins = GameObject.FindGameObjectsWithTag("Pin").ToList();
        foreach (var pin in _pins)
        {
            _pinsDefaultPositions[pin] = pin.transform.position;
        }
        ballSound = GetComponent<BallSound>();
     
    }

    private void Update()
    {
        if (_ballMoving) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Shoot());
        }
    }

    private IEnumerator Shoot()
    {
        cameraAnim.SetTrigger("Go");
        cameraAnim.SetFloat("CameraSpeed", _arrow.localScale.z);
        _ballMoving = true;
        _arrow.gameObject.SetActive(false);
        rb.isKinematic = false;

        Vector3 forceVector = _arrow.forward * (startSpeed * _arrow.localScale.z);
        rb.AddForce(forceVector, ForceMode.Impulse);

        yield return new WaitForSecondsRealtime(7);

        _ballMoving = false;
        CalculatePinsHit(); // شمارش پین‌های برخوردی
        ballSound.PlayRollSound();

        yield return new WaitForSecondsRealtime(2);

        ResetGame();
    }

    private static void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void CalculatePinsHit()
    {
        pinsHitCount = 0; // شمارش را ریست کنیم

        foreach (GameObject pin in _pins)
        {
            // بررسی کنیم که آیا پین سقوط کرده است یا خیر
            if (pin.transform.up.y < 0.5f) // چک کردن زاویه پین
            {
                pinsHitCount++;
            }
        }

        Debug.Log("Number of pins hit: " + pinsHitCount);
        Point = pinsHitCount; // تنظیم امتیاز
        ballSound.PlayHitSound();
        

    }

}
