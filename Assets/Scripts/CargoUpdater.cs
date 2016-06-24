using UnityEngine;
using UnityEngine.UI;

public class CargoUpdater : MonoBehaviour {
    public int count { get; private set; }
    private Text cargo;

	void Start () {
        cargo = GetComponent<Text>();
        count = int.Parse(cargo.text);
        UpdateCargo();
	}

    void UpdateCargo() {
        if (count < 0) { count = 0; }
        cargo.text = count.ToString();
    }

    public void AddCrate() {
        count++;
        UpdateCargo();
    }

    public void RemoveAllCargo() {
        count = 0;
        UpdateCargo();
    }
}
