using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace GPR5100_S2
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        // Menüleiste
        // File
        // File->New => Grid geleert werden - Done -
        // File->Save => SaveFileDialog - Work in Progress -
        // File->Load => OpenFileDialog - Work in Progress -
        // Toolbox hinzufügen (Empfehle StackPanel mit Images) - Almost Done -
        // Statusbar soll letzte Aktion enthalten ("Datei xy wurde gespeichert")... - Almost Done -
        //** Statusbar KANN eine Progressbar enthalten, welche den Ladestatus angibt (LoadImages async) **/
        // Das Programm darf unter keinen Umständen abstürzen.
        // Es sollen (falls notwendig) klare Fehlermeldungen angezeigt werden (z.B. MessageBox)
        // Im optimalfall können keine Fehler auftreten.
        // Tipp zum Laden:
        // Grid.GetColumn(image); - Work in Progress -
        // Grid.GetRow(image); - Work in Progress -

        private List<BitmapSource> bitmapSources;

        private Image sourceImage = new Image();

        public MainWindow()
        {
            InitializeComponent();

            CreateGrid();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender">Image</param>
        /// <param name="e"></param>
        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            // Clicked Image from Grid
            Image gridImage = (Image)sender;

            // if there is no Source Image yet selected
            if (sourceImage.Source == null)
            {
                // Give out an MesageBox with no Image selected
                MessageBox.Show("Kein Bild ausgewählt", "Achtung", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            // if Image is selected
            else
            {
                // change Source from GridImage to the Selected One
                gridImage.Source = sourceImage.Source;
            }

        }

        // Muss noch gegen fehler abgesichert werden.
        private List<BitmapSource> LoadImages()
        {
            List<BitmapSource> bitmapImages = new List<BitmapSource>();

            // alle pngs durchgehen
            foreach (string file in Directory.GetFiles("./images", "*.png"))
            {
                // die datei zum laden
                using (var stream = File.OpenRead(file))
                {
                    var decoder = BitmapDecoder.Create(stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);

                    bitmapImages.Add(decoder.Frames.First());
                }
            }
            return bitmapImages;
        }

        /// <summary>
        /// Create Grid
        /// </summary>
        private void CreateGrid()
        {
            //alle Bilder laden
            bitmapSources = LoadImages();

            // dynamisch 10 * 10 zellen erstellen
            for (int i = 0; i < 10; ++i)
            {
                sceneGrid.ColumnDefinitions.Add(new ColumnDefinition());
                sceneGrid.RowDefinitions.Add(new RowDefinition());
            }
            try
            {
                for (int x = 0; x < 10; ++x)
                    for (int y = 0; y < 10; ++y)
                    {
                        Image image = new Image();
                        image.Source = bitmapSources.First();
                        Grid.SetColumn(image, x);
                        Grid.SetRow(image, y);
                        sceneGrid.Children.Add(image);

                        image.MouseUp += Image_MouseUp;
                    }
            }
            catch (Exception _e)
            {
                MessageBox.Show($"{_e}", "Achtung", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        /// <summary>
        /// New Button Function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenNew_Click(object sender, RoutedEventArgs e)
        {
            // clear Images in Grid
            sceneGrid.Children.Clear();

            CreateGrid();

            stbAction.Content = "Das Level wurde geleert.";
        }

        /// <summary>
        /// Save Function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Text-Datei|*.txt";
            saveFile.Title = "Level Speichern";
            saveFile.ShowDialog();

            try
            {
                using (saveFile.OpenFile())
                {
                    string filepath = saveFile.FileName;

                    switch (saveFile.FilterIndex)
                    {
                        case 1:
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception _e)
            {
                MessageBox.Show($"{_e}", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        /// <summary>
        /// Load Function
        /// </summary>
        /// <param name="sender">Image</param>
        /// <param name="e"></param>
        private void MenLoad_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
        }

        /// <summary>
        /// Clicked on the Stone Image in Toolbox
        /// </summary>
        /// <param name="sender">Image</param>
        /// <param name="e"></param>
        private void Stone_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Image Stone = new Image();

            Stone = (Image)sender;

            sourceImage.Source = Stone.Source;

            stbAction.Content = "Stein wurde ausgewählt!";
        }

        /// <summary>
        /// Clicked on the Grass Image in Toolbox
        /// </summary>
        /// <param name="sender">Image</param>
        /// <param name="e"></param>
        private void Grass_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Image Grass = new Image();

            Grass = (Image)sender;

            sourceImage.Source = Grass.Source;

            stbAction.Content = "Grass wurde ausgewählt!";
        }

        /// <summary>
        /// Clicked on the Wood Image in Toolbox
        /// </summary>
        /// <param name="sender">Image</param>
        /// <param name="e"></param>
        private void Wood_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Image Wood = new Image();

            Wood = (Image)sender;

            sourceImage.Source = Wood.Source;

            stbAction.Content = "Holz wurde ausgewählt!";
        }

        /// <summary>
        /// Clicked on the Ice Image in Toolbox
        /// </summary>
        /// <param name="sender">Image</param>
        /// <param name="e"></param>
        private void Ice_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Image Ice = new Image();

            Ice = (Image)sender;

            sourceImage.Source = Ice.Source;

            stbAction.Content = "Eis wurde ausgewählt!";
        }

        /// <summary>
        /// Clicked on the Plastic Image in Toolbox
        /// </summary>
        /// <param name="sender">Image</param>
        /// <param name="e"></param>
        private void Plastic_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Image Plastic = new Image();

            Plastic = (Image)sender;

            sourceImage.Source = Plastic.Source;

            stbAction.Content = "Plastik wurde ausgewählt!";
        }
    }
}