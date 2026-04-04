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
        // Output file path (hardcoded)
        string outputPath = "Output/highdpi.bmp";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Configure BMP creation options with high DPI
        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.BitsPerPixel = 24;
        bmpOptions.Source = new FileCreateSource(outputPath, false);
        bmpOptions.ResolutionSettings = new ResolutionSetting(300.0, 300.0); // 300 DPI horizontal and vertical

        int width = 800;
        int height = 600;

        // Create the BMP image with the specified options
        using (Image image = Image.Create(bmpOptions, width, height))
        {
            // Obtain a Graphics object for drawing
            Graphics graphics = new Graphics(image);

            // Clear the canvas with white background
            graphics.Clear(Color.White);

            // Draw a red rectangle
            Pen redPen = new Pen(Color.Red, 5);
            graphics.DrawRectangle(redPen, new Rectangle(100, 100, 200, 150));

            // Fill an ellipse with a blue brush
            using (SolidBrush blueBrush = new SolidBrush(Color.Blue))
            {
                graphics.FillEllipse(blueBrush, new Rectangle(350, 200, 150, 100));
            }

            // Draw a green diagonal line
            Pen greenPen = new Pen(Color.Green, 3);
            graphics.DrawLine(greenPen, new Point(50, 50), new Point(750, 550));

            // Save the image (file is already bound via FileCreateSource)
            image.Save();
        }
    }
}