﻿using UnityEngine;
using System.Collections;

	public class EnemyMovement : MonoBehaviour {
		public Transform[] waypoints;
		int cur = 0;

		//public float speed = 0.3f;
		public float speed;


	void FixedUpdate () {
		float step = speed * Time.deltaTime;
		// Waypoint not reached yet? then move closer
		if (transform.position != waypoints[cur].position) {
			Vector3 p = Vector3.MoveTowards(transform.position,
				waypoints[cur].position,
				step);
			GetComponent<Rigidbody>().MovePosition(p);
		}
		// Waypoint reached, select next one
		else cur = (cur + 1) % waypoints.Length;

		// Animation
		Vector3 dir = waypoints[cur].position - (Vector3)transform.position;
		GetComponent<Animator>().SetFloat("DirX", dir.x);
		//GetComponent<Animator>().SetFloat("DirY", dir.y);
	}

	void OnTriggerEnter3D(Collider co) {
		if (co.name == "pixel")
			Destroy(co.gameObject);
	}
}
