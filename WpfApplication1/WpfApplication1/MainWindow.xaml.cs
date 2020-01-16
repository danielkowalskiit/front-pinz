using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static List<Grid> components = new List<Grid>(); //Lista wszytkich grid
        static int counter = 0; // Zmienna, która służy jako parametr licznika nawigacji

        public MainWindow()
        {
            InitializeComponent();

            //Generuje listę components
            components.Add(BoxAddFile);
            components.Add(BoxEncryptFile);
            components.Add(BoxSendFile);

            
            textBlockAppInfo.Text = 
                "Aby wysłać sprawowzdanie finansowe przejdź poprzez wszystkie wymagane kroki kreatora, aż do momentu kiedy będzie widoczny przycisk umożliwijący wysłanie przygotowanego pliku."
                +" \n\nPrzycisk wyślij będzie aktywny dopiero po poprawnym uzupełnieniu wszystkich opisanych kroków. Po jego kliknięciu pojawi się informacja o statusie wysłanego pliku."
                +" \n\nW menu kreatora jest dostępny przycisk zakończ. Można z niego skorzystać w każdym momencie działania kreatora, tylko że załaczony plik nie zostanie wysyłany do urzędu"+"ee";
        }

        private void button_Start_Click(object sender, RoutedEventArgs e)
        {
            btn_start.IsEnabled = false; //zablokowanie przycisku start
            components[0].Visibility = Visibility.Visible; //wyświetl pierwszy components
            NavigationComponents.Visibility = Visibility.Visible; //wyświetl nawigację
            if (counter == 0) btn_prev.Visibility = Visibility.Hidden; //jeśli counter jest równy 0 ukryj przycisk poprzedni
        }

        private void prev_Click(object sender, RoutedEventArgs e)
        {
            components[counter].Visibility = Visibility.Hidden; //ukryj obecny
            if (counter > 0) counter--; //zmniejsz jeśli counter jest większy od 0 gdyż pierwszy index w components jest równy 0 
            components[counter].Visibility = Visibility.Visible; //wyświetl poprzedni

            if (counter == 0) btn_prev.Visibility = Visibility.Hidden; //jeśli counter=0 ukryj przycisk poprzedni
            if (counter <= components.Count - 1) btn_next.Visibility = Visibility.Visible; //jeśli counter jest <= od wielkości listy components wyświetl przycisk następny
        }

        private void next_Click(object sender, RoutedEventArgs e)
        {
            components[counter].Visibility = Visibility.Hidden; //ukryj obceny
            if (counter < components.Count-1) counter++; //zwiększ jeśli counter jest mniejszy od listy components
            components[counter].Visibility = Visibility.Visible; //wyświetl nastęny

            if (counter != 0)  btn_prev.Visibility = Visibility.Visible; //jeśli counter !=0 wyswietl przycisk poprzedni
            if (counter == components.Count - 1) btn_next.Visibility = Visibility.Hidden; //jeśli counter jest równy wielkości listy components ukryj przycisk następny
        }

        private void end_Click(object sender, RoutedEventArgs e)
        {
            counter = 0; //ustawienie domyślnej wartości licznika nawigacji
            btn_start.IsEnabled = true;  //odblokowanie przycisku start
            foreach (Grid component in components) component.Visibility = Visibility.Hidden; //ukrycie wszystich z listy komponentów
            btn_prev.Visibility = Visibility.Visible;
            btn_next.Visibility = Visibility.Visible;
            NavigationComponents.Visibility = Visibility.Hidden; //ukrycie nawigacji
        }
    }
}
