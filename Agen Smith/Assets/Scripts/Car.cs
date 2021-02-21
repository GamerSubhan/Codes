using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Car : MonoBehaviour
{
   public float speed = .5f;
   public Rigidbody2D rb;
   public Transform car;
   public Transform target;
   public GameObject player;
    public Animator animator;
    public GameObject Fade, vehicle, Player, Camera, Camera1;
    public Text TimerText;
    private float startingTime;
    [SerializeField] private GameObject Text, Text1, Text2;

   bool NearCar;

   void Start(){
       rb = GetComponent<Rigidbody2D>();

       Destroy(Text, 3f);
   }

   void Update(){
       float vertical = Input.GetAxis("Vertical");

       rb.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime / 60);

       if (Vector3.Distance(transform.position, target.position) < 0.001f)
        {
            // Swap the position of the cylinder.
            target.position *= -1.0f;
        }

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -11f, 11f),
        Mathf.Clamp(transform.position.y, -632f, 570f), transform.position.z);

        float t = Time.time - startingTime;
        string minutes = ((int) t / 60).ToString();
        string seconds = (t % 60).ToString("f1");

        TimerText.text = minutes + ":" + seconds;

        if (seconds == "1.0"){
            Text1.SetActive(true);
            Destroy(Text1, 3f);
        }

        if (seconds == "9.0"){
            Text2.SetActive(true);
            Destroy(Text2, 2f);
        }
   }

   void OnTriggerEnter2D(Collider2D collider){
       if (collider.tag == "Target")
       {
           Debug.Log("ARRIVE!");
           Fade.SetActive(true);
           animator.SetTrigger("Fade");
           vehicle.SetActive(false);
           Player.SetActive(true);
           Camera.SetActive(false);
           Camera1.SetActive(true);
       } 
   }

   
}
