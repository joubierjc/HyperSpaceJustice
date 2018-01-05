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
        // TODO Input manager or smth
        // Movements
        var horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * stat.speed;
        var vertical = Input.GetAxis("Vertical") * Time.deltaTime * stat.speed;
        transform.Translate(new Vector3(horizontal, vertical), Space.World);

        // Firing
        if(weapsys.CanFire()) {
            weapsys.Fire();
        }
    }
}
