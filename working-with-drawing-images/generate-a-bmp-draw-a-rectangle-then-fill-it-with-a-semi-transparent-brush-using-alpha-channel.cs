using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded output path
        string outputPath = @"C:\Temp\output.bmp";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Set BMP options with a file create source
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create the image canvas
            using (Image image = Image.Create(bmpOptions, 400, 300))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Rectangle parameters
                int rectX = 50;
                int rectY = 50;
                int rectWidth = 200;
                int rectHeight = 150;

                // Draw rectangle outline
                graphics.DrawRectangle(new Pen(Color.Black, 2), new Rectangle(rectX, rectY, rectWidth, rectHeight));

                // Fill rectangle with semi‑transparent brush
                using (SolidBrush brush = new SolidBrush(Color.Blue))
                {
                    brush.Opacity = 0.5f; // 50% opacity
                    graphics.FillRectangle(brush, new Rectangle(rectX, rectY, rectWidth, rectHeight));
                }

                // Save the image (output file is already bound via FileCreateSource)
                image.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}