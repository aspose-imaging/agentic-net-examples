using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded output path
        string outputPath = @"C:\temp\offcenter_oval.png";

        try
        {
            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up PNG options with a file create source
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            // Create a new image with desired dimensions
            using (Image image = Image.Create(pngOptions, 500, 400))
            {
                // Initialize graphics object for drawing
                Graphics graphics = new Graphics(image);

                // Clear background
                graphics.Clear(Color.Wheat);

                // Define a pen for the ellipse
                Pen pen = new Pen(Color.Blue, 3);

                // Draw an off‑center oval using location and size parameters
                // x = 150, y = 80 positions the bounding rectangle away from the image center
                // width = 250, height = 150 defines the oval size
                graphics.DrawEllipse(pen, 150f, 80f, 250f, 150f);

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
 * 1. When generating a custom PNG badge where a blue‑outlined oval must be drawn off‑center to frame a logo using Aspose.Imaging’s Graphics.DrawEllipse method.
 * 2. When creating a printable PDF form template in C# that requires an off‑center oval field for a signature stamp, drawn with a Pen and saved as a PNG via Aspose.Imaging.
 * 3. When designing a UI mock‑up image that shows a highlighted off‑center circular progress indicator on a wheat‑colored background, using the Graphics.DrawEllipse overload with location and size parameters.
 * 4. When producing a set of marketing banners that need an off‑center oval overlay to frame product photos, leveraging Aspose.Imaging’s PNG options and the DrawEllipse method.
 * 5. When building an automated image‑processing test that validates alignment by programmatically drawing an off‑center oval as a reference shape with C# and Aspose.Imaging.
 */