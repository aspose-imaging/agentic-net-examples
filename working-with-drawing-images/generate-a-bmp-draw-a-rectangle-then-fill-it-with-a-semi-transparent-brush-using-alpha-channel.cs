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
        // Hardcoded output path
        string outputPath = @"C:\temp\output.bmp";

        try
        {
            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set BMP options and bind to the output file
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create a new image canvas (500x500)
            using (Image image = Image.Create(bmpOptions, 500, 500))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);

                // Define rectangle bounds
                Rectangle rect = new Rectangle(50, 50, 200, 150);

                // Draw rectangle outline with a blue pen
                graphics.DrawRectangle(new Pen(Color.Blue, 3), rect);

                // Fill rectangle with a semi‑transparent red brush
                using (SolidBrush brush = new SolidBrush())
                {
                    brush.Color = Color.Red;
                    brush.Opacity = 0.5f; // 50% opacity
                    graphics.FillRectangle(brush, rect);
                }

                // Save the image (output path already bound)
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
 * 1. When a developer needs to generate a 24‑bit BMP thumbnail with a highlighted rectangular area for a legacy Windows reporting tool that only accepts BMP files.
 * 2. When a developer wants to programmatically add a blue‑bordered rectangle filled with a semi‑transparent red overlay to indicate selection or focus in a desktop UI mockup using C# and Aspose.Imaging.
 * 3. When a developer must create a BMP asset for an embedded system where a rectangular safety warning with 50 % opacity is required to preserve underlying image details.
 * 4. When a developer is building an automated batch process that stamps rectangular markers with adjustable alpha blending onto scanned documents saved as BMP for archival compatibility.
 * 5. When a developer needs to produce a BMP diagram that demonstrates layering effects by drawing a rectangle outline and filling it with a semi‑transparent brush to teach image‑processing concepts in a C# tutorial.
 */