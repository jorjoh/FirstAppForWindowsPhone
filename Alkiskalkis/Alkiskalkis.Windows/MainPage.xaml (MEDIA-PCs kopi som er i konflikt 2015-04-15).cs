using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.ServiceModel.Description;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Alkiskalkis
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public MainPage()
        {
            this.InitializeComponent();
        }

        //
        

        //typer alkohol
        int promille = 0;
        int øl = 0;
        int wine = 0;
        int brennevin = 0;
        int hetVin = 0;

        // vol%
        int hetVin_vol = 0;
        int øl_vol = 0;
        int wine_vol = 0;
        int brennevin_vol = 0;
        
       


        
   
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int resultatAlkoholiGram;

            Double beer = (double.Parse(ol_vol.Text) * double.Parse(ol_ml.Text)/100);
            Double wine = double.Parse(wineBox.Text) * double.Parse(vin_ml.Text);
            Double hotwineDouble = double.Parse(hotWineBox.Text) * double.Parse(hotWine_ml.Text);
            Double brennevin = double.Parse(brennevinVol.Text) * double.Parse(sprit_ml.Text);

            Debug.WriteLine(beer);

            ol.Text = beer.ToString();
            vin.Text = wine.ToString();
            hotWineTextbox.Text = hotwineDouble.ToString();
            sprit.Text = brennevin.ToString();
           

        }

    }
    
}
