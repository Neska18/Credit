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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void questionBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            double sum1 = 0;
            double sum2 = 0;
            double sum3 = 0;
            double sum4 = 0;
            for (int i = 0; i < questionDataGridView.Rows.Count; i++)
            {
                if (Convert.ToInt32(questionDataGridView.Rows[i].Cells["dataGridViewTextBoxColumn4"].Value) == 2)
                    sum1 += Convert.ToDouble(questionDataGridView.Rows[i].Cells["dataGridViewTextBoxColumn2"].Value);
                if (Convert.ToInt32(questionDataGridView.Rows[i].Cells["dataGridViewTextBoxColumn4"].Value) == 3)
                    sum2 += Convert.ToDouble(questionDataGridView.Rows[i].Cells["dataGridViewTextBoxColumn2"].Value);
                if (Convert.ToInt32(questionDataGridView.Rows[i].Cells["dataGridViewTextBoxColumn4"].Value) == 4)
                    sum3 += Convert.ToDouble(questionDataGridView.Rows[i].Cells["dataGridViewTextBoxColumn2"].Value);
                if (Convert.ToInt32(questionDataGridView.Rows[i].Cells["dataGridViewTextBoxColumn4"].Value) == 6)
                    sum4 += Convert.ToDouble(questionDataGridView.Rows[i].Cells["dataGridViewTextBoxColumn2"].Value);
            }
            if (sum1 == 1 && sum2 == 1 && sum3 == 1 && sum4 == 1)
            {
                this.Validate();
                this.questionBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.database1DataSet);
            }
            else
            {
                if (sum1 != 1)
                    MessageBox.Show(
                    "Сумма группы вопросов 'Личные данные' не равна 1!",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                if (sum2 != 1)
                    MessageBox.Show(
                    "Сумма группы вопросов 'Сведения о работе' не равна 1!",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                if (sum3 != 1)
                    MessageBox.Show(
                    "Сумма группы вопросов 'Сведения об активах' не равна 1!",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                if (sum4 != 1)
                    MessageBox.Show(
                    "Сумма группы вопросов 'Дополнительные сведения' не равна 1!",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

        }

        private void Form6_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet.group". При необходимости она может быть перемещена или удалена.
            this.groupTableAdapter.Fill(this.database1DataSet.group);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet.question". При необходимости она может быть перемещена или удалена.
            this.questionTableAdapter.Fill(this.database1DataSet.question);

        }
    }
}
