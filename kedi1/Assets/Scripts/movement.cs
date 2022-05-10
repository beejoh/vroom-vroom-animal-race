using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movement : MonoBehaviour
{
    [SerializeField] float mvSpeed;
    [SerializeField] float highSpeed;
    [SerializeField] float lowSpeed;
    float tempSpeed;
    Rigidbody rb;
    Vector3 direction;
    bool isMoving;
    AnimationCont animationController;
    public GameObject orbit;

    private float currentMoveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        animationController=gameObject.GetComponent<AnimationCont>();
        currentMoveSpeed = mvSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector3(Input.GetAxis("Horizontal") ,0, Input.GetAxis("Vertical"));
        transform.forward = direction;
        orbit.transform.forward = transform.forward;
        if(Input.GetAxis("Horizontal")!=0 || Input.GetAxis("Vertical") != 0)
        {
            isMoving = true;
            animationController.ChangeStatus(true);
        }
        else
        {
            isMoving = false;
            animationController.ChangeStatus(false);
        }

        if(direction != Vector3.zero)
        {
            transform.forward = direction;
        }

    }
   
    private void FixedUpdate()
    {
        if (isMoving)
        {
            rb.AddForce(transform.forward* mvSpeed);
        }
    }
    IEnumerator GoHighSpeed()
    {
        tempSpeed = mvSpeed;
        mvSpeed = highSpeed;
        yield return new WaitForSeconds(2);
        mvSpeed = tempSpeed;
    }
    IEnumerator GoLowSpeed()
    {
        tempSpeed = mvSpeed;
        mvSpeed = lowSpeed;
        yield return new WaitForSeconds(2);
        mvSpeed = tempSpeed;
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("SpeedBoost"))
        {
            StartCoroutine(GoHighSpeed());
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("SpeedDown"))
        {
            StartCoroutine(GoLowSpeed());
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("NextLevel"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
