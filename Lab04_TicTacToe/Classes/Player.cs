﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Lab04_TicTacToe.Classes
{
    public class Player
    {
		public string Name { get; set; }
		/// <summary>
		/// P1 is X and P2 will be O
		/// </summary>
		public string Marker { get; set; }

		/// <summary>
		/// Flag to determine if it is the user's turn
		/// </summary>
		public bool IsTurn { get; set; }


		public Position GetPosition(Board board)
		{
			Position desiredCoordinate = null;
			while (desiredCoordinate is null)
			{
				Console.WriteLine($"Please select a location");
				Int32.TryParse(Console.ReadLine(), out int position);
				desiredCoordinate = PositionForNumber(position);
			}
			return desiredCoordinate;

		}

        /// <summary>
        /// Takes in a position given by a player (a number 1 - 9) and returns the corresponding positon on the game board
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
		public static Position PositionForNumber(int position)
		{
			switch (position)
			{
				case 1:
                    return new Position(0, 0); // Top Left
				case 2: return new Position(0, 1); // Top Middle
				case 3: return new Position(0, 2); // Top Right
				case 4: return new Position(1, 0); // Middle Left
				case 5: return new Position(1, 1); // Middle Middle
				case 6: return new Position(1, 2); // Middle Right
				case 7: return new Position(2, 0); // Bottom Left
				case 8: return new Position(2, 1); // Bottom Middle 
				case 9: return new Position(2, 2); // Bottom Right

				default: return null;
			}
		}

        
        internal static void TakeTurn(object board)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Runs GetPosition, sets player marker to equal the selected board game position
        /// </summary>
        /// <param name="board"></param>
        public void TakeTurn(Board board)
		{
			IsTurn = true;

			Console.WriteLine($"{Name} it is your turn");

			Position position = GetPosition(board);

			if (Int32.TryParse(board.GameBoard[position.Row, position.Column], out int _))
			{
				board.GameBoard[position.Row, position.Column] = Marker;

                
                
			}
			else
			{                
				Console.WriteLine("This space is already occupied");
                board.DisplayBoard();
                TakeTurn(board);

			}
		}
	}
}
