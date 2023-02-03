using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveSphere : MonoBehaviour {

    Material mat;

    private void Start() {
        mat = GetComponent<Renderer>().material;
    }

    private void Update() {
        mat.SetFloat("_DissolveAmount", Time.time*0.2f);
    }
}