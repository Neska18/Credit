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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void groupBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            double sum = 0;
            for (int i = 0; i < groupDataGridView.Rows.Count; i++)
            {
                sum += Convert.ToDouble(groupDataGridView.Rows[i].Cells["dataGridViewTextBoxColumn3"].Value);
            }
            if (sum == 1)
            {
                this.Validate();
                this.groupBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.database1DataSet);
            }
            else
                MessageBox.Show(
                "Сумма весов должна быть равна 1!",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet.group". При необходимости она может быть перемещена или удалена.
            this.groupTableAdapter.Fill(this.database1DataSet.group);

        }
    }
}
