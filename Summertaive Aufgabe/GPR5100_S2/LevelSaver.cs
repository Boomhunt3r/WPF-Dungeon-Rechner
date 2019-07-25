using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GPR5100_S2
{
    public class LevelSaver
    {
        public static void SaveLevel(Grid _grid, List<Image> _images, SaveFileDialog _saveFile)
        {
            using (Stream stream = File.OpenWrite(System.IO.Path.GetFullPath(_saveFile.FileName)))
            {
                StreamWriter writer = new StreamWriter(stream);

                Image image = new Image();

                for (int i = 0; i < _grid.Children.Count; ++i)
                {
                    image = (Image)_grid.Children[i];

                    // Stone
                    if (image.Source == _images[0].Source)
                    {
                        writer.WriteLine('S');
                    }
                    // Grass
                    else if (image.Source == _images[1].Source)
                    {
                        writer.WriteLine('G');
                    }
                    // Wood
                    else if (image.Source == _images[2].Source)
                    {
                        writer.WriteLine('W');
                    }
                    // Ice
                    else if (image.Source == _images[3].Source)
                    {
                        writer.WriteLine('I');
                    }
                    // Plastic
                    else if (image.Source == _images[4].Source)
                    {
                        writer.WriteLine('P');
                    }
                    // Fill
                    else if (image.Source == _images[5].Source)
                    {
                        writer.WriteLine('X');
                    }
                }
                writer.Flush();
            }
        }

        public static void LoadLevel()
        {

        }
    }
}
