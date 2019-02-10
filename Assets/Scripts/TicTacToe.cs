using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicTacToe 
{
	private char[] gameboard = {'N','N','N','N','N','N','N','N','N'};
	private char player = 'X';

	private int winposition = 8;

	private bool win = false;

	public char getPlayer(){
		return player;
	}

	public bool isWon(){
		return win;
	}

	public int getWinPosition(){
		return winposition;
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
		else if(player == 'O')
			player = 'X';
	}

	private bool checkWinConditions(){
		//row 1
		if(gameboard[0] == gameboard[1] && gameboard[1] == gameboard[2] && gameboard[2] != 'N'){
			playerSwitch();
			winposition = 0;
			return true;
		}
		//row 2
		if(gameboard[3] == gameboard[4] && gameboard[4] == gameboard[5] && gameboard[5] != 'N'){
			playerSwitch();
			winposition = 1;
			return true;
		}
		//row 3
		if(gameboard[6] == gameboard[7] && gameboard[7] == gameboard[8] && gameboard[8] != 'N'){
			playerSwitch();
			winposition = 2;
			return true;
		}

		//column 1
		if(gameboard[0] == gameboard[3] && gameboard[3] == gameboard[6] && gameboard[6] != 'N'){
			playerSwitch();
			winposition = 3;
			return true;
		}
		//column 2
		if(gameboard[1] == gameboard[4] && gameboard[4] == gameboard[7] && gameboard[7] != 'N'){
			playerSwitch();
			winposition = 4;
			return true;
		}
		//column 3
		if(gameboard[2] == gameboard[5] && gameboard[5] == gameboard[8] && gameboard[8] != 'N'){
			playerSwitch();
			winposition = 5;
			return true;
		}
	
		//diagonal 1
		if(gameboard[0] == gameboard[4] && gameboard[4] == gameboard[8] && gameboard[8] != 'N'){
			playerSwitch();
			winposition = 6;
			return true;
		}
		//diagonal 2
		if(gameboard[2] == gameboard[4] && gameboard[4] == gameboard[6] && gameboard[6] != 'N'){
			playerSwitch();
			winposition = 7;
			return true;
		}

		//if gameboard is not full
		for(int i = 0; i < 9; i++){
			if (gameboard[i] == 'N'){
				return false;
			}
		}
		//if gameboard is full and no winner was found
		player = 'N';
		return true;
	}

	//reset all variables for the ttt logic
	public void reset(){
		for(int i = 0; i < 9; i++)
			gameboard[i] = 'N';
		player = 'X';
		win = false;
		winposition = 8;
	}
}
