using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFunctions : MonoBehaviour
{
	[SerializeField]
	private GameObject[] buttons = default;

	//prefabs for gameboard
	[SerializeField]
	private GameObject cross = default;
	[SerializeField]
	private GameObject circle = default;

	//for showing gameboard 
	[SerializeField]
	private GameObject gameboard = default;
	[SerializeField]
	private GameObject gBCross = default;
	[SerializeField]
	private GameObject gBCircle = default;

	//for showing winningscreen
	[SerializeField]
	private GameObject winningScreen = default;
	[SerializeField]
	private GameObject wSCross = default;
	[SerializeField]
	private GameObject wSCircle = default;
	[SerializeField]
	private GameObject winline = default;

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
				showWinLine();
			}
		}
	}

	//shows a line to indicate what line brought victory to one of the players
	private void showWinLine(){
		//row1
		if(ttt.getWinPosition() == 0){
			GameObject go = Instantiate(winline, buttons[1].transform.position, Quaternion.identity);
			go.transform.SetParent(this.transform);
		}
		//row2
		if(ttt.getWinPosition() == 1){
			GameObject go = Instantiate(winline, buttons[4].transform.position, Quaternion.identity);
			go.transform.SetParent(this.transform);
		}
		//row3
		if(ttt.getWinPosition() == 2){
			GameObject go = Instantiate(winline, buttons[7].transform.position, Quaternion.identity);
			go.transform.SetParent(this.transform);
		}

		//column1
		if(ttt.getWinPosition() == 3){
			GameObject go = Instantiate(winline, buttons[3].transform.position, Quaternion.AngleAxis(-90, Vector3.forward));
			go.transform.SetParent(this.transform);
		}
		//column2
		if(ttt.getWinPosition() == 4){
			GameObject go = Instantiate(winline, buttons[4].transform.position, Quaternion.AngleAxis(-90, Vector3.forward));
			go.transform.SetParent(this.transform);
		}
		//column3
		if(ttt.getWinPosition() == 5){
			GameObject go = Instantiate(winline, buttons[5].transform.position, Quaternion.AngleAxis(-90, Vector3.forward));
			go.transform.SetParent(this.transform);
		}

		//diagonal1
		if(ttt.getWinPosition() == 6){
			GameObject go = Instantiate(winline, buttons[4].transform.position, Quaternion.AngleAxis(-45, Vector3.forward));
			go.transform.SetParent(this.transform);
		}
		//diagonal2
		if(ttt.getWinPosition() == 7){
			GameObject go = Instantiate(winline, buttons[4].transform.position, Quaternion.AngleAxis(45, Vector3.forward));
			go.transform.SetParent(this.transform);
		}
		//none
		if(ttt.getWinPosition() == 8){
			showWinScreen();
		}

	}
	//is called when the animation of the winline is finished
	public void resume(){
		showWinScreen();
	}


	private void showWinScreen(){
		//first deactivate the gameboard 
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
		//then destroy signs on the gameboard
		GameObject[] signs = GameObject.FindGameObjectsWithTag("Player");
		foreach(GameObject sign in signs)
			Destroy(sign);
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
