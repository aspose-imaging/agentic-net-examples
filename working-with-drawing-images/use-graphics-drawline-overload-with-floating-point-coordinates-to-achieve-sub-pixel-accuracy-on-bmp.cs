using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\sample.bmp";
        string outputPath = @"C:\temp\sample.subpixel.bmp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the BMP image
        using (BmpImage bmp = new BmpImage(inputPath))
        {
            // Create a Graphics object for drawing
            Graphics graphics = new Graphics(bmp);

            // Define a pen (blue, 1 pixel wide)
            Pen pen = new Pen(Color.Blue, 1);

            // Draw a line with sub‑pixel (floating‑point) coordinates
            // Example: from (20.3, 30.7) to (200.8, 150.2)
            graphics.DrawLine(pen, 20.3f, 30.7f, 200.8f, 150.2f);

            // Save the modified image
            bmp.Save(outputPath);
        }
    }
}