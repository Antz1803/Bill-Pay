namespace MancillaBillPay
{
    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();
        }


        double Bill, BillPer, SubTotal, TipAmount, TipAmountPer;
        private int personCountOne = 1;
        private void txtbillOne_Completed(object sender, EventArgs e)
        {
            UpdateBillCalculations();
        }

        private void tipsCustomizes_Completed(object sender, EventArgs e)
        {
            UpdateBillCalculations();
        }

        // This method updates bill calculations based on the current values
        private void UpdateBillCalculations()
        {
            if (personCountOne > 0 && double.TryParse(txtBillone.Text, out Bill) && double.TryParse(TipCustomizes.Text, out double customTip))
            {
                TipAmount = customTip / 100;
                TipAmountPer = (Bill * TipAmount) / personCountOne;
                SubTotal = Bill / personCountOne;
                BillPer = TipAmountPer + SubTotal;

                lblTipPerPerson.Text = $"₱{TipAmountPer.ToString("n2")}";
                lblSubtotal.Text = $"₱{SubTotal.ToString("n2")}";
                lblTotal.Text = $"₱{BillPer.ToString("n2")}";
            }
        }

        private void OnIncrementClicked(object sender, EventArgs e)
        {
            if (int.TryParse(PersonCountLabelOne.Text, out personCountOne))
            {
                personCountOne++;
                PersonCountLabelOne.Text = personCountOne.ToString();
                UpdateBillCalculations();
            }
        }

        private void OnDecrementClicked(object sender, EventArgs e)
        {
            if (int.TryParse(PersonCountLabelOne.Text, out personCountOne) && personCountOne > 1) // Ensure at least one person
            {
                personCountOne--;
                PersonCountLabelOne.Text = personCountOne.ToString();
                UpdateBillCalculations();
            }
        }


        #region Button can navigate the Customize Tip and Automated Tip
        private void OnCustomize(object sender, EventArgs e)
        {
            CustomizeTip.IsVisible = true;
            AutomatedTip.IsVisible = false;

            txtBillone.Text = null;
            txtBilltwo.Text = null;
            TipCustomizes.Text = null;
            sldTip.Value = 0;
            lblTipPerPerson.Text = null;
            lblSubtotal.Text = null;
            lblTotal.Text = null;
            PersonCountLabelOne.Text = (1).ToString();
        }

        private void OnAutomated(object sender, EventArgs e)
        {
            AutomatedTip.IsVisible = true;
            CustomizeTip.IsVisible = false;

            txtBillone.Text = null;
            txtBilltwo.Text = null;
            sldTip.Value = 0;
            lblTipPerPerson.Text = null;
            lblSubtotal.Text = null;
            lblTotal.Text = null;
            PersonCountLabelTwo.Text = (1).ToString();
        }
        #endregion


        #region Automated calculation

        private void txtBilltwo_Completed(object sender, EventArgs e)
        {
            Bill = Convert.ToDouble(txtBilltwo.Text);
            TipAmount = sldTip.Value / 100;
            TipAmountPer = Bill * TipAmount;
            SubTotal = (Bill / personCountTwo);
            BillPer = SubTotal;

            SharePerson.Text = $"₱{((Bill + TipAmountPer) / double.Parse(PersonCountLabelTwo.Text)).ToString("N2")}";
            lblTipPerPerson.Text = $"₱{TipAmountPer.ToString("n2")}";
            lblSubtotal.Text = $"₱{SubTotal.ToString("n2")}";
            lblTotal.Text = $"₱{BillPer.ToString("n2")}";
        }

        private void sldTip_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            TipAmountPer = Convert.ToInt32(sldTip.Value);
            TipAmount = sldTip.Value / 100;
            TipAmountPer = Bill * TipAmount;
       
            BillPer = TipAmountPer + Bill;
            SharePerson.Text = $"₱{((Bill + TipAmountPer) / double.Parse(PersonCountLabelTwo.Text)).ToString("N2")}";
            lblTip.Text = $"{Convert.ToInt32(sldTip.Value)}%";
            lblTipPerPerson.Text = $"₱{TipAmountPer.ToString("n2")}";
          
            lblTotal.Text = $"₱{BillPer.ToString("n2")}";
        }

        private void btnTips1_Clicked(object sender, EventArgs e)
        {
            sldTip.Value = 10;
            TipAmount = sldTip.Value / 100;
            TipAmountPer = (Bill / personCountTwo) * TipAmount;
            SubTotal = TipAmount / personCountTwo;
            BillPer = TipAmountPer + Bill;

            SharePerson.Text = $"₱{((Bill + TipAmountPer) / double.Parse(PersonCountLabelTwo.Text)).ToString("N2")}";
            lblTipPerPerson.Text = $"₱{TipAmountPer.ToString("n2")}";
         
            lblTotal.Text = $"₱{BillPer.ToString("n2")}";
        }

        private void btnTips2_Clicked(object sender, EventArgs e)
        {
            sldTip.Value = 15;
            TipAmount = sldTip.Value / 100;
            TipAmountPer = Bill * TipAmount;
            SubTotal = TipAmount / personCountTwo;
            BillPer = TipAmountPer + Bill;

            SharePerson.Text = $"₱{((Bill + TipAmountPer) / double.Parse(PersonCountLabelTwo.Text)).ToString("N2")}";
            lblTipPerPerson.Text = $"₱{TipAmountPer.ToString("n2")}";

            lblTotal.Text = $"₱{BillPer.ToString("n2")}";
        }

        private void btnTips3_Clicked(object sender, EventArgs e)
        {
            sldTip.Value = 20;
            TipAmount = sldTip.Value / 100;
            TipAmountPer = Bill * TipAmount;
         SubTotal = TipAmount / personCountTwo;
            BillPer = TipAmountPer + Bill;

            SharePerson.Text = $"₱{((Bill + TipAmountPer) / double.Parse(PersonCountLabelTwo.Text)).ToString("N2")}";
            lblTipPerPerson.Text = $"₱{TipAmountPer.ToString("n2")}";

            lblTotal.Text = $"₱{BillPer.ToString("n2")}";
        }

        private int personCountTwo = 1;
        private void OnIncrementClickedTwo(object sender, EventArgs e)
        {
            // Try to parse the current person count from the Entry
            if (int.TryParse(PersonCountLabelTwo.Text, out personCountTwo))
            {
                personCountTwo++; // Increment the count
                PersonCountLabelTwo.Text = personCountTwo.ToString(); // Update the Entry
                UpdateBillCalculationsTwo(); // Update calculations here after incrementing
            }
        }

        // This method decrements the person count and updates the UI
        private void OnDecrementClickedTwo(object sender, EventArgs e)
        {
            // Try to parse the current person count from the Entry
            if (int.TryParse(PersonCountLabelTwo.Text, out personCountTwo) && personCountTwo > 0)
            {
                personCountTwo--; // Decrement the count
                PersonCountLabelTwo.Text = personCountTwo.ToString(); // Update the Entry
                UpdateBillCalculationsTwo(); // Update calculations here after decrementing
            }
        }

        // This method updates bill calculations based on the current values
        private void UpdateBillCalculationsTwo()
        {
            // Ensure personCount is greater than zero to avoid division by zero
            if (personCountTwo > 0)
            {
                double tipAmount = sldTip.Value / 100; 
                double tipAmountPer = Bill * tipAmount;
                double billPer = tipAmountPer + Bill;

                // Update the UI labels with the calculated amounts
                lblTipPerPerson.Text = $"₱{tipAmountPer.ToString("n2")}";
                SharePerson.Text = $"₱{((Bill + tipAmountPer) / double.Parse(PersonCountLabelTwo.Text)).ToString("N2")}";
                lblTotal.Text = $"₱{billPer.ToString("n2")}";
            }
        }
        private void PersonCountLabelTwo_Completed(object sender, EventArgs e)
        {
            if (int.TryParse(PersonCountLabelTwo.Text, out int newCount) && newCount > 1)
            {
                personCountTwo = newCount; // Update the person count
                UpdateBillCalculationsTwo(); // Update calculations based on new count
            }
            else
            {
                PersonCountLabelTwo.Text = personCountTwo.ToString(); // Reset to previous valid value
            }
        }
        #endregion
    }
}