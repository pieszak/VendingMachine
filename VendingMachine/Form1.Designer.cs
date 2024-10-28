namespace VendingMachine
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            btn_Latte = new Button();
            btn_FlatWhite = new Button();
            main_txtBox = new TextBox();
            sum_btn = new Button();
            btn_amer = new Button();
            btn_Cap = new Button();
            money_5p = new PictureBox();
            money_10p = new PictureBox();
            paymentBox = new PictureBox();
            money_20p = new PictureBox();
            money_1GBP = new PictureBox();
            money_50p = new PictureBox();
            money_5GBP = new PictureBox();
            money_10GBP = new PictureBox();
            money_2GBP = new PictureBox();
            drinkSelectionPanel = new Panel();
            moneyPanel = new Panel();
            label2 = new Label();
            label1 = new Label();
            moneyIn_txtBox = new TextBox();
            payment_but = new Button();
            cancel_but = new Button();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)money_5p).BeginInit();
            ((System.ComponentModel.ISupportInitialize)money_10p).BeginInit();
            ((System.ComponentModel.ISupportInitialize)paymentBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)money_20p).BeginInit();
            ((System.ComponentModel.ISupportInitialize)money_1GBP).BeginInit();
            ((System.ComponentModel.ISupportInitialize)money_50p).BeginInit();
            ((System.ComponentModel.ISupportInitialize)money_5GBP).BeginInit();
            ((System.ComponentModel.ISupportInitialize)money_10GBP).BeginInit();
            ((System.ComponentModel.ISupportInitialize)money_2GBP).BeginInit();
            drinkSelectionPanel.SuspendLayout();
            moneyPanel.SuspendLayout();
            SuspendLayout();
            // 
            // btn_Latte
            // 
            btn_Latte.Location = new Point(0, 83);
            btn_Latte.Name = "btn_Latte";
            btn_Latte.Size = new Size(236, 80);
            btn_Latte.TabIndex = 0;
            btn_Latte.Text = "Latte";
            btn_Latte.UseVisualStyleBackColor = true;
            btn_Latte.Click += btn_Latte_Click;
            // 
            // btn_FlatWhite
            // 
            btn_FlatWhite.Location = new Point(0, 0);
            btn_FlatWhite.Name = "btn_FlatWhite";
            btn_FlatWhite.Size = new Size(236, 77);
            btn_FlatWhite.TabIndex = 1;
            btn_FlatWhite.Text = "Flat White";
            btn_FlatWhite.UseVisualStyleBackColor = true;
            btn_FlatWhite.Click += btn_FlatWhite_Click;
            // 
            // main_txtBox
            // 
            main_txtBox.Location = new Point(785, 159);
            main_txtBox.Multiline = true;
            main_txtBox.Name = "main_txtBox";
            main_txtBox.ReadOnly = true;
            main_txtBox.ScrollBars = ScrollBars.Vertical;
            main_txtBox.Size = new Size(279, 400);
            main_txtBox.TabIndex = 4;
            // 
            // sum_btn
            // 
            sum_btn.Location = new Point(399, 501);
            sum_btn.Name = "sum_btn";
            sum_btn.Size = new Size(118, 58);
            sum_btn.TabIndex = 5;
            sum_btn.Text = "Total";
            sum_btn.UseVisualStyleBackColor = true;
            sum_btn.Click += sum_btn_Click;
            // 
            // btn_amer
            // 
            btn_amer.Location = new Point(0, 256);
            btn_amer.Name = "btn_amer";
            btn_amer.Size = new Size(236, 80);
            btn_amer.TabIndex = 3;
            btn_amer.Text = "Americano";
            btn_amer.UseVisualStyleBackColor = true;
            btn_amer.Click += btn_amer_Click;
            // 
            // btn_Cap
            // 
            btn_Cap.Location = new Point(0, 170);
            btn_Cap.Name = "btn_Cap";
            btn_Cap.Size = new Size(236, 80);
            btn_Cap.TabIndex = 2;
            btn_Cap.Text = "Cappuccino";
            btn_Cap.UseVisualStyleBackColor = true;
            btn_Cap.Click += btn_Cap_Click;
            // 
            // money_5p
            // 
            money_5p.BackgroundImage = Properties.Resources._5p;
            money_5p.BackgroundImageLayout = ImageLayout.Zoom;
            money_5p.Location = new Point(0, 3);
            money_5p.Name = "money_5p";
            money_5p.Size = new Size(102, 95);
            money_5p.TabIndex = 6;
            money_5p.TabStop = false;
            money_5p.MouseDown += money_MouseDown;
            // 
            // money_10p
            // 
            money_10p.BackgroundImage = Properties.Resources.images;
            money_10p.BackgroundImageLayout = ImageLayout.Zoom;
            money_10p.Location = new Point(108, 3);
            money_10p.Name = "money_10p";
            money_10p.Size = new Size(102, 95);
            money_10p.TabIndex = 7;
            money_10p.TabStop = false;
            money_10p.MouseDown += money_MouseDown;
            // 
            // paymentBox
            // 
            paymentBox.BackgroundImage = Properties.Resources.VposTouch_2;
            paymentBox.BackgroundImageLayout = ImageLayout.Zoom;
            paymentBox.Location = new Point(714, 18);
            paymentBox.Name = "paymentBox";
            paymentBox.Size = new Size(136, 186);
            paymentBox.TabIndex = 8;
            paymentBox.TabStop = false;
            paymentBox.DragDrop += paymentBox_DragDrop;
            paymentBox.DragEnter += paymentBox_DragEnter;
            // 
            // money_20p
            // 
            money_20p.BackgroundImage = Properties.Resources._20p;
            money_20p.BackgroundImageLayout = ImageLayout.Zoom;
            money_20p.Location = new Point(216, 3);
            money_20p.Name = "money_20p";
            money_20p.Size = new Size(102, 95);
            money_20p.TabIndex = 9;
            money_20p.TabStop = false;
            money_20p.MouseDown += money_MouseDown;
            // 
            // money_1GBP
            // 
            money_1GBP.BackgroundImage = Properties.Resources._1pound;
            money_1GBP.BackgroundImageLayout = ImageLayout.Zoom;
            money_1GBP.Location = new Point(432, 3);
            money_1GBP.Name = "money_1GBP";
            money_1GBP.Size = new Size(102, 95);
            money_1GBP.TabIndex = 10;
            money_1GBP.TabStop = false;
            money_1GBP.MouseDown += money_MouseDown;
            // 
            // money_50p
            // 
            money_50p.BackgroundImage = Properties.Resources._50p;
            money_50p.BackgroundImageLayout = ImageLayout.Zoom;
            money_50p.Location = new Point(324, 3);
            money_50p.Name = "money_50p";
            money_50p.Size = new Size(102, 95);
            money_50p.TabIndex = 11;
            money_50p.TabStop = false;
            money_50p.MouseDown += money_MouseDown;
            // 
            // money_5GBP
            // 
            money_5GBP.BackgroundImage = Properties.Resources._5pound;
            money_5GBP.BackgroundImageLayout = ImageLayout.Zoom;
            money_5GBP.Location = new Point(200, 104);
            money_5GBP.Name = "money_5GBP";
            money_5GBP.Size = new Size(186, 95);
            money_5GBP.TabIndex = 12;
            money_5GBP.TabStop = false;
            money_5GBP.MouseDown += money_MouseDown;
            // 
            // money_10GBP
            // 
            money_10GBP.BackgroundImage = Properties.Resources._10pound;
            money_10GBP.BackgroundImageLayout = ImageLayout.Zoom;
            money_10GBP.Location = new Point(0, 104);
            money_10GBP.Name = "money_10GBP";
            money_10GBP.Size = new Size(194, 95);
            money_10GBP.TabIndex = 13;
            money_10GBP.TabStop = false;
            money_10GBP.MouseDown += money_MouseDown;
            // 
            // money_2GBP
            // 
            money_2GBP.BackgroundImage = Properties.Resources._2pound;
            money_2GBP.BackgroundImageLayout = ImageLayout.Zoom;
            money_2GBP.Location = new Point(403, 104);
            money_2GBP.Name = "money_2GBP";
            money_2GBP.Size = new Size(102, 95);
            money_2GBP.TabIndex = 14;
            money_2GBP.TabStop = false;
            money_2GBP.MouseDown += money_MouseDown;
            // 
            // drinkSelectionPanel
            // 
            drinkSelectionPanel.BackColor = Color.Transparent;
            drinkSelectionPanel.Controls.Add(btn_Latte);
            drinkSelectionPanel.Controls.Add(btn_FlatWhite);
            drinkSelectionPanel.Controls.Add(btn_Cap);
            drinkSelectionPanel.Controls.Add(btn_amer);
            drinkSelectionPanel.Location = new Point(399, 159);
            drinkSelectionPanel.Name = "drinkSelectionPanel";
            drinkSelectionPanel.Size = new Size(242, 336);
            drinkSelectionPanel.TabIndex = 15;
            // 
            // moneyPanel
            // 
            moneyPanel.Controls.Add(label2);
            moneyPanel.Controls.Add(label1);
            moneyPanel.Controls.Add(moneyIn_txtBox);
            moneyPanel.Controls.Add(payment_but);
            moneyPanel.Controls.Add(money_20p);
            moneyPanel.Controls.Add(money_5p);
            moneyPanel.Controls.Add(money_2GBP);
            moneyPanel.Controls.Add(money_10p);
            moneyPanel.Controls.Add(money_10GBP);
            moneyPanel.Controls.Add(paymentBox);
            moneyPanel.Controls.Add(money_1GBP);
            moneyPanel.Controls.Add(money_5GBP);
            moneyPanel.Controls.Add(money_50p);
            moneyPanel.Location = new Point(111, 601);
            moneyPanel.Name = "moneyPanel";
            moneyPanel.Size = new Size(864, 207);
            moneyPanel.TabIndex = 16;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(571, 149);
            label2.Name = "label2";
            label2.Size = new Size(77, 20);
            label2.TabIndex = 21;
            label2.Text = "Total Paid:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(555, 13);
            label1.Name = "label1";
            label1.Size = new Size(153, 80);
            label1.TabIndex = 20;
            label1.Text = "Please drag money to\r\nthe payment machine\r\nthen click Pay to \r\ncomplete your order!";
            // 
            // moneyIn_txtBox
            // 
            moneyIn_txtBox.Location = new Point(571, 172);
            moneyIn_txtBox.Name = "moneyIn_txtBox";
            moneyIn_txtBox.Size = new Size(118, 27);
            moneyIn_txtBox.TabIndex = 19;
            // 
            // payment_but
            // 
            payment_but.Location = new Point(571, 104);
            payment_but.Name = "payment_but";
            payment_but.Size = new Size(118, 42);
            payment_but.TabIndex = 18;
            payment_but.Text = "Pay";
            payment_but.UseVisualStyleBackColor = true;
            payment_but.Click += payment_but_Click;
            // 
            // cancel_but
            // 
            cancel_but.Location = new Point(523, 501);
            cancel_but.Name = "cancel_but";
            cancel_but.Size = new Size(112, 58);
            cancel_but.TabIndex = 17;
            cancel_but.Text = "Cancel";
            cancel_but.UseVisualStyleBackColor = true;
            cancel_but.Click += cancel_but_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 159);
            label3.Name = "label3";
            label3.Size = new Size(205, 420);
            label3.TabIndex = 18;
            label3.Text = resources.GetString("label3.Text");
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.B1rVJKqs;
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(1086, 820);
            Controls.Add(label3);
            Controls.Add(cancel_but);
            Controls.Add(moneyPanel);
            Controls.Add(drinkSelectionPanel);
            Controls.Add(sum_btn);
            Controls.Add(main_txtBox);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)money_5p).EndInit();
            ((System.ComponentModel.ISupportInitialize)money_10p).EndInit();
            ((System.ComponentModel.ISupportInitialize)paymentBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)money_20p).EndInit();
            ((System.ComponentModel.ISupportInitialize)money_1GBP).EndInit();
            ((System.ComponentModel.ISupportInitialize)money_50p).EndInit();
            ((System.ComponentModel.ISupportInitialize)money_5GBP).EndInit();
            ((System.ComponentModel.ISupportInitialize)money_10GBP).EndInit();
            ((System.ComponentModel.ISupportInitialize)money_2GBP).EndInit();
            drinkSelectionPanel.ResumeLayout(false);
            moneyPanel.ResumeLayout(false);
            moneyPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_Latte;
        private Button btn_FlatWhite;
        private TextBox main_txtBox;
        private Button sum_btn;
        private Button btn_amer;
        private Button btn_Cap;
        private PictureBox money_5p;
        private PictureBox money_10p;
        private PictureBox paymentBox;
        private PictureBox money_20p;
        private PictureBox money_1GBP;
        private PictureBox money_50p;
        private PictureBox money_5GBP;
        private PictureBox money_10GBP;
        private PictureBox money_2GBP;
        private Panel drinkSelectionPanel;
        private Panel moneyPanel;
        private Button payment_but;
        private Button cancel_but;
        private TextBox moneyIn_txtBox;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}
