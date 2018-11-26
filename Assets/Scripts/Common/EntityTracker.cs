using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public static class EntityTracker {

	private static Dictionary<EntityType, List<GameObject>> entities = new Dictionary<EntityType, List<GameObject>>();

	public static IEnumerable<GameObject> Find(EntityType filter) {
		if (entities.ContainsKey(filter)) {
			return entities[filter];
		}
		return Enumerable.Empty<GameObject>();
	}

	public static void Register(EntityType filter, GameObject obj) {
		if (entities.ContainsKey(filter)) {
			entities[filter].Add(obj);
			return;
		}
		entities.Add(filter, new List<GameObject> { obj });
	}

	public static void Unregister(EntityType filter, GameObject obj) {
		if (entities.ContainsKey(filter)) {
			entities[filter].Remove(obj);
		}
	}
}
