using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded output path
        string outputPath = @"C:\temp\diagonal_line.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Configure BMP options with a file create source
        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.Source = new FileCreateSource(outputPath, false);

        // Create a 600x600 BMP image
        using (Image image = Image.Create(bmpOptions, 600, 600))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);

            // Draw a diagonal orange line from (0,0) to (599,599)
            Pen orangePen = new Pen(Color.Orange, 1);
            graphics.DrawLine(orangePen, 0, 0, 599, 599);

            // Save the image (output path is already bound)
            image.Save();
        }
    }
}