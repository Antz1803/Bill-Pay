namespace MancillaBillPay
{
    public partial class MainPage : ContentPage
    {
     

        public MainPage()
        {
            InitializeComponent();
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
        }

        private void OnDecrementClicked(object sender, EventArgs e)
        {
            if (personCount > 0)
            {
                personCount--;
                PersonCountLabelOne.Text = personCount.ToString();
            }
        }
        private void OnIncrementClickedOne(object sender, EventArgs e)
        {
            personCount++;
            PersonCountLabelTwo.Text = personCount.ToString();
        }

        private void OnDecrementClickedOne(object sender, EventArgs e)
        {
            if (personCount > 0)
            {
                personCount--;
                PersonCountLabelTwo.Text = personCount.ToString();
            }
        }

    }

}
