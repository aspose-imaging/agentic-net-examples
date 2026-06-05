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
            // Output BMP file path
            string outputPath = @"C:\temp\output.bmp";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set BMP options with a file source bound to the output path
            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            // Create a new image canvas
            using (Image image = Image.Create(bmpOptions, 200, 100))
            {
                // Initialize graphics for drawing
                Graphics graphics = new Graphics(image);

                // Draw a black line
                graphics.DrawLine(new Pen(Color.Black, 2), new Point(10, 50), new Point(100, 50));

                // Apply scaling transform to double horizontal length
                graphics.ScaleTransform(2.0f, 1.0f);

                // Draw a red line (will appear twice as long horizontally)
                graphics.DrawLine(new Pen(Color.Red, 2), new Point(10, 70), new Point(100, 70));

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
 * 1. Use this code when you must generate a BMP image in C# with Aspose.Imaging, draw baseline lines, and then double their horizontal length via Graphics.ScaleTransform for technical diagrams.
 * 2. This approach is useful for creating printable barcode templates where a black reference line is drawn and a red guide line is stretched to twice its width to match scaling requirements.
 * 3. Developers building UI mock‑ups can employ the snippet to produce BMP assets that contain original and scaled lines, illustrating how UI elements will appear after horizontal scaling.
 * 4. When exporting simple graph plots to BMP, the code lets you draw an axis line and then render a second line that is automatically doubled in length to represent amplified data series.
 * 5. The example is ideal for generating test images for image‑processing pipelines, where a known black line and a scaled red line in a BMP file serve as reference patterns for verifying scaling algorithms.
 */