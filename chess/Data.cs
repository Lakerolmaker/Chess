using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chess
{
    class Globalvar
    {

        public static List<piece> pieces = new List<piece>();

        public static List<highlightedTile> highlightedTiles = new List<highlightedTile>();

        public static Label[,] Tiles = new Label[8, 8];

    }
}
