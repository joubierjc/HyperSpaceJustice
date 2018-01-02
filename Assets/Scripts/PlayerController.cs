using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private StatHolder stat;
    private WeaponSystem weapsys;
    
	private void Start () {
        stat = GetComponent<StatHolder>();
        weapsys = GetComponent<WeaponSystem>();
	}
	
	private void Update () {
        // Once the player press an input do something based on in stats/body/holder/...

        // Movements
        // TODO Input manager or smth
        var horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * stat.speed;
        var vertical = Input.GetAxis("Vertical") * Time.deltaTime * stat.speed;
        transform.Translate(new Vector3(horizontal, vertical));

        // Firing
        if(weapsys.CanFire()) {
            weapsys.Fire();
        }
    }
}
