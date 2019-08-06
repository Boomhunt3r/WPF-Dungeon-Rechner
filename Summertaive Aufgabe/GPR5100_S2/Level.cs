using Microsoft.Win32;
using System.Collections.Generic;
using System.IO;
using System.Windows.Controls;

namespace GPR5100_S2
{
    public class Level
    {
        /// <summary>
        /// Save Level Function
        /// </summary>
        /// <param name="_grid">Grid to Save</param>
        /// <param name="_images">List with Images</param>
        /// <param name="_saveFile">Path to Save File</param>
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
                        writer.Write('0');
                    }
                }
                writer.Flush();
            }
        }

        /// <summary>
        /// Load Level Function 
        /// </summary>
        /// <param name="_grid">Grid to Load Images into</param>
        /// <param name="_images">List with all Images</param>
        /// <param name="_openFile">Path from file to open</param>
        /// <returns>Grid</returns>
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
        
        /// <summary>
        /// Clear Level Function
        /// </summary>
        /// <param name="_grid">Grid to clear</param>
        /// <param name="_images">List with all Images</param>
        public static void ClearGrid(Grid _grid,Image _image)
        {
            Image image = new Image();

            for (int i = 0; i < _grid.Children.Count; i++)
            {
                image = (Image)_grid.Children[i];

                image.Source = _image.Source;
            }
        }
    }
}
