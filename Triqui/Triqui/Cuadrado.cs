using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triqui
{

    public struct Cuadrado
    {
		public enum Player { None = 0, Noughts, Crosses }

		public Jugador Owner { get; }
        public Cuadrado(Jugador owner)
        {
            this.Owner = owner;
        }


		public override string ToString()
		{
			switch (Owner)
			{
				case Player.None:
					return ".";
				case Player.Crosses:
					return "X";
				case Player.Noughts:
					return "O";
				default:
					throw new Exception("Invalid state");
			}
		}





	}
}
