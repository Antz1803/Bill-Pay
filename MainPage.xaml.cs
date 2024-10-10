namespace MancillaBillPay

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

			lblTip.Text = $"Tip: {Convert.ToInt32(sldTip.Value)}%";
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

		private void OnIncrementClicked(object sender, EventArgs e)
		{
			personCount++;
			PersonCountLabelOne.Text = personCount.ToString();


			PersonCountLabelTwo.Text = personCount.ToString();
			TipAmount = sldTip.Value / 100;
			TipAmountPer = (Bill / personCount) * TipAmount;
			SubTotal = (Bill / personCount);
			BillPer = TipAmountPer + SubTotal;

			lblTipPerPerson.Text = $"TIP: P{TipAmountPer.ToString("n2")}";
			lblSubtotal.Text = $"P{SubTotal.ToString("n2")}";
			lblTotal.Text = $"P{BillPer.ToString("n2")}";
		}

		private void OnDecrementClicked(object sender, EventArgs e)
		{
			if (personCount > 0)
			{
				personCount--;
				PersonCountLabelOne.Text = personCount.ToString();
			}

			TipAmount = sldTip.Value / 100;
			TipAmountPer = (Bill / personCount) * TipAmount;
			SubTotal = (Bill / personCount);
			BillPer = TipAmountPer + SubTotal;

			lblTipPerPerson.Text = $"TIP: P{TipAmountPer.ToString("n2")}";
			lblSubtotal.Text = $"P{SubTotal.ToString("n2")}";
			lblTotal.Text = $"P{BillPer.ToString("n2")}";
		}
		private void OnIncrementClickedOne(object sender, EventArgs e)
		{
			personCount++;
			PersonCountLabelTwo.Text = personCount.ToString();
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
