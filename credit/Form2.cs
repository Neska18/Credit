using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace credit
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet1.Result". При необходимости она может быть перемещена или удалена.
            this.resultTableAdapter.Fill(this.database1DataSet1.Result);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet.Result". При необходимости она может быть перемещена или удалена.
            this.resultTableAdapter.Fill(this.database1DataSet.Result);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            resultBindingSource.Filter = "surname LIKE '" + textBox1.Text + "%'";
        }
    }
}
