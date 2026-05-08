using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.gif";
        string outputPath = "output.gif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (GifImage gif = (GifImage)Image.Load(inputPath))
            {
                // Define overlay rectangle dimensions and position
                int rectX = 10;
                int rectY = 10;
                int rectWidth = 200;
                int rectHeight = 150;

                // Semi‑transparent red brush
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(128, Color.Red)))
                {
                    Graphics graphics = new Graphics(gif.ActiveFrame);
                    graphics.FillRectangle(brush, new Rectangle(rectX, rectY, rectWidth, rectHeight));
                }

                GifOptions options = new GifOptions();
                gif.Save(outputPath, options);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}