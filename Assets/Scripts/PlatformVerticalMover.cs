using UnityEngine;
 
 public class PlatformPhysicsMover : MonoBehaviour
 {
     public float distanciaDeSubida = 5.0f;
     public float velocidad = 2.0f;
 
     private Rigidbody rb;
     private Vector3 puntoInicial;
     private Vector3 puntoFinal;
     private bool subiendo = true;
 
     void Start()
     {
         // Necesitamos el Rigidbody para moverlo físicamente
         rb = GetComponent<Rigidbody>();
         puntoInicial = transform.position;
         puntoFinal = puntoInicial + new Vector3(0, distanciaDeSubida, 0);
     }
 
     void FixedUpdate() // Usamos FixedUpdate para cálculos de física
     {
         Vector3 objetivo = subiendo ? puntoFinal : puntoInicial;
 
         // Calculamos la siguiente posición
         Vector3 nuevaPosicion = Vector3.MoveTowards(rb.position, objetivo, velocidad * Time.fixedDeltaTime);
 
         // MovePosition hace que la plataforma "empuje" lo que haya en su camino
         rb.MovePosition(nuevaPosicion);
 
         if (Vector3.Distance(rb.position, objetivo) < 0.01f)
         {
             subiendo = !subiendo;
         }
     }
 }