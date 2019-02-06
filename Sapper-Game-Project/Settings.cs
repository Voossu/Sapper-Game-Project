using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sapper
{
    public partial class Settings : Form
    {
        static GameManagerForm gameManagerForm = GameManagerForm.getInstance();

        public Settings()
        {
            InitializeComponent();
            rowsUpDown.Value = gameManagerForm.MR;
            columsUpDown.Value = gameManagerForm.MC;
            minesUpDown.Value = gameManagerForm.NM;
        }

        private void ok_Click(object sender, EventArgs e)
        {
            gameManagerForm.MR = Decimal.ToInt32(rowsUpDown.Value);
            gameManagerForm.MC = Decimal.ToInt32(columsUpDown.Value);
            gameManagerForm.NM = Decimal.ToInt32(minesUpDown.Value);
        }
    }
}
