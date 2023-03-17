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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void answerBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            bool check = true;
            for (int i = 0; i < answerDataGridView.Rows.Count; i++)
            {
                if (Convert.ToDouble(answerDataGridView.Rows[i].Cells["dataGridViewTextBoxColumn2"].Value) < 0 || Convert.ToDouble(answerDataGridView.Rows[i].Cells["dataGridViewTextBoxColumn2"].Value) > 1)
                    check = false;
            }
            if (check)
            {
                this.Validate();
                this.questionBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.database1DataSet);
            }
            else
                MessageBox.Show(
                "Вес ответа должен быть в пределе от 0 до 1!",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

        }

        private void Form7_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet.question". При необходимости она может быть перемещена или удалена.
            this.questionTableAdapter.Fill(this.database1DataSet.question);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet.answer". При необходимости она может быть перемещена или удалена.
            this.answerTableAdapter.Fill(this.database1DataSet.answer);

        }
    }
}
