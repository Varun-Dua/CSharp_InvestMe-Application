/* Student Name: Varun Dua
 * Student ID: 19230587
 * Date: 13/11/2019
 * Assignment: 4
 * Assignment: Your client MyMoney Bank Corp is a financial services company that offers various investment
 * products to its customers. One of these is a medium-term investment product called ‘InvestMe’, in
 * which a client invests a principal sum of money and receive returns depending on the amount and
 * duration of the Investment (terms ranging from 1 to 10 years). Your company has been commissioned
 * to create a well-designed application for bank employees to process client transactions for this
 * product.
*/


using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dua_Varun_Assignment4_MS806
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
         /*Form Load*/
        private void Form1_Load(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Enabled = false;
            InformationPanel.Enabled = false;
            DetailPanel.Enabled = false;
            SummaryPanel.Visible = false;
            SearchPanel.Visible = false;
        }
        /*Field varibales for Display, Confirm and WriteToFile methoods*/
        int TermPeriod;
        decimal IntRate;
        String CustomerName;
        String Telephone;
        String EmailId;
        decimal Principal;
        long TransactionNumber;
        decimal Amount = 0;
        int RateFlag = 0;

        /*Interest Rate Card*/
        const decimal LOWERRATE1 = 0.50000m;
        const decimal LOWERRATE3 = 0.62500m;
        const decimal LOWERRATE5 = 0.71250m;
        const decimal LOWERRATE10 = 1.01250m;
        const decimal HIGHERRATE1 = 0.60000m;
        const decimal HIGHERRATE3 = 0.72500m;
        const decimal HIGHERRATE5 = 0.81250m;
        const decimal HIGHERRATE10 = 1.02500m;

        /*Display Button Event handler*/
        private void DisplayButton_Click(object sender, EventArgs e)
        {
            try
            {
                Principal = Decimal.Parse(DisplayTextBox.Text.ToString());
                ProceedButton.Enabled = true;
                SummaryPanel.Visible = false;
                SearchPanel.Visible = false;
                InformationPanel.Visible = true;
                TermPanel.Visible = true;
                DetailPanel.Visible = true;
                splitContainer1.Panel2.Enabled = true;
                TermView.Items.Clear();
                /*Checking the investment amount and deciding the corresponding interest rate to be applied.*/
                if (Principal < 250000)
                {
                    TermView.Items.Add(AddItem(1, Principal, LOWERRATE1));
                    TermView.Items.Add(AddItem(3, Principal, LOWERRATE3));
                    TermView.Items.Add(AddItem(5, Principal, LOWERRATE5));
                    TermView.Items.Add(AddItem(10, Principal, LOWERRATE10));

                    RateFlag = 1;
                }
                else if (Principal > 250000 && Principal < 1000000)
                {
                    TermView.Items.Add(AddItem(1, Principal, HIGHERRATE1));
                    TermView.Items.Add(AddItem(3, Principal, HIGHERRATE3));
                    TermView.Items.Add(AddItem(5, Principal, HIGHERRATE5));
                    TermView.Items.Add(AddItem(10, Principal, HIGHERRATE10));

                    RateFlag = 2;
                }
                else
                {
                    TermView.Items.Add(AddItem(1, Principal, HIGHERRATE1));
                    TermView.Items.Add(AddItemAndBonus(3, Principal, HIGHERRATE3));
                    TermView.Items.Add(AddItemAndBonus(5, Principal, HIGHERRATE5));
                    TermView.Items.Add(AddItemAndBonus(10, Principal, HIGHERRATE10));

                    RateFlag = 3;
                }
                TermView.Select();
            }
            /*If no Princicpal is input.*/
            catch(Exception)           
            {
                DisplayTextBox.Select();
                DisplayTextBox.SelectAll();
                MessageBox.Show("Please input a Valid Principal Amount", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }
            
            
        }

        /*Method to calculate the Balance Amount on the investment.*/
        private decimal CalculateBalance(int T, decimal P, decimal R)
        {
            decimal A;
            A = (decimal)((double)P * Math.Pow((double)(1 + (R / 1200)), 12 * T));
            return A;                          
        }

        /*Method to Add Items to a list - TermViewList*/
        private ListViewItem AddItem(int T, decimal P, decimal R)
        {
            ListViewItem Item = new ListViewItem(T.ToString());
            Item.SubItems.Add(R.ToString());
            Item.SubItems.Add(CalculateBalance(T, P, R).ToString("C"));
            return Item;
        }

        /*Method to Add Items(with bonus) to a list - TermViewList*/
        private ListViewItem AddItemAndBonus(int T, decimal P, decimal R)
        {
            ListViewItem Item = new ListViewItem(T.ToString());
            Item.SubItems.Add(R.ToString());
            Item.SubItems.Add((CalculateBalance(T, P, R) + 25000).ToString("C"));
            return Item;
        }

        /*Proceed Button Event handler*/
        private void ProceedButton_Click(object sender, EventArgs e)
        {
            if(TermView.SelectedItems.Count > 0 )
            {
                if (RateFlag == 1)
                {
                    foreach (var item in TermView.SelectedIndices)
                    {
                        switch (item)
                        {
                            case 0:
                                TermPeriod = 1;
                                Amount = CalculateBalance(1, Principal, LOWERRATE1);
                                DetailTermLabel.Text = Principal + " -- " + TermPeriod.ToString();
                                IntRate = LOWERRATE1;
                                DetailInterestLabel.Text = LOWERRATE1.ToString();
                                DetailBalanceLabel.Text = Amount.ToString("C");
                                break;
                            case 1:
                                TermPeriod = 3;
                                Amount = CalculateBalance(3, Principal, LOWERRATE3);
                                DetailTermLabel.Text = Principal + " -- " + TermPeriod.ToString();
                                IntRate = LOWERRATE3;
                                DetailInterestLabel.Text = LOWERRATE3.ToString();
                                DetailBalanceLabel.Text = Amount.ToString("C");
                                break;
                            case 2:
                                TermPeriod = 5;
                                Amount = CalculateBalance(5, Principal, LOWERRATE5);
                                DetailTermLabel.Text = Principal + " -- " + TermPeriod.ToString();
                                IntRate = LOWERRATE5;
                                DetailInterestLabel.Text = LOWERRATE5.ToString();
                                DetailBalanceLabel.Text = Amount.ToString("C");
                                break;
                            case 3:
                                TermPeriod = 10;
                                Amount = CalculateBalance(10, Principal, LOWERRATE10);
                                DetailTermLabel.Text = Principal + " -- " + TermPeriod.ToString();
                                IntRate = LOWERRATE10;
                                DetailInterestLabel.Text = LOWERRATE10.ToString();
                                DetailBalanceLabel.Text = Amount.ToString("C");
                                break;
                            
                        }
                    }
                }
                else if (RateFlag == 2)
                {
                    foreach (var item in TermView.SelectedIndices)
                    {
                        switch (item)
                        {
                            case 0:
                                TermPeriod = 1;
                                Amount = CalculateBalance(1, Principal, HIGHERRATE1);
                                DetailTermLabel.Text = Principal + " -- " + TermPeriod.ToString();
                                IntRate = HIGHERRATE1;
                                DetailInterestLabel.Text = HIGHERRATE1.ToString();
                                DetailBalanceLabel.Text = Amount.ToString("C");
                                break;
                            case 1:
                                TermPeriod = 3;
                                Amount = CalculateBalance(3, Principal, HIGHERRATE3);
                                DetailTermLabel.Text = Principal + " -- " + TermPeriod.ToString();
                                IntRate = HIGHERRATE3;
                                DetailInterestLabel.Text = HIGHERRATE3.ToString();
                                DetailBalanceLabel.Text = Amount.ToString("C");
                                break;
                            case 2:
                                TermPeriod = 5;
                                Amount = CalculateBalance(5, Principal, HIGHERRATE5);
                                DetailTermLabel.Text = Principal + " -- " + TermPeriod.ToString();
                                IntRate = HIGHERRATE5;
                                DetailInterestLabel.Text = HIGHERRATE5.ToString();
                                DetailBalanceLabel.Text = Amount.ToString("C");
                                break;
                            case 3:
                                TermPeriod = 10;
                                Amount = CalculateBalance(10, Principal, HIGHERRATE10);
                                DetailTermLabel.Text = Principal + " -- " + TermPeriod.ToString();
                                IntRate = HIGHERRATE10;
                                DetailInterestLabel.Text = HIGHERRATE10.ToString();
                                DetailBalanceLabel.Text = Amount.ToString("C");
                                break;
                            
                        }
                    }
                }
                else if (RateFlag == 3)
                {
                    foreach (var item in TermView.SelectedIndices)
                    {
                        switch (item)
                        {
                            case 0:
                                TermPeriod = 1;
                                Amount = CalculateBalance(1, Principal, HIGHERRATE1);
                                DetailTermLabel.Text = Principal + " -- " + TermPeriod.ToString();
                                IntRate = HIGHERRATE1;
                                DetailInterestLabel.Text = HIGHERRATE1.ToString();
                                DetailBalanceLabel.Text = Amount.ToString("C");
                                break;
                            case 1:
                                TermPeriod = 3;
                                Amount = CalculateBalance(3, Principal, HIGHERRATE3) + 25000;
                                DetailTermLabel.Text = Principal + " -- " + TermPeriod.ToString();
                                IntRate = HIGHERRATE3;
                                DetailInterestLabel.Text = HIGHERRATE3.ToString();
                                DetailBalanceLabel.Text = Amount.ToString("C");
                                break;
                            case 2:
                                TermPeriod = 5;
                                Amount = CalculateBalance(5, Principal, HIGHERRATE5) + 25000;
                                DetailTermLabel.Text = Principal + " -- " + TermPeriod.ToString();
                                IntRate = HIGHERRATE5;
                                DetailInterestLabel.Text = HIGHERRATE5.ToString();
                                DetailBalanceLabel.Text = Amount.ToString("C");
                                break;
                            case 3:
                                TermPeriod = 10;
                                Amount = CalculateBalance(10, Principal, HIGHERRATE10) + 25000;
                                DetailTermLabel.Text = Principal + " -- " + TermPeriod.ToString();
                                IntRate = HIGHERRATE10;
                                DetailInterestLabel.Text = HIGHERRATE10.ToString();
                                DetailBalanceLabel.Text = Amount.ToString("C");
                                break;
                           
                        }
                    }
                }
                InformationPanel.Enabled = true;
                /*Checking if the Random number generated for Transaction is unique from the text file.*/
                Random number = new Random();
                int RandomFlag=0;
                if (File.Exists(@"C: \Users\Varun Dua\source\repos\Dua_Varun_Assignment4_MS806\Dua_Varun_Assignment4_MS806\bin\Debug\InvestMeData.txt"))
                {                    
                    StreamReader InputFile;
                    InputFile = File.OpenText(@"C: \Users\Varun Dua\source\repos\Dua_Varun_Assignment4_MS806\Dua_Varun_Assignment4_MS806\bin\Debug\InvestMeData.txt");
                    do
                    {
                        TransactionNumber = number.Next(100000, 999999);
                        RandomFlag = 0;
                        while (!InputFile.EndOfStream)
                        {                          

                            for (int j = 0; j <= 7; j++)
                            {
                                String Read = InputFile.ReadLine();
                                if (j == 0)
                                {
                                    if (long.Parse(Read) == TransactionNumber)
                                    {
                                        RandomFlag = 1;
                                    }
                                }
                            }

                        } 
                    } while (RandomFlag == 1) ;
                }
                else
                {
                    TransactionNumber = number.Next(100000, 999999);
                } 
                

                TransactionNumberLabel.Text = TransactionNumber.ToString();                
                TermPanel.Enabled = false;                
                splitContainer1.Panel1.Enabled = false;
            }
            else
            {
                MessageBox.Show("Please select a Term", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }         


        }

        /*Confirm button event handler.*/
        private void ConfirmButton_Click(object sender, EventArgs e)
        {                        
            CustomerName = NameTextBox.Text;
            Telephone = TelephoneTextBox.Text;
            EmailId = EmailTextBox.Text;
            
            
            if(ValidateInfo() == 0)
            {
                InformationPanel.Enabled = false;
                TermPanel.Enabled = false;
                DetailPanel.Enabled = true;
                DetailNameLabel.Text = CustomerName;
                DetailTelephoneLabel.Text = Telephone;
                DetailEmailLabel.Text = EmailId;
                DetailTransactionLabel.Text = TransactionNumber.ToString();

                String Confirm = String.Format("Confirm Investment? Please check complete details before clicking OK. \nName: {0} \nTransaction: {1} \nEmailId: {2} \nBalance {3:C} \nTerm: {4} \nInvestment: {5} \nTelephone: {6} \nInterest Rate {7}", CustomerName, TransactionNumber, EmailId, Amount, TermPeriod, Principal, Telephone, IntRate);

                /*Dialog box to get final confirmation.*/
                DialogResult result = MessageBox.Show(Confirm, "Confirm Investment?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    WriteToFile();
                    ClearStream();
                    ClearPanel2();
                    splitContainer1.Panel2.Enabled = false;
                    TermPanel.Enabled = true;
                    InformationPanel.Enabled = false;
                    DetailPanel.Enabled = false;
                    splitContainer1.Panel1.Enabled = true;
                    DisplayTextBox.Clear();
                }
                else
                {
                    DetailTermLabel.Text = "";
                    DetailBalanceLabel.Text = "";
                    DetailEmailLabel.Text = "";
                    DetailInterestLabel.Text = "";
                    DetailNameLabel.Text = "";
                    DetailTelephoneLabel.Text = "";
                    DetailTransactionLabel.Text = "";
                    DetailPanel.Enabled = false;
                    TermPanel.Enabled = true;
                    InformationPanel.Enabled = false;
                    splitContainer1.Panel1.Enabled = true;
                }
            }
            else if(ValidateInfo() == 1)
            {
                NameTextBox.Select();
                NameTextBox.SelectAll();
                MessageBox.Show("Please enter a valid Name", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                               
            }
            else if (ValidateInfo() == 2)
            {
                TelephoneTextBox.Select();
                TelephoneTextBox.SelectAll();
                MessageBox.Show("Please enter a valid 10 digit Phone Number", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                
            }
            else if (ValidateInfo() == 3)
            {
                EmailTextBox.Select();
                EmailTextBox.SelectAll();
                MessageBox.Show("Please enter a valid Email Id", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                
            }

            

        }

        /*Method to validate data input by the user.*/
        private int ValidateInfo()
        {
            if (CustomerName.Length == 0)
            {
                return 1;
            }
            else if (Telephone.Length != 10)
            {
                return 2;
            }
            else if (EmailId.Contains("@") != true || EmailId.Contains(".") != true)
            {
                return 3;
            }
            else
            {
                return 0;
            }                                                             
        }

        /*Method to write data to file.*/
        private void WriteToFile()
        {
            
            if (File.Exists(@"C:\Users\Varun Dua\source\repos\Dua_Varun_Assignment4_MS806\Dua_Varun_Assignment4_MS806\bin\Debug\InvestMeData.txt") != true) 
            {
                StreamWriter CreateFile;
                CreateFile = File.CreateText("InvestMeData.txt");
                CreateFile.Close();
            }

            StreamWriter OutputFile;
            OutputFile = File.AppendText("InvestMeData.txt");
            OutputFile.WriteLine(TransactionNumber);
            OutputFile.WriteLine(EmailId);
            OutputFile.WriteLine(CustomerName);
            OutputFile.WriteLine(Telephone);
            OutputFile.WriteLine(Principal);
            OutputFile.WriteLine(TermPeriod);
            OutputFile.WriteLine(IntRate);
            OutputFile.WriteLine(Amount);
            OutputFile.Close();
        }

        /*Method to clear field variables*/
        private void ClearStream ()
        {
            TransactionNumber = 0;
            EmailId = "";
            CustomerName = "";
            Telephone = "";
            Principal = 0;
            IntRate = 0;
            Amount = 0;
        }


        /*method to clear labels and textboxes on the panel 2*/
        private void ClearPanel2()
        {
            TransactionNumberLabel.Text = "";
            NameTextBox.Clear();
            TelephoneTextBox.Clear();
            EmailTextBox.Clear();
            DetailTermLabel.Text = "";
            DetailBalanceLabel.Text = "";
            DetailEmailLabel.Text = "";
            DetailInterestLabel.Text = "";
            DetailNameLabel.Text = "";
            DetailTelephoneLabel.Text = "";
            DetailTransactionLabel.Text = "";
            TermView.Items.Clear();
        }

        /*Cancel button event handler.*/
        private void CancelButton_Click(object sender, EventArgs e)
        {
            ClearStream();
            ClearPanel2();
            splitContainer1.Panel2.Enabled = false;
            TermPanel.Enabled = true;
            InformationPanel.Enabled = false;
            DetailPanel.Enabled = false;
            splitContainer1.Panel1.Enabled = true;
            DisplayTextBox.Clear();
        }

        /*Event handler in case the text in textbox for investment data is changed*/
        private void DisplayTextBox_TextChanged(object sender, EventArgs e)
        {
            TermView.Items.Clear();
            ProceedButton.Enabled = false;
            
        }

        /*Summary button event handler*/
        private void SummaryButton_Click(object sender, EventArgs e)
        {
            DisplayTextBox.Text = "";
            SearchPanel.Visible = false;
            InformationPanel.Visible = false;
            TermPanel.Visible = false;
            DetailPanel.Visible = false;
            TransactionBox.Items.Clear();
            int i=0;
            decimal SumOfPrincipal=0;
            int SumOfTerms = 0;
            decimal AverageTerm;
            decimal SumOfAmount = 0;
            decimal InterestAccrued;
            splitContainer1.Panel2.Enabled = true;
            SummaryPanel.Visible = true;
            
            if(File.Exists(@"C: \Users\Varun Dua\source\repos\Dua_Varun_Assignment4_MS806\Dua_Varun_Assignment4_MS806\bin\Debug\InvestMeData.txt"))
            {
                StreamReader InputFile;
                InputFile = File.OpenText(@"C: \Users\Varun Dua\source\repos\Dua_Varun_Assignment4_MS806\Dua_Varun_Assignment4_MS806\bin\Debug\InvestMeData.txt");
                while (!InputFile.EndOfStream)
                {

                    for (int j = 0; j <= 7; j++)
                    {
                        String Read = InputFile.ReadLine();
                        if (j == 0)
                        {
                            TransactionBox.Items.Add(Read);
                        }
                        else if (j == 4)
                        {
                            SumOfPrincipal += Decimal.Parse(Read);
                        }
                        else if (j == 5)
                        {
                            SumOfTerms += int.Parse(Read);
                        }
                        else if (j == 7)
                        {
                            SumOfAmount += decimal.Parse(Read);
                        }

                    }
                    i++;
                }
                SummaryLabel1.Text = "Total Investments:" + SumOfPrincipal.ToString("C");
                AverageTerm = SumOfTerms / (decimal)i;
                SummaryLabel2.Text = "Average Duration of Terms:" + AverageTerm.ToString();
                InterestAccrued = SumOfAmount - SumOfPrincipal;
                SummaryLabel3.Text = "Interest Accruing:" + InterestAccrued.ToString("C");
                InputFile.Close();
            }
            
            
        }

        /*Search button event handler.*/
        private void SearchButton_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Enabled = true;
            SummaryPanel.Visible = true;
            SearchPanel.Visible = true;
            SearchView.Enabled = true;
            SearchView.Items.Clear();
            if (File.Exists(@"C: \Users\Varun Dua\source\repos\Dua_Varun_Assignment4_MS806\Dua_Varun_Assignment4_MS806\bin\Debug\InvestMeData.txt"))
            {
                StreamReader InputFile;
                InputFile = File.OpenText(@"C: \Users\Varun Dua\source\repos\Dua_Varun_Assignment4_MS806\Dua_Varun_Assignment4_MS806\bin\Debug\InvestMeData.txt");
                while (!InputFile.EndOfStream)
                {
                    string SearchItem = SearchTextBox.Text;
                    int SearchStyle = 0;
                    int ItemFoundFlag = 0;
                    ListViewItem Item = new ListViewItem();
                    if (SearchItem.Contains("@"))
                    {
                        SearchStyle = 1;
                    }
                    for (int j = 0; j <= 7; j++)
                    {

                        String Read = InputFile.ReadLine();

                        if (j == 0)
                        {
                            Item = new ListViewItem(Read);
                            if (SearchItem == Read)
                            {

                                ItemFoundFlag = 1;
                            }
                        }
                        else if (SearchStyle == 1 && j == 1)
                        {
                            if (SearchItem == Read)
                            {
                                ItemFoundFlag = 1;
                            }
                        }
                        if (ItemFoundFlag == 1 && j > 0)
                        {

                            if (j == 4 || j == 7)
                            {
                                decimal Currency = decimal.Parse(Read);
                                Item.SubItems.Add(Currency.ToString("C"));
                            }
                            else
                            {
                                Item.SubItems.Add(Read);
                            }
                        }

                    }
                    if (ItemFoundFlag == 1)
                    {
                        SearchView.Items.Add(Item);
                    }


                }
                InputFile.Close();
            }
            
            SearchTextBox.Clear();
            DisplayTextBox.Clear();
            SearchView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize); //Autosize the ListView.
        }
         /*Clear button event handler*/
        private void ClearButton_Click(object sender, EventArgs e)
        {
            DisplayTextBox.Clear();
            SearchTextBox.Clear();
        }

        /*Exit button evvent handler*/
        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
