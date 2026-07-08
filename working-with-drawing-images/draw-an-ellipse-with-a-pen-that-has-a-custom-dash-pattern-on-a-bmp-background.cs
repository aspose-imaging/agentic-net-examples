using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded output path
            string outputPath = @"c:\temp\ellipse_dash.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set BMP options
            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24,
                Source = new FileCreateSource(outputPath, false)
            };

            // Create a 500x500 BMP image
            using (Image image = Image.Create(bmpOptions, 500, 500))
            {
                // Initialize graphics object
                Graphics graphics = new Graphics(image);

                // Fill background with Wheat color
                graphics.Clear(Color.Wheat);

                // Create a pen with custom dash pattern
                Pen pen = new Pen(Color.Blue, 3);
                pen.DashPattern = new float[] { 10f, 5f }; // dash 10 units, space 5 units

                // Draw an ellipse within the specified rectangle
                graphics.DrawEllipse(pen, new Rectangle(100, 100, 300, 200));

                // Save the image
                image.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When generating printable engineering diagrams that require a dashed elliptical annotation on a 24‑bit BMP canvas for legacy CAD compatibility.
 * 2. When creating custom map overlays where a dashed ellipse highlights a region of interest on a wheat‑colored BMP background for GIS applications.
 * 3. When producing UI mockups that need a stylized dashed ellipse button rendered as a BMP image for Windows desktop resources.
 * 4. When automating the generation of report graphics that include dashed elliptical markers on a BMP background for embedding into PDFs.
 * 5. When developing a game asset pipeline that draws dashed elliptical collision zones onto BMP textures using C# and Aspose.Imaging.
 */