using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoEditor
{
    public partial class SizeDialog : Form
    {
        private int size;

        public SizeDialog()
        {
            InitializeComponent();
        }

        public int Size
        {
            get { return size; }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            size = (int)numericUpDown.Value;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SizeDialog_Load(object sender, EventArgs e)
        {
            okButton.DialogResult = DialogResult.OK;
            cancelButton.DialogResult = DialogResult.Cancel;
        }
    }
}
