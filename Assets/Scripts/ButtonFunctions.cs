using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFunctions : MonoBehaviour
{
	[SerializeField]
	private GameObject[] buttons;

	//prefabs for gameboard
	[SerializeField]
	private GameObject cross;
	[SerializeField]
	private GameObject circle;

	//for showing gameboard 
	[SerializeField]
	private GameObject gameboard;
	[SerializeField]
	private GameObject gBCross;
	[SerializeField]
	private GameObject gBCircle;

	//for showing winningscreen
	[SerializeField]
	private GameObject winningScreen;
	[SerializeField]
	private GameObject wSCross;
	[SerializeField]
	private GameObject wSCircle;

	//for all actions that need Tic Tac Toe logic
	private TicTacToe ttt= new TicTacToe();

	//code for starting a new game
	public void newGameButton(){
		//if player decides to restart half way trough
		GameObject[] signs = GameObject.FindGameObjectsWithTag("Player");
		foreach(GameObject sign in signs)
			Destroy(sign);

		//toggle winscreen and show gameboard
		gameboard.SetActive(true);
		winningScreen.SetActive(false);
		wSCross.SetActive(false);
		wSCircle.SetActive(false);

		//also reactivate the buttons
		for(int i = 0; i < 9; i++)
			buttons[i].SetActive(true);

		//reset the next player
		gBCross.SetActive(true);
		gBCircle.SetActive(false);

		//and finally reset the Tic tac toe logic
		ttt.reset();
	}

	//code for pressing the buttons on the gameboard
	public void gameButton (int number){
		if(!ttt.isWon()){
			//places the correct sign onto the gameboard 
			placeSign(number);

			//show player for next turn
			gBCross.SetActive(!gBCross.activeSelf);
			gBCircle.SetActive(!gBCircle.activeSelf);

			//activate Tic tac toe logic
			ttt.setArray(number);
			if (ttt.isWon()){
				showWinScreen();
			}
		}
	}

	private void showWinScreen(){
		//first destroy signs on the gameboard
		GameObject[] signs = GameObject.FindGameObjectsWithTag("Player");
		foreach(GameObject sign in signs)
			Destroy(sign);

		//then deactivate the gameboard 
		gameboard.SetActive(false);
		//and activate the winingScreen with the player who won
		winningScreen.SetActive(true);
		if(ttt.getPlayer() == 'X'){
			wSCross.SetActive(true);
		} else if(ttt.getPlayer() == 'O'){
			wSCircle.SetActive(true);
		}else{
			wSCross.SetActive(true);
			wSCircle.SetActive(true);
		}
	}

	private void placeSign (int number){
		char player = ttt.getPlayer();
		if(player == 'X'){
			//places a cross on the gameboard
			GameObject go = Instantiate(cross, buttons[number].transform.position, Quaternion.identity);
			go.transform.SetParent(this.transform);
		} else {
			// places a circle on the gameboard
			GameObject go = Instantiate(circle, buttons[number].transform.position, Quaternion.identity);
			go.transform.SetParent(this.transform);
		}
		//deactivate button so it wont get clicked again
		buttons[number].SetActive(false);
	}


	public void quit(){
		Application.Quit();
	}

}
