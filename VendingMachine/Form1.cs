using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace VendingMachine
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            paymentBox.AllowDrop = true;
            buttonControlEnabled(1, false);

            foreach (string drink in drinkPrices.Keys) // allows us to change if the drinkPrices gets updated
            {
                drinkQuantities[drink] = 0;
            }
            UpdateListBox();
        }


        #region Public Variables and Data

        // global variable decleration
        private decimal totalPriceCost;
        private decimal totalMoneyInput;
        private decimal totalChange;

        // Dictionary - allows the drinks to stack in the list box
        private Dictionary<string, int> drinkQuantities = new Dictionary<string, int>();


        private string lastAction = "Welcome! Please select your drinks.";


        // Dictionary that has all the components of the drinks offered
        private Dictionary<string, decimal> drinkPrices = new Dictionary<string, decimal>()
        {
            { "Flat White", 2.25m },
            { "Latte", 2.85m },
            { "Cappuccino", 3.00m },
            { "Americano", 2.95m }
        };

        //error message get's printed whenever a critical faul happens in the code.
        private void errorMessage()
        {
            MessageBox.Show("It seems that the vending machine fell into a fatal error. Please restart the machine.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //controls the money and drinks panel - turns on and off
        private void buttonControlEnabled(int i, bool selection)
        {

            if (i == 0)
            {
                drinkSelectionPanel.Enabled = selection;
                sum_btn.Enabled = true;
            }
            else if (i == 1)
            {
                moneyPanel.Enabled = selection;
            }
            else
            {
                errorMessage();
            }
        }

        // resets values when the program comes to completion
        private void resetValues()
        {
            totalMoneyInput = 0;
            totalPriceCost = 0;
            totalChange = 0;
            main_listBox.Items.Clear();
            moneyIn_txtBox.Clear();
            foreach (var drink in drinkQuantities.Keys)
            {
                drinkQuantities[drink] = 0;
            }
            buttonControlEnabled(1, false);
            buttonControlEnabled(0, true);
            lastAction = "";
        }
        #endregion

        #region Drag and Drop

        //money down pressed
        private void money_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox moneyBox = sender as PictureBox;
            moneyBox.DoDragDrop(moneyBox, DragDropEffects.Copy);
        }

        private void paymentBox_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        //
        private void paymentBox_DragDrop(object sender, DragEventArgs e)
        {
            PictureBox droppedCoin = e.Data.GetData(typeof(PictureBox)) as PictureBox;

            if (droppedCoin == money_5p) totalMoneyInput += .05m;
            else if (droppedCoin == money_10p) totalMoneyInput += 0.10m;
            else if (droppedCoin == money_20p) totalMoneyInput += 0.20m;
            else if (droppedCoin == money_50p) totalMoneyInput += 0.50m;
            else if (droppedCoin == money_1GBP) totalMoneyInput += 1.00m;
            else if (droppedCoin == money_2GBP) totalMoneyInput += 2.00m;
            else if (droppedCoin == money_5GBP) totalMoneyInput += 5.00m;
            else if (droppedCoin == money_10GBP) totalMoneyInput += 10.00m;
            else
            {
                errorMessage();
            }
            moneyIn_txtBox.Text = "£" + totalMoneyInput.ToString("F2"); //F2 maintains the output is limited to 2 d.p.
            lastAction = $"Added £{totalMoneyInput:F2}. Total inserted: £{totalMoneyInput:F2}"; // string interpolation
        }
        #endregion

        #region Selection Construction


        private void UpdateListBox()
        {
            main_listBox.Items.Clear();
            // First, add drink items
            foreach (var drink in drinkQuantities.Where(x => x.Value > 0))
            {
                decimal price = drinkPrices[drink.Key];
                decimal itemTotal = price * drink.Value;
                string line = $"{drink.Key} x{drink.Value} - £{itemTotal:F2}";
                main_listBox.Items.Add(line);
            }

            // Add a separator line
            main_listBox.Items.Add("--------------------------------------------");

            // Add total
            main_listBox.Items.Add($"Your total is: £{totalPriceCost:F2}");

            // Add last action at the very end
            main_listBox.Items.Add(lastAction);
        }

        private void SelectionConstructor(string selectionText, int foo)
        {
            if (foo == 0 && !string.IsNullOrEmpty(selectionText))
            {
                drinkQuantities[selectionText]++;
                totalPriceCost += drinkPrices[selectionText];
                lastAction = $"Added 1 {selectionText} to your order.";
                UpdateListBox();
            }
            else if (foo == 1)
            {
                buttonControlEnabled(0, false);
                buttonControlEnabled(1, true);
                lastAction = "Order totaled. Please insert payment.";
            }
        }
        #endregion

        #region Event Actions
        private void btn_Latte_Click(object sender, EventArgs e)
        {
            SelectionConstructor("Latte", 0);
        }

        private void btn_FlatWhite_Click(object sender, EventArgs e)
        {
            SelectionConstructor("Flat White", 0);
        }

        private void btn_Cap_Click(object sender, EventArgs e)
        {
            SelectionConstructor("Cappuccino", 0);
        }

        private void btn_amer_Click(object sender, EventArgs e)
        {
            SelectionConstructor("Americano", 0);
        }

        private void sum_btn_Click(object sender, EventArgs e)
        {
            SelectionConstructor(null, 1);
            sum_btn.Enabled = false;
        }

        private void cancel_but_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("Cancel your order?", "Warning", MessageBoxButtons.YesNo);
            if (Result == DialogResult.Yes)
            {
                resetValues();
            }
            // else not required
        }

        private void payment_but_Click(object sender, EventArgs e)
        {
            if (totalPriceCost > totalMoneyInput)
            {
                decimal remaining = totalPriceCost - totalMoneyInput;
                MessageBox.Show($"Please insert £{remaining:F2} more.");
                lastAction = $"Insufficient funds. Please insert £{remaining:F2} more.";
            }
            else if (totalPriceCost <= totalMoneyInput)
            {
                //allows us to set the template for the receipt .txt file
                totalChange = totalMoneyInput - totalPriceCost;
                MessageBox.Show($"Thank you for your payment! Please take your drink. Your change is: £{totalChange:F2}");
                main_listBox.Items.Add("--------------------------------------------");
                main_listBox.Items.Add($"Total money paid = £{totalMoneyInput:F2}");
                main_listBox.Items.Add("--------------------------------------------");
                main_listBox.Items.Add($"Total Change = £{totalChange:F2}");
                receiptPrinter(main_listBox.Items);
                lastAction = "Payment complete. Thank you for your purchase!";
                resetValues();
            }
            else
            {
                errorMessage();
            }
        }

        private static void receiptPrinter(ListBox.ObjectCollection content) //used for saving the above text to a .txt file
        {
            try
            {
                string currentDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "receipt");
                if (!Directory.Exists(currentDirectory))
                {
                    Directory.CreateDirectory(currentDirectory);
                }

                string date = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
                string filePath = Path.Combine(currentDirectory, date + ".txt");

                File.WriteAllLines(filePath, content.Cast<string>());
                Console.WriteLine($"File successfully written to: {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing file: {ex.Message}");
            }
        }
    }
}
#endregion
