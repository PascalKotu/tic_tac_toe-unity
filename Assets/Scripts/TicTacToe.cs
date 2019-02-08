using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicTacToe 
{
	private char[] gameboard = {'N','N','N','N','N','N','N','N','N'};
	private char player = 'X';

	private bool win = false;

	public char getPlayer(){
		return player;
	}

	public bool isWon(){
		return win;
	}

	public void setArray(int field){
		if(gameboard[field] == 'N'){
			gameboard[field] = player;
			playerSwitch();
			win = checkWinConditions();
		}else{
			win = false;
		}
	}

	private void playerSwitch(){
		if(player == 'X')
			player = 'O';
		else
			player = 'X';
	}

	private bool checkWinConditions(){
		//row 1
		if(gameboard[0] == gameboard[1] && gameboard[1] == gameboard[2] && gameboard[2] != 'N'){
			playerSwitch();
			return true;
		}
		//row 2
		if(gameboard[3] == gameboard[4] && gameboard[4] == gameboard[5] && gameboard[5] != 'N'){
			playerSwitch();
			return true;
		}
		//row 3
		if(gameboard[6] == gameboard[7] && gameboard[7] == gameboard[8] && gameboard[8] != 'N'){
			playerSwitch();
			return true;
		}

		//column 1
		if(gameboard[0] == gameboard[3] && gameboard[3] == gameboard[6] && gameboard[6] != 'N'){
			playerSwitch();
			return true;
		}
		//column 2
		if(gameboard[1] == gameboard[4] && gameboard[4] == gameboard[7] && gameboard[7] != 'N'){
			playerSwitch();
			return true;
		}
		//column 3
		if(gameboard[2] == gameboard[5] && gameboard[5] == gameboard[8] && gameboard[8] != 'N'){
			playerSwitch();
			return true;
		}
	
		//diagonal 1
		if(gameboard[0] == gameboard[4] && gameboard[4] == gameboard[8] && gameboard[8] != 'N'){
			playerSwitch();
			return true;
		}
		//diagonal 2
		if(gameboard[2] == gameboard[4] && gameboard[4] == gameboard[6] && gameboard[6] != 'N'){
			playerSwitch();
			return true;
		}

		//if gameboard is not full
		for(int i = 0; i < 9; i++){
			if (gameboard[i] == 'N'){
				return false;
			}
		}
		//if gameboard is full and not winner was found
		player = 'N';
		return true;
	}
}
