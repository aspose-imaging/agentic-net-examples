using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded paths
        string outputPath = @"C:\temp\vertical_lines.bmp";

        try
        {
            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Image dimensions
            int width = 500;
            int height = 300;
            int lineCount = 10;
            int spacing = width / (lineCount + 1);

            // Create BMP options and specify the file to create
            BmpOptions bmpOptions = new BmpOptions
            {
                BitsPerPixel = 24,
                Source = new FileCreateSource(outputPath, false)
            };

            // Create the image
            using (Image image = Image.Create(bmpOptions, width, height))
            {
                // Initialize graphics object
                Graphics graphics = new Graphics(image);

                // Thin black pen
                Pen pen = new Pen(Color.Black, 1);

                // Draw equally spaced vertical lines
                for (int i = 1; i <= lineCount; i++)
                {
                    int x = i * spacing;
                    graphics.DrawLine(pen, x, 0, x, height);
                }

                // Save the image (already linked to outputPath via FileCreateSource)
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
 * 1. When generating a simple grid overlay on a BMP chart in a C# reporting application, the code draws ten equally spaced vertical lines using Aspose.Imaging’s Graphics and Pen objects.
 * 2. When creating a placeholder BMP image with vertical separators for a web UI mock‑up, developers can use this loop to add thin black lines via Aspose.Imaging.
 * 3. When producing a test‑pattern BMP to verify printer or monitor calibration, the code provides ten evenly spaced vertical lines drawn with a 1‑pixel Pen.
 * 4. When automating the creation of a ruler‑style background BMP for a CAD or measurement tool, the loop supplies consistent vertical guides using Aspose.Imaging’s drawing API.
 * 5. When building a lightweight BMP template that requires fixed vertical guides for dynamic text or barcode placement, this example shows how to draw the lines with a thin Pen in .NET.
 */