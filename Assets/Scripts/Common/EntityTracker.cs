using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public static class EntityTracker {

	private static Dictionary<SearchFilter, List<GameObject>> entities = new Dictionary<SearchFilter, List<GameObject>>();

	public static IEnumerable<GameObject> Find(SearchFilter filter) {
		if (entities.ContainsKey(filter)) {
			return entities[filter];
		}
		return Enumerable.Empty<GameObject>();
	}

	public static void Register(SearchFilter filter, GameObject obj) {
		if (entities.ContainsKey(filter)) {
			entities[filter].Add(obj);
			return;
		}
		entities.Add(filter, new List<GameObject> { obj });
	}

	public static void Unregister(SearchFilter filter, GameObject obj) {
		if (entities.ContainsKey(filter)) {
			entities[filter].Remove(obj);
		}
	}
}
