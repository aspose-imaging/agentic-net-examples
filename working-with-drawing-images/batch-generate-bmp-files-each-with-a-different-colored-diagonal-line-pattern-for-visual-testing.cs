using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Output directory for generated BMP files
        string outputDir = @"C:\Temp\BmpDiagonalLines";

        // Image dimensions
        int width = 200;
        int height = 200;

        // Define colors and corresponding file name parts
        var colorInfos = new List<(Color color, string name)>
        {
            (Color.Red, "red"),
            (Color.Green, "green"),
            (Color.Blue, "blue"),
            (Color.Yellow, "yellow"),
            (Color.Purple, "purple")
        };

        foreach (var info in colorInfos)
        {
            // Construct output file path
            string outputPath = Path.Combine(outputDir, $"diag_{info.name}.bmp");

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up BMP creation options with bound file source
            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24,
                Source = new FileCreateSource(outputPath, false)
            };

            // Create the BMP image canvas
            using (Image image = Image.Create(bmpOptions, width, height))
            {
                // Draw a diagonal line of the specified color
                Graphics graphics = new Graphics(image);
                Pen pen = new Pen(info.color, 5);
                graphics.DrawLine(pen, new Point(0, 0), new Point(width - 1, height - 1));

                // Save the bound image
                image.Save();
            }
        }
    }
}