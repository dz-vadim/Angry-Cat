using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaunch : MonoBehaviour
{
    [SerializeField] GameObject dragPoint;
    [SerializeField] private float forceValue;
    [SerializeField] private float minSpeedDrag;
    private Rigidbody2D rb2d;
    private Camera mainCamera;
    private Vector2 startPosition;
    private bool canDrag;

    private void Awake()
    {
        mainCamera = Camera.main;
        rb2d = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        rb2d.isKinematic = true;
    }
    private void OnMouseDown()
    {
        float playerSpeed = rb2d.velocity.magnitude; //визначаємо швидкість
        if (playerSpeed < minSpeedDrag)              // якщо швидкість менше мінімальної
        {
            dragPoint.transform.position = transform.position;
            canDrag = true;                 //даємо можливість натягувати рогатку 
            rb2d.isKinematic = true;        //зупиняємо будь-яку фізичну дію на об'єкт
            rb2d.velocity = Vector2.zero;   //зупиняємо сам об'єкт
            startPosition = rb2d.position;  //початкова позиція рогатки = початкова позиція об'єкта
        }
    }
    private void OnMouseUp()
    {
        if (canDrag)
        {
            dragPoint.SetActive(false);
            Vector2 currentPostion = rb2d.position;
            Vector2 direction = startPosition - currentPostion; //порахували напрям куди летітти
            rb2d.isKinematic = false; //повертаємо фізичні сили
            rb2d.AddForce(direction * forceValue);
            canDrag = false;          //блокуємо можливість натягувати рогатку 
        }
    }
    private void OnMouseDrag()
    {
        if (canDrag)
        {
            dragPoint.SetActive(true);
            Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePosition;
        }
    }
    void Update()
    {
        
    }
}
