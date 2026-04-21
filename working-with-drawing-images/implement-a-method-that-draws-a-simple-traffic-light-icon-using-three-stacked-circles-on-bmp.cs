using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        // Output file path (hard‑coded)
        string outputPath = @"C:\temp\traffic_light.bmp";

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Configure BMP options with a bound file source
        BmpOptions options = new BmpOptions();
        options.BitsPerPixel = 24;
        options.Source = new FileCreateSource(outputPath, false);

        // Define canvas size
        int canvasWidth = 100;
        int canvasHeight = 300;

        // Create the BMP image (bound to the output file)
        using (Image image = Image.Create(options, canvasWidth, canvasHeight))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(image);

            // Clear background (black)
            graphics.Clear(Color.Black);

            // Circle parameters
            int diameter = 80;
            int offsetX = (canvasWidth - diameter) / 2;
            int[] offsetY = { 20, 110, 200 }; // top, middle, bottom positions

            // Red light
            using (SolidBrush redBrush = new SolidBrush(Color.Red))
            {
                graphics.FillEllipse(redBrush, new Rectangle(offsetX, offsetY[0], diameter, diameter));
            }

            // Yellow light
            using (SolidBrush yellowBrush = new SolidBrush(Color.Yellow))
            {
                graphics.FillEllipse(yellowBrush, new Rectangle(offsetX, offsetY[1], diameter, diameter));
            }

            // Green light
            using (SolidBrush greenBrush = new SolidBrush(Color.Green))
            {
                graphics.FillEllipse(greenBrush, new Rectangle(offsetX, offsetY[2], diameter, diameter));
            }

            // Save the bound image
            image.Save();
        }
    }
}