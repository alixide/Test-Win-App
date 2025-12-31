using System;
using System.Windows.Forms;

namespace CalculatorApp
{
    public partial class CalculatorForm : Form
    {
        private double currentValue = 0;
        private double storedValue = 0;
        private string operation = "";
        private bool operationPressed = false;

        public CalculatorForm()
        {
            InitializeComponent();
        }

        private void NumberButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (txtDisplay.Text == "0" || operationPressed)
            {
                txtDisplay.Clear();
                operationPressed = false;
            }

            txtDisplay.Text += button.Text;
        }

        private void OperatorButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (!string.IsNullOrEmpty(operation) && !operationPressed)
            {
                btnEquals.PerformClick();
            }

            operation = button.Text;
            storedValue = double.Parse(txtDisplay.Text);
            operationPressed = true;
        }

        private void BtnEquals_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(operation))
                return;

            currentValue = double.Parse(txtDisplay.Text);

            switch (operation)
            {
                case "+":
                    txtDisplay.Text = (storedValue + currentValue).ToString();
                    break;
                case "-":
                    txtDisplay.Text = (storedValue - currentValue).ToString();
                    break;
                case "×":
                    txtDisplay.Text = (storedValue * currentValue).ToString();
                    break;
                case "÷":
                    if (currentValue != 0)
                        txtDisplay.Text = (storedValue / currentValue).ToString();
                    else
                        txtDisplay.Text = "Error";
                    break;
            }

            operation = "";
            operationPressed = true;
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
            currentValue = 0;
            storedValue = 0;
            operation = "";
            operationPressed = false;
        }

        private void BtnDecimal_Click(object sender, EventArgs e)
        {
            if (!txtDisplay.Text.Contains("."))
            {
                txtDisplay.Text += ".";
            }
        }

        private void BtnBackspace_Click(object sender, EventArgs e)
        {
            if (txtDisplay.Text.Length > 1)
            {
                txtDisplay.Text = txtDisplay.Text.Substring(0, txtDisplay.Text.Length - 1);
            }
            else
            {
                txtDisplay.Text = "0";
            }
        }
    }
}
