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
        // Output BMP file path
        string outputPath = @"C:\temp\output.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Set BMP options with a file source bound to the output path
        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.Source = new FileCreateSource(outputPath, false);

        // Create a new BMP image with specified dimensions
        using (Image image = Image.Create(bmpOptions, 500, 400))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);

            // Define rectangle bounds
            Rectangle rect = new Rectangle(50, 50, 200, 150);

            // Draw rectangle outline
            graphics.DrawRectangle(new Pen(Color.Black, 2), rect);

            // Fill rectangle interior with a solid blue brush
            using (SolidBrush brush = new SolidBrush(Color.Blue))
            {
                graphics.FillRectangle(brush, rect);
            }

            // Save the image (already bound to the file)
            image.Save();
        }
    }
}