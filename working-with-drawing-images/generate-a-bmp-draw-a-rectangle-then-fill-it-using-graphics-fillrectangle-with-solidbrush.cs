using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Output BMP file path (hardcoded)
        string outputPath = @"C:\temp\output.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Set up BMP options
        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.BitsPerPixel = 24;
        bmpOptions.Source = new FileCreateSource(outputPath, false);

        // Create a new BMP image with specified dimensions
        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(bmpOptions, 200, 200))
        {
            // Initialize Graphics for drawing
            Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);

            // Clear the canvas with white background
            graphics.Clear(Aspose.Imaging.Color.White);

            // Fill a rectangle using SolidBrush
            using (SolidBrush brush = new SolidBrush(Aspose.Imaging.Color.Blue))
            {
                graphics.FillRectangle(brush, new Aspose.Imaging.Rectangle(50, 50, 100, 100));
            }

            // Save the image (output is already bound to the file)
            image.Save();
        }
    }
}