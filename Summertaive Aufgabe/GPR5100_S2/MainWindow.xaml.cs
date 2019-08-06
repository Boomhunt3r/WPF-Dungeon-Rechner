using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;

namespace GPR5100_S2
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Image sourceImage = new Image();
        private List<Image> allImages = new List<Image>();
        private int GridSize = 10;

        public MainWindow()
        {
            InitializeComponent();

            allImages.Add(Stone);
            allImages.Add(Grass);
            allImages.Add(Wood);
            allImages.Add(Ice);
            allImages.Add(Plastic);
            allImages.Add(Fill);

            CreateGrid();
        }

        /// <summary>
        /// Create Grid
        /// </summary>
        private void CreateGrid()
        {
            // dynamisch 10 * 10 zellen erstellen
            for (int i = 0; i < GridSize; ++i)
            {
                sceneGrid.ColumnDefinitions.Add(new ColumnDefinition());
                sceneGrid.RowDefinitions.Add(new RowDefinition());
            }
            try
            {
                for (int x = 0; x < GridSize; ++x)
                    for (int y = 0; y < GridSize; ++y)
                    {
                        Image image = new Image();
                        image.Source = Fill.Source;
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

        /// <summary>
        /// New Button Function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenNew_Click(object sender, RoutedEventArgs e)
        {
            Level.ClearGrid(sceneGrid, allImages[5]);

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
            saveFile.InitialDirectory = System.IO.Path.GetFullPath("./Level");
            saveFile.ShowDialog();

            try
            {
                string filepath = saveFile.FileName;

                switch (saveFile.FilterIndex)
                {
                    case 1:
                        Level.SaveLevel(sceneGrid, allImages, saveFile);

                        stbAction.Content = $"Das Level wurde unter dem Namen {saveFile.FileName} gespeichert.";
                        break;
                    default:
                        break;
                }
            }
            catch (InvalidOperationException _e)
            {
                MessageBox.Show(_e.Message, "Fehler beim Speichern", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception _ex)
            {
                MessageBox.Show(_ex.Message, "Fehler beim Speichern", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Load Function
        /// </summary>
        /// <param name="sender">Image</param>
        /// <param name="e">Mouse Click</param>
        private void MenLoad_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Text-Datei|*.txt";
            openFile.InitialDirectory = System.IO.Path.GetFullPath("./Level");
            openFile.ShowDialog();

            try
            {
                sceneGrid = Level.LoadLevel(sceneGrid, allImages, openFile);

                stbAction.Content = $"Das Level {openFile.FileName} wurde geöffnet.";
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Die Datei konne nicht gefunden werden.", "Fehler beim Laden", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception _e)
            {
                MessageBox.Show(_e.Message, "Fehler beim Laden", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        /// <summary>
        /// Clicked on the Stone Image in Toolbox
        /// </summary>
        /// <param name="sender">Image</param>
        /// <param name="e">Mouse Click</param>
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
        /// <param name="e">Mouse Click</param>
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
        /// <param name="e">Mouse Click</param>
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
        /// <param name="e">Mouse Click</param>
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
        /// <param name="e">Mouse Click</param>
        private void Plastic_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Image Plastic = new Image();

            Plastic = (Image)sender;

            sourceImage.Source = Plastic.Source;

            stbAction.Content = "Plastik wurde ausgewählt!";
        }

        /// <summary>
        /// Clicked on the Fill Image in Toolbox
        /// </summary>
        /// <param name="sender">Image</param>
        /// <param name="e">Mouse Click</param>
        private void Fill_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Image Fill = new Image();

            Fill = (Image)sender;

            sourceImage.Source = Fill.Source;

            stbAction.Content = "Fill wurde ausgewählt!";
        }
    }
}