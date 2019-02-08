using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFunctions : MonoBehaviour
{
	private TicTacToe ttt= new TicTacToe();
	//code for starting a new game
	public void newGameButton(){
		Debug.Log("Starting new game... ");
	}

	//code for pressing the buttons on the gameboard
	public void gameButton (int number){
		Debug.Log("Button "+ number+ " is pressed");
		ttt.setArray(number);
	}
}
