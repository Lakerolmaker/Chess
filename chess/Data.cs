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

        public static int playerID = 1;

        public static List<piece> pieces = new List<piece>();

        public static List<highlightedTile> highlightedTiles = new List<highlightedTile>();

        public static Label[,] Tiles = new Label[8, 8];

        public static int whiteKillCount = 0;
        public static int blackKillcount = 0;

        public static List<PictureBox> whiteKillBoard = new List<PictureBox>();
        public static List<PictureBox> blackKillBoard = new List<PictureBox>();


        public static piece getPiece(String pieceName)
        {
            piece returned = null;

            //: hittar rätt piece
            foreach (piece item in Globalvar.pieces)
            {
                if (item.ThePiece.Name == pieceName)
                {
                    returned = item;
                }
            }

            return returned;
        }

        public static piece getPieceAt(int x , int y)
        {
            //: hittar rätt piece
            foreach (piece item in Globalvar.pieces)
            {
                if ((item.X == x) && (item.Y == y))
                {
                    return item;
                }
            }

            return null;
        }

        public static int getIndex(String pieceName)
        {
            //: hittar rätt piece
            for(int  i = 0; i < pieces.Count; i++)
            {
                if (pieces[i].ThePiece.Name == pieceName)
                {
                    return i;
                }
            }

            return -1;
        }

        public static void removePiece(String pieceName)
        {
            for (int i = 0; i < pieces.Count; i++)
            {
                if (pieces[i].ThePiece.Name == pieceName)
                {
                    pieces.RemoveAt(i);
                }
            }
        }

        public static void changeTurn()
        {
            if(playerID == 1)
            {
                playerID = 2;
            }else
            {
                playerID = 1;
            }
        }

        public static void removeKillOrder()
        {
            foreach (piece item in Globalvar.pieces)
            {
                item.killOrder = false;
            }
        }

        public static void removeHighlight()
        {
            foreach (highlightedTile item in Globalvar.highlightedTiles)
            {
                item.changeback();
                item.location.Click -= item.Location_Click;
            }
        }

    }

}
