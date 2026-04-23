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
        // Define output directory and ensure it exists
        string outputDir = @"C:\Temp\BmpDiagonalLines";
        Directory.CreateDirectory(outputDir);

        // Image dimensions
        int width = 200;
        int height = 200;

        // Define colors and corresponding file names
        var colorInfos = new List<(Color color, string fileName)>
        {
            (Color.Red, "Diagonal_Red.bmp"),
            (Color.Green, "Diagonal_Green.bmp"),
            (Color.Blue, "Diagonal_Blue.bmp"),
            (Color.Yellow, "Diagonal_Yellow.bmp"),
            (Color.Magenta, "Diagonal_Magenta.bmp"),
            (Color.Cyan, "Diagonal_Cyan.bmp")
        };

        foreach (var (color, fileName) in colorInfos)
        {
            string outputPath = Path.Combine(outputDir, fileName);
            // Ensure the directory for the output file exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create BmpOptions with a bound file source
            Source source = new FileCreateSource(outputPath, false);
            BmpOptions options = new BmpOptions
            {
                BitsPerPixel = 24,
                Source = source
            };

            // Create a new BMP image bound to the output file
            using (Image image = Image.Create(options, width, height))
            {
                // Draw a diagonal line using the specified color
                Graphics graphics = new Graphics(image);
                Pen pen = new Pen(color, 5);
                graphics.DrawLine(pen, new Point(0, 0), new Point(width - 1, height - 1));

                // Save the bound image
                image.Save();
            }
        }
    }
}