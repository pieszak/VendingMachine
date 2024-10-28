using Microsoft.VisualBasic;
using System;
using System.Drawing.Text;
using System.Security.AccessControl;

namespace VendingMachine
{
    public partial class Form1 : Form
    {
        public Form1() //starts the WinForm
        {
            InitializeComponent();
            paymentBox.AllowDrop = true;
            buttonControlEnabled(1, false); // turns off the money box on start up -- ISSUE NEED TO FIX THE PHOTOS ARE NOT TURNING GREY
        }

        #region Public Variables and Data --- Holds all public variables such as drink prices etc.

        decimal totalPriceCost;
        int valueTest;
        decimal totalMoneyInput;

        Dictionary<string, decimal> drinkPrices = new Dictionary<string, decimal>()
        {
            { "Flat White", 2.25m },
            { "Latte", 2.85m },
            { "Cappuccino", 3.00m },
            { "Americano", 2.95m }
        };

        public void buttonControlEnabled(int i, bool selection)
        // drinks = 0; money = 2;
        {
            if (i == 0)
            {
                // this is the drink buttons
                drinkSelectionPanel.Enabled = selection;
                sum_btn.Enabled = true;
            }
            else if (i == 1)
            {
                moneyPanel.Enabled = selection;
                
            }
            else
            {
                //ERROR HANDLING
            }
        }

        public static void WriteAllText(string content) //this works
        {
            try
            {
                // Get the current directory where the program is running
                string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;


                // Create a path for the text file in the internal folder
                string filePath = Path.Combine(currentDirectory, DateTime.Now + ".txt"); //send to debug/net/

                // Write the content to the file
                File.WriteAllText(filePath, content);

                Console.WriteLine($"File successfully written to: {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing file: {ex.Message}");
            }
        }

        



        public void resetValues()
        {
            totalMoneyInput = 0; totalPriceCost = 0; main_txtBox.Clear(); moneyIn_txtBox.Clear(); buttonControlEnabled(1, false); buttonControlEnabled(0, true);
        }

        #endregion 


        #region Drag and Drop --- Used for the money being deposited inside the cash machine


        private void money_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox moneyBox = sender as PictureBox;

            moneyBox.DoDragDrop(moneyBox, DragDropEffects.Copy);

        }

        private void paymentBox_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }


        private void paymentBox_DragDrop(object sender, DragEventArgs e)
        {
            PictureBox droppedCoin = e.Data.GetData(typeof(PictureBox)) as PictureBox;

            if (droppedCoin == money_5p)
            {
                totalMoneyInput += .05m;
            }
            else if (droppedCoin == money_10p)
            {
                totalMoneyInput += 0.10m;
            }
            else if (droppedCoin == money_20p)
            {
                totalMoneyInput += 0.20m;
            }
            else if (droppedCoin == money_50p)
            {
                totalMoneyInput += 0.50m;
            }
            else if (droppedCoin == money_1GBP)
            {
                totalMoneyInput += 1.00m;
            }
            else if (droppedCoin == money_2GBP)
            {
                totalMoneyInput += 2.00m;
            }
            else if (droppedCoin == money_5GBP)
            {
                totalMoneyInput += 5.00m;
            }
            else if (droppedCoin == money_10GBP)
            {
                totalMoneyInput += 10.00m;
            }
            else
            {
                //ERROR
            }
            // main_txtBox.Text = selectionText + " - £" + str_tempDrinkPrice + ControlChars.NewLine;
            moneyIn_txtBox.Text = "£" + totalMoneyInput;
        }

        #endregion
        // payment works. just need to fix the payment button

        #region Textbox Selection Construction
        public void SelectionConstructor(string selectionText, int foo)
        {

            if (foo == 0)
            {

                decimal tempDrinkPrice = drinkPrices[selectionText]; //fetching price of drink also allows us to perform computation of total price
                totalPriceCost = totalPriceCost + tempDrinkPrice; //sum of the cost of the order

                string str_tempDrinkPrice = tempDrinkPrice.ToString("F2"); // converting to string -- F2 makes sure 2 d.p are always displayed as "ToString" usually cuts off 0's

                if (main_txtBox.Text == null)
                {
                    main_txtBox.Text = selectionText + " - £" + str_tempDrinkPrice + ControlChars.NewLine;
                }
                else
                {
                    main_txtBox.Text = main_txtBox.Text + selectionText + " - £" + str_tempDrinkPrice + ControlChars.NewLine;
                }
            }
            else if (foo == 1)
            {
                string tempTotalPriceCost = totalPriceCost.ToString("F2");

                main_txtBox.Text = main_txtBox.Text + "Your total is: £" + tempTotalPriceCost;

                // Disables the buttons as per the assingment
                buttonControlEnabled(0, false); //turns off the drinks selection
                buttonControlEnabled(1, true); // turns on the money box
            }
        }
        #endregion



        #region Event Actions
        //-------------------------------------------------------------------------------------------------------------------------
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

        private void sum_btn_Click(object sender, EventArgs e) // this is the total button
        {
            SelectionConstructor(null, 1);
            sum_btn.Enabled = false;
        }

        private void cancel_but_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("Cancel your order?", "Warning", MessageBoxButtons.YesNo);
            resetValues();
            
        }

        private void payment_but_Click(object sender, EventArgs e)
        {

            if (totalPriceCost > totalMoneyInput)
            {
                // not enough money
                decimal foo = totalPriceCost - totalMoneyInput;
                System.Windows.Forms.MessageBox.Show("Please insert £" + foo);
            }
            else if (totalPriceCost == totalPriceCost)
            {
                System.Windows.Forms.MessageBox.Show("Thank you for your payment! Please take your drink");
                
                WriteAllText(main_txtBox.Text);
                resetValues();
            }
            else if (totalPriceCost < totalMoneyInput)
            {
                // PROCESS PAYMENT - calculate difference and return change then reset
            }
            else if (totalMoneyInput == null)
            {
                System.Windows.Forms.MessageBox.Show("Please insert money");
            }
        }
    }
}
#endregion