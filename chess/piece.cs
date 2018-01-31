using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chess
{

    public class piece
    {

        //: spelpjäsen
        //: Bilden på spelpjäsen
        public PictureBox ThePiece;
        //: pjäsens namn
        public string pieceType;
        //: färgen som pjäsen har
        public string color;
        //: antal drag pjäsen har tagit
        public int moves = 0;
        //: vilken position pjäsen är på
        public Label location;
        //: om pjäsen ska tas bort när den klickas på
        public Boolean killOrder = false;

        //: vilken kordinat som den är i
        public int X = 0;
        public int Y = 0;

        public String killer = null;
         
        //: tar in nment på pjäsen när den skapas
        public piece(string pieceinput, string colorinput,  Label locationInput , string pieceTypeInput, int Xinput, int Yinput)
        {
            pieceType = pieceinput;

            color = colorinput;

            location = locationInput;

            //: skapar bilden
            ThePiece = new PictureBox();

            ThePiece.Name = pieceTypeInput;

            //: lägegr  till positionen i den figuren
            ThePiece.Location = new Point(0, 0);

            ThePiece.Size = new Size(60, 60);

            //: Lägger till onclick funktionen
            ThePiece.Click += onCLick;


            //: Gör så att musen visar att man kan clicka på pjäsen 
            ThePiece.Cursor = Cursors.Hand;

            //: Sparar x & y värdet
            X = Xinput;
            Y = Yinput;
        
            //: lägget till positionen 
            ThePiece.Parent = location;

            #region picture
            //: Lägger in bilden beroende på vilken pjäs den är
           
            #region black
            if (color == "black") {
          
            if (pieceType == "pawn")
            {
                ThePiece.Image = Properties.Resources.blackpawn;
            }
            else if (pieceType == "tower")
            {
                ThePiece.Image = Properties.Resources.blacktower;
            }
            else if (pieceType == "horse")
            {
                ThePiece.Image = Properties.Resources.blackhorse;
            }
            else if (pieceType == "sprinter")
            {
                ThePiece.Image = Properties.Resources.blacksprinter;
            }
            else if (pieceType == "king")
            {
                ThePiece.Image = Properties.Resources.blackking;
            }
            else if (pieceType == "queen")
            {
                ThePiece.Image = Properties.Resources.blackqueen;
            }
            }
            #endregion
            #region White
            else if (color == "white")
            {

                if (pieceType == "pawn")
                {
                    ThePiece.Image = Properties.Resources.whitepawn;
                }
                else if (pieceType == "tower")
                {
                    ThePiece.Image = Properties.Resources.whitetower;
                }
                else if (pieceType == "horse")
                {
                    ThePiece.Image = Properties.Resources.whitehorse;
                }
                else if (pieceType == "sprinter")
                {
                    ThePiece.Image = Properties.Resources.whitesprinter;
                }
                else if (pieceType == "king")
                {
                    ThePiece.Image = Properties.Resources.whiteking;
                }
                else if (pieceType == "queen")
                {
                    ThePiece.Image = Properties.Resources.whitequeen;
                }
            }
            #endregion

            #endregion

        }

        private void onCLick(object sender, EventArgs e)
        {

            if (killOrder == true)
            {
                Kill();
            }
            else if (((Globalvar.playerID == 1) && (color == "white")) || ((Globalvar.playerID == 2) && (color == "black")))
            {
            
            //: startar en fuktion somtar bort det föregående markerade rutora
            Globalvar.removeHighlight();
            Globalvar.removeKillOrder();

                //: logic

               
                #region Pawn
                if (pieceType == "pawn")
                {

                    #region Black
                    if (color == "black")
                    {

                        if (moves == 0)
                        {
                            #region move1
                            //: en trycatcher ifall den går utanför planen
                            try
                            {
                                //: kollar att det inte står en pjäs ivägen
                                if (Globalvar.Tiles[X, Y + 1].Controls.Count == 0)
                                {

                                    //: skapar en ny tile oms ka synas
                                    highlightedTile highlightedTile = new highlightedTile(Globalvar.Tiles[X, Y + 1].BackColor, Color.Yellow, Globalvar.Tiles[X, Y + 1], ThePiece.Name, X, Y + 1);

                                    //: Ändrar fägen på den
                                    highlightedTile.change();

                                    //: Lägger till den i en lista så att man ändra tillbaka alla
                                    Globalvar.highlightedTiles.Add(highlightedTile);

                                }
                            }
                            catch { }

                            #endregion
                            #region move2
                            //: en trycatcher ifall den går utanför planen
                            try
                            {
                                //: kollar att det inte står en pjäs ivägen
                                if (Globalvar.Tiles[X, Y + 2].Controls.Count == 0)
                                {

                                    //: skapar en ny tile oms ka synas
                                    highlightedTile highlightedTile = new highlightedTile(Globalvar.Tiles[X, Y + 2].BackColor, Color.Yellow, Globalvar.Tiles[X, Y + 2], ThePiece.Name, X, Y + 2);

                                    //: Ändrar fägen på den
                                    highlightedTile.change();

                                    //: Lägger till den i en lista så att man ändra tillbaka alla
                                    Globalvar.highlightedTiles.Add(highlightedTile);

                                }
                            }
                            catch { }
                            #endregion

                        }
                        //: ifall den har gått ett steg tidigare
                        else if (moves > 0)
                        {
                            #region move
                            //: en trycatcher ifall den går utanför planen
                            try
                            {
                                //: kollar att det inte står en pjäs ivägen
                                if (Globalvar.Tiles[X, Y + 1].Controls.Count == 0)
                                {

                                    //: skapar en ny tile oms ka synas
                                    highlightedTile highlightedTile = new highlightedTile(Globalvar.Tiles[X, Y + 1].BackColor, Color.Yellow, Globalvar.Tiles[X, Y + 1], ThePiece.Name, X, Y + 1);

                                    //: Ändrar fägen på den
                                    highlightedTile.change();

                                    //: Lägger till den i en lista så att man ändra tillbaka alla
                                    Globalvar.highlightedTiles.Add(highlightedTile);

                                }
                            }
                            catch { }
                            #endregion
                        }


                        //: Kollar om det finns någon att atackera
                        #region Attack

                        #region Right
                        //: en trycatcher ifall den går utanför planen
                        try
                        {
                            //: kollar att det inte står en pjäs ivägen
                            if (Globalvar.Tiles[X + 1, Y + 1].Controls.Count == 1)
                            {
                                //: tar fram namnet på den pjäsen som är i vägen
                                string nameofopposite = Globalvar.Tiles[X + 1, Y + 1].Controls[0].Name;

                                if (!nameofopposite.Contains(color))
                                {
                                    //: skapar en ny tile oms ka synas
                                    highlightedTile highlightedTile = new highlightedTile(Globalvar.Tiles[X + 1, Y + 1].BackColor, Color.Red, Globalvar.Tiles[X + 1, Y + 1], ThePiece.Name, X + 1, Y + 1);

                                    //: Ändrar fägen på den
                                    highlightedTile.change();

                                    //: Lägger till den i en lista så att man ändra tillbaka alla
                                    Globalvar.highlightedTiles.Add(highlightedTile);

                                }

                            }
                        }
                       
                        catch { }
                        #endregion
                        #region Left
                        try
                        {
                            //: kollar att det inte står en pjäs ivägen
                            if (Globalvar.Tiles[X - 1, Y + 1].Controls.Count == 1)
                            {

                                //: tar fram namnet på den pjäsen som är i vägen
                                string nameofopposite = Globalvar.Tiles[X - 1, Y + 1].Controls[0].Name;

                                if (!nameofopposite.Contains(color))
                                {
                                    //: skapar en ny tile oms ka synas
                                    highlightedTile highlightedTile = new highlightedTile(Globalvar.Tiles[X - 1, Y + 1].BackColor, Color.Red, Globalvar.Tiles[X - 1, Y + 1], ThePiece.Name, X - 1, Y + 1);

                                    //: Ändrar fägen på den
                                    highlightedTile.change();

                                    //: Lägger till den i en lista så att man ändra tillbaka alla
                                    Globalvar.highlightedTiles.Add(highlightedTile);

                                }

                            }
                        }
                        catch { }
                        #endregion

                        #endregion
                    }

                    #endregion

                    #region White
                    if (color == "white")
                    {

                        if (moves == 0)
                        {
                            #region move1
                            //: en trycatcher ifall den går utanför planen
                            try
                            {
                                //: kollar att det inte står en pjäs ivägen
                                if (Globalvar.Tiles[X, Y - 1].Controls.Count == 0)
                                {

                                    //: skapar en ny tile oms ka synas
                                    highlightedTile highlightedTile = new highlightedTile(Globalvar.Tiles[X, Y - 1].BackColor, Color.Yellow, Globalvar.Tiles[X, Y - 1], ThePiece.Name, X, Y - 1);

                                    //: Ändrar fägen på den
                                    highlightedTile.change();

                                    //: Lägger till den i en lista så att man ändra tillbaka alla
                                    Globalvar.highlightedTiles.Add(highlightedTile);

                                }
                            }
                            catch { }
                            #endregion
                            #region move1
                            //: en trycatcher ifall den går utanför planen
                            try
                            {
                                //: kollar att det inte står en pjäs ivägen
                                if (Globalvar.Tiles[X, Y - 2].Controls.Count == 0)
                                {

                                    //: skapar en ny tile oms ka synas
                                    highlightedTile highlightedTile = new highlightedTile(Globalvar.Tiles[X, Y - 2].BackColor, Color.Yellow, Globalvar.Tiles[X, Y - 2], ThePiece.Name, X, Y - 2);

                                    //: Ändrar fägen på den
                                    highlightedTile.change();

                                    //: Lägger till den i en lista så att man ändra tillbaka alla
                                    Globalvar.highlightedTiles.Add(highlightedTile);

                                }
                                else
                                {
                                    //: tar fram namnet på den pjäsen som är i vägen
                                    string nameofopposite = Globalvar.Tiles[X, Y - 2].Controls[0].Name;

                                    if (!nameofopposite.Contains(color))
                                    {
                                        //: skapar en ny tile oms ka synas
                                        highlightedTile highlightedTile = new highlightedTile(Globalvar.Tiles[X, Y - 2].BackColor, Color.Red, Globalvar.Tiles[X, Y - 2], ThePiece.Name, X, Y - 2);

                                        //: Ändrar fägen på den
                                        highlightedTile.change();

                                        //: Lägger till den i en lista så att man ändra tillbaka alla
                                        Globalvar.highlightedTiles.Add(highlightedTile);

                                    }

                                }
                            }
                            catch { }
                            #endregion

                        }
                        else if (moves > 0)
                        {
                            #region move
                            //: en trycatcher ifall den går utanför planen
                            try
                            {
                                //: kollar att det inte står en pjäs ivägen
                                if (Globalvar.Tiles[X, Y - 1].Controls.Count == 0)
                                {

                                    //: skapar en ny tile oms ka synas
                                    highlightedTile highlightedTile = new highlightedTile(Globalvar.Tiles[X, Y - 1].BackColor, Color.Yellow, Globalvar.Tiles[X, Y - 1], ThePiece.Name, X, Y - 1);

                                    //: Ändrar fägen på den
                                    highlightedTile.change();

                                    //: Lägger till den i en lista så att man ändra tillbaka alla
                                    Globalvar.highlightedTiles.Add(highlightedTile);

                                }

                            }
                            
                            catch { }
                            #endregion
                        }

                        #region Atack

                        #region Right
                        //: en trycatcher ifall den går utanför planen
                        try
                        {

                            //: kollar att det inte står en pjäs ivägen
                            if (Globalvar.Tiles[X + 1, Y - 1].Controls.Count == 1)
                            {
                                //: tar fram namnet på den pjäsen som är i vägen
                                string nameofopposite = Globalvar.Tiles[X + 1, Y - 1].Controls[0].Name;

                                if (!nameofopposite.Contains(color))
                                {
                                    //: skapar en ny tile oms ka synas
                                    highlightedTile highlightedTile = new highlightedTile(Globalvar.Tiles[X + 1, Y - 1].BackColor, Color.Red, Globalvar.Tiles[X + 1, Y - 1], ThePiece.Name, X + 1, Y - 1);

                                    //: Ändrar fägen på den
                                    highlightedTile.change();

                                    //: Lägger till den i en lista så att man ändra tillbaka alla
                                    Globalvar.highlightedTiles.Add(highlightedTile);

                                }

                            }
                        }

                        catch { }
                        #endregion
                        #region Left
                        try
                        {
                            //: kollar att det inte står en pjäs ivägen
                            if (Globalvar.Tiles[X - 1, Y - 1].Controls.Count == 1)
                            {

                                //: tar fram namnet på den pjäsen som är i vägen
                                string nameofopposite = Globalvar.Tiles[X - 1, Y - 1].Controls[0].Name;

                                if (!nameofopposite.Contains(color))
                                {
                                    //: skapar en ny tile oms ka synas
                                    highlightedTile highlightedTile = new highlightedTile(Globalvar.Tiles[X - 1, Y - 1].BackColor, Color.Red, Globalvar.Tiles[X - 1, Y - 1], ThePiece.Name, X - 1, Y - 1);

                                    //: Ändrar fägen på den
                                    highlightedTile.change();

                                    //: Lägger till den i en lista så att man ändra tillbaka alla
                                    Globalvar.highlightedTiles.Add(highlightedTile);

                                }

                            }
                        }
                        catch { }
                        #endregion

                        #endregion

                    }
                    #endregion

                }

                #endregion

                #region Tower
                if (pieceType == "tower")
                {
                    //: varbeler som säger ifall man ska sluta kolla i en riktning
                    bool readydown = false;
                    bool readyup = false;
                    bool readyleft = false;
                    bool readyright = false;


                    //: en for-loop som kollar alla håll
                    #region Down
                    for (int i = 1; readydown == false && i < Globalvar.Tiles.Length; i++)
                    {

                        //: en trycatcher ifall den går utanför planen
                        try
                        {
                            //: kollar att det inte står en pjäs ivägen
                            if (Globalvar.Tiles[X, Y + i].Controls.Count == 0)
                            {

                                //: skapar en ny tile oms ka synas
                                highlightedTile highlightedTile = new highlightedTile(Globalvar.Tiles[X, Y + i].BackColor, Color.Yellow, Globalvar.Tiles[X, Y + i], ThePiece.Name, X, Y + i);

                                //: Ändrar fägen på den
                                highlightedTile.change();

                                //: Lägger till den i en lista så att man ändra tillbaka alla
                                Globalvar.highlightedTiles.Add(highlightedTile);

                            }
                            else
                            {
                                //: tar fram namnet på den pjäsen som är i vägen
                                string nameofopposite = Globalvar.Tiles[X, Y + i].Controls[0].Name;

                                if (!nameofopposite.Contains(color))
                                {
                                    //: skapar en ny tile oms ka synas
                                    highlightedTile highlightedTile = new highlightedTile(Globalvar.Tiles[X, Y + i].BackColor, Color.Red, Globalvar.Tiles[X, Y + i], ThePiece.Name, X, Y + i);

                                    //: Ändrar fägen på den
                                    highlightedTile.change();

                                    //: Lägger till den i en lista så att man ändra tillbaka alla
                                    Globalvar.highlightedTiles.Add(highlightedTile);



                                }
                                //: stänger av söknignen på grund av att man har gått in en pjäs
                                readydown = true;
                            }

                            //: stänger av den ifall den går utanför banan
                            if (Globalvar.Tiles[X, Y + i] == null)
                            {
                                readydown = true;
                            }

                        }
                        catch { }
                    }

                    #endregion

                    #region Up

                    for (int i = 1; readyup == false && i < Globalvar.Tiles.Length; i++)
                    {

                        //: en trycatcher ifall den går utanför planen
                        try
                        {
                            //: kollar att det inte står en pjäs ivägen
                            if (Globalvar.Tiles[X, Y - i].Controls.Count == 0)
                            {

                                //: skapar en ny tile oms ka synas
                                highlightedTile highlightedTile = new highlightedTile(Globalvar.Tiles[X, Y - i].BackColor, Color.Yellow, Globalvar.Tiles[X, Y - i], ThePiece.Name, X, Y - i);

                                //: Ändrar fägen på den
                                highlightedTile.change();

                                //: Lägger till den i en lista så att man ändra tillbaka alla
                                Globalvar.highlightedTiles.Add(highlightedTile);

                            }
                            else
                            {
                                //: tar fram namnet på den pjäsen som är i vägen
                                string nameofopposite = Globalvar.Tiles[X, Y - i].Controls[0].Name;

                                if (!nameofopposite.Contains(color))
                                {
                                    //: skapar en ny tile oms ka synas
                                    highlightedTile highlightedTile = new highlightedTile(Globalvar.Tiles[X, Y - i].BackColor, Color.Red, Globalvar.Tiles[X, Y - i], ThePiece.Name, X, Y - i);

                                    //: Ändrar fägen på den
                                    highlightedTile.change();

                                    //: Lägger till den i en lista så att man ändra tillbaka alla
                                    Globalvar.highlightedTiles.Add(highlightedTile);



                                }
                                //: stänger av söknignen på grund av att man har gått in en pjäs
                                readyup = true;
                            }

                            //: stänger av den ifall den går utanför banan
                            if (Globalvar.Tiles[X, Y + i] == null)
                            {
                                readyup = true;
                            }

                        }
                        catch { }
                    }

                    #endregion

                    #region Left

                    for (int i = 1; readyleft == false && i < Globalvar.Tiles.Length; i++)
                    {

                        //: en trycatcher ifall den går utanför planen
                        try
                        {
                            //: kollar att det inte står en pjäs ivägen
                            if (Globalvar.Tiles[X - i, Y].Controls.Count == 0)
                            {

                                //: skapar en ny tile oms ka synas
                                highlightedTile highlightedTile = new highlightedTile(Globalvar.Tiles[X - i, Y].BackColor, Color.Yellow, Globalvar.Tiles[X - i, Y], ThePiece.Name, X - i, Y);

                                //: Ändrar fägen på den
                                highlightedTile.change();

                                //: Lägger till den i en lista så att man ändra tillbaka alla
                                Globalvar.highlightedTiles.Add(highlightedTile);

                            }
                            else
                            {
                                //: tar fram namnet på den pjäsen som är i vägen
                                string nameofopposite = Globalvar.Tiles[X - i, Y].Controls[0].Name;

                                if (!nameofopposite.Contains(color))
                                {
                                    //: skapar en ny tile oms ka synas
                                    highlightedTile highlightedTile = new highlightedTile(Globalvar.Tiles[X - i, Y].BackColor, Color.Red, Globalvar.Tiles[X - i, Y], ThePiece.Name, X - i, Y);

                                    //: Ändrar fägen på den
                                    highlightedTile.change();

                                    //: Lägger till den i en lista så att man ändra tillbaka alla
                                    Globalvar.highlightedTiles.Add(highlightedTile);



                                }
                                //: stänger av söknignen på grund av att man har gått in en pjäs
                                readyleft = true;
                            }

                            //: stänger av den ifall den går utanför banan
                            if (Globalvar.Tiles[X - i, Y] == null)
                            {
                                readyleft = true;
                            }

                        }
                        catch { }
                    }

                    #endregion

                    #region Right

                    for (int i = 1; readyright == false && i < Globalvar.Tiles.Length; i++)
                    {

                        //: en trycatcher ifall den går utanför planen
                        try
                        {
                            //: kollar att det inte står en pjäs ivägen
                            if (Globalvar.Tiles[X + i, Y].Controls.Count == 0)
                            {

                                //: skapar en ny tile oms ka synas
                                highlightedTile highlightedTile = new highlightedTile(Globalvar.Tiles[X + i, Y].BackColor, Color.Yellow, Globalvar.Tiles[X + i, Y], ThePiece.Name, X + i, Y);

                                //: Ändrar fägen på den
                                highlightedTile.change();

                                //: Lägger till den i en lista så att man ändra tillbaka alla
                                Globalvar.highlightedTiles.Add(highlightedTile);

                            }
                            else
                            {
                                //: tar fram namnet på den pjäsen som är i vägen
                                string nameofopposite = Globalvar.Tiles[X + i, Y].Controls[0].Name;

                                if (!nameofopposite.Contains(color))
                                {
                                    //: skapar en ny tile oms ka synas
                                    highlightedTile highlightedTile = new highlightedTile(Globalvar.Tiles[X + i, Y].BackColor, Color.Red, Globalvar.Tiles[X + i, Y], ThePiece.Name, X + i, Y);

                                    //: Ändrar fägen på den
                                    highlightedTile.change();

                                    //: Lägger till den i en lista så att man ändra tillbaka alla
                                    Globalvar.highlightedTiles.Add(highlightedTile);



                                }
                                //: stänger av söknignen på grund av att man har gått in en pjäs
                                readyright = true;
                            }

                            //: stänger av den ifall den går utanför banan
                            if (Globalvar.Tiles[X + i, Y] == null)
                            {
                                readyright = true;
                            }

                        }
                        catch { }
                    }

                    #endregion
                }
                #endregion

                #region Sprinter
                if (pieceType == "sprinter")
                {
                    //: varbeler som säger ifall man ska sluta kolla i en riktning
                    bool readyupright = false;
                    bool readydownright = false;
                    bool readydownleft = false;
                    bool readyupleft = false;


                    //: en for-loop som kollar alla håll
                    #region readyupright
                    for (int i = 1; readyupright == false && i < Globalvar.Tiles.Length; i++)
                    {

                        //: en trycatcher ifall den går utanför planen
                        try
                        {
                            //: kollar att det inte står en pjäs ivägen
                            if (Globalvar.Tiles[X + i, Y - i].Controls.Count == 0)
                            {

                                //: skapar en ny tile oms ka synas
                                highlightedTile highlightedTile = new highlightedTile(Globalvar.Tiles[X + i, Y - i].BackColor, Color.Yellow, Globalvar.Tiles[X + i, Y - i], ThePiece.Name, X + i, Y - i);

                                //: Ändrar fägen på den
                                highlightedTile.change();

                                //: Lägger till den i en lista så att man ändra tillbaka alla
                                Globalvar.highlightedTiles.Add(highlightedTile);

                            }
                            else
                            {
                                //: tar fram namnet på den pjäsen som är i vägen
                                string nameofopposite = Globalvar.Tiles[X + i, Y - i].Controls[0].Name;

                                if (!nameofopposite.Contains(color))
                                {
                                    //: skapar en ny tile oms ka synas
                                    highlightedTile highlightedTile = new highlightedTile(Globalvar.Tiles[X + i, Y - i].BackColor, Color.Red, Globalvar.Tiles[X + i, Y - i], ThePiece.Name, X + i, Y - i);

                                    //: Ändrar fägen på den
                                    highlightedTile.change();

                                    //: Lägger till den i en lista så att man ändra tillbaka alla
                                    Globalvar.highlightedTiles.Add(highlightedTile);

                                }
                                //: stänger av söknignen på grund av att man har gått in en pjäs
                                readyupright = true;
                            }

                            //: stänger av den ifall den går utanför banan
                            if (Globalvar.Tiles[X + i, Y - i] == null)
                            {
                                readyupright = true;
                            }

                        }
                        catch { }
                    }

                    #endregion

                    #region readydownright

                    for (int i = 1; readydownright == false && i < Globalvar.Tiles.Length; i++)
                    {

                        //: en trycatcher ifall den går utanför planen
                        try
                        {
                            //: kollar att det inte står en pjäs ivägen
                            if (Globalvar.Tiles[X + i, Y + i].Controls.Count == 0)
                            {

                                //: skapar en ny tile oms ka synas
                                highlightedTile highlightedTile = new highlightedTile(Globalvar.Tiles[X + i, Y + i].BackColor, Color.Yellow, Globalvar.Tiles[X + i, Y + i], ThePiece.Name, X + i, Y + i);

                                //: Ändrar fägen på den
                                highlightedTile.change();

                                //: Lägger till den i en lista så att man ändra tillbaka alla
                                Globalvar.highlightedTiles.Add(highlightedTile);

                            }
                            else
                            {
                                //: tar fram namnet på den pjäsen som är i vägen
                                string nameofopposite = Globalvar.Tiles[X + i, Y + i].Controls[0].Name;

                                if (!nameofopposite.Contains(color))
                                {
                                    //: skapar en ny tile oms ka synas
                                    highlightedTile highlightedTile = new highlightedTile(Globalvar.Tiles[X + i, Y + i].BackColor, Color.Red, Globalvar.Tiles[X + i, Y + i], ThePiece.Name, X + i, Y + i);

                                    //: Ändrar fägen på den
                                    highlightedTile.change();

                                    //: Lägger till den i en lista så att man ändra tillbaka alla
                                    Globalvar.highlightedTiles.Add(highlightedTile);



                                }
                                //: stänger av söknignen på grund av att man har gått in en pjäs
                                readydownright = true;
                            }

                            //: stänger av den ifall den går utanför banan
                            if (Globalvar.Tiles[X + i, Y + i] == null)
                            {
                                readydownright = true;
                            }

                        }
                        catch { }
                    }

                    #endregion

                    #region readydownleft

                    for (int i = 1; readydownleft == false && i < Globalvar.Tiles.Length; i++)
                    {

                        //: en trycatcher ifall den går utanför planen
                        try
                        {
                            //: kollar att det inte står en pjäs ivägen
                            if (Globalvar.Tiles[X - i, Y + i].Controls.Count == 0)
                            {

                                //: skapar en ny tile oms ka synas
                                highlightedTile highlightedTile = new highlightedTile(Globalvar.Tiles[X - i, Y + i].BackColor, Color.Yellow, Globalvar.Tiles[X - i, Y + i], ThePiece.Name, X - i, Y + i);

                                //: Ändrar fägen på den
                                highlightedTile.change();

                                //: Lägger till den i en lista så att man ändra tillbaka alla
                                Globalvar.highlightedTiles.Add(highlightedTile);

                            }
                            else
                            {
                                //: tar fram namnet på den pjäsen som är i vägen
                                string nameofopposite = Globalvar.Tiles[X - i, Y + i].Controls[0].Name;

                                if (!nameofopposite.Contains(color))
                                {
                                    //: skapar en ny tile oms ka synas
                                    highlightedTile highlightedTile = new highlightedTile(Globalvar.Tiles[X - i, Y + i].BackColor, Color.Red, Globalvar.Tiles[X - i, Y + i], ThePiece.Name, X - i, Y + i);

                                    //: Ändrar fägen på den
                                    highlightedTile.change();

                                    //: Lägger till den i en lista så att man ändra tillbaka alla
                                    Globalvar.highlightedTiles.Add(highlightedTile);



                                }
                                //: stänger av söknignen på grund av att man har gått in en pjäs
                                readydownleft = true;
                            }

                            //: stänger av den ifall den går utanför banan
                            if (Globalvar.Tiles[X - i, Y + i] == null)
                            {
                                readydownleft = true;
                            }

                        }
                        catch { }
                    }

                    #endregion

                    #region readyupleft

                    for (int i = 1; readyupleft == false && i < Globalvar.Tiles.Length; i++)
                    {

                        //: en trycatcher ifall den går utanför planen
                        try
                        {
                            //: kollar att det inte står en pjäs ivägen
                            if (Globalvar.Tiles[X - i, Y - i].Controls.Count == 0)
                            {

                                //: skapar en ny tile oms ka synas
                                highlightedTile highlightedTile = new highlightedTile(Globalvar.Tiles[X - i, Y - i].BackColor, Color.Yellow, Globalvar.Tiles[X - i, Y - i], ThePiece.Name, X - i, Y - i);

                                //: Ändrar fägen på den
                                highlightedTile.change();

                                //: Lägger till den i en lista så att man ändra tillbaka alla
                                Globalvar.highlightedTiles.Add(highlightedTile);

                            }
                            else
                            {
                                //: tar fram namnet på den pjäsen som är i vägen
                                string nameofopposite = Globalvar.Tiles[X - i, Y - i].Controls[0].Name;

                                if (!nameofopposite.Contains(color))
                                {
                                    //: skapar en ny tile oms ka synas
                                    highlightedTile highlightedTile = new highlightedTile(Globalvar.Tiles[X - i, Y - i].BackColor, Color.Red, Globalvar.Tiles[X - i, Y - i], ThePiece.Name, X - i, Y - i);

                                    //: Ändrar fägen på den
                                    highlightedTile.change();

                                    //: Lägger till den i en lista så att man ändra tillbaka alla
                                    Globalvar.highlightedTiles.Add(highlightedTile);



                                }
                                //: stänger av söknignen på grund av att man har gått in en pjäs
                                readyupleft = true;
                            }

                            //: stänger av den ifall den går utanför banan
                            if (Globalvar.Tiles[X - i, Y - i] == null)
                            {
                                readyupleft = true;
                            }

                        }
                        catch { }
                    }

                    #endregion

                }
                #endregion

                #region Horse
                if (pieceType == "horse")
                {


                    #region upright1
                    //: en trycatcher ifall den går utanför planen
                    try
                    {
                        //: kollar att det inte står en pjäs ivägen
                        if (Globalvar.Tiles[X + 1, Y - 2].Controls.Count == 0)
                        {

                            //: skapar en ny tile oms ka synas
                            highlightedTile highlightedTile = new highlightedTile(Globalvar.Tiles[X + 1, Y - 2].BackColor, Color.Yellow, Globalvar.Tiles[X + 1, Y - 2], ThePiece.Name, X + 1, Y - 2);

                            //: Ändrar fägen på den
                            highlightedTile.change();

                            //: Lägger till den i en lista så att man ändra tillbaka alla
                            Globalvar.highlightedTiles.Add(highlightedTile);

                        }
                        else
                        {
                            //: tar fram namnet på den pjäsen som är i vägen
                            string nameofopposite = Globalvar.Tiles[X + 1, Y - 2].Controls[0].Name;

                            if (!nameofopposite.Contains(color))
                            {
                                //: skapar en ny tile oms ka synas
                                highlightedTile highlightedTile = new highlightedTile(Globalvar.Tiles[X + 1, Y - 2].BackColor, Color.Red, Globalvar.Tiles[X + 1, Y - 2], ThePiece.Name, X + 1, Y - 2);

                                //: Ändrar fägen på den
                                highlightedTile.change();

                                //: Lägger till den i en lista så att man ändra tillbaka alla
                                Globalvar.highlightedTiles.Add(highlightedTile);



                            }

                        }
                    }
                    catch { }
                    #endregion

                    #region upright2
                    //: en trycatcher ifall den går utanför planen
                    try
                    {
                        //: kollar att det inte står en pjäs ivägen
                        if (Globalvar.Tiles[X + 2, Y - 1].Controls.Count == 0)
                        {

                            //: skapar en ny tile oms ka synas
                            highlightedTile highlightedTile = new highlightedTile(Globalvar.Tiles[X + 2, Y - 1].BackColor, Color.Yellow, Globalvar.Tiles[X + 2, Y - 1], ThePiece.Name, X + 2, Y - 1);

                            //: Ändrar fägen på den
                            highlightedTile.change();

                            //: Lägger till den i en lista så att man ändra tillbaka alla
                            Globalvar.highlightedTiles.Add(highlightedTile);

                        }
                        else
                        {
                            //: tar fram namnet på den pjäsen som är i vägen
                            string nameofopposite = Globalvar.Tiles[X + 2, Y - 1].Controls[0].Name;

                            if (!nameofopposite.Contains(color))
                            {
                                //: skapar en ny tile oms ka synas
                                highlightedTile highlightedTile = new highlightedTile(Globalvar.Tiles[X + 2, Y - 1].BackColor, Color.Red, Globalvar.Tiles[X + 2, Y - 1], ThePiece.Name, X + 2, Y - 1);

                                //: Ändrar fägen på den
                                highlightedTile.change();

                                //: Lägger till den i en lista så att man ändra tillbaka alla
                                Globalvar.highlightedTiles.Add(highlightedTile);



                            }

                        }
                    }
                    catch { }
                    #endregion

                    #region downright1
                    //: en trycatcher ifall den går utanför planen
                    try
                    {
                        //: kollar att det inte står en pjäs ivägen
                        if (Globalvar.Tiles[X + 2, Y + 1].Controls.Count == 0)
                        {

                            //: skapar en ny tile oms ka synas
                            highlightedTile highlightedTile = new highlightedTile(Globalvar.Tiles[X + 2, Y + 1].BackColor, Color.Yellow, Globalvar.Tiles[X + 2, Y + 1], ThePiece.Name, X + 2, Y + 1);

                            //: Ändrar fägen på den
                            highlightedTile.change();

                            //: Lägger till den i en lista så att man ändra tillbaka alla
                            Globalvar.highlightedTiles.Add(highlightedTile);

                        }
                        else
                        {
                            //: tar fram namnet på den pjäsen som är i vägen
                            string nameofopposite = Globalvar.Tiles[X + 2, Y + 1].Controls[0].Name;

                            if (!nameofopposite.Contains(color))
                            {
                                //: skapar en ny tile oms ka synas
                                highlightedTile highlightedTile = new highlightedTile(Globalvar.Tiles[X + 2, Y + 1].BackColor, Color.Red, Globalvar.Tiles[X + 2, Y + 1], ThePiece.Name, X + 2, Y + 1);

                                //: Ändrar fägen på den
                                highlightedTile.change();

                                //: Lägger till den i en lista så att man ändra tillbaka alla
                                Globalvar.highlightedTiles.Add(highlightedTile);



                            }

                        }
                    }
                    catch { }
                    #endregion

                    #region downright2
                    //: en trycatcher ifall den går utanför planen
                    try
                    {
                        //: kollar att det inte står en pjäs ivägen
                        if (Globalvar.Tiles[X + 1, Y + 2].Controls.Count == 0)
                        {

                            //: skapar en ny tile oms ka synas
                            highlightedTile highlightedTile = new highlightedTile(Globalvar.Tiles[X + 1, Y + 2].BackColor, Color.Yellow, Globalvar.Tiles[X + 1, Y + 2], ThePiece.Name, X + 1, Y + 2);

                            //: Ändrar fägen på den
                            highlightedTile.change();

                            //: Lägger till den i en lista så att man ändra tillbaka alla
                            Globalvar.highlightedTiles.Add(highlightedTile);

                        }
                        else
                        {
                            //: tar fram namnet på den pjäsen som är i vägen
                            string nameofopposite = Globalvar.Tiles[X + 1, Y + 2].Controls[0].Name;

                            if (!nameofopposite.Contains(color))
                            {
                                //: skapar en ny tile oms ka synas
                                highlightedTile highlightedTile = new highlightedTile(Globalvar.Tiles[X + 1, Y + 2].BackColor, Color.Red, Globalvar.Tiles[X + 1, Y + 2], ThePiece.Name, X + 1, Y + 2);

                                //: Ändrar fägen på den
                                highlightedTile.change();

                                //: Lägger till den i en lista så att man ändra tillbaka alla
                                Globalvar.highlightedTiles.Add(highlightedTile);



                            }

                        }
                    }
                    catch { }
                    #endregion

                    #region downleft1
                    //: en trycatcher ifall den går utanför planen
                    try
                    {
                        //: kollar att det inte står en pjäs ivägen
                        if (Globalvar.Tiles[X - 1, Y + 2].Controls.Count == 0)
                        {

                            //: skapar en ny tile oms ka synas
                            highlightedTile highlightedTile = new highlightedTile(Globalvar.Tiles[X - 1, Y + 2].BackColor, Color.Yellow, Globalvar.Tiles[X - 1, Y + 2], ThePiece.Name, X - 1, Y + 2);

                            //: Ändrar fägen på den
                            highlightedTile.change();

                            //: Lägger till den i en lista så att man ändra tillbaka alla
                            Globalvar.highlightedTiles.Add(highlightedTile);

                        }
                        else
                        {
                            //: tar fram namnet på den pjäsen som är i vägen
                            string nameofopposite = Globalvar.Tiles[X - 1, Y + 2].Controls[0].Name;

                            if (!nameofopposite.Contains(color))
                            {
                                //: skapar en ny tile oms ka synas
                                highlightedTile highlightedTile = new highlightedTile(Globalvar.Tiles[X - 1, Y + 2].BackColor, Color.Red, Globalvar.Tiles[X - 1, Y + 2], ThePiece.Name, X - 1, Y + 2);

                                //: Ändrar fägen på den
                                highlightedTile.change();

                                //: Lägger till den i en lista så att man ändra tillbaka alla
                                Globalvar.highlightedTiles.Add(highlightedTile);



                            }

                        }
                    }
                    catch { }
                    #endregion

                    #region downleft2
                    //: en trycatcher ifall den går utanför planen
                    try
                    {
                        //: kollar att det inte står en pjäs ivägen
                        if (Globalvar.Tiles[X - 2, Y + 1].Controls.Count == 0)
                        {

                            //: skapar en ny tile oms ka synas
                            highlightedTile highlightedTile = new highlightedTile(Globalvar.Tiles[X - 2, Y + 1].BackColor, Color.Yellow, Globalvar.Tiles[X - 2, Y + 1], ThePiece.Name, X - 2, Y + 1);

                            //: Ändrar fägen på den
                            highlightedTile.change();

                            //: Lägger till den i en lista så att man ändra tillbaka alla
                            Globalvar.highlightedTiles.Add(highlightedTile);

                        }
                        else
                        {
                            //: tar fram namnet på den pjäsen som är i vägen
                            string nameofopposite = Globalvar.Tiles[X - 2, Y + 1].Controls[0].Name;

                            if (!nameofopposite.Contains(color))
                            {
                                //: skapar en ny tile oms ka synas
                                highlightedTile highlightedTile = new highlightedTile(Globalvar.Tiles[X - 2, Y + 1].BackColor, Color.Red, Globalvar.Tiles[X - 2, Y + 1], ThePiece.Name, X - 2, Y + 1);

                                //: Ändrar fägen på den
                                highlightedTile.change();

                                //: Lägger till den i en lista så att man ändra tillbaka alla
                                Globalvar.highlightedTiles.Add(highlightedTile);



                            }

                        }
                    }
                    catch { }
                    #endregion

                    #region upleft1
                    //: en trycatcher ifall den går utanför planen
                    try
                    {
                        //: kollar att det inte står en pjäs ivägen
                        if (Globalvar.Tiles[X - 2, Y - 1].Controls.Count == 0)
                        {

                            //: skapar en ny tile oms ka synas
                            highlightedTile highlightedTile = new highlightedTile(Globalvar.Tiles[X - 2, Y - 1].BackColor, Color.Yellow, Globalvar.Tiles[X - 2, Y - 1], ThePiece.Name, X - 2, Y - 1);

                            //: Ändrar fägen på den
                            highlightedTile.change();

                            //: Lägger till den i en lista så att man ändra tillbaka alla
                            Globalvar.highlightedTiles.Add(highlightedTile);

                        }
                        else
                        {
                            //: tar fram namnet på den pjäsen som är i vägen
                            string nameofopposite = Globalvar.Tiles[X - 2, Y - 1].Controls[0].Name;

                            if (!nameofopposite.Contains(color))
                            {
                                //: skapar en ny tile oms ka synas
                                highlightedTile highlightedTile = new highlightedTile(Globalvar.Tiles[X - 2, Y - 1].BackColor, Color.Red, Globalvar.Tiles[X - 2, Y - 1], ThePiece.Name, X - 2, Y - 1);

                                //: Ändrar fägen på den
                                highlightedTile.change();

                                //: Lägger till den i en lista så att man ändra tillbaka alla
                                Globalvar.highlightedTiles.Add(highlightedTile);



                            }

                        }
                    }
                    catch { }
                    #endregion

                    #region upleft2
                    //: en trycatcher ifall den går utanför planen
                    try
                    {
                        //: kollar att det inte står en pjäs ivägen
                        if (Globalvar.Tiles[X - 1, Y - 2].Controls.Count == 0)
                        {

                            //: skapar en ny tile oms ka synas
                            highlightedTile highlightedTile = new highlightedTile(Globalvar.Tiles[X - 1, Y - 2].BackColor, Color.Yellow, Globalvar.Tiles[X - 1, Y - 2], ThePiece.Name, X - 1, Y - 2);

                            //: Ändrar fägen på den
                            highlightedTile.change();

                            //: Lägger till den i en lista så att man ändra tillbaka alla
                            Globalvar.highlightedTiles.Add(highlightedTile);

                        }
                        else
                        {
                            //: tar fram namnet på den pjäsen som är i vägen
                            string nameofopposite = Globalvar.Tiles[X - 1, Y - 2].Controls[0].Name;

                            if (!nameofopposite.Contains(color))
                            {
                                //: skapar en ny tile oms ka synas
                                highlightedTile highlightedTile = new highlightedTile(Globalvar.Tiles[X - 1, Y - 2].BackColor, Color.Red, Globalvar.Tiles[X - 1, Y - 2], ThePiece.Name, X - 1, Y - 2);

                                //: Ändrar fägen på den
                                highlightedTile.change();

                                //: Lägger till den i en lista så att man ändra tillbaka alla
                                Globalvar.highlightedTiles.Add(highlightedTile);



                            }

                        }
                    }
                    catch { }
                    #endregion

                }

                #endregion

                // TODO gör rokad
                #region King
                if (pieceType == "king")
                {

                    #region 1x1
                    //: en trycatcher ifall den går utanför planen
                    try
                    {
                        //: kollar att det inte står en pjäs ivägen
                        if (Globalvar.Tiles[X - 1, Y - 1].Controls.Count == 0)
                        {

                            //: skapar en ny tile oms ka synas
                            highlightedTile highlightedTile = new highlightedTile(Globalvar.Tiles[X - 1, Y - 1].BackColor, Color.Yellow, Globalvar.Tiles[X - 1, Y - 1], ThePiece.Name, X - 1, Y - 1);

                            //: Ändrar fägen på den
                            highlightedTile.change();

                            //: Lägger till den i en lista så att man ändra tillbaka alla
                            Globalvar.highlightedTiles.Add(highlightedTile);

                        }
                        else
                        {
                            //: tar fram namnet på den pjäsen som är i vägen
                            string nameofopposite = Globalvar.Tiles[X - 1, Y - 1].Controls[0].Name;

                            if (!nameofopposite.Contains(color))
                            {
                                //: skapar en ny tile oms ka synas
                                highlightedTile highlightedTile = new highlightedTile(Globalvar.Tiles[X - 1, Y - 1].BackColor, Color.Red, Globalvar.Tiles[X - 1, Y - 1], ThePiece.Name, X - 1, Y - 1);

                                //: Ändrar fägen på den
                                highlightedTile.change();

                                //: Lägger till den i en lista så att man ändra tillbaka alla
                                Globalvar.highlightedTiles.Add(highlightedTile);

                            }

                        }
                    }
                    catch { }
                    #endregion

                    #region 1x2
                    //: en trycatcher ifall den går utanför planen
                    try
                    {
                        //: kollar att det inte står en pjäs ivägen
                        if (Globalvar.Tiles[X, Y - 1].Controls.Count == 0)
                        {

                            //: skapar en ny tile oms ka synas
                            highlightedTile highlightedTile = new highlightedTile(Globalvar.Tiles[X, Y - 1].BackColor, Color.Yellow, Globalvar.Tiles[X, Y - 1], ThePiece.Name, X, Y - 1);

                            //: Ändrar fägen på den
                            highlightedTile.change();

                            //: Lägger till den i en lista så att man ändra tillbaka alla
                            Globalvar.highlightedTiles.Add(highlightedTile);

                        }
                        else
                        {
                            //: tar fram namnet på den pjäsen som är i vägen
                            string nameofopposite = Globalvar.Tiles[X, Y - 1].Controls[0].Name;

                            if (!nameofopposite.Contains(color))
                            {
                                //: skapar en ny tile oms ka synas
                                highlightedTile highlightedTile = new highlightedTile(Globalvar.Tiles[X, Y - 1].BackColor, Color.Red, Globalvar.Tiles[X, Y - 1], ThePiece.Name, X, Y - 1);

                                //: Ändrar fägen på den
                                highlightedTile.change();

                                //: Lägger till den i en lista så att man ändra tillbaka alla
                                Globalvar.highlightedTiles.Add(highlightedTile);

                            }

                        }
                    }
                    catch { }
                    #endregion

                    #region 1x3
                    //: en trycatcher ifall den går utanför planen
                    try
                    {
                        //: kollar att det inte står en pjäs ivägen
                        if (Globalvar.Tiles[X + 1, Y - 1].Controls.Count == 0)
                        {

                            //: skapar en ny tile oms ka synas
                            highlightedTile highlightedTile = new highlightedTile(Globalvar.Tiles[X + 1, Y - 1].BackColor, Color.Yellow, Globalvar.Tiles[X + 1, Y - 1], ThePiece.Name, X + 1, Y - 1);

                            //: Ändrar fägen på den
                            highlightedTile.change();

                            //: Lägger till den i en lista så att man ändra tillbaka alla
                            Globalvar.highlightedTiles.Add(highlightedTile);

                        }
                        else
                        {
                            //: tar fram namnet på den pjäsen som är i vägen
                            string nameofopposite = Globalvar.Tiles[X + 1, Y - 1].Controls[0].Name;

                            if (!nameofopposite.Contains(color))
                            {
                                //: skapar en ny tile oms ka synas
                                highlightedTile highlightedTile = new highlightedTile(Globalvar.Tiles[X + 1, Y - 1].BackColor, Color.Red, Globalvar.Tiles[X + 1, Y - 1], ThePiece.Name, X + 1, Y - 1);

                                //: Ändrar fägen på den
                                highlightedTile.change();

                                //: Lägger till den i en lista så att man ändra tillbaka alla
                                Globalvar.highlightedTiles.Add(highlightedTile);

                            }

                        }
                    }
                    catch { }
                    #endregion

                    #region 2x1
                    //: en trycatcher ifall den går utanför planen
                    try
                    {
                        //: kollar att det inte står en pjäs ivägen
                        if (Globalvar.Tiles[X - 1, Y].Controls.Count == 0)
                        {

                            //: skapar en ny tile oms ka synas
                            highlightedTile highlightedTile = new highlightedTile(Globalvar.Tiles[X - 1, Y].BackColor, Color.Yellow, Globalvar.Tiles[X - 1, Y], ThePiece.Name, X - 1, Y);

                            //: Ändrar fägen på den
                            highlightedTile.change();

                            //: Lägger till den i en lista så att man ändra tillbaka alla
                            Globalvar.highlightedTiles.Add(highlightedTile);

                        }
                        else
                        {
                            //: tar fram namnet på den pjäsen som är i vägen
                            string nameofopposite = Globalvar.Tiles[X - 1, Y].Controls[0].Name;

                            if (!nameofopposite.Contains(color))
                            {
                                //: skapar en ny tile oms ka synas
                                highlightedTile highlightedTile = new highlightedTile(Globalvar.Tiles[X - 1, Y].BackColor, Color.Red, Globalvar.Tiles[X - 1, Y], ThePiece.Name, X - 1, Y);

                                //: Ändrar fägen på den
                                highlightedTile.change();

                                //: Lägger till den i en lista så att man ändra tillbaka alla
                                Globalvar.highlightedTiles.Add(highlightedTile);

                            }

                        }
                    }
                    catch { }
                    #endregion

                    #region 2x3
                    //: en trycatcher ifall den går utanför planen
                    try
                    {
                        //: kollar att det inte står en pjäs ivägen
                        if (Globalvar.Tiles[X + 1, Y].Controls.Count == 0)
                        {

                            //: skapar en ny tile oms ka synas
                            highlightedTile highlightedTile = new highlightedTile(Globalvar.Tiles[X + 1, Y].BackColor, Color.Yellow, Globalvar.Tiles[X + 1, Y], ThePiece.Name, X + 1, Y);

                            //: Ändrar fägen på den
                            highlightedTile.change();

                            //: Lägger till den i en lista så att man ändra tillbaka alla
                            Globalvar.highlightedTiles.Add(highlightedTile);

                        }
                        else
                        {
                            //: tar fram namnet på den pjäsen som är i vägen
                            string nameofopposite = Globalvar.Tiles[X + 1, Y].Controls[0].Name;

                            if (!nameofopposite.Contains(color))
                            {
                                //: skapar en ny tile oms ka synas
                                highlightedTile highlightedTile = new highlightedTile(Globalvar.Tiles[X + 1, Y].BackColor, Color.Red, Globalvar.Tiles[X + 1, Y], ThePiece.Name, X + 1, Y);

                                //: Ändrar fägen på den
                                highlightedTile.change();

                                //: Lägger till den i en lista så att man ändra tillbaka alla
                                Globalvar.highlightedTiles.Add(highlightedTile);

                            }

                        }
                    }
                    catch { }
                    #endregion

                    #region 3x1
                    //: en trycatcher ifall den går utanför planen
                    try
                    {
                        //: kollar att det inte står en pjäs ivägen
                        if (Globalvar.Tiles[X - 1, Y + 1].Controls.Count == 0)
                        {

                            //: skapar en ny tile oms ka synas
                            highlightedTile highlightedTile = new highlightedTile(Globalvar.Tiles[X - 1, Y + 1].BackColor, Color.Yellow, Globalvar.Tiles[X - 1, Y + 1], ThePiece.Name, X - 1, Y + 1);

                            //: Ändrar fägen på den
                            highlightedTile.change();

                            //: Lägger till den i en lista så att man ändra tillbaka alla
                            Globalvar.highlightedTiles.Add(highlightedTile);

                        }
                        else
                        {
                            //: tar fram namnet på den pjäsen som är i vägen
                            string nameofopposite = Globalvar.Tiles[X - 1, Y + 1].Controls[0].Name;

                            if (!nameofopposite.Contains(color))
                            {
                                //: skapar en ny tile oms ka synas
                                highlightedTile highlightedTile = new highlightedTile(Globalvar.Tiles[X - 1, Y + 1].BackColor, Color.Red, Globalvar.Tiles[X - 1, Y + 1], ThePiece.Name, X - 1, Y + 1);

                                //: Ändrar fägen på den
                                highlightedTile.change();

                                //: Lägger till den i en lista så att man ändra tillbaka alla
                                Globalvar.highlightedTiles.Add(highlightedTile);

                            }

                        }
                    }
                    catch { }
                    #endregion

                    #region 3x2
                    //: en trycatcher ifall den går utanför planen
                    try
                    {
                        //: kollar att det inte står en pjäs ivägen
                        if (Globalvar.Tiles[X, Y + 1].Controls.Count == 0)
                        {

                            //: skapar en ny tile oms ka synas
                            highlightedTile highlightedTile = new highlightedTile(Globalvar.Tiles[X, Y + 1].BackColor, Color.Yellow, Globalvar.Tiles[X, Y + 1], ThePiece.Name, X, Y + 1);

                            //: Ändrar fägen på den
                            highlightedTile.change();

                            //: Lägger till den i en lista så att man ändra tillbaka alla
                            Globalvar.highlightedTiles.Add(highlightedTile);

                        }
                        else
                        {
                            //: tar fram namnet på den pjäsen som är i vägen
                            string nameofopposite = Globalvar.Tiles[X, Y + 1].Controls[0].Name;

                            if (!nameofopposite.Contains(color))
                            {
                                //: skapar en ny tile oms ka synas
                                highlightedTile highlightedTile = new highlightedTile(Globalvar.Tiles[X, Y + 1].BackColor, Color.Red, Globalvar.Tiles[X, Y + 1], ThePiece.Name, X, Y + 1);

                                //: Ändrar fägen på den
                                highlightedTile.change();

                                //: Lägger till den i en lista så att man ändra tillbaka alla
                                Globalvar.highlightedTiles.Add(highlightedTile);

                            }

                        }
                    }
                    catch { }
                    #endregion

                    #region 3x3
                    //: en trycatcher ifall den går utanför planen
                    try
                    {
                        //: kollar att det inte står en pjäs ivägen
                        if (Globalvar.Tiles[X + 1, Y + 1].Controls.Count == 0)
                        {

                            //: skapar en ny tile oms ka synas
                            highlightedTile highlightedTile = new highlightedTile(Globalvar.Tiles[X + 1, Y + 1].BackColor, Color.Yellow, Globalvar.Tiles[X + 1, Y + 1], ThePiece.Name, X + 1, Y + 1);

                            //: Ändrar fägen på den
                            highlightedTile.change();

                            //: Lägger till den i en lista så att man ändra tillbaka alla
                            Globalvar.highlightedTiles.Add(highlightedTile);

                        }
                        else
                        {
                            //: tar fram namnet på den pjäsen som är i vägen
                            string nameofopposite = Globalvar.Tiles[X + 1, Y + 1].Controls[0].Name;

                            if (!nameofopposite.Contains(color))
                            {
                                //: skapar en ny tile oms ka synas
                                highlightedTile highlightedTile = new highlightedTile(Globalvar.Tiles[X + 1, Y + 1].BackColor, Color.Red, Globalvar.Tiles[X + 1, Y + 1], ThePiece.Name, X + 1, Y + 1);

                                //: Ändrar fägen på den
                                highlightedTile.change();

                                //: Lägger till den i en lista så att man ändra tillbaka alla
                                Globalvar.highlightedTiles.Add(highlightedTile);

                            }

                        }
                    }
                    catch { }

                    #endregion

                }
                #endregion

                #region Queen
                if (pieceType == "queen")
                {

                    #region I  diagonalen

                    //: varbeler som säger ifall man ska sluta kolla i en riktning
                    bool readyupright = false;
                    bool readydownright = false;
                    bool readydownleft = false;
                    bool readyupleft = false;

                    //: en for-loop som kollar alla håll
                    #region readyupright
                    for (int i = 1; readyupright == false && i < Globalvar.Tiles.Length; i++)
                    {

                        //: en trycatcher ifall den går utanför planen
                        try
                        {
                            //: kollar att det inte står en pjäs ivägen
                            if (Globalvar.Tiles[X + i, Y - i].Controls.Count == 0)
                            {

                                //: skapar en ny tile oms ka synas
                                highlightedTile highlightedTile = new highlightedTile(Globalvar.Tiles[X + i, Y - i].BackColor, Color.Yellow, Globalvar.Tiles[X + i, Y - i], ThePiece.Name, X + i, Y - i);

                                //: Ändrar fägen på den
                                highlightedTile.change();

                                //: Lägger till den i en lista så att man ändra tillbaka alla
                                Globalvar.highlightedTiles.Add(highlightedTile);

                            }
                            else
                            {
                                //: tar fram namnet på den pjäsen som är i vägen
                                string nameofopposite = Globalvar.Tiles[X + i, Y - i].Controls[0].Name;

                                if (!nameofopposite.Contains(color))
                                {
                                    //: skapar en ny tile oms ka synas
                                    highlightedTile highlightedTile = new highlightedTile(Globalvar.Tiles[X + i, Y - i].BackColor, Color.Red, Globalvar.Tiles[X + i, Y - i], ThePiece.Name, X + i, Y - i);

                                    //: Ändrar fägen på den
                                    highlightedTile.change();

                                    //: Lägger till den i en lista så att man ändra tillbaka alla
                                    Globalvar.highlightedTiles.Add(highlightedTile);



                                }
                                //: stänger av söknignen på grund av att man har gått in en pjäs
                                readyupright = true;
                            }

                            //: stänger av den ifall den går utanför banan
                            if (Globalvar.Tiles[X + i, Y - i] == null)
                            {
                                readyupright = true;
                            }

                        }
                        catch { }
                    }

                    #endregion

                    #region readydownright

                    for (int i = 1; readydownright == false && i < Globalvar.Tiles.Length; i++)
                    {

                        //: en trycatcher ifall den går utanför planen
                        try
                        {
                            //: kollar att det inte står en pjäs ivägen
                            if (Globalvar.Tiles[X + i, Y + i].Controls.Count == 0)
                            {

                                //: skapar en ny tile oms ka synas
                                highlightedTile highlightedTile = new highlightedTile(Globalvar.Tiles[X + i, Y + i].BackColor, Color.Yellow, Globalvar.Tiles[X + i, Y + i], ThePiece.Name, X + i, Y + i);

                                //: Ändrar fägen på den
                                highlightedTile.change();

                                //: Lägger till den i en lista så att man ändra tillbaka alla
                                Globalvar.highlightedTiles.Add(highlightedTile);

                            }
                            else
                            {
                                //: tar fram namnet på den pjäsen som är i vägen
                                string nameofopposite = Globalvar.Tiles[X + i, Y + i].Controls[0].Name;

                                if (!nameofopposite.Contains(color))
                                {
                                    //: skapar en ny tile oms ka synas
                                    highlightedTile highlightedTile = new highlightedTile(Globalvar.Tiles[X + i, Y + i].BackColor, Color.Red, Globalvar.Tiles[X + i, Y + i], ThePiece.Name, X + i, Y + i);

                                    //: Ändrar fägen på den
                                    highlightedTile.change();

                                    //: Lägger till den i en lista så att man ändra tillbaka alla
                                    Globalvar.highlightedTiles.Add(highlightedTile);



                                }
                                //: stänger av söknignen på grund av att man har gått in en pjäs
                                readydownright = true;
                            }

                            //: stänger av den ifall den går utanför banan
                            if (Globalvar.Tiles[X + i, Y + i] == null)
                            {
                                readydownright = true;
                            }

                        }
                        catch { }
                    }

                    #endregion

                    #region readydownleft

                    for (int i = 1; readydownleft == false && i < Globalvar.Tiles.Length; i++)
                    {

                        //: en trycatcher ifall den går utanför planen
                        try
                        {
                            //: kollar att det inte står en pjäs ivägen
                            if (Globalvar.Tiles[X - i, Y + i].Controls.Count == 0)
                            {

                                //: skapar en ny tile oms ka synas
                                highlightedTile highlightedTile = new highlightedTile(Globalvar.Tiles[X - i, Y + i].BackColor, Color.Yellow, Globalvar.Tiles[X - i, Y + i], ThePiece.Name, X - i, Y + i);

                                //: Ändrar fägen på den
                                highlightedTile.change();

                                //: Lägger till den i en lista så att man ändra tillbaka alla
                                Globalvar.highlightedTiles.Add(highlightedTile);

                            }
                            else
                            {
                                //: tar fram namnet på den pjäsen som är i vägen
                                string nameofopposite = Globalvar.Tiles[X - i, Y + i].Controls[0].Name;

                                if (!nameofopposite.Contains(color))
                                {
                                    //: skapar en ny tile oms ka synas
                                    highlightedTile highlightedTile = new highlightedTile(Globalvar.Tiles[X - i, Y + i].BackColor, Color.Red, Globalvar.Tiles[X - i, Y + i], ThePiece.Name, X - i, Y + i);

                                    //: Ändrar fägen på den
                                    highlightedTile.change();

                                    //: Lägger till den i en lista så att man ändra tillbaka alla
                                    Globalvar.highlightedTiles.Add(highlightedTile);



                                }
                                //: stänger av söknignen på grund av att man har gått in en pjäs
                                readydownleft = true;
                            }

                            //: stänger av den ifall den går utanför banan
                            if (Globalvar.Tiles[X - i, Y + i] == null)
                            {
                                readydownleft = true;
                            }

                        }
                        catch { }
                    }

                    #endregion

                    #region readyupleft

                    for (int i = 1; readyupleft == false && i < Globalvar.Tiles.Length; i++)
                    {

                        //: en trycatcher ifall den går utanför planen
                        try
                        {
                            //: kollar att det inte står en pjäs ivägen
                            if (Globalvar.Tiles[X - i, Y - i].Controls.Count == 0)
                            {

                                //: skapar en ny tile oms ka synas
                                highlightedTile highlightedTile = new highlightedTile(Globalvar.Tiles[X - i, Y - i].BackColor, Color.Yellow, Globalvar.Tiles[X - i, Y - i], ThePiece.Name, X - i, Y - i);

                                //: Ändrar fägen på den
                                highlightedTile.change();

                                //: Lägger till den i en lista så att man ändra tillbaka alla
                                Globalvar.highlightedTiles.Add(highlightedTile);

                            }
                            else
                            {
                                //: tar fram namnet på den pjäsen som är i vägen
                                string nameofopposite = Globalvar.Tiles[X - i, Y - i].Controls[0].Name;

                                if (!nameofopposite.Contains(color))
                                {
                                    //: skapar en ny tile oms ka synas
                                    highlightedTile highlightedTile = new highlightedTile(Globalvar.Tiles[X - i, Y - i].BackColor, Color.Red, Globalvar.Tiles[X - i, Y - i], ThePiece.Name, X - i, Y - i);

                                    //: Ändrar fägen på den
                                    highlightedTile.change();

                                    //: Lägger till den i en lista så att man ändra tillbaka alla
                                    Globalvar.highlightedTiles.Add(highlightedTile);



                                }
                                //: stänger av söknignen på grund av att man har gått in en pjäs
                                readyupleft = true;
                            }

                            //: stänger av den ifall den går utanför banan
                            if (Globalvar.Tiles[X - i, Y - i] == null)
                            {
                                readyupleft = true;
                            }

                        }
                        catch { }
                    }

                    #endregion

                    #endregion

                    #region horisontelt och vertikalt
                    //: varbeler som säger ifall man ska sluta kolla i en riktning
                    bool readydown = false;
                    bool readyup = false;
                    bool readyleft = false;
                    bool readyright = false;


                    //: en for-loop som kollar alla håll
                    #region Down
                    for (int i = 1; readydown == false && i < Globalvar.Tiles.Length; i++)
                    {

                        //: en trycatcher ifall den går utanför planen
                        try
                        {
                            //: kollar att det inte står en pjäs ivägen
                            if (Globalvar.Tiles[X, Y + i].Controls.Count == 0)
                            {

                                //: skapar en ny tile oms ka synas
                                highlightedTile highlightedTile = new highlightedTile(Globalvar.Tiles[X, Y + i].BackColor, Color.Yellow, Globalvar.Tiles[X, Y + i], ThePiece.Name, X, Y + i);

                                //: Ändrar fägen på den
                                highlightedTile.change();

                                //: Lägger till den i en lista så att man ändra tillbaka alla
                                Globalvar.highlightedTiles.Add(highlightedTile);

                            }
                            else
                            {
                                //: tar fram namnet på den pjäsen som är i vägen
                                string nameofopposite = Globalvar.Tiles[X, Y + i].Controls[0].Name;

                                if (!nameofopposite.Contains(color))
                                {
                                    //: skapar en ny tile oms ka synas
                                    highlightedTile highlightedTile = new highlightedTile(Globalvar.Tiles[X, Y + i].BackColor, Color.Red, Globalvar.Tiles[X, Y + i], ThePiece.Name, X, Y + i);

                                    //: Ändrar fägen på den
                                    highlightedTile.change();

                                    //: Lägger till den i en lista så att man ändra tillbaka alla
                                    Globalvar.highlightedTiles.Add(highlightedTile);



                                }
                                //: stänger av söknignen på grund av att man har gått in en pjäs
                                readydown = true;
                            }

                            //: stänger av den ifall den går utanför banan
                            if (Globalvar.Tiles[X, Y + i] == null)
                            {
                                readydown = true;
                            }

                        }
                        catch { }
                    }

                    #endregion

                    #region Up

                    for (int i = 1; readyup == false && i < Globalvar.Tiles.Length; i++)
                    {

                        //: en trycatcher ifall den går utanför planen
                        try
                        {
                            //: kollar att det inte står en pjäs ivägen
                            if (Globalvar.Tiles[X, Y - i].Controls.Count == 0)
                            {

                                //: skapar en ny tile oms ka synas
                                highlightedTile highlightedTile = new highlightedTile(Globalvar.Tiles[X, Y - i].BackColor, Color.Yellow, Globalvar.Tiles[X, Y - i], ThePiece.Name, X, Y - i);

                                //: Ändrar fägen på den
                                highlightedTile.change();

                                //: Lägger till den i en lista så att man ändra tillbaka alla
                                Globalvar.highlightedTiles.Add(highlightedTile);

                            }
                            else
                            {
                                //: tar fram namnet på den pjäsen som är i vägen
                                string nameofopposite = Globalvar.Tiles[X, Y - i].Controls[0].Name;

                                if (!nameofopposite.Contains(color))
                                {
                                    //: skapar en ny tile oms ka synas
                                    highlightedTile highlightedTile = new highlightedTile(Globalvar.Tiles[X, Y - i].BackColor, Color.Red, Globalvar.Tiles[X, Y - i], ThePiece.Name, X, Y - i);

                                    //: Ändrar fägen på den
                                    highlightedTile.change();

                                    //: Lägger till den i en lista så att man ändra tillbaka alla
                                    Globalvar.highlightedTiles.Add(highlightedTile);



                                }
                                //: stänger av söknignen på grund av att man har gått in en pjäs
                                readyup = true;
                            }

                            //: stänger av den ifall den går utanför banan
                            if (Globalvar.Tiles[X, Y + i] == null)
                            {
                                readyup = true;
                            }

                        }
                        catch { }
                    }

                    #endregion

                    #region Left

                    for (int i = 1; readyleft == false && i < Globalvar.Tiles.Length; i++)
                    {

                        //: en trycatcher ifall den går utanför planen
                        try
                        {
                            //: kollar att det inte står en pjäs ivägen
                            if (Globalvar.Tiles[X - i, Y].Controls.Count == 0)
                            {

                                //: skapar en ny tile oms ka synas
                                highlightedTile highlightedTile = new highlightedTile(Globalvar.Tiles[X - i, Y].BackColor, Color.Yellow, Globalvar.Tiles[X - i, Y], ThePiece.Name, X - i, Y);

                                //: Ändrar fägen på den
                                highlightedTile.change();

                                //: Lägger till den i en lista så att man ändra tillbaka alla
                                Globalvar.highlightedTiles.Add(highlightedTile);

                            }
                            else
                            {
                                //: tar fram namnet på den pjäsen som är i vägen
                                string nameofopposite = Globalvar.Tiles[X - i, Y].Controls[0].Name;

                                if (!nameofopposite.Contains(color))
                                {
                                    //: skapar en ny tile oms ka synas
                                    highlightedTile highlightedTile = new highlightedTile(Globalvar.Tiles[X - i, Y].BackColor, Color.Red, Globalvar.Tiles[X - i, Y], ThePiece.Name, X - i, Y);

                                    //: Ändrar fägen på den
                                    highlightedTile.change();

                                    //: Lägger till den i en lista så att man ändra tillbaka alla
                                    Globalvar.highlightedTiles.Add(highlightedTile);



                                }
                                //: stänger av söknignen på grund av att man har gått in en pjäs
                                readyleft = true;
                            }

                            //: stänger av den ifall den går utanför banan
                            if (Globalvar.Tiles[X - i, Y] == null)
                            {
                                readyleft = true;
                            }

                        }
                        catch { }
                    }

                    #endregion

                    #region Right

                    for (int i = 1; readyright == false && i < Globalvar.Tiles.Length; i++)
                    {

                        //: en trycatcher ifall den går utanför planen
                        try
                        {
                            //: kollar att det inte står en pjäs ivägen
                            if (Globalvar.Tiles[X + i, Y].Controls.Count == 0)
                            {

                                //: skapar en ny tile oms ka synas
                                highlightedTile highlightedTile = new highlightedTile(Globalvar.Tiles[X + i, Y].BackColor, Color.Yellow, Globalvar.Tiles[X + i, Y], ThePiece.Name, X + i, Y);

                                //: Ändrar fägen på den
                                highlightedTile.change();

                                //: Lägger till den i en lista så att man ändra tillbaka alla
                                Globalvar.highlightedTiles.Add(highlightedTile);

                            }
                            else
                            {
                                //: tar fram namnet på den pjäsen som är i vägen
                                string nameofopposite = Globalvar.Tiles[X + i, Y].Controls[0].Name;

                                if (!nameofopposite.Contains(color))
                                {
                                    //: skapar en ny tile oms ka synas
                                    highlightedTile highlightedTile = new highlightedTile(Globalvar.Tiles[X + i, Y].BackColor, Color.Red, Globalvar.Tiles[X + i, Y], ThePiece.Name, X + i, Y);

                                    //: Ändrar fägen på den
                                    highlightedTile.change();

                                    //: Lägger till den i en lista så att man ändra tillbaka alla
                                    Globalvar.highlightedTiles.Add(highlightedTile);



                                }
                                //: stänger av söknignen på grund av att man har gått in en pjäs
                                readyright = true;
                            }

                            //: stänger av den ifall den går utanför banan
                            if (Globalvar.Tiles[X + i, Y] == null)
                            {
                                readyright = true;
                            }

                        }
                        catch { }
                    }

                    #endregion

                    #endregion

                }
                #endregion


            }
        }

        public void changeLocation( int Xinput , int Yinput)
        {

            X = Xinput;

            Y = Yinput;

            ThePiece.Parent = Globalvar.Tiles[ X , Y ];

            location = Globalvar.Tiles[X, Y];

            moves++;

            if(queenCheck() == true)
            {

                Globalvar.removePiece(ThePiece.Name);
                ThePiece.Parent = null;
                location.Image = null;

                int uniqeId = Globalvar.pieces.Count;

                Globalvar.pieces.Add(new piece("queen", color, location, color + "queen" + uniqeId, X, Y));
            }


           // Globalvar.changeTurn();
        }

        public void Kill()
        {
            if (color == "black")
            {
                ThePiece.Parent = null;
                location.Image = null;
                Globalvar.blackKillBoard[Globalvar.blackKillcount].Image = ThePiece.Image;
                Globalvar.blackKillcount++;

            }
            else
            {
                ThePiece.Parent = null;
                location.Image = null;
                Globalvar.whiteKillBoard[Globalvar.whiteKillCount].Image = ThePiece.Image;
                Globalvar.whiteKillCount++;
            }
            Globalvar.removeHighlight();
            Globalvar.removeKillOrder();
            Globalvar.getPiece(killer).changeLocation(X, Y);
           
        }

        public Boolean queenCheck()
        {

            if((pieceType == "pawn") && (((Y == 0) && (color == "white")) || ((Y == 7) && (color == "black"))))
            {
                return true;
            }

            return false;
        }

    }

    class highlightedTile
    {

        Color BeforeColor;
        Color AfterColor;
        public Label location;

        string pieceName;
         
        //: vilken korninat den pjäsen som hr klikts har
        public int X = 0;
        public int Y = 0;

        public piece enemy = null;

        public highlightedTile(Color colorBefore, Color colorAfter, Label locationinput, string pieceNameInput, int Xinput, int Yinput) {

            BeforeColor = colorBefore;
            
            AfterColor = colorAfter;

            location = locationinput;

            pieceName = pieceNameInput;

            X = Xinput;

            Y = Yinput; 

            location.Click += Location_Click;

            location.Cursor = Cursors.Hand;

                if(AfterColor == Color.Red)
               {
                enemy = Globalvar.getPieceAt(X, Y);
                enemy.killOrder = true;
                enemy.killer = pieceName;
               }
            }

        public void Location_Click(object sender, EventArgs e)
        {    
        
            //: om man ska attackera
            if(AfterColor == Color.Yellow)
            {
              Globalvar.getPiece(pieceName).changeLocation(X, Y);
            }

            //: tar bort allting efter man har gått till den.
            Globalvar.removeHighlight();
            Globalvar.removeKillOrder();

        }


        public void change()
        {
            location.BackColor = AfterColor;
        }
       
        public void changeback()
        {
            location.BackColor = BeforeColor;
        }

    }

}



