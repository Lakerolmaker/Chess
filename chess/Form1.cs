using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chess
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       
      
        // TODO : gör multiplayer 

        

        private void Form1_Load(object sender, EventArgs e)
        {

            #region lägger in all tiles i en array

            Globalvar.Tiles[0, 0] = tile11;
            Globalvar.Tiles[1, 0] = tile12;
            Globalvar.Tiles[2, 0] = tile13;
            Globalvar.Tiles[3, 0] = tile14;
            Globalvar.Tiles[4, 0] = tile15;
            Globalvar.Tiles[5, 0] = tile16;
            Globalvar.Tiles[6, 0] = tile17;
            Globalvar.Tiles[7, 0] = tile18;
            Globalvar.Tiles[0, 1] = tile21;
            Globalvar.Tiles[1, 1] = tile22;
            Globalvar.Tiles[2, 1] = tile23;
            Globalvar.Tiles[3, 1] = tile24;
            Globalvar.Tiles[4, 1] = tile25;
            Globalvar.Tiles[5, 1] = tile26;
            Globalvar.Tiles[6, 1] = tile27;
            Globalvar.Tiles[7, 1] = tile28;
            Globalvar.Tiles[0, 2] = tile31;
            Globalvar.Tiles[1, 2] = tile32;
            Globalvar.Tiles[2, 2] = tile33;
            Globalvar.Tiles[3, 2] = tile34;
            Globalvar.Tiles[4, 2] = tile35;
            Globalvar.Tiles[5, 2] = tile36;
            Globalvar.Tiles[6, 2] = tile37;
            Globalvar.Tiles[7, 2] = tile38;
            Globalvar.Tiles[0, 3] = tile41;
            Globalvar.Tiles[1, 3] = tile42;
            Globalvar.Tiles[2, 3] = tile43;
            Globalvar.Tiles[3, 3] = tile44;
            Globalvar.Tiles[4, 3] = tile45;
            Globalvar.Tiles[5, 3] = tile46;
            Globalvar.Tiles[6, 3] = tile47;
            Globalvar.Tiles[7, 3] = tile48;
            Globalvar.Tiles[0, 4] = tile51;
            Globalvar.Tiles[1, 4] = tile52;
            Globalvar.Tiles[2, 4] = tile53;
            Globalvar.Tiles[3, 4] = tile54;
            Globalvar.Tiles[4, 4] = tile55;
            Globalvar.Tiles[5, 4] = tile56;
            Globalvar.Tiles[6, 4] = tile57;
            Globalvar.Tiles[7, 4] = tile58;
            Globalvar.Tiles[0, 5] = tile61;
            Globalvar.Tiles[1, 5] = tile62;
            Globalvar.Tiles[2, 5] = tile63;
            Globalvar.Tiles[3, 5] = tile64;
            Globalvar.Tiles[4, 5] = tile65;
            Globalvar.Tiles[5, 5] = tile66;
            Globalvar.Tiles[6, 5] = tile67;
            Globalvar.Tiles[7, 5] = tile68;
            Globalvar.Tiles[0, 6] = tile71;
            Globalvar.Tiles[1, 6] = tile72;
            Globalvar.Tiles[2, 6] = tile73;
            Globalvar.Tiles[3, 6] = tile74;
            Globalvar.Tiles[4, 6] = tile75;
            Globalvar.Tiles[5, 6] = tile76;
            Globalvar.Tiles[6, 6] = tile77;
            Globalvar.Tiles[7, 6] = tile78;
            Globalvar.Tiles[0, 7] = tile81;
            Globalvar.Tiles[1, 7] = tile82;
            Globalvar.Tiles[2, 7] = tile83;
            Globalvar.Tiles[3, 7] = tile84;
            Globalvar.Tiles[4, 7] = tile85;
            Globalvar.Tiles[5, 7] = tile86;
            Globalvar.Tiles[6, 7] = tile87; 
            Globalvar.Tiles[7, 7] = tile88;

            #endregion

            #region skapar alla pjäser

            Globalvar.pieces.Add(new piece("tower", "black", tile11, "blacktower1" , 0, 0));
            Globalvar.pieces.Add(new piece("horse", "black", tile12, "blackhorse1", 1, 0));
            Globalvar.pieces.Add(new piece("sprinter", "black", tile13, "blacksprinter1", 2, 0));
            Globalvar.pieces.Add(new piece("queen", "black", tile14, "blackqueen", 3, 0));
            Globalvar.pieces.Add(new piece("king", "black", tile15, "blackking", 4, 0));
            Globalvar.pieces.Add(new piece("sprinter", "black", tile16, "blacksprinter2", 5, 0));
            Globalvar.pieces.Add(new piece("horse", "black", tile17, "blackhorse2", 6, 0));
            Globalvar.pieces.Add(new piece("tower", "black", tile18, "blacktower2", 7, 0));

            Globalvar.pieces.Add(new piece("pawn", "black", tile21, "blackpawn1", 0, 1));
            Globalvar.pieces.Add(new piece("pawn", "black", tile22, "blackpawn2", 1, 1));
            Globalvar.pieces.Add(new piece("pawn", "black", tile23, "blackpawn3", 2, 1));
            Globalvar.pieces.Add(new piece("pawn", "black", tile24, "blackpawn4", 3, 1));
            Globalvar.pieces.Add(new piece("pawn", "black", tile25, "blackpawn5", 4, 1));
            Globalvar.pieces.Add(new piece("pawn", "black", tile26, "blackpawn6", 5, 1));
            Globalvar.pieces.Add(new piece("pawn", "black", tile27, "blackpawn7", 6, 1));
            Globalvar.pieces.Add(new piece("pawn", "black", tile28, "blackpawn8", 7, 1));



            Globalvar.pieces.Add(new piece("pawn", "white", tile71, "whitepawn1", 0, 6));
            Globalvar.pieces.Add(new piece("pawn", "white", tile72, "whitepawn2", 1, 6));
            Globalvar.pieces.Add(new piece("pawn", "white", tile73, "whitepawn3", 2, 6));
            Globalvar.pieces.Add(new piece("pawn", "white", tile74, "whitepawn4", 3, 6));
            Globalvar.pieces.Add(new piece("pawn", "white", tile75, "whitepawn5", 4, 6));
            Globalvar.pieces.Add(new piece("pawn", "white", tile76, "whitepawn6", 5, 6));
            Globalvar.pieces.Add(new piece("pawn", "white", tile77, "whitepawn7", 6, 6));
            Globalvar.pieces.Add(new piece("pawn", "white", tile78, "whitepawn8", 7, 6));

            Globalvar.pieces.Add(new piece("tower", "white", tile81, "whitetower1", 0, 7));
            Globalvar.pieces.Add(new piece("horse", "white", tile82, "whiteorse1", 1, 7));
            Globalvar.pieces.Add(new piece("sprinter", "white", tile83, "whitesprinter1", 2, 7));
            Globalvar.pieces.Add(new piece("queen", "white", tile84, "whitequeen", 3, 7));
            Globalvar.pieces.Add(new piece("king", "white", tile85, "whiteking", 4, 7));
            Globalvar.pieces.Add(new piece("sprinter", "white", tile86, "whitesprinter2", 5, 7));
            Globalvar.pieces.Add(new piece("horse", "white", tile87, "whitehorse2", 6, 7));
            Globalvar.pieces.Add(new piece("tower", "white", tile88, "whitetower2", 7, 7));

            #endregion

            #region lägger till kill board

            Globalvar.whiteKillBoard.Add(player2Kill1);
            Globalvar.whiteKillBoard.Add(player2Kill2);
            Globalvar.whiteKillBoard.Add(player2Kill3);
            Globalvar.whiteKillBoard.Add(player2Kill4);
            Globalvar.whiteKillBoard.Add(player2Kill5);
            Globalvar.whiteKillBoard.Add(player2Kill6);
            Globalvar.whiteKillBoard.Add(player2Kill7);
            Globalvar.whiteKillBoard.Add(player2Kill8);
            Globalvar.whiteKillBoard.Add(player2Kill9);
            Globalvar.whiteKillBoard.Add(player2Kill10);
            Globalvar.whiteKillBoard.Add(player2Kill11);
            Globalvar.whiteKillBoard.Add(player2Kill12);
            Globalvar.whiteKillBoard.Add(player2Kill13);
            Globalvar.whiteKillBoard.Add(player2Kill14);
            Globalvar.whiteKillBoard.Add(player2Kill15);
            Globalvar.whiteKillBoard.Add(player2Kill16);

            Globalvar.blackKillBoard.Add(player1Kill1);
            Globalvar.blackKillBoard.Add(player1Kill2);
            Globalvar.blackKillBoard.Add(player1Kill3);
            Globalvar.blackKillBoard.Add(player1Kill4);
            Globalvar.blackKillBoard.Add(player1Kill5);
            Globalvar.blackKillBoard.Add(player1Kill6);
            Globalvar.blackKillBoard.Add(player1Kill7);
            Globalvar.blackKillBoard.Add(player1Kill8);
            Globalvar.blackKillBoard.Add(player1Kill9);
            Globalvar.blackKillBoard.Add(player1Kill10);
            Globalvar.blackKillBoard.Add(player1Kill11);
            Globalvar.blackKillBoard.Add(player1Kill12);
            Globalvar.blackKillBoard.Add(player1Kill13);
            Globalvar.blackKillBoard.Add(player1Kill14);
            Globalvar.blackKillBoard.Add(player1Kill15);
            Globalvar.blackKillBoard.Add(player1Kill16);


            #endregion

        }


        



    }
}
