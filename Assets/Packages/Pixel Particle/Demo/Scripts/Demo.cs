namespace MoenenGames.PixelParticle {

	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.UI;
#if UNITY_EDITOR
	using UnityEditor;
	using System.IO;
#endif


	public class Demo : MonoBehaviour {



		// SUB
		[System.Serializable]
		public class ParticleData {


			public Transform this[int index] {
				get {
					return ParticleRoot[Mathf.Clamp(index, 0, Count - 1)];
				}
			}

			public int Count {
				get {
					return ParticleRoot.Count;
				}
			}

			public string Label {
				get {
					return m_Label;
				}

				set {
					m_Label = value;
				}
			}

			public List<Transform> ParticleRoot {
				get {
					return m_ParticleRoot;
				}

				set {
					m_ParticleRoot = value;
				}
			}



			[SerializeField] private string m_Label;
			[SerializeField] private List<Transform> m_ParticleRoot;


		}




		// VAR
		private Transform ShowingParticleRoot {
			get {
				if (!m_ShowingParticleRoot) {
					m_ShowingParticleRoot = new GameObject("Showing Particle Root").transform;
					m_ShowingParticleRoot.SetParent(null);
					m_ShowingParticleRoot.position = Vector3.zero;
					m_ShowingParticleRoot.rotation = Quaternion.identity;
					m_ShowingParticleRoot.localScale = Vector3.one;
				}
				return m_ShowingParticleRoot;
			}
		}

		public List<ParticleData> Data {
			get {
				return m_Data;
			}
			set {
				m_Data = value;
			}
		}


		[SerializeField] private Text m_NameLabel;
		[SerializeField] private Transform m_SwitchPanelRoot;
		[SerializeField] private Toggle m_SwitchTGTemplate;
		[SerializeField] private Image m_Bar;
		[SerializeField] private bool m_RandomType = true;
		[SerializeField] private List<ParticleData> m_Data;



		private int CurrentParticleIndex = 0;
		private int CurrentSubIndex = 0;
		private Transform m_ShowingParticleRoot = null;





		// MSG
		private void Awake () {
			SwitchParticle();
		}



		private void Update () {

			if (Input.GetKeyDown(KeyCode.LeftArrow) ||
				Input.GetKeyDown(KeyCode.DownArrow) ||
				Input.GetKeyDown(KeyCode.Backspace)
			) {
				SpawnPrevParticle();
			}


			if (Input.GetKeyDown(KeyCode.RightArrow) ||
				Input.GetKeyDown(KeyCode.UpArrow) ||
				Input.GetKeyDown(KeyCode.Space) ||
				Input.GetKeyDown(KeyCode.Return)
			) {
				SpawnNextParticle();
			}


			if (Input.GetKeyDown(KeyCode.Tab)) {
				ChangeSubIndex((CurrentSubIndex + 1) % m_Data[CurrentParticleIndex].Count);
				RespawnToggles();
				ResetName();
			}

		}



		private void SwitchParticle () {

			// Check
			if (m_Data[CurrentParticleIndex][CurrentSubIndex] == null) {
				m_NameLabel.text = "";
				return;
			}

			// Sub Index
			if (m_RandomType) {
				CurrentSubIndex = (int)(Random.value * m_Data[CurrentParticleIndex].Count - 0.001f);
			}
			ChangeSubIndex(Mathf.Clamp(CurrentSubIndex, 0, m_Data[CurrentParticleIndex].Count - 1));

			// UI
			ResetName();
			RespawnToggles();

		}




		public void RespawnParticle (int index, int subIndex) {

			// Delete Old
			if (m_ShowingParticleRoot) {
				DestroyImmediate(m_ShowingParticleRoot.gameObject, false);
			}

			// Bar
			FreshBar();

			// Add New
			ParticleData data = m_Data[index];
			Transform tf = Instantiate(data[subIndex]);
			tf.SetParent(ShowingParticleRoot);
			tf.localPosition = Vector3.zero;
			tf.localRotation = Quaternion.identity;
			tf.localScale = Vector3.one;

		}



		// API
		public void UGUI_NextParticle () {
			SpawnNextParticle();
		}



		public void UGUI_PrevParticle () {
			SpawnPrevParticle();
		}



		public void UGUI_FiveStar () {
			Application.OpenURL(@"http://u3d.as/1hbh");
		}


		public void UGUI_LPP () {
			Application.OpenURL(@"http://u3d.as/Mq0");
		}






#if UNITY_EDITOR

		public void SyncData () {
			
			var dir = new DirectoryInfo("Assets/Pixel Particle/Prefab");
			if (dir.Exists) {
				var dataMap = new Dictionary<string, ParticleData>();
				var prefabFiles = dir.GetFiles("*.prefab", SearchOption.AllDirectories);
				for (int i = 0; i < prefabFiles.Length; i++) {
					string path = RelativePath(prefabFiles[i].FullName);
					var parG = AssetDatabase.LoadAssetAtPath<GameObject>(path);
					ParticleSystem par = null;
					if (parG) { par = parG.GetComponent<ParticleSystem>(); }
					if (par) {
						string parName = prefabFiles[i].Directory.Name;
						if (dataMap.ContainsKey(parName)) {
							dataMap[parName].ParticleRoot.Add(par.transform);
						} else {
							dataMap.Add(parName, new ParticleData() {
								Label = parName,
								ParticleRoot = new List<Transform>() { par.transform },
							});
						}
					}
				}
				Data = new List<ParticleData>(dataMap.Values);
			}
		}


		private string RelativePath (string path) {
			path = FixPath(path);
			if (path.StartsWith("Assets")) {
				return path;
			}
			if (path.StartsWith(FixPath(Application.dataPath))) {
				return "Assets" + path.Substring(FixPath(Application.dataPath).Length);
			} else {
				return "";
			}
		}



		private string FixPath (string _path) {
			_path = _path.Replace('\\', '/');
			_path = _path.Replace("//", "/");
			while (_path.Length > 0 && _path[0] == '/') {
				_path = _path.Remove(0, 1);
			}
			return _path;
		}


#endif

		// Logic
		private void SpawnNextParticle () {
			CurrentParticleIndex = (int)Mathf.Repeat(CurrentParticleIndex + 1, m_Data.Count);
			SwitchParticle();
		}


		private void SpawnPrevParticle () {
			CurrentParticleIndex = (int)Mathf.Repeat(CurrentParticleIndex - 1, m_Data.Count);
			SwitchParticle();
		}


		private void ChangeSubIndex (int index) {
			CurrentSubIndex = index;
			RespawnParticle(CurrentParticleIndex, CurrentSubIndex);
		}


		private void RespawnToggles () {
			// Clear
			Toggle[] tgs = m_SwitchPanelRoot.GetComponentsInChildren<Toggle>(true);
			for (int i = 0; i < tgs.Length; i++) {
				tgs[i].onValueChanged.RemoveAllListeners();// I did this in demo code....
				DestroyImmediate(tgs[i].gameObject, false);
			}
			// Add
			for (int i = 0; i < m_Data[CurrentParticleIndex].Count; i++) {
				Toggle tg = Instantiate(m_SwitchTGTemplate);
				if (!tg.gameObject.activeSelf) {
					tg.gameObject.SetActive(true);
				}
				tg.transform.SetParent(m_SwitchPanelRoot);
				tg.transform.localScale = Vector3.one;
				tg.transform.localRotation = Quaternion.identity;
				Vector2 pos = tg.transform.localPosition;
				tg.transform.localPosition = pos;
				int index = i;
				int count = m_Data[CurrentParticleIndex].Count;
				tg.isOn = i == Mathf.Clamp(CurrentSubIndex, 0, count - 1);
				tg.onValueChanged.AddListener((isOn) => {
					if (isOn) {
						ChangeSubIndex(index % count);
						ResetName();
					}
				});
				Text text = tg.GetComponentInChildren<Text>(true);
				if (text) {
					string _subName = m_Data[CurrentParticleIndex][i].name;
					if (!string.IsNullOrEmpty(_subName)) {
						text.text = _subName[_subName.Length - 1].ToString();
					}
				}
			}
		}


		private void ResetName () {
			string _name = m_Data[CurrentParticleIndex][CurrentSubIndex].name;
			m_NameLabel.text = _name + "\n<size=18>" + (CurrentParticleIndex + 1).ToString("00") + " / " + m_Data.Count.ToString("00") + "</size>";
		}


		private void FreshBar () {
			m_Bar.fillAmount = ((CurrentParticleIndex + 0.1f) / (m_Data.Count - 1f));
		}




		private void FixCurves (params ParticleSystem.MinMaxCurve[] curves) {

			for (int i = 1; i < curves.Length; i++) {
				if (curves[i].mode == curves[0].mode) { continue; }
				Debug.Log(curves[i].mode + " >> " + curves[0].mode);
				curves[i].mode = curves[0].mode;
			}



		}

	}





#if UNITY_EDITOR


	[CustomEditor(typeof(Demo))]
	public class DemoInspector : Editor {


		public override void OnInspectorGUI () {
			base.OnInspectorGUI();

			GUILayout.Space(2);

			if (GUI.Button(GUILayoutUtility.GetRect(0f, 36f, GUILayout.ExpandWidth(true)), "Sync Data")) {
				(target as Demo).SyncData();
			}

			GUILayout.Space(4);

		}



	}


#endif

}