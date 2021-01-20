using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Auktionshus_WPF.Model;

namespace Auktionshus_WPF
{
    /// <summary>
    /// Interaction logic for AuctionWindow.xaml
    /// </summary>
    public partial class AuctionWindow : Window
    {
        readonly Account account = (Account)Application.Current.Properties["Account"];
        readonly BackgroundWorker worker = new BackgroundWorker();
        readonly List<string> TimeLeftArray = new List<string>();
        private int TimeArrayIndex;

        public AuctionWindow()
        {
            InitializeComponent();
            ICollection<SalesOffer> salesoffers = Controller.GetSalesOffers();
            SalesOfferLW.ItemsSource = salesoffers;
            worker.DoWork += Worker_DoWork;
            worker.ProgressChanged += Worker_ProgressChanged;
            worker.WorkerReportsProgress = true;
            worker.RunWorkerAsync();
        }

        private void OfferButton_Click(object sender, RoutedEventArgs e)
        {
            SalesOffer so = (SalesOffer)SalesOfferLW.SelectedItem;
            if (so != null)
            {
                Controller.CreatePurchaseOffer(account, so, PriceInput.Text);
            }
        }

        private void SalesOfferLW_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.TimeArrayIndex = SalesOfferLW.SelectedIndex;
            PurchaseOfferLW.Items.Clear();
            SalesOffer so = (SalesOffer)SalesOfferLW.SelectedItem;
            List<PurchaseOffer> purchaseoffers = Controller.GetPurchaseOffersById(so);

            foreach (PurchaseOffer po in purchaseoffers)
            {
                ListViewItem item = new ListViewItem
                {
                    Content = po
                };
                if (po.Account.Username.Equals(account.Username))
                {
                    item.Background = new SolidColorBrush(Colors.Yellow);
                }
                PurchaseOfferLW.Items.Add(item);
            }

            // Doesn't work
            var view = (CollectionView)CollectionViewSource.GetDefaultView(purchaseoffers);
            view.SortDescriptions.Add(new SortDescription("Amount", ListSortDirection.Ascending));
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            bool firstRun = true;
            while (true)
            {
                List<SalesOffer> offers = Controller.GetSalesOffers();
                for (int i = 0; i < offers.Count; i++)
                {
                    if (firstRun)
                    {
                        this.TimeLeftArray.Add(FormatDateTime(offers[i]));
                    }
                    else
                    {
                        this.TimeLeftArray[i] = FormatDateTime(offers[i]);

                    }
                }
                firstRun = false;
                worker.ReportProgress(0, "report");
                Thread.Sleep(1000);
            }
        }

        private string FormatDateTime(SalesOffer offer)
        {

            DateTime now = DateTime.UtcNow;
            DateTime deadline = offer.Deadline;
            TimeSpan timeDiff = (deadline - now);
            string result = $"{timeDiff.Days} Days : {timeDiff.Hours} Hours : {timeDiff.Minutes} Min : {timeDiff.Seconds} Sec";
            if (offer.Deadline < DateTime.Now)
            {
                result = "Udløbet";
            }
            return result;


        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.UserState != null)
            {
                TimeLabel.Content = TimeLeftArray[TimeArrayIndex];
            }
        }
    }
}
