using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class StoneSpawner : MonoBehaviour
	{
		[SerializeField]
		private GameObject[] stonePrefabs;
		[SerializeField]
		private GameObject[] stonePrefabsBlack;

		[SerializeField]
		private DataController m_dataController;
		public GameObject Spawn()
		{
			var position = transform.position;
			var rotation = transform.rotation;
			var index = Random.Range(0, stonePrefabs.Length);

			switch (m_dataController.m_gameData.rockChoice)
            {
				case 0:
					return GameObject.Instantiate(stonePrefabs[index], position, rotation);
				case 1:
					return GameObject.Instantiate(stonePrefabsBlack[index], position, rotation);
				default:
					return null;
			}
		}
	}
}
