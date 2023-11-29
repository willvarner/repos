using System.IO.Pipelines;
using System.Numerics;

namespace ConnectFour.Models
{
    public class State
    {
        State()
        {
            players = new Players[]
            {
      new Player() { Name= "Player", Points = 0 },
      new Player() { Name= "Opponent", Points = 0 }
            };
            GameRoundsPlayed = 0;
            GameOver = false;
        }

        void ResetGame()
        {
            GameOver = false;
            players[0].Points = 0;
            players[1].Points = 0;
        }

        void EndGame()
        {
            GameOver = true;
            GameRoundsPlayed++;
            // award winner.. 
        }

        Player[] players;

        int GameRoundsPlayed;
        bool GameOver;
    }

    Piece[] pieces;
    State()
    {
        this.pieces = new Piece[25]; // 5x5 board
    }

    void PlayPiece(int position)
    {
        this.pieces[position] = true; // true = occupied 
    }
}
