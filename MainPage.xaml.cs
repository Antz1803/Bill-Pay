namespace MancillaBillPay
{
    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();
        }


        double Bill, BillPer, CurrentBill, TipAmount, TipAmountPer;

        #region Customize Calculation
        private int personCountOne = 1;
        private void txtbillOne_Completed(object sender, EventArgs e)
        {
            TipAmount = 0;
            TipAmountPer = 0;
            personCountOne = 1;
            PersonCountLabelOne.Text = personCountOne.ToString();

            Bill = Convert.ToDouble(txtBillone.Text);
            double customTip = 0;
            if (double.TryParse(TipCustomizes.Text, out customTip))
            {
                TipAmount = customTip / 100; // Convert percentage to decimal
            }
            else
            {
                TipAmount = 0; // Default to 0 if input is invalid
            }
            TipAmountPer = Bill * TipAmount;
            CurrentBill = (Bill / personCountOne);
            BillPer = CurrentBill;

            SharePerson.Text = $"₱{((Bill + TipAmountPer) / double.Parse(PersonCountLabelOne.Text)).ToString("N2")}";
            lblTipPerPerson.Text = $"₱{TipAmountPer.ToString("n2")}";
            lblCurentBill.Text = $"₱{CurrentBill.ToString("n2")}";
            lblTotal.Text = $"₱{BillPer.ToString("n2")}";

        }

        private void tipsCustomizes_Completed(object sender, EventArgs e)
        {
            double customTip = 0;
            if (double.TryParse(TipCustomizes.Text, out customTip))
            {
                TipAmount = customTip / 100; // Convert percentage to decimal
            }
            else
            {
                TipAmount = 0; // Default to 0 if input is invalid
            }
            TipAmountPer = (Bill / personCountOne) * TipAmount;
            CurrentBill = TipAmount / personCountOne;
            BillPer = TipAmountPer + Bill;

            SharePerson.Text = $"₱{((Bill + TipAmountPer) / double.Parse(PersonCountLabelOne.Text)).ToString("N2")}";
            lblTipPerPerson.Text = $"₱{TipAmountPer.ToString("n2")}";

            lblTotal.Text = $"₱{BillPer.ToString("n2")}";

        }
        // This method updates bill calculations based on the current values
        private void UpdateBillCalculations()
        {
            // Ensure personCount is greater than zero to avoid division by zero
            if (personCountOne > 0)
            {
                double customTip = 0;

                // Validate custom tip input
                if (double.TryParse(TipCustomizes.Text, out customTip))
                {
                    TipAmount = customTip / 100; // Convert percentage to decimal
                }
                else
                {
                    TipAmount = 0; // Default to 0 if input is invalid
                }

                double tipAmountPer = Bill * TipAmount;
                double totalBill = Bill + tipAmountPer;

                // Validate person count for sharing calculations
                if (double.TryParse(PersonCountLabelOne.Text, out double personCount) && personCount > 0)
                {
                    SharePerson.Text = $"₱{(totalBill / personCount).ToString("N2")}";
                }
                else
                {
                    SharePerson.Text = "₱0.00"; // Default value if person count is invalid
                }

                // Update the UI labels with the calculated amounts
                lblTipPerPerson.Text = $"₱{tipAmountPer.ToString("n2")}";
                lblTotal.Text = $"₱{totalBill.ToString("n2")}";
            }
        
        }

        private void OnIncrementClicked(object sender, EventArgs e)
        {
            // Try to parse the current person count from the Entry
            if (int.TryParse(PersonCountLabelOne.Text, out personCountOne))
            {
                personCountOne++; // Increment the count
                PersonCountLabelOne.Text = personCountOne.ToString(); // Update the Entry
                UpdateBillCalculations(); // Update calculations here after incrementing
            }
        }

        private void OnDecrementClicked(object sender, EventArgs e)
        {
            // Try to parse the current person count from the Entry
            if (int.TryParse(PersonCountLabelOne.Text, out personCountOne) && personCountOne > 0)
            {
                personCountOne--; // Decrement the count
                PersonCountLabelOne.Text = personCountOne.ToString(); // Update the Entry
                UpdateBillCalculationsTwo(); // Update calculations here after decrementing
            }
        }

        private void PersonCountLabelOne_Completed(object sender, EventArgs e)
        {
            if (int.TryParse(PersonCountLabelOne.Text, out int newCount) && newCount > 1)
            {
                personCountOne = newCount; // Update the person count
                UpdateBillCalculations(); // Update calculations based on new count
            }
            else
            {
                PersonCountLabelOne.Text = personCountOne.ToString(); // Reset to previous valid value
            }
        }
        #endregion

        #region Button can navigate the Customize Tip and Automated Tip
        private void OnCustomize(object sender, EventArgs e)
        {
                CustomizeTip.IsVisible = true;
                AutomatedTip.IsVisible = false;

            SharePerson.Text = "₱0.00";
            txtBillone.Text = null;
            TipCustomizes.Text = null;
            lblTipPerPerson.Text = "₱0.00";
            lblCurentBill.Text = "₱0.00";
            lblTotal.Text = "₱0.00";
            PersonCountLabelOne.Text = (1).ToString();
         
            }

        private void OnAutomated(object sender, EventArgs e)
        {
            AutomatedTip.IsVisible = true;
            CustomizeTip.IsVisible = false;

            // Reset all values to default
            SharePerson.Text = "₱0.00";
            txtBilltwo.Text = null;
            sldTip.Value = 0;
            lblTipPerPerson.Text = "₱0.00";
            lblCurentBill.Text = "₱0.00";
            lblTotal.Text = "₱0.00";
            personCountOne = 1; // Reset person count
            PersonCountLabelTwo.Text = personCountOne.ToString();

            Bill = 0;
            TipAmount = 0;
            TipAmountPer = 0;

            // Ensure any calculations that rely on these values are reset
            UpdateBillCalculationsTwo();
        }
        #endregion

        #region Automated calculation
        private void txtBilltwo_Completed(object sender, EventArgs e)
        {
            sldTip.Value = 0;
            TipAmount = 0;
            TipAmountPer = 0;
            personCountTwo = 1;
            PersonCountLabelTwo.Text = personCountTwo.ToString();

            Bill = Convert.ToDouble(txtBilltwo.Text);
            TipAmount = sldTip.Value / 100;
            TipAmountPer = Bill * TipAmount;
            CurrentBill = (Bill / personCountTwo);
            BillPer = CurrentBill;

            SharePerson.Text = $"₱{((Bill + TipAmountPer) / double.Parse(PersonCountLabelTwo.Text)).ToString("N2")}";
            lblTipPerPerson.Text = $"₱{TipAmountPer.ToString("n2")}";
            lblCurentBill.Text = $"₱{CurrentBill.ToString("n2")}";
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
            CurrentBill = TipAmount / personCountTwo;
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
            CurrentBill = TipAmount / personCountTwo;
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
            CurrentBill = TipAmount / personCountTwo;
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