// HOW-TO: Create BMP Image with Dashed Ellipse Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded output path
        string outputPath = @"C:\temp\ellipse.bmp";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Set BMP options
            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24,
                Source = new FileCreateSource(outputPath, false)
            };

            // Create image canvas
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(bmpOptions, 400, 300))
            {
                // Initialize graphics
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);

                // Fill background
                graphics.Clear(Aspose.Imaging.Color.Wheat);

                // Create pen with custom dash pattern
                Aspose.Imaging.Pen pen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Blue, 3);
                pen.DashPattern = new float[] { 5, 3 };

                // Draw ellipse
                graphics.DrawEllipse(pen, new Aspose.Imaging.Rectangle(50, 50, 300, 150));

                // Save image (output file already bound)
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
 * 1. When generating a printable report that requires a blue dashed ellipse drawn on a BMP background using Aspose.Imaging to highlight a region.
 * 2. When creating custom map markers where a wheat‑colored bitmap contains a dashed ellipse overlay for GIS visualization.
 * 3. When producing test images for UI components that need a specific dash pattern on an ellipse to verify rendering consistency across platforms.
 * 4. When automating badge templates that include a stylized dashed ellipse on a 24‑bit BMP canvas for branding purposes.
 * 5. When developing a diagnostic tool that visualizes sensor coverage areas with a dashed ellipse on a BMP image to aid analysis.
 */
