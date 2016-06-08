using UnityEngine;
using System.Collections.Generic;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class CargoController : MonoBehaviour {
    public const int MaxCargo = 5;
    public const float CargoDistance = 1.35f;
    public GameObject crate;
    private GameObject player;
    private List<GameObject> cargos;

	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        cargos = new List<GameObject>();
	}
	
	void Update () {
	    
	}

    GameObject GetLastCrate() {
        return cargos[cargos.Count - 1];
    }

    public void AddCargo() {
        if (cargos.Count < MaxCargo) {
            GameObject newCargo = (GameObject)Instantiate(crate, Vector3.zero, Quaternion.identity);

            if (cargos.Count > 0) {
                // Conecta a nova caixa à última caixa
                newCargo.GetComponent<FixedJoint2D>().connectedBody = GetLastCrate().GetComponent<Rigidbody2D>();
                newCargo.GetComponent<FixedJoint2D>().anchor = new Vector2(0, CargoDistance);

                // Posição da caixa
                newCargo.transform.position = new Vector3(
                    GetLastCrate().transform.position.x, 
                    GetLastCrate().transform.position.y - GetLastCrate().GetComponent<SpriteRenderer>().bounds.size.y
                );
            } else {
                newCargo.GetComponent<FixedJoint2D>().connectedBody = player.GetComponent<Rigidbody2D>();

                newCargo.transform.position = new Vector3(
                    player.transform.position.x, 
                    player.transform.position.y - newCargo.GetComponent<FixedJoint2D>().anchor.y
                );
            }
            newCargo.transform.parent = player.transform;
            cargos.Add(newCargo);
        }
    }

    public void RemoveCargo(GameObject cargo) {
        cargos.Remove(cargo);
        Destroy(cargo);
    }
}

#if UNITY_EDITOR
// Botões para debug (inspector)
[CustomEditor(typeof(CargoController))]
public class CargoControllerEditor : Editor {
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();

        CargoController cc = (CargoController)target;
        if (GUILayout.Button("Add cargo")) {
            cc.AddCargo();
        }

        if (GUILayout.Button("Destroy all cargo")) {
            foreach (GameObject cargo in GameObject.FindGameObjectsWithTag("Crate")) {
                cc.RemoveCargo(cargo);
            }
        }
    }
}
#endif
