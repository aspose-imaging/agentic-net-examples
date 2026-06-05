using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output file path (hardcoded)
            string outputPath = @"C:\temp\offcenter_oval.png";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set PNG options with a file create source bound to the output path
            PngOptions pngOptions = new PngOptions();
            pngOptions.Source = new FileCreateSource(outputPath, false);

            // Create a 400x300 image canvas
            using (Image image = Image.Create(pngOptions, 400, 300))
            {
                // Initialize graphics for the image
                Graphics graphics = new Graphics(image);

                // Clear the canvas with white background
                graphics.Clear(Color.White);

                // Define a blue pen with thickness 3
                Pen pen = new Pen(Color.Blue, 3);

                // Draw an off‑center oval using location and size parameters
                graphics.DrawEllipse(pen, 50f, 30f, 200f, 100f);

                // Save the image (already bound to the output file)
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
 * 1. When generating a PNG badge with Aspose.Imaging where a blue off‑center oval is drawn behind a logo to create a decorative background.
 * 2. When producing a printable invoice image using C# and Aspose.Imaging and needing a blue oval highlight positioned away from the page center to draw attention to a field.
 * 3. When building a custom chart component in .NET that plots data points as off‑center ellipses on a 400×300 canvas using the Graphics.DrawEllipse overload.
 * 4. When automating UI mock‑up creation and requiring an off‑center oval overlay to indicate a focus area on a screenshot saved as a PNG file.
 * 5. When designing a game asset pipeline that renders off‑center ovals as part of sprite masks with Aspose.Imaging before writing the images to disk.
 */