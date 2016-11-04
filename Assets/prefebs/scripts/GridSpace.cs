using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GridSpace : MonoBehaviour {

	public Button button;
	public Text buttonText;

	private GameController gamecontroller;

	public void setSpace(){
		buttonText.text=gamecontroller.getPlayerSide();
		button.interactable = false;
		gamecontroller.EndTurn ();

}

	public void SetGameControllerReference(GameController controller){
		gamecontroller = controller;
	}


}
 