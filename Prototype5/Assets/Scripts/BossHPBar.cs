using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHPBar : MonoBehaviour
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
        var newScale = (HP / TotalHP) * 10;
        transform.localScale = new Vector3(newScale, 1, 1);
        transform.position = new Vector3((newScale - 10) /2, 4.4f, 0);
    }
}
