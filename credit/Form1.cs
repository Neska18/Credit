using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace credit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet3._16". При необходимости она может быть перемещена или удалена.
            this._16TableAdapter.Fill(this.database1DataSet3._16);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet3._15". При необходимости она может быть перемещена или удалена.
            this._15TableAdapter.Fill(this.database1DataSet3._15);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet3._14". При необходимости она может быть перемещена или удалена.
            this._14TableAdapter.Fill(this.database1DataSet3._14);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet3._13". При необходимости она может быть перемещена или удалена.
            this._13TableAdapter.Fill(this.database1DataSet3._13);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet3.stoimavt". При необходимости она может быть перемещена или удалена.
            this.stoimavtTableAdapter.Fill(this.database1DataSet3.stoimavt);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet3.summa". При необходимости она может быть перемещена или удалена.
            this.summaTableAdapter.Fill(this.database1DataSet3.summa);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet3.nedvijmush". При необходимости она может быть перемещена или удалена.
            this.nedvijmushTableAdapter.Fill(this.database1DataSet3.nedvijmush);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet3.typedolj". При необходимости она может быть перемещена или удалена.
            this.typedoljTableAdapter.Fill(this.database1DataSet3.typedolj);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet3.sphere". При необходимости она может быть перемещена или удалена.
            this.sphereTableAdapter.Fill(this.database1DataSet3.sphere);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet3.form". При необходимости она может быть перемещена или удалена.
            this.formTableAdapter.Fill(this.database1DataSet3.form);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet3.count". При необходимости она может быть перемещена или удалена.
            this.countTableAdapter.Fill(this.database1DataSet3.count);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet3.type". При необходимости она может быть перемещена или удалена.
            this.typeTableAdapter.Fill(this.database1DataSet3.type);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet3.time". При необходимости она может быть перемещена или удалена.
            this.timeTableAdapter.Fill(this.database1DataSet3.time);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet3.education". При необходимости она может быть перемещена или удалена.
            this.educationTableAdapter.Fill(this.database1DataSet3.education);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet2.status". При необходимости она может быть перемещена или удалена.
            this.statusTableAdapter.Fill(this.database1DataSet2.status);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet1.age". При необходимости она может быть перемещена или удалена.
            this.ageTableAdapter.Fill(this.database1DataSet1.age);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database1DataSet.answer". При необходимости она может быть перемещена или удалена.
            this.answerTableAdapter.Fill(this.database1DataSet.answer);

        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.answerTableAdapter.FillBy(this.database1DataSet.answer);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
        Group getGroup(string id)
        {
            // Получить объект Connection подключенный к DB.
            SqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            try
            {
                string sql = "Select * from [group] where id_group = " + id;

                // Создать объект Command.
                SqlCommand cmd = new SqlCommand();

                // Сочетать Command с Connection.
                cmd.Connection = conn;
                cmd.CommandText = sql;

                int idG = 0;
                string nameG = "";
                double weightG = 0;
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            idG = Convert.ToInt32(reader.GetValue(0));
                            nameG = reader.GetValue(1).ToString();
                            weightG = Convert.ToDouble(reader.GetValue(2));
                        }
                    }
                }

                sql = "Select * from question where id_group = " + id;

                // Создать объект Command.
                cmd = new SqlCommand();

                // Сочетать Command с Connection.
                cmd.Connection = conn;
                cmd.CommandText = sql;

                List<Question> questions = new List<Question>();
                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int idQ = Convert.ToInt32(reader.GetValue(0));
                            string nameQ = reader.GetValue(2).ToString();
                            double weightQ = Convert.ToDouble(reader.GetValue(1));
                            questions.Add(new Question(idQ, nameQ, weightQ));

                        }
                    }
                }
                return new Group(idG, nameG, weightG, questions);
            }
            catch (Exception _e)
            {
                MessageBox.Show(
                "Error: " + _e + "\n" + _e.StackTrace,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                // Закрыть соединение.
                conn.Close();
                // Разрушить объект, освободить ресурс.
                conn.Dispose();
            }
        }

        string return_s(int interval_s)
        {
            string s = "";
            switch(interval_s)
            {
                case 1: s = "99 999 рублей!"; break;
                case 2: s = "499 999 рублей!"; break;
                case 3: s = "999 999 999 рублей!"; break;
                case 4: s = "4 999 999 рублей!"; break;
            }
            return s;
        }

        double return_k(int interval_s)
        {
            double s = 0;
            switch (interval_s)
            {
                case 1: s = 99999.99; break;
                case 2: s = 499999.99; break;
                case 3: s = 999999.99; break;
                case 4: s = 4999999.99; break;
            }
            return s;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show(
                "Не все обязательные поля заполнены!",
                "Сообщение",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
                return;
            }

            Group ld = getGroup("2");
            Group work = getGroup("3");
            Group active = getGroup("4");
            Group dop = getGroup("6");
            double sum = 0;
            for(int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dataGridView1.Rows[i].Cells["Check"].Value))
                    sum += Convert.ToDouble(dataGridView1.Rows[i].Cells["weightanswerDataGridViewTextBoxColumn"].Value);
            }
            double ld_r = ld.Weight * (ld.Questions[0].Weight * Convert.ToDouble(comboBox1.SelectedValue) +
                                        ld.Questions[1].Weight * Convert.ToDouble(comboBox2.SelectedValue) +
                                        ld.Questions[2].Weight * Convert.ToDouble(comboBox3.SelectedValue));
            double work_r = work.Weight * (work.Questions[0].Weight * Convert.ToDouble(comboBox4.SelectedValue) +
                                        work.Questions[1].Weight * Convert.ToDouble(comboBox5.SelectedValue) +
                                        work.Questions[2].Weight * Convert.ToDouble(comboBox7.SelectedValue) +
                                        work.Questions[3].Weight * Convert.ToDouble(comboBox6.SelectedValue) +
                                        work.Questions[4].Weight * Convert.ToDouble(comboBox9.SelectedValue) +
                                        work.Questions[5].Weight * Convert.ToDouble(comboBox8.SelectedValue));
            double active_r = active.Weight * (active.Questions[0].Weight * sum +
                                        active.Questions[1].Weight * Convert.ToDouble(comboBox10.SelectedValue) +
                                        active.Questions[2].Weight * Convert.ToDouble(comboBox11.SelectedValue));
            double dop_r = dop.Weight * (dop.Questions[0].Weight * Convert.ToDouble(comboBox13.SelectedValue) +
                                        dop.Questions[1].Weight * Convert.ToDouble(comboBox12.SelectedValue) +
                                        dop.Questions[2].Weight * Convert.ToDouble(comboBox15.SelectedValue) +
                                        dop.Questions[3].Weight * Convert.ToDouble(comboBox14.SelectedValue));
            double result = (ld_r +
                            work_r +
                            active_r +
                            dop_r) * 100;
            if (result < 20)
            {
               MessageBox.Show(
               "К сожалению, Вы не набрали необходимое количество баллов!",
               "Сообщение",
               MessageBoxButtons.OK,
               MessageBoxIcon.Warning);
               return;
            }
            double k = Convert.ToDouble(numericUpDown1.Value);
            double p = 0;
            if (k < 100000)
                p = 0.2;
            if (k >= 100000 && k <= 500000)
                p = 0.15;
            if (k > 500000 && k <= 1000000)
                p = 0.13;
            if (k > 1000000 && k <= 5000000)
                p = 0.1;
            int m = Convert.ToInt32(numericUpDown2.Value) * 12;
            if (m > 60)
            {
                MessageBox.Show(
                "Количество лет не должно превышать 5 лет.",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }
            double a = k * (p/12*Math.Pow(1 + p/12, m))/(Math.Pow(1 + p / 12, m) - 1);
            double zp = Convert.ToDouble(numericUpDown3.Value);
            double pd = Convert.ToDouble(numericUpDown4.Value);
            double eo = Convert.ToDouble(numericUpDown5.Value);
            int ki = Convert.ToInt32(numericUpDown6.Value);
            double dr = (zp + pd) *0.6  - eo - ki * 14000.0;

            int interval_s = 0;
            int interval_b = 0;
            bool[,] arr = new bool[,] { { true, true, true, true }, { false, true, true, true }, { false, false, true, true }, { false, false, false, true } };
            if (k < 100000)
                interval_s = 1;
            else if (k >= 100000 && k < 500000)
                interval_s = 2;
            else if (k >= 500000 && k < 1000000)
                interval_s = 3;
            else if (k >= 1000000 && k < 5000000)
                interval_s = 4;

            if (result <= 50 && result > 20)
                interval_b = 1;
            else if (result <= 65 && result > 50)
                interval_b = 2;
            else if (result <= 84 && result > 65)
                interval_b= 3;
            else if (result > 84)
                interval_b = 4;
            string ansver = "";
            bool check = false;
            if (dr >= a)
            {
                if (arr[interval_s - 1, interval_b - 1])
                {
                    ansver = "Запрашиваемая сумма " + k.ToString() + " на " + m.ToString() + " месяца(ев) одобрена!\n\n";
                  }
                else
                {
                    while (!arr[interval_s - 1, interval_b - 1])
                        interval_s--;
                    ansver = "Запрашиваемая сумма " + k.ToString() + " на " + m.ToString() + " месяца(ев) не может быть выдана!\nМаксимально возможная сумма кредита на выбранный Вами период " + m.ToString() + " месяца(ев) составит " + return_s(interval_s);
                }
            }
            else
            {
                ansver = "Запрашиваемая сумма " + k.ToString() + " на " + m.ToString() + " месяца(ев) не может быть выдана!\nМы можем предложить Вам следующие варианты:\n- ";
                for (int i = m; i <= 60; i += 12)
                {
                    a = k * (p / 12 * Math.Pow(1 + p / 12, i)) / (Math.Pow(1 + p / 12, i) - 1);
                    if (dr >= a)
                    {
                        ansver += (k.ToString() + " рублей на " + i.ToString() + " месяца(ев);\n- ");
                        break;
                    }
                }
                k = (dr * Math.Pow(1 + p / 12, m) - dr) / (p / 12 * Math.Pow(1 + p / 12, m));
                ansver += (Math.Round(k).ToString() + " рублей на " + m.ToString() + " месяца(ев).");
            }
            DialogResult res = MessageBox.Show(
                ansver + "\n\nЗаписать результат в БД?",
                "Ответ",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information);
            if (res == DialogResult.Yes)
            {
                string surname = textBox1.Text;
                string name = textBox2.Text;
                string patronymic = textBox3.Text;
                DateTime my_date = dateTimePicker1.Value;
                SqlConnection connection = DBUtils.GetDBConnection();
                connection.Open();
                try
                {
                    string sql = "Insert into Result (surname, name, patronymic, data_obr, result)"
                        + " values (@sn, @n, @p, @d, @r)";

                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = sql;

                    cmd.Parameters.Add("@sn", SqlDbType.NVarChar).Value = surname;
                    cmd.Parameters.Add("@n", SqlDbType.NVarChar).Value = name;
                    cmd.Parameters.Add("@p", SqlDbType.NVarChar).Value = patronymic;
                    cmd.Parameters.Add("@d", SqlDbType.Date).Value = my_date;
                    cmd.Parameters.Add("@r", SqlDbType.NVarChar).Value = ansver;

                    // Выполнить Command (Используется для delete, insert, update).
                    int rowCount = cmd.ExecuteNonQuery();
                }
                catch (Exception _e)
                {
                    MessageBox.Show(
                    "Error: " + _e + "\n" + _e.StackTrace,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                    connection = null;
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "менее 16 лет")
            {
               MessageBox.Show(
               "К сожалению, кредит выдается с 16 лет!",
               "Сообщение",
               MessageBoxButtons.OK,
               MessageBoxIcon.Warning);
               button1.Visible = false;
            }
        }
    }
}
