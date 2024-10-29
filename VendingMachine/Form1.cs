using Microsoft.VisualBasic;
using System;
using System.Drawing.Text;
using System.Security.AccessControl;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        // global variables
        private decimal totalPriceCost;
        private int valueTest;
        private decimal totalMoneyInput;
        private decimal totalChange;

        //price list of different drinks
        private Dictionary<string, decimal> drinkPrices = new Dictionary<string, decimal>()
        {
            { "Flat White", 2.25m },
            { "Latte", 2.85m },             
            { "Cappuccino", 3.00m },
            { "Americano", 2.95m }
        }; 

        //error message for when the program falls into a critical state
        private void errorMessage()
        {
            MessageBox.Show("It seems that the vending machine fell into a fatal error. Please restart the machine.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
        }

        //turns off and on the different panels - drink and payment panels
        private void buttonControlEnabled(int i, bool selection)
        // (i = 1) = / (i = 2) = 
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
                errorMessage(); 
            }
        }


        private static void receiptPrinter(string content) 
        {
            try
            {
                string currentDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "receipt");
                // make sure the receipt folder exists - especially if uploading onto different hardware
                if (!Directory.Exists(currentDirectory))
                {
                    Directory.CreateDirectory(currentDirectory);
                }

                string date = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"); // convert to string
             
                string filePath = Path.Combine(currentDirectory, date + ".txt"); //send to debug/net/

                // Write the content to the file
                File.WriteAllText(filePath, content);

                Console.WriteLine($"File successfully written to: {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing file: {ex.Message}");
            }
        }

        


        // resets the value to allow for the next user
        private void resetValues()
        {
            totalMoneyInput = 0; totalPriceCost = 0; main_txtBox.Clear(); moneyIn_txtBox.Clear(); buttonControlEnabled(1, false); buttonControlEnabled(0, true); totalChange = 0;
        }

        #endregion 


        #region Drag and Drop --- Used for the money being deposited inside the cash machine


        //money panel when mouse down input detected
        private void money_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox moneyBox = sender as PictureBox;

            moneyBox.DoDragDrop(moneyBox, DragDropEffects.Copy);

        }

        // payment box allows drag enter to happen
        private void paymentBox_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        // once the item is dragged and dropped the price is increaced here
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
                errorMessage(); // error message
            }
            moneyIn_txtBox.Text = "£" + totalMoneyInput; //displays the amount inserted
        }

        #endregion


        #region Textbox Selection Construction
        // this function is responsible for controling the input on the text box
        private void SelectionConstructor(string selectionText, int foo)
        {
            // this is triggered on a selection of the drinks.
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
            // this is triggered if the total button is pressed.
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
        
        //button click events
        private void btn_Latte_Click(object sender, EventArgs e) //latte
        {
            SelectionConstructor("Latte", 0);
            errorMessage();
        }

        private void btn_FlatWhite_Click(object sender, EventArgs e) //flat white
        {
            SelectionConstructor("Flat White", 0);
        }

        private void btn_Cap_Click(object sender, EventArgs e) // cappucino
        {
            SelectionConstructor("Cappuccino", 0);
        }

        private void btn_amer_Click(object sender, EventArgs e) //americano
        {
            SelectionConstructor("Americano", 0);
        }

        private void sum_btn_Click(object sender, EventArgs e) // total putton
        {
            SelectionConstructor(null, 1);
            sum_btn.Enabled = false;
        }

        private void cancel_but_Click(object sender, EventArgs e) // cancel button
        {
            DialogResult Result = System.Windows.Forms.MessageBox.Show("Cancel your order?", "Warning", MessageBoxButtons.YesNo);

            if (Result == DialogResult.Yes)
            {
                resetValues();
            }
            else 
            {
                // nothing else required
            }
        }

        // payment button even
        private void payment_but_Click(object sender, EventArgs e)
        {
            
            var receiptTemplate = new Action(() =>            {
                System.Windows.Forms.MessageBox.Show("Thank you for your payment! Please take your drink." + ControlChars.NewLine + "Your change is: £" + totalChange);
                main_txtBox.Text += ControlChars.NewLine + "--------------------------------------------";
                main_txtBox.Text += ControlChars.NewLine + "Total money paid = £" + totalMoneyInput;
                main_txtBox.Text += ControlChars.NewLine + "--------------------------------------------";
                main_txtBox.Text += ControlChars.NewLine + "Total Change = £" + totalChange;
             });

            if (totalPriceCost > totalMoneyInput)
            {
                // not enough money
                decimal foo = totalPriceCost - totalMoneyInput;
                System.Windows.Forms.MessageBox.Show("Please insert £" + foo);
            }
            else if (totalPriceCost == totalMoneyInput)
            {
         
                receiptTemplate();
                receiptPrinter(main_txtBox.Text);
                resetValues();
            }
            else if (totalPriceCost < totalMoneyInput)
            {
                totalChange = totalMoneyInput - totalPriceCost;
                receiptTemplate();
                receiptPrinter(main_txtBox.Text);
                resetValues();
            }
            else if (totalMoneyInput == null)
            {
                System.Windows.Forms.MessageBox.Show("Please insert money");
            }
            else
            {
                errorMessage(); // error message
            }
        }
    }
}
#endregion


