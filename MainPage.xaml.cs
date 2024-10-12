namespace MancillaBillPay
{
    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();
        }


        double Bill, BillPer, SubTotal, TipAmount, TipAmountPer;
        private void txtBilltwo_Completed(object sender, EventArgs e)
        {
            Bill = Convert.ToDouble(txtBilltwo.Text);
            TipAmount = sldTip.Value / 100;
            TipAmountPer = (Bill / personCountTwo) * TipAmount;
            SubTotal = (Bill / personCountTwo);
            BillPer = TipAmountPer + SubTotal;

            lblTipPerPerson.Text = $"₱{TipAmountPer.ToString("n2")}";
            lblSubtotal.Text = $"₱{SubTotal.ToString("n2")}";
            lblTotal.Text = $"₱{BillPer.ToString("n2")}";
        }
        private void txtbillOne_Completed(object sender, EventArgs e)
        {
            Bill = Convert.ToDouble(txtBillone.Text);
            TipAmount = sldTip.Value / 100;
            TipAmountPer = (Bill / personCountOne) * TipAmount;
            SubTotal = (Bill / personCountOne);
            BillPer = TipAmountPer + SubTotal;

            lblTipPerPerson.Text = $"₱{TipAmountPer.ToString("n2")}";
            lblSubtotal.Text = $"₱{SubTotal.ToString("n2")}";
            lblTotal.Text = $"₱{BillPer.ToString("n2")}";
        }
        private void tipsCustomizes_Completed(object sender, EventArgs e)
        {
            Bill = Convert.ToDouble(txtBilltwo.Text);
            TipAmount = sldTip.Value / 100;
            TipAmountPer = (Bill / personCountTwo) * TipAmount;
            SubTotal = (Bill / personCountTwo);
            BillPer = TipAmountPer + SubTotal;

            lblTipPerPerson.Text = $"₱{TipAmountPer.ToString("n2")}";
            lblSubtotal.Text = $"₱{SubTotal.ToString("n2")}";
            lblTotal.Text = $"₱{BillPer.ToString("n2")}";
        }

        private void sldTip_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            TipAmountPer = Convert.ToInt32(sldTip.Value);
            TipAmount = sldTip.Value / 100;
            TipAmountPer = (Bill / personCountTwo) * TipAmount;
            SubTotal = (Bill / personCountTwo);
            BillPer = TipAmountPer + SubTotal;

            lblTip.Text = $"{Convert.ToInt32(sldTip.Value)}%";
            lblTipPerPerson.Text = $"₱{TipAmountPer.ToString("n2")}";
            lblSubtotal.Text = $"₱{SubTotal.ToString("n2")}";
            lblTotal.Text = $"₱{BillPer.ToString("n2")}";
        }

        private void btnTips1_Clicked(object sender, EventArgs e)
        {
            sldTip.Value = 10;
            TipAmount = sldTip.Value / 100;
            TipAmountPer = (Bill / personCountTwo) * TipAmount;
            SubTotal = (Bill / personCountTwo);
            BillPer = TipAmountPer + SubTotal;

            lblTipPerPerson.Text = $"₱{TipAmountPer.ToString("n2")}";
            lblSubtotal.Text = $"₱{SubTotal.ToString("n2")}";
            lblTotal.Text = $"₱{BillPer.ToString("n2")}";
        }

        private void btnTips2_Clicked(object sender, EventArgs e)
        {
            sldTip.Value = 15;
            TipAmount = sldTip.Value / 100;
            TipAmountPer = (Bill / personCountTwo) * TipAmount;
            SubTotal = (Bill / personCountTwo);
            BillPer = TipAmountPer + SubTotal;

            lblTipPerPerson.Text = $"₱{TipAmountPer.ToString("n2")}";
            lblSubtotal.Text = $"₱{SubTotal.ToString("n2")}";
            lblTotal.Text = $"₱{BillPer.ToString("n2")}";
        }

        private void btnTips3_Clicked(object sender, EventArgs e)
        {
            sldTip.Value = 20;
            TipAmount = sldTip.Value / 100;
            TipAmountPer = (Bill / personCountTwo) * TipAmount;
            SubTotal = (Bill / personCountTwo);
            BillPer = TipAmountPer + SubTotal;

            lblTipPerPerson.Text = $"₱{TipAmountPer.ToString("n2")}";
            lblSubtotal.Text = $"₱{SubTotal.ToString("n2")}";
            lblTotal.Text = $"₱{BillPer.ToString("n2")}";
        }
        private void OnCustomize(object sender, EventArgs e)
        {
            CustomizeTip.IsVisible = true;
            AutomatedTip.IsVisible = false;

            txtBillone.Text = null;
            txtBilltwo.Text = null;
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

        private int personCountOne = 1;
        private int personCountTwo = 1;

        private void OnIncrementClicked(object sender, EventArgs e)
        {
            // Try to parse the current person count from the Entry
            if (int.TryParse(PersonCountLabelOne.Text, out personCountOne))
            {
                personCountOne++; // Increment the count
                PersonCountLabelOne.Text = personCountOne.ToString(); // Update the Entry
                UpdateBillCalculationsOne(); // Update calculations here after incrementing
            }
        }

        // This method decrements the person count and updates the UI
        private void OnDecrementClicked(object sender, EventArgs e)
        {
            // Try to parse the current person count from the Entry
            if (int.TryParse(PersonCountLabelOne.Text, out personCountOne) && personCountOne > 0)
            {
                personCountOne--; // Decrement the count
                PersonCountLabelOne.Text = personCountOne.ToString(); // Update the Entry
                UpdateBillCalculationsOne(); // Update calculations here after decrementing
            }
        }

        // This method updates bill calculations based on the current values
        private void UpdateBillCalculationsOne()
        {
            // Ensure personCount is greater than zero to avoid division by zero
            if (personCountOne > 0)
            {
                double tipAmount = sldTip.Value / 100; // Assuming sldTip is a Slider
                double tipAmountPer = (Bill * tipAmount) / personCountOne;
                double subTotal = Bill / personCountOne;
                double billPer = tipAmountPer + subTotal;

                // Update the UI labels with the calculated amounts
                lblTipPerPerson.Text = $"₱{tipAmountPer.ToString("n2")}";
                lblSubtotal.Text = $"₱{subTotal.ToString("n2")}";
                lblTotal.Text = $"₱{billPer.ToString("n2")}";
            }
        }

        // This method updates bill calculations based on the current values
        private void UpdateBillCalculationsTwo()
        {
            // Ensure personCount is greater than zero to avoid division by zero
            if (personCountTwo > 0)
            {
                double tipAmount = sldTip.Value / 100; // Assuming sldTip is a Slider
                double tipAmountPer = (Bill * tipAmount) / personCountTwo;
                double subTotal = Bill / personCountTwo;
                double billPer = tipAmountPer + subTotal;

                // Update the UI labels with the calculated amounts
                lblTipPerPerson.Text = $"₱{tipAmountPer.ToString("n2")}";
                lblSubtotal.Text = $"₱{subTotal.ToString("n2")}";
                lblTotal.Text = $"₱{billPer.ToString("n2")}";
            }
        }

        private void OnIncrementClickedOne(object sender, EventArgs e)
        {
            // Try to parse the current person count from the Entry
            if (int.TryParse(PersonCountLabelTwo.Text, out personCountTwo))
            {
                personCountTwo++; // Increment the count
                PersonCountLabelTwo.Text = personCountTwo.ToString(); // Update the Entry
                UpdateBillCalculationsTwo(); // Update calculations here after incrementing
            }
        }

        private void OnDecrementClickedOne(object sender, EventArgs e)
        {
            // Try to parse the current person count from the Entry
            if (int.TryParse(PersonCountLabelTwo.Text, out personCountTwo) && personCountTwo > 0)
            {
                personCountTwo--; // Decrement the count
                PersonCountLabelTwo.Text = personCountTwo.ToString(); // Update the Entry
                UpdateBillCalculationsTwo(); // Update calculations here after decrementing
            }
        }
    }
}