using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sapper
{
    public enum GameStatus {BEGIN, ON, VICTORY, FAIL}

    public partial class GameManagerForm : Form
    {
        // кол-во клеток по вертикали
        public int MR
        {
            get;  set;
        }
        // кол-во клеток по горизонтали
        public int MC
        {
            get; set;
        }
        // кол-во мин
        public int NM
        {
            get; set;
        }
        // ширина = высоте клетки (квадратная)
        public int CellSize
        {
            get; set;
        }

        private Sell[ , ] GameField; 

         // статус игры
        private GameStatus status;
 
        // графическая поверхность формы
        private System.Drawing.Graphics g;

        private void InitNewGameClearField(int _sellsize)
      {
         for (int row = 0; row < MR; row++)
          for (int col = 0; col < MC; col++)
          {
            GameField[row, col] = new Sell(_sellsize, 
                      (row == 0) || (row == MR - 1) || (col == 0) || (col == MC - 1) ? true : false);
          }
      }
        
        private void InitNewGameField()
      {
        status = GameStatus.BEGIN;      // начало игры


        // устанавливаем размер формы в соответствии с размером игрового поля
        GameField = new Sell[MR, MC];
        ClientSize = new Size(CellSize * MC, CellSize * MR + menuStrip1.Height);
        InitNewGameClearField(CellSize);

        int row, col;    // индексы клетки
        int n = 0;       // количество поставленных мин

        // инициализация генератора случайных чисел
        Random rnd = new Random();

        // расставим мины
        do
        {
          row = rnd.Next(MR);
          col = rnd.Next(MC);

          if (!GameField[row, col].HasMine)
          {
            GameField[row, col].HasMine = true;
            if (row != 0 && col != 0) GameField[row - 1, col - 1].NeibourMinesQty++;
            if (row != 0) GameField[row - 1, col].NeibourMinesQty++;
            if (row != 0 && col != MC - 1) GameField[row - 1, col + 1].NeibourMinesQty++;
            if (col != 0) GameField[row, col - 1].NeibourMinesQty++;
            if (col != MC - 1) GameField[row, col + 1].NeibourMinesQty++;
            if (row != MR - 1 && col != 0) GameField[row + 1, col - 1].NeibourMinesQty++;
            if (row != MR - 1) GameField[row + 1, col].NeibourMinesQty++;
            if (row != MR - 1  && col != MC - 1) GameField[row + 1, col + 1].NeibourMinesQty++;
            n++;
          }
        }
        while (n != NM);

            // графическая поверхность
            g = panel1.CreateGraphics();
        }

        private static GameManagerForm instance;

        public static GameManagerForm getInstance()
        {
            if (instance == null)
            {
                instance = new GameManagerForm();
            }
            return instance;
        }

        private GameManagerForm()
        {
            InitializeComponent();

            MR = 15;
            MC = 15;
            NM = 20;
            CellSize = 40;

            // новая игра
            InitNewGameField();
            
            
        }
      
       // рисует поле
        private void ShowField(Graphics g, GameStatus status)
        {

          for (int row = 0; row < MR; row++)
            for (int col = 0; col < MC; col++)
              GameField[row, col].DrawSell(g, row, col, CellSize, status);
        }

        private bool CheckIfVictory()
        {
              int nMinWithFlag = 0;  // кол-во правильно найденных мин
            
               for (int row = 0; row < MR; row++)
                  for (int col = 0; col < MC; col++)
                    if (GameField[row, col].HasMine && GameField[row, col].HasFlag) nMinWithFlag++;

               return (nMinWithFlag == NM ? true : false);
        }


        // открывает текущую и все соседние с ней клетки, в которых нет мин
        // 
        private void OpenSells(int row, int col)
        {

          if (!GameField[row, col].IsOpen && GameField[row, col].HasMine)
          {
            status = GameStatus.FAIL;
            GameField[row, col].SellBackColor = Brushes.Red;
          }
          else
          {
            if (!GameField[row, col].IsOpen && GameField[row, col].NeibourMinesQty == 0)
            {

              GameField[row, col].OpenSell();

              // открыть примыкающие клетки слева, справа, сверху, снизу
              if (col != 0) this.OpenSells(row, col - 1);
              if (row != 0) this.OpenSells(row - 1, col);
              if (col != MC - 1) this.OpenSells(row, col + 1);
              if (row != MR - 1) this.OpenSells(row + 1, col);

              //примыкающие диагонально
              if (row != 0 && col != 0) this.OpenSells(row - 1, col - 1);
              if (row != 0 && col != MC - 1) this.OpenSells(row - 1, col + 1);
              if (row != MR - 1 && col != 0) this.OpenSells(row + 1, col - 1);
              if (row != MR - 1 && col != MC - 1) this.OpenSells(row + 1, col + 1);
            }
            else
              if (!GameField[row, col].IsOpen && GameField[row, col].NeibourMinesQty != 0)
              {
                GameField[row, col].OpenSell();
              }
          }
          GameField[row, col].DrawSell(g, row, col, CellSize, status);
        }


        // щелчок кнопкой в клетке игрового поля
        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
          // игра завершена
          if (status == GameStatus.VICTORY || status == GameStatus.FAIL) return;

          // первый щелчок
          if (status == GameStatus.BEGIN) status = GameStatus.ON;

          // преобразуем координаты мыши (e.X, e.Y) в индексы клетки поля, в которой был сделан щелчок;
               
          int row = (int)(e.Y / CellSize);
          int col = (int)(e.X / CellSize);

          // щелчок левой кнопки мыши
          if (e.Button == MouseButtons.Left)
          {
            this.OpenSells(row, col);
          }

          if (status == GameStatus.FAIL)
          {
            ShowField(g, status);
            MessageBox.Show("You have fail!", "Fail",MessageBoxButtons.OK);
          }
          // щелчок правой кнопки мыши
          if (e.Button == MouseButtons.Right)
          {
            if (!GameField[row, col].HasFlag && !GameField[row, col].IsOpen)
            {
             GameField[row, col].HasFlag = true;
            }
            else
            if (GameField[row, col].HasFlag && !GameField[row, col].IsOpen)
            {
              GameField[row, col].HasFlag = false;
            }
          
            GameField[row, col].DrawSell(g, row, col, CellSize, status);
            if (CheckIfVictory())
            {
              status = GameStatus.VICTORY;
              MessageBox.Show("You have won!", "Victory", MessageBoxButtons.OK);
            }
          }
        }
     
        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
          InitNewGameField();
          ShowField(g, status);
        }

        // обработка события Paint панели
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            ShowField(g, status);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm aboutBox = new AboutForm();
            aboutBox.ShowDialog();
        }

        // выбор в меню Справка команды Правила игры
        private void rulesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("help.html");
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings aboutBox = new Settings();
            aboutBox.ShowDialog();
        }

    }
}