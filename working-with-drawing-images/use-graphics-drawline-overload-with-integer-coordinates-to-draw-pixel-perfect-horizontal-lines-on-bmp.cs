using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Output BMP file path
        string outputPath = @"C:\temp\horizontal_lines.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Set up BMP options with a file create source
        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.Source = new FileCreateSource(outputPath, false);

        int width = 200;
        int height = 100;

        // Create the image canvas
        using (Image image = Image.Create(bmpOptions, width, height))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);
            graphics.Clear(Color.White);

            // Pen for drawing horizontal lines
            Pen pen = new Pen(Color.Black, 1);

            // Draw pixel‑perfect horizontal lines every 10 pixels
            for (int y = 0; y < height; y += 10)
            {
                graphics.DrawLine(pen, 0, y, width - 1, y);
            }

            // Save the image (file is already bound to the output path)
            image.Save();
        }
    }
}