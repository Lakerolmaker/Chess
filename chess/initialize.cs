using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess
{
    class initialize
    {
        //: skapar alla pjäser

        public static void normal()
        {
            Globalvar.pieces.Add(new piece("tower", "black", Globalvar.Tiles[0,0], "blacktower1", 0, 0));
            Globalvar.pieces.Add(new piece("horse", "black", Globalvar.Tiles[1, 0], "blackhorse1", 1, 0));
            Globalvar.pieces.Add(new piece("sprinter", "black", Globalvar.Tiles[2, 0], "blacksprinter1", 2, 0));
            Globalvar.pieces.Add(new piece("queen", "black", Globalvar.Tiles[3, 0], "blackqueen", 3, 0));
            Globalvar.pieces.Add(new piece("king", "black", Globalvar.Tiles[4, 0], "blackking", 4, 0));
            Globalvar.pieces.Add(new piece("sprinter", "black", Globalvar.Tiles[5, 0], "blacksprinter2", 5, 0));
            Globalvar.pieces.Add(new piece("horse", "black", Globalvar.Tiles[6, 0], "blackhorse2", 6, 0));
            Globalvar.pieces.Add(new piece("tower", "black", Globalvar.Tiles[7, 0], "blacktower2", 7, 0));

            Globalvar.pieces.Add(new piece("pawn", "black", Globalvar.Tiles[0, 1], "blackpawn1", 0, 1));
            Globalvar.pieces.Add(new piece("pawn", "black", Globalvar.Tiles[1, 1], "blackpawn2", 1, 1));
            Globalvar.pieces.Add(new piece("pawn", "black", Globalvar.Tiles[2, 1], "blackpawn3", 2, 1));
            Globalvar.pieces.Add(new piece("pawn", "black", Globalvar.Tiles[3, 1], "blackpawn4", 3, 1));
            Globalvar.pieces.Add(new piece("pawn", "black", Globalvar.Tiles[4, 1], "blackpawn5", 4, 1));
            Globalvar.pieces.Add(new piece("pawn", "black", Globalvar.Tiles[5, 1], "blackpawn6", 5, 1));
            Globalvar.pieces.Add(new piece("pawn", "black", Globalvar.Tiles[6, 1], "blackpawn7", 6, 1));
            Globalvar.pieces.Add(new piece("pawn", "black", Globalvar.Tiles[7, 1], "blackpawn8", 7, 1));



            Globalvar.pieces.Add(new piece("pawn", "white", Globalvar.Tiles[0, 6], "whitepawn1", 0, 6));
            Globalvar.pieces.Add(new piece("pawn", "white", Globalvar.Tiles[1, 6], "whitepawn2", 1, 6));
            Globalvar.pieces.Add(new piece("pawn", "white", Globalvar.Tiles[2, 6], "whitepawn3", 2, 6));
            Globalvar.pieces.Add(new piece("pawn", "white", Globalvar.Tiles[3, 6], "whitepawn4", 3, 6));
            Globalvar.pieces.Add(new piece("pawn", "white", Globalvar.Tiles[4, 6], "whitepawn5", 4, 6));
            Globalvar.pieces.Add(new piece("pawn", "white", Globalvar.Tiles[5, 6], "whitepawn6", 5, 6));
            Globalvar.pieces.Add(new piece("pawn", "white", Globalvar.Tiles[6, 6], "whitepawn7", 6, 6));
            Globalvar.pieces.Add(new piece("pawn", "white", Globalvar.Tiles[7, 6], "whitepawn8", 7, 6));

            Globalvar.pieces.Add(new piece("tower", "white", Globalvar.Tiles[0, 7], "whitetower1", 0, 7));
            Globalvar.pieces.Add(new piece("horse", "white", Globalvar.Tiles[1, 7], "whiteorse1", 1, 7));
            Globalvar.pieces.Add(new piece("sprinter", "white", Globalvar.Tiles[2, 7], "whitesprinter1", 2, 7));
            Globalvar.pieces.Add(new piece("queen", "white", Globalvar.Tiles[3, 7], "whitequeen", 3, 7));
            Globalvar.pieces.Add(new piece("king", "white", Globalvar.Tiles[4, 7], "whiteking", 4, 7));
            Globalvar.pieces.Add(new piece("sprinter", "white", Globalvar.Tiles[5, 7], "whitesprinter2", 5, 7));
            Globalvar.pieces.Add(new piece("horse", "white", Globalvar.Tiles[6, 7], "whitehorse2", 6, 7));
            Globalvar.pieces.Add(new piece("tower", "white", Globalvar.Tiles[7, 7], "whitetower2", 7, 7));

        }

        public static void random()
        {

            #region black


            Boolean blackKing = false;

            for (int i = 0; i < 8; i += 0)
            {
                String pieceName = Globalvar.getRandomPiece();

                if(pieceName != "king")
                {
                    Globalvar.pieces.Add(new piece(pieceName, "black", Globalvar.Tiles[i, 0], "black1" + pieceName + i, i, 0));
                    i++;
                }
                else if((pieceName == "king") && (blackKing == false))
                {
                    Globalvar.pieces.Add(new piece(pieceName, "black", Globalvar.Tiles[i, 0], "black1" + pieceName + i, i, 0));
                    i++;
                    blackKing = true;
                }
            }

            for (int i = 0; i < 8; i += 0)
            {
                String pieceName = Globalvar.getRandomPiece();

                if (pieceName != "king")
                {
                    Globalvar.pieces.Add(new piece(pieceName, "black", Globalvar.Tiles[i, 1], "black2" + pieceName + i, i, 1));
                    i++;
                }
                else if ((pieceName == "king") && (blackKing == false))
                {
                    Globalvar.pieces.Add(new piece(pieceName, "black", Globalvar.Tiles[i, 1], "black2" + pieceName + i, i, 1));
                    i++;
                    blackKing = true;

                }

            }

            #endregion

            #region white


            Boolean whiteKing = false;

            for (int i = 0; i < 8; i += 0)
            {
                String pieceName = Globalvar.getRandomPiece();

                if (pieceName != "king")
                {
                    Globalvar.pieces.Add(new piece(pieceName, "white", Globalvar.Tiles[i, 7], "white1" + pieceName + i, i, 7));
                    i++;
                }
                else if ((pieceName == "king") && (whiteKing == false))
                {
                    Globalvar.pieces.Add(new piece(pieceName, "white", Globalvar.Tiles[i, 7], "white1" + pieceName + i, i, 7));
                    i++;
                    whiteKing = true;
                }
            }

            for (int i = 0; i < 8; i += 0)
            {
                String pieceName = Globalvar.getRandomPiece();

                if (pieceName != "king")
                {
                    Globalvar.pieces.Add(new piece(pieceName, "white", Globalvar.Tiles[i, 6], "white2" + pieceName + i, i, 6));
                    i++;
                }
                else if ((pieceName == "king") && (whiteKing == false))
                {
                    Globalvar.pieces.Add(new piece(pieceName, "white", Globalvar.Tiles[i, 6], "white2" + pieceName + i, i, 6));
                    i++;
                    whiteKing = true;

                }

            }

            #endregion



        }


    }
}
