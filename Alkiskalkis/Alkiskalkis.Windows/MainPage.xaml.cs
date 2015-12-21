using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.ServiceModel.Description;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Streams;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Alkiskalkis
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        //Formler som brukes til utregning
         Double promilleFormelForMann;
         Double promilleFormelForKvinne;
         Double alkoholiGram;
         
        //Double promilleEtterXTimer;

        // Typer alkohol
         Double beer;
         Double wine;
         Double hotwineDouble;
         Double brennevin;

        public MainPage()
        {
            this.InitializeComponent();
            
        }
        
      private void Button_Click(object sender, RoutedEventArgs e)
      {
            // Hvis input-feltet til "ml" er tomt, sett = 0 og regn ut resten
            if (beerVolume.Text == "" || int.Parse(beerVolume.Text) < 0)
            {
                beerVolume.Text = "0";
            }
            if (wineVolume.Text == "" || int.Parse(wineVolume.Text) < 0)
            {
                wineVolume.Text = "0";
             
            }
            if (hotWineVolume.Text == "" || int.Parse(hotWineVolume.Text) < 0)
            {
              
                hotWineVolume.Text = "0";
                
            }
            if (spritVolum.Text == "" || int.Parse(spritVolum.Text) < 0)
            {
               
                 spritVolum.Text = "0";
            } 
            // Kjør utregning
         else
            {
                UtRegningAvProsentGangerMengde();
            }
            
            // Debugkode
           /* Debug.WriteLine("----- Prosent på enhet * mengde (ml)------");
            Debug.WriteLine(beer);
            Debug.WriteLine(wine);
            Debug.WriteLine(hotwineDouble);
            Debug.WriteLine(brennevin);
            Debug.WriteLine("---------------------------------------");
            */


        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (bodyWeight.Text == "" || int.Parse(bodyWeight.Text) < 0 || antallTimer.Text == "" || int.Parse(antallTimer.Text) < 0)
            {
                kommentarTilPromille.Text = "Skriv inn korrekt vekt og timer fra drikkestart og kun positive tall";
            }
            else
            {

                // Hvis mann blir valgt kjør dnene metoden
                if (mann.IsChecked == true)
                {
                    promilleUtregningForMann();
                }

                // Hvis kvinne er valgt kjøre denne metoden
                if (kvinne.IsChecked == true)
                {

                    promilleUtregningForKvinne();
                }
            }
        }

        private void promilleUtregningForMann ()
        {
            // Formel for promilleUtregning - Mann
            promilleFormelForMann = (alkoholiGram / (double.Parse(bodyWeight.Text) * 0.7)) - (0.15 * (double.Parse(antallTimer.Text)));

            double utregnetPromilleMann = Math.Round(double.Parse(promilleFormelForMann.ToString()), 3);

            // Setter inn resultatet av utrgningen i resultat-tekstboksen
            faktiskPromille.Text = utregnetPromilleMann.ToString();

            // Hvis resultatet er mer enn 0,2 skriv ut passende melding
            if (promilleFormelForMann > 0.2)
            {
                //Setter kommertarfelt = stirng tekst
                kommentarTilPromille.Text = "Du er dritings! La bilen stå ellers så ender den opp som dette:";
                edru.Visibility = Visibility.Collapsed;
                dritings.Visibility = Visibility.Visible;
            }
           
            // Hvis resultatet er mindre enn 0,2 skriv ut passende melding
            if (promilleFormelForMann < 0.2)
            {
                //Setter kommertarfelt = stirng tekst
                kommentarTilPromille.Text = "Du er edru!! Kom deg på butikken og skaff deg alkis!!";
                edru.Visibility = Visibility.Visible;
                dritings.Visibility = Visibility.Collapsed;
            }
            // Hvis resultatet er lik eller minder enn 0,0 skriv ut passende melding
            if (promilleFormelForMann < 0.000)
            {
                // Overstyrer svar som er mindre enn 0 og setter resultat til 0, slik unngår vi minus i resultatboksen
                promilleFormelForMann = 0;
                //Setter kommertarfelt = stirng tekst
                faktiskPromille.Text = promilleFormelForMann.ToString();
                edru.Visibility = Visibility.Visible;
            }
        }

        private void promilleUtregningForKvinne()
        {
            // Formel for promilleUtregning - Mann
            promilleFormelForKvinne = (alkoholiGram / (double.Parse(bodyWeight.Text) * 0.6)) - (0.15 * (double.Parse(antallTimer.Text)));

            double utregnetPromille = Math.Round(double.Parse(promilleFormelForKvinne.ToString()), 3);

            // Setter inn resultatet av utrgningen i resultat-tekstboksen
            faktiskPromille.Text = utregnetPromille.ToString();

            // Hvis resultatet er mer enn 0,2 skriv ut passende melding
            if (promilleFormelForKvinne> 0.2)
            {
                kommentarTilPromille.Text = "Du er dritings! La bilen stå ellers så ender den opp som dette: ";
                edru.Visibility = Visibility.Collapsed;
                dritings.Visibility = Visibility.Visible;

            }
            // Hvis resultatet er mindre enn 0,2 skriv ut passende melding
            if (promilleFormelForKvinne < 0.2)
            {
                kommentarTilPromille.Text = "Du er edru!! Kom deg på butikken og skaff deg alkis!!";
                edru.Visibility = Visibility.Visible;
                dritings.Visibility = Visibility.Collapsed;
            }
            // Hvis resultatet er lik eller minder enn 0,0 skriv ut passende melding
            if (promilleFormelForKvinne < 0.000)
            {
                // Overstyrer svar som er mindre enn 0 og setter resultat til 0, slik unngår vi minus i resultatboksen
                promilleFormelForKvinne = 0;
                //Setter kommertarfelt = stirng tekst
                faktiskPromille.Text = promilleFormelForKvinne.ToString();
                
            }
        }

        private void UtRegningAvProsentGangerMengde()
        {
            //Parser verdiene fra textboksene vol% og mengde alkohol 
            beer = (double.Parse(beerPercent.Text) * double.Parse(beerVolume.Text));
            wine = double.Parse(wineBoxPercent.Text) * double.Parse(wineVolume.Text);
            hotwineDouble = double.Parse(hotWinePercent.Text) * double.Parse(hotWineVolume.Text);
            brennevin = double.Parse(spiritPercent.Text) * double.Parse(spritVolum.Text);

            RegnUtPromille.IsEnabled = true;

            // Legger resultatet av regnestykke i egne textboxer
            ol.Text = beer.ToString();
            vin.Text = wine.ToString();
            hotWineTextbox.Text = hotwineDouble.ToString();
            sprit.Text = brennevin.ToString();

            //Legger sammen textboxene og regner ut hvor mange gram alkohol du har i kroppen
            alkoholiGram = beer + wine + hotwineDouble + brennevin;
            Debug.WriteLine(alkoholiGram + "Gram alkohol");
            resultat_vol.Text = alkoholiGram.ToString();
        }
    }
    
}
