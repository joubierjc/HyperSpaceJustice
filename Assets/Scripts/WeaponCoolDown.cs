using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCoolDown : MonoBehaviour {

	public string weaponButtonAxisName = "Fire1";

	[SerializeField]
	private Weapon weapon;
	//private AudioSource abilitySource;

	private float coolDownDuration;
	private float nextReadyTime;
	private float coolDownTimeLeft;

	void Start() {
		Init(weapon);
	}

	public void Init(Weapon selectedWeapon) {
		//myButtonImage = GetComponent<Image>();
		//abilitySource = GetComponent<AudioSource>();
		//myButtonImage.sprite = weapon.aSprite;
		//darkMask.sprite = weapon.aSprite;
		coolDownDuration = weapon.CoolDown;
		weapon.Init(gameObject);
		//WeaponReady();
	}

	// Update is called once per frame
	private void Update() {
		bool coolDownComplete = (Time.time > nextReadyTime);
		if (coolDownComplete) {
			//WeaponReady();
			if (Input.GetButton(weaponButtonAxisName)) {
				ButtonTriggered();
			}
		}
		else {
			CoolDown();
		}
	//}

	//private void WeaponReady() {
	//	coolDownTextDisplay.enabled = false;
	//	darkMask.enabled = false;
	}

	private void CoolDown() {
		coolDownTimeLeft -= Time.deltaTime;
		float roundedCd = Mathf.Round(coolDownTimeLeft);
		//coolDownTextDisplay.text = roundedCd.ToString();
		//darkMask.fillAmount = (coolDownTimeLeft / coolDownDuration);
	}

	private void ButtonTriggered() {
		nextReadyTime = coolDownDuration + Time.time;
		coolDownTimeLeft = coolDownDuration;
		//darkMask.enabled = true;
		//coolDownTextDisplay.enabled = true;

		//abilitySource.clip = weapon.aSound;
		//abilitySource.Play();
		weapon.Trigger();
	}
}
