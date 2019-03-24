using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHPBar : MonoBehaviour
{
    public float TotalHP;
    public float HP;
    // Start is called before the first frame update
    void Start()
    {
        HP = TotalHP;
    }

    // Update is called once per frame
    void Update()
    {
        var transform = GetComponent<Transform>();
        var newScale = (HP / TotalHP) * 3;
        transform.localScale = new Vector3(newScale, 1, 1);
        transform.position = new Vector3(9-(3 - newScale)/2, -1, 0);
    }
}
