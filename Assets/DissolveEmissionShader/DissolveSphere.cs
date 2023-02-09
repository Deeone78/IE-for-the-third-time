using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveSphere : MonoBehaviour {
    float paintSpeed = 4f; 
    Material mat;
    public ParticleSystem paint;
    public List<ParticleCollisionEvent> collisionEvents;

    float paintedAmount = 0f;

    private void Start() {
        mat = GetComponent<Renderer>().material;
        paint = FindObjectOfType<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();


        //GameObject copy = Instantiate(gameObject, transform.position, transform.rotation);
        //opy.GetComponent<DissolveSphere>().enabled = false;

        // mat.SetFloat("_DissolveAmount", Mathf.Sin(Time.time) / 2 + 0.5f);
    }
    private void OnParticleCollision(GameObject other)
    {
        if (paintedAmount < 1.0f)
        {
            paintedAmount = paintedAmount + Time.deltaTime*paintSpeed;
        }
    }

    private void Update() {
        mat.SetFloat("_DissolveAmount", paintedAmount);
    }
}