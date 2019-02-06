using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;

namespace Sapper
{
 
  class Sell
  {
    private int sellSize; //размер клетки
   
    private bool hasMine; //есть ли в клетке мина
    private bool hasFlag; //стоит ли в клетке флажок
    private bool isOpen;  //открыта ли клетка

    private int neibourMinesQty; //сколько в сумме мин в соседних клетках 

    private Brush sellBackColor; //цвет фона клетки


    public Sell(int _sellSize, bool _isOnBorder)
    {
      sellSize = _sellSize;
     
      hasMine = false;
      neibourMinesQty = 0;
      sellBackColor = Brushes.DarkGray;
      hasFlag = false;
      isOpen = false;
    }

    // рисует мину
    private void DrawMine(Graphics g, int x, int y)
    {
      //// корпус
      g.FillRectangle(Brushes.Green, x + 16, y + 26, 8, 4);
      g.FillRectangle(Brushes.Green, x + 8, y + 30, 24, 4);
      g.DrawPie(Pens.Black, x + 6, y + 28, 28, 16, 0, -180);
      g.FillPie(Brushes.Green, x + 6, y + 28, 28, 16, 0, -180);

      // полоса на корпусе
      g.DrawLine(Pens.Black, x + 12, y + 32, x + 28, y + 32);

      // вертикальный "ус"
      g.DrawLine(Pens.Black, x + 20, y + 22, x + 20, y + 26);

      // боковые "усы"
      g.DrawLine(Pens.Black, x + 8, y + 30, x + 6, y + 28);
      g.DrawLine(Pens.Black, x + 32, y + 30, x + 34, y + 28);
    }

    // рисует флаг
    private void DrowFlag(Graphics g, int x, int y)
    {
      Point[] p = new Point[3];
      Point[] m = new Point[5];

      // флажок
      p[0].X = x + 4; p[0].Y = y + 4;
      p[1].X = x + 30; p[1].Y = y + 12;
      p[2].X = x + 4; p[2].Y = y + 20;
      g.FillPolygon(Brushes.Red, p);

      // древко
      g.DrawLine(Pens.Black, x + 4, y + 4, x + 4, y + 35);

      // буква M на флажке
      m[0].X = x + 8; m[0].Y = y + 14;
      m[1].X = x + 8; m[1].Y = y + 8;
      m[2].X = x + 10; m[2].Y = y + 10;
      m[3].X = x + 12; m[3].Y = y + 8;
      m[4].X = x + 12; m[4].Y = y + 14;
      g.DrawLines(Pens.White, m);
    }

    public void DrawSell(Graphics g, int row, int col, int CellSize, GameStatus status)
    {

      // координаты левого верхнего угла клетки
     int x = (col) * CellSize + 1 ;
     int y = (row ) * CellSize + 1 ;

      if (status == GameStatus.FAIL && this.hasMine)
      {
        this.sellBackColor = Brushes.Red;
      }

      g.FillRectangle(sellBackColor, x - 1, y - 1, CellSize, CellSize);// рисуем фон клетки
      g.DrawRectangle(Pens.Black,x - 1, y - 1, CellSize, CellSize);  // рисуем границу клетки

      if (this.isOpen)
      {
        g.DrawString((this.neibourMinesQty == 0 ? "" : this.neibourMinesQty.ToString()),  
            new Font("Tahoma", 16, System.Drawing.FontStyle.Regular),
              Brushes.Indigo, x + 10, y + 7);
      }
         
      // в клетке поставлен флаг
      if (this.hasFlag)
        this.DrowFlag(g, x, y);

      //if (this.hasMine)
      //{
      //  this.DrawMine(g, x, y);
      //}

      // если игра завершена поражением, показываем мины
      if ((status == GameStatus.FAIL) && (this.hasMine))
      {
        this.DrawMine(g, x, y);
      }
    }

    public void OpenSell()
    {
      this.IsOpen = true;
      this.SellBackColor = Brushes.LightGray;
    }

    public Brush SellBackColor
    {
      //get { return (sellBackColor); }
      set { sellBackColor = value; }
    }
    public int NeibourMinesQty
    {
      get { return (neibourMinesQty); }
      set { neibourMinesQty = value; }
    }
    public bool HasMine
    {
      get { return (hasMine); }
      set { hasMine = value; }
    }

    public bool HasFlag
    {
      get { return (hasFlag); }
      set { hasFlag = value; }
    }
    public bool IsOpen
    {
      get { return (isOpen); }
      set { isOpen = value; }
    }
    public int SellSize
    {
      get { return (sellSize); }
      set { sellSize = value; }
    }
   }
}
