using Microsoft.VisualBasic;
using System;
using System.Security.AccessControl;

namespace VendingMachine
{


    public partial class Form1 : Form
    {
        public Form1() //starts the WinForm
        {
            InitializeComponent();
            paymentBox.AllowDrop = true;
            buttonControlEnabled(1, false); // turns off the money box on start up
        }

        #region Public Variables and Data --- Holds all public variables such as drink prices etc.



        double totalPriceCost;
        int valueTest;

        Dictionary<string, double> drinkPrices = new Dictionary<string, double>()
        {
            { "Flat White", 2.25 },
            { "Latte", 2.85 },
            { "Cappuccino", 3.00 },
            { "Americano", 2.95 }
        };

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


            }
            else if (droppedCoin == money_10p)
            {

            }
            else if (droppedCoin == money_20p)
            {

            }
            else if (droppedCoin == money_50p)
            {

            }
            else if (droppedCoin == money_1GBP)
            {

            }
            else if (droppedCoin == money_2GBP)
            {

            }
            else if (droppedCoin == money_5GBP)
            {

            }
            else if (droppedCoin == money_10GBP)
            {

            }
            else
            {
                //ERROR
            }
        }

        #endregion

        #region Selection Construction
        public void SelectionConstructor(string selectionText, int foo)
        {

            if (foo == 0)
            {

                double tempDrinkPrice = drinkPrices[selectionText]; //fetching price of drink also allows us to perform computation of total price
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

        public void buttonControlEnabled(int i, bool selection)
        // drinks = 0; money = 2;
        {
            if (i == 0)
            {
                // this is the drink buttons
                drinkSelectionPanel.Enabled = selection;


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

        private void main_txtBox_TextChanged(object sender, EventArgs e)
        {

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
            sum_btn.Enabled = false; // shuts down the total button
        }

        private void cancel_but_Click(object sender, EventArgs e)
        {
             = System.Windows.Forms.MessageBox.Show("Cancel your order?", "Warning", MessageBoxButtons.YesNo);
            if (mess)
            main_txtBox.Clear();
        }

        private void payment_but_Click(object sender, EventArgs e)
        {

        }
    }
}
#endregion