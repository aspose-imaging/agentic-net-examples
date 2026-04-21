using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded output path
        string outputPath = @"C:\temp\bordered.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Image dimensions
        int width = 400;
        int height = 400;

        // Configure BMP options with a FileCreateSource
        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.BitsPerPixel = 24;
        bmpOptions.Source = new FileCreateSource(outputPath, false);

        // Create the BMP image
        using (Image image = Image.Create(bmpOptions, width, height))
        {
            // Initialize Graphics for drawing
            Graphics graphics = new Graphics(image);

            // Clear background to white
            graphics.Clear(Color.White);

            // Define a thick border pen
            Pen borderPen = new Pen(Color.Black, 10);

            // Draw the outer border rectangle
            graphics.DrawRectangle(borderPen, 0, 0, width, height);

            // Define inset for inner rectangle (leaving space for the border)
            int inset = 20;

            // Fill the inner rectangle with a light gray color
            using (SolidBrush innerBrush = new SolidBrush(Color.LightGray))
            {
                graphics.FillRectangle(innerBrush, inset, inset, width - 2 * inset, height - 2 * inset);
            }

            // Save the image (output file is already bound via FileCreateSource)
            image.Save();
        }
    }
}