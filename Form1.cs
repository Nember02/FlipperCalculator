using System.Globalization;

namespace FlipperCalculator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.TopMost = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(textBox1.Text.Replace(" ", ""), out decimal number))
            {
                textBox1.Text = string.Format("{0:N0}", number);
                textBox1.SelectionStart = textBox1.Text.Length;
            }

            if (decimal.TryParse(textBox1.Text, out decimal sale))
            {
                // Вычисление 4% и 8% комиссий от числа в textBox1 и вывод результатов в textBox3 и textBox4
                decimal commission4Percent = sale * 0.04m;
                decimal commission8Percent = sale * 0.08m;

                textBox3.Text = (sale - commission4Percent).ToString();
                textBox4.Text = (sale - commission8Percent).ToString();

                // Вызов метода для обновления процентов профита
                UpdateProfitLabels();
            }
            else
            {
                // Отображение ошибки при некорректных данных
                textBox3.Text = "Error";
                textBox4.Text = "Error";
            }
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(textBox2.Text.Replace(" ", ""), out decimal number))
            {
                textBox2.Text = string.Format("{0:N0}", number);
                textBox2.SelectionStart = textBox2.Text.Length;
            }

            UpdateProfitLabels();
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Отменяет ввод символа, если он не является цифрой или управляющим символом (например, Backspace)
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Отменяет ввод символа, если он не является цифрой или управляющим символом (например, Backspace)
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(textBox3.Text, out decimal number))
            {
                textBox3.Text = string.Format("{0:N0}", number);
                textBox3.SelectionStart = textBox3.Text.Length;
            }
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(textBox4.Text, out decimal number))
            {
                textBox4.Text = string.Format("{0:N0}", number);
                textBox4.SelectionStart = textBox4.Text.Length;
            }
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(textBox5.Text, out decimal number))
            {
                textBox5.Text = string.Format("{0:N0}", number);
                textBox5.SelectionStart = textBox5.Text.Length;
            }
        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(textBox5.Text, out decimal number))
            {
                textBox6.Text = string.Format("{0:N0}", number);
                textBox6.SelectionStart = textBox6.Text.Length;
            }
        }


        private void UpdateProfitLabels()
        {
            if (decimal.TryParse(textBox1.Text, out decimal sale) && decimal.TryParse(textBox2.Text, out decimal purchase))
            {
                // Вычисление суммы комиссий
                decimal commission4Percent = sale * 0.04m;
                decimal commission8Percent = sale * 0.08m;

                // Вычисление профита с учетом комиссий
                decimal profitWith4PercentCommission = sale - purchase - commission4Percent;
                decimal profitWith8PercentCommission = sale - purchase - commission8Percent;

                // Отображение результатов в текстовых полях
                textBox3.Text = (sale - commission4Percent).ToString();
                textBox4.Text = (sale - commission8Percent).ToString();
                textBox5.Text = profitWith4PercentCommission.ToString();
                textBox6.Text = profitWith8PercentCommission.ToString();

                // Вычисление процентов профита с учетом комиссий и округление до целых чисел
                decimal profitPercentWith4PercentCommission = Math.Round((profitWith4PercentCommission / purchase) * 100);
                decimal profitPercentWith8PercentCommission = Math.Round((profitWith8PercentCommission / purchase) * 100);

                // Определение знака профита и отображение процентов профита в метках
                label3.Text = $"{(profitPercentWith4PercentCommission >= 0 ? "+" : "-")}{Math.Abs(profitPercentWith4PercentCommission)}%";
                label7.Text = $"{(profitPercentWith8PercentCommission >= 0 ? "+" : "-")}{Math.Abs(profitPercentWith8PercentCommission)}%";

                label3.ForeColor = profitPercentWith4PercentCommission >= 0 ? Color.Green : Color.Red;
                label7.ForeColor = profitPercentWith8PercentCommission >= 0 ? Color.Green : Color.Red;
            }
            else
            {
                // Отображение ошибки при некорректных данных
                label3.Text = "Error";
                label7.Text = "Error";
            }
        }



        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void rotatedLabel_Click(object sender, EventArgs e)
        {

        }
    }
}