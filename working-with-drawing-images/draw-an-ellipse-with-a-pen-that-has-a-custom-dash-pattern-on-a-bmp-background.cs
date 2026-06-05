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
        // Hardcoded paths
        string outputPath = @"C:\temp\ellipse_custom_dash.bmp";

        try
        {
            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set BMP options (24‑bit)
            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24,
                Source = new FileCreateSource(outputPath, false)
            };

            // Create a new 500x500 BMP image
            using (Image image = Image.Create(bmpOptions, 500, 500))
            {
                // Initialize graphics object
                Graphics graphics = new Graphics(image);

                // Fill background with a solid color
                graphics.Clear(Color.Wheat);

                // Create a pen with custom dash pattern
                Pen pen = new Pen(Color.Blue, 3);
                pen.DashStyle = DashStyle.Custom;
                pen.DashPattern = new float[] { 5f, 2f, 1f, 2f }; // dash, space, dash, space

                // Draw the ellipse using the custom pen
                graphics.DrawEllipse(pen, new Rectangle(100, 100, 300, 200));

                // Save changes to the file
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
 * 1. When a developer needs to generate a 24‑bit BMP report thumbnail that highlights a region with a blue dashed‑outline ellipse for a medical imaging dashboard.
 * 2. When an engineering application must programmatically create a printable schematic on a BMP canvas and emphasize component boundaries using a custom dash pattern pen.
 * 3. When a desktop utility creates watermark overlays on scanned documents saved as BMP files and requires a stylized elliptical border to indicate confidential sections.
 * 4. When a game‑level editor exports terrain maps as BMP images and uses a custom‑dashed ellipse to mark spawn zones or safe areas.
 * 5. When an automated testing tool captures UI screenshots in BMP format and draws a dashed ellipse around elements that failed validation for visual debugging.
 */