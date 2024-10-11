namespace MancillaBillPay
{
	public partial class MainPage : ContentPage
	{


		public MainPage()
		{
			InitializeComponent();
		}


		double Bill, BillPer, SubTotal, TipAmount, TipAmountPer;

		private void txtBill_Completed(object sender, EventArgs e)
		{
			Bill = Convert.ToDouble(txtBill.Text);
			TipAmount = sldTip.Value / 100;
			TipAmountPer = (Bill / personCount) * TipAmount;
			SubTotal = (Bill / personCount);
			BillPer = TipAmountPer + SubTotal;

			lblTipPerPerson.Text = $"TIP: P{TipAmountPer.ToString("n2")}";
			lblSubtotal.Text = $"P{SubTotal.ToString("n2")}";
			lblTotal.Text = $"P{BillPer.ToString("n2")}";
		}

		private void sldTip_ValueChanged(object sender, ValueChangedEventArgs e)
		{
			TipAmountPer = Convert.ToInt32(sldTip.Value);
			TipAmount = sldTip.Value / 100;
			TipAmountPer = (Bill / personCount) * TipAmount;
			SubTotal = (Bill / personCount);
			BillPer = TipAmountPer + SubTotal;

			lblTip.Text = $"{Convert.ToInt32(sldTip.Value)}%";
			lblTipPerPerson.Text = $"TIP: P{TipAmountPer.ToString("n2")}";
			lblSubtotal.Text = $"P{SubTotal.ToString("n2")}";
			lblTotal.Text = $"P{BillPer.ToString("n2")}";
		}

		private void btnTips1_Clicked(object sender, EventArgs e)
		{
			sldTip.Value = 10;
			TipAmount = sldTip.Value / 100;
			TipAmountPer = (Bill / personCount) * TipAmount;
			SubTotal = (Bill / personCount);
			BillPer = TipAmountPer + SubTotal;

			lblTipPerPerson.Text = $"TIP: P{TipAmountPer.ToString("n2")}";
			lblSubtotal.Text = $"P{SubTotal.ToString("n2")}";
			lblTotal.Text = $"P{BillPer.ToString("n2")}";
		}

		private void btnTips2_Clicked(object sender, EventArgs e)
		{
			sldTip.Value = 15;
			TipAmount = sldTip.Value / 100;
			TipAmountPer = (Bill / personCount) * TipAmount;
			SubTotal = (Bill / personCount);
			BillPer = TipAmountPer + SubTotal;

			lblTipPerPerson.Text = $"TIP: P{TipAmountPer.ToString("n2")}";
			lblSubtotal.Text = $"P{SubTotal.ToString("n2")}";
			lblTotal.Text = $"P{BillPer.ToString("n2")}";
		}

		private void btnTips3_Clicked(object sender, EventArgs e)
		{
			sldTip.Value = 20;
			TipAmount = sldTip.Value / 100;
			TipAmountPer = (Bill / personCount) * TipAmount;
			SubTotal = (Bill / personCount);
			BillPer = TipAmountPer + SubTotal;

			lblTipPerPerson.Text = $"TIP: P{TipAmountPer.ToString("n2")}";
			lblSubtotal.Text = $"P{SubTotal.ToString("n2")}";
			lblTotal.Text = $"P{BillPer.ToString("n2")}";
		}
		private void OnCustomize(object sender, EventArgs e)
		{
			CustomizeTip.IsVisible = true;
			AutomatedTip.IsVisible = false;
		}

		private void OnAutomated(object sender, EventArgs e)
		{
			AutomatedTip.IsVisible = true;
			CustomizeTip.IsVisible = false;
		}

        private int personCount = 0;

        // This method increments the person count and updates the UI
        private void OnIncrementClicked(object sender, EventArgs e)
        {
            // Try to parse the current person count from the Entry
            if (int.TryParse(PersonCountLabelOne.Text, out personCount))
            {
                personCount++; // Increment the count
                PersonCountLabelOne.Text = personCount.ToString(); // Update the Entry
                UpdateBillCalculations(); // Update calculations here after incrementing
            }
        }

        // This method decrements the person count and updates the UI
        private void OnDecrementClicked(object sender, EventArgs e)
        {
            // Try to parse the current person count from the Entry
            if (int.TryParse(PersonCountLabelOne.Text, out personCount) && personCount > 0)
            {
                personCount--; // Decrement the count
                PersonCountLabelOne.Text = personCount.ToString(); // Update the Entry
                UpdateBillCalculations(); // Update calculations here after decrementing
            }
        }

        // This method updates bill calculations based on the current values
        private void UpdateBillCalculations()
        {
            // Ensure personCount is greater than zero to avoid division by zero
            if (personCount > 0)
            {
                double tipAmount = sldTip.Value / 100; // Assuming sldTip is a Slider
                double tipAmountPer = (Bill * tipAmount) / personCount;
                double subTotal = Bill / personCount;
                double billPer = tipAmountPer + subTotal;

                // Update the UI labels with the calculated amounts
                lblTipPerPerson.Text = $"TIP: P{tipAmountPer.ToString("n2")}";
                lblSubtotal.Text = $"P{subTotal.ToString("n2")}";
                lblTotal.Text = $"P{billPer.ToString("n2")}";
            }
        }

        // XAML code remains unchanged, but ensure controls are initialized properly.

        private void OnIncrementClickedOne(object sender, EventArgs e)
		{
			personCount++;
			PersonCountLabelTwo.Text = personCount.ToString();
			TipAmount = sldTip.Value / 100;
			TipAmountPer = (Bill / personCount) * TipAmount;
			SubTotal = (Bill / personCount);
			BillPer = TipAmountPer + SubTotal;

			lblTipPerPerson.Text = $"TIP: P{TipAmountPer.ToString("n2")}";
			lblSubtotal.Text = $"P{SubTotal.ToString("n2")}";
			lblTotal.Text = $"P{BillPer.ToString("n2")}";
		}

		private void OnDecrementClickedOne(object sender, EventArgs e)
		{
			if (personCount > 0)
			{
				personCount--;
				PersonCountLabelTwo.Text = personCount.ToString();
			}
			TipAmount = sldTip.Value / 100;
			TipAmountPer = (Bill / personCount) * TipAmount;
			SubTotal = (Bill / personCount);
			BillPer = TipAmountPer + SubTotal;

			lblTipPerPerson.Text = $"TIP: P{TipAmountPer.ToString("n2")}";
			lblSubtotal.Text = $"P{SubTotal.ToString("n2")}";
			lblTotal.Text = $"P{BillPer.ToString("n2")}";
		}
	}
}