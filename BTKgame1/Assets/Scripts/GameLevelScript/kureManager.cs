using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kureManager : MonoBehaviour
{

    public kupManager kupManager;

    

    // Start is called before the first frame update
    void Start()
    {
        kupManager = GameObject.Find("Kupp").GetComponent<kupManager>();

        Debug.Log(kupManager.kupunHacmi);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
