using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBuilding", menuName = "Building/BuildingSO")]
public class Building : ScriptableObject
{
	[SerializeField] List<BuildStatus> buildings = new List<BuildStatus>();
	public List<BuildStatus> buildStatus => buildings;

	[Serializable]
	public class BuildStatus
	{
		//Œš•¨‚Ìƒpƒ‰ƒ[ƒ^‚ðƒŒƒxƒ‹‚²‚Æ‚ÉŠi”[
		[SerializeField] string _name;
		[SerializeField] int _lv;
		[SerializeField] int _cost;
		[SerializeField] float _effectParameter;

		public string Name => _name;
		public int Lv => _lv;
		public int Cost => _cost;
		public float EffectParameter => _effectParameter;
	}
}
