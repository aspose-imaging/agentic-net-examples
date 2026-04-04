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
        // Output file path
        string outputPath = @"C:\temp\traffic_light.bmp";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Set BMP options with file source
        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.Source = new FileCreateSource(outputPath, false);

        // Define canvas size
        int canvasWidth = 200;
        int canvasHeight = 600;

        // Create BMP canvas bound to the output file
        using (RasterImage canvas = (RasterImage)Image.Create(bmpOptions, canvasWidth, canvasHeight))
        {
            // Initialize graphics for drawing
            Graphics graphics = new Graphics(canvas);
            graphics.Clear(Aspose.Imaging.Color.White);

            // Circle parameters
            int diameter = 150;
            int offsetX = (canvasWidth - diameter) / 2;
            int firstY = 30;   // Top circle (red)
            int secondY = 210; // Middle circle (yellow)
            int thirdY = 390;  // Bottom circle (green)

            // Draw red circle
            using (SolidBrush redBrush = new SolidBrush(Aspose.Imaging.Color.Red))
            {
                graphics.FillEllipse(redBrush, new Rectangle(offsetX, firstY, diameter, diameter));
            }

            // Draw yellow circle
            using (SolidBrush yellowBrush = new SolidBrush(Aspose.Imaging.Color.Yellow))
            {
                graphics.FillEllipse(yellowBrush, new Rectangle(offsetX, secondY, diameter, diameter));
            }

            // Draw green circle
            using (SolidBrush greenBrush = new SolidBrush(Aspose.Imaging.Color.Green))
            {
                graphics.FillEllipse(greenBrush, new Rectangle(offsetX, thirdY, diameter, diameter));
            }

            // Save the bound image
            canvas.Save();
        }
    }
}