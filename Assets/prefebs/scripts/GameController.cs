using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public Text[] buttonList;
	private string playerSide;
	public GameObject gameOverPanel;
	public Text gameOverText;
	private int moveCount;
	public GameObject restartButton;

	 



	void Awake(){
		SetGameControllerReferenceOnButtons ();
		playerSide = "X";
		gameOverPanel.SetActive (false);
		moveCount = 0;
		restartButton.SetActive (false);

	}





	public void SetGameControllerReferenceOnButtons(){
		for (int i=0; i< buttonList.Length; i++) {
			buttonList[i].GetComponentInParent<GridSpace>().SetGameControllerReference(this);
		}
	}






	public string getPlayerSide(){
		return playerSide;

	}






	public void EndTurn(){
		moveCount++;
		if (buttonList [0].text == playerSide && buttonList [1].text == playerSide && buttonList [2].text == playerSide) {
			gameOver(playerSide);
		}

		if (buttonList [3].text == playerSide && buttonList[4].text == playerSide && buttonList[5].text == playerSide) {
			gameOver(playerSide);
		}

		if (buttonList [6].text == playerSide && buttonList [7].text == playerSide && buttonList [8].text == playerSide) {
			gameOver(playerSide);
		}

		if (buttonList [0].text == playerSide && buttonList [3].text == playerSide && buttonList [6].text == playerSide) {
			gameOver(playerSide);
		}

		if (buttonList [1].text == playerSide && buttonList [4].text == playerSide && buttonList [7].text == playerSide) {
			gameOver(playerSide);
		}

		if (buttonList [2].text == playerSide && buttonList [5].text == playerSide && buttonList [8].text == playerSide) {
			gameOver(playerSide);
		}

		if (buttonList [0].text == playerSide && buttonList [4].text == playerSide && buttonList [8].text == playerSide) {
			gameOver(playerSide);
		}

		if (buttonList [2].text == playerSide && buttonList [4].text == playerSide && buttonList [6].text == playerSide) {
			gameOver(playerSide);
		}
		if (moveCount >= 9) {
		
			gameOver("draw");
		}
		changeSide ();

	}






	void gameOver(string winningPlayer){
		setInteractable (false);
		if (winningPlayer == "draw") {
			setGameOverText ("It's a draw");
		} 
		else {
			setGameOverText(winningPlayer + " wins");
		}
		restartButton.SetActive (true);
	}










	void changeSide(){
		playerSide= (playerSide == "X")? "O" : "X";
	}










	void setGameOverText(string value){
		gameOverPanel.SetActive (true);
		gameOverText.text = value;
	}








	public void restartGame(){
		playerSide = "X";
		moveCount = 0;
		gameOverPanel.SetActive (false);
		setInteractable(true);
		for(int i = 0 ; i < buttonList.Length; i++){

			buttonList[i].text="";
		}

		restartButton.SetActive (false);

	}





	public void setInteractable(bool toggle){
		for(int i = 0 ; i < buttonList.Length; i++){
			buttonList[i].GetComponentInParent<Button>().interactable=toggle;
		}
	}

}
