using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFunctions : MonoBehaviour
{
	[SerializeField]
	private GameObject[] buttons;
	[SerializeField]
	private GameObject cross;
	[SerializeField]
	private GameObject circle;


	private TicTacToe ttt= new TicTacToe();

	//code for starting a new game
	public void newGameButton(){
		GameObject[] signs = GameObject.FindGameObjectsWithTag("Player");
		foreach(GameObject sign in signs)
			Destroy(sign);
		for(int i = 0; i < 9; i++)
			buttons[i].SetActive(true);
		ttt.reset();
	}

	//code for pressing the buttons on the gameboard
	public void gameButton (int number){
		if(!ttt.isWon()){
			placeSign(number);
			ttt.setArray(number);
			if (ttt.isWon()){
				Debug.Log(ttt.getPlayer() +" wins");
			}
		}
	}
	private void placeSign (int number){
		char player = ttt.getPlayer();
		if(player == 'X'){
			GameObject go = Instantiate(cross, buttons[number].transform.position, Quaternion.identity);
			go.transform.SetParent(this.transform);
		} else {
			GameObject go = Instantiate(circle, buttons[number].transform.position, Quaternion.identity);
			go.transform.SetParent(this.transform);
		}
		buttons[number].SetActive(false);
	}

}
