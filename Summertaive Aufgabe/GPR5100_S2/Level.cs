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
    public class Level
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
                        writer.Write('S');
                    }
                    // Grass
                    else if (image.Source == _images[1].Source)
                    {
                        writer.Write('G');
                    }
                    // Wood
                    else if (image.Source == _images[2].Source)
                    {
                        writer.Write('W');
                    }
                    // Ice
                    else if (image.Source == _images[3].Source)
                    {
                        writer.Write('I');
                    }
                    // Plastic
                    else if (image.Source == _images[4].Source)
                    {
                        writer.Write('P');
                    }
                    // Fill
                    else if (image.Source == _images[5].Source)
                    {
                        writer.Write('X');
                    }
                }
                writer.Flush();
            }
        }

        public static Grid LoadLevel(Grid _grid, List<Image> _images, OpenFileDialog _openFile)
        {
            Image image = new Image();

            using (Stream stream = File.OpenRead(Path.GetFullPath(_openFile.FileName)))
            {
                StreamReader reader = new StreamReader(stream);

                char[] content = new char[_grid.Children.Count];

                reader.Read(content,0, _grid.Children.Count);

                for (int i = 0; i < _grid.Children.Count; ++i)
                {
                    image = (Image)_grid.Children[i];

                    if (content[i] == 'S')
                    {
                        image.Source = _images[0].Source;
                    }
                    else if (content[i] == 'G')
                    {
                        image.Source = _images[1].Source;
                    }
                    else if (content[i] == 'W')
                    {
                        image.Source = _images[2].Source;
                    }
                    else if (content[i] == 'I')
                    {
                        image.Source = _images[3].Source;
                    }
                    else if (content[i] == 'P')
                    {
                        image.Source = _images[4].Source;
                    }
                    else if (content[i] == 'X')
                    {
                        image.Source = _images[5].Source;
                    }
                }
            }
            return _grid;
        }
        
        public static void ClearGrid(Grid _grid, List<Image> _images)
        {
            Image image = new Image();

            for (int i = 0; i < _grid.Children.Count; i++)
            {
                image = (Image)_grid.Children[i];

                image.Source = _images[5].Source;
            }
        }
    }
}
