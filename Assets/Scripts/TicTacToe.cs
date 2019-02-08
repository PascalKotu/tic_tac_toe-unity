using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicTacToe 
{
	private char[] gameboard = {'N','N','N','N','N','N','N','N','N'};
	private char player = 'X';

	public char getPlayer(){
		return player;
	}
	public void setArray(int field){
		if(gameboard[field] == 'N'){
			gameboard[field] = player;
			playerSwitch();
			checkWinConditions();
		}
	}

	private void playerSwitch(){
		if(player == 'X')
			player = 'O';
		else
			player = 'X';
	}

	private void checkWinConditions(){
		//row 1
		if(gameboard[0] == gameboard[1] && gameboard[1] == gameboard[2] && gameboard[2] != 'N')
			Debug.Log("Row 1");
		//row 2
		if(gameboard[3] == gameboard[4] && gameboard[4] == gameboard[5] && gameboard[5] != 'N')
			Debug.Log("Row 2");
		//row 3
		if(gameboard[6] == gameboard[7] && gameboard[7] == gameboard[8] && gameboard[8] != 'N')
			Debug.Log("Row 3");

		//column 1
		if(gameboard[0] == gameboard[3] && gameboard[3] == gameboard[6] && gameboard[6] != 'N')
			Debug.Log("Column 1");
		//column 2
		if(gameboard[1] == gameboard[4] && gameboard[4] == gameboard[7] && gameboard[7] != 'N')
			Debug.Log("Column 2");
		//column 3
		if(gameboard[2] == gameboard[5] && gameboard[5] == gameboard[8] && gameboard[8] != 'N')
			Debug.Log("Column 3");
	
		//diagonal 1
		if(gameboard[0] == gameboard[4] && gameboard[4] == gameboard[8] && gameboard[8] != 'N')
			Debug.Log("Diagonal 1");
		//diagonal 2
		if(gameboard[2] == gameboard[4] && gameboard[4] == gameboard[6] && gameboard[6] != 'N')
			Debug.Log("Diagonal 2");
	}
}
