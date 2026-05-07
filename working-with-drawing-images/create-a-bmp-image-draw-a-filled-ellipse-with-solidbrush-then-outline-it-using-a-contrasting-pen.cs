using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string outputPath = @"c:\temp\ellipse.bmp";

        try
        {
            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set BMP options (24 bits per pixel)
            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24,
                Source = new FileCreateSource(outputPath, false)
            };

            // Create a new BMP image of size 400x300
            using (Image image = Image.Create(bmpOptions, 400, 300))
            {
                // Initialize graphics object for drawing
                Graphics graphics = new Graphics(image);

                // Define the bounding rectangle for the ellipse
                Rectangle ellipseRect = new Rectangle(50, 50, 300, 200);

                // Fill the ellipse with a solid blue brush
                SolidBrush fillBrush = new SolidBrush(Color.Blue);
                graphics.FillEllipse(fillBrush, ellipseRect);

                // Outline the ellipse with a contrasting yellow pen
                Pen outlinePen = new Pen(Color.Yellow, 5);
                graphics.DrawEllipse(outlinePen, ellipseRect);

                // Save the image (writes to the path specified in FileCreateSource)
                image.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}