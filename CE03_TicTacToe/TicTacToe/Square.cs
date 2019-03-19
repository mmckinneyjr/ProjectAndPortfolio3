using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Square
    {
        bool isEmpty = true;
        bool isRed = false;
        bool isBlue =false;
        bool isX =false;
        bool isO =false;
        
        public bool IsEmpty { get => isEmpty; set => isEmpty = value; }
        public bool IsRed { get => isRed; set => isRed = value; }
        public bool IsBlue { get => isBlue; set => isBlue = value; }
        public bool IsX { get => isX; set => isX = value; }
        public bool IsO { get => isO; set => isO = value; }
    }
}
