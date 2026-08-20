// HOW-TO: Create JPEG2000 Image With Red Rectangle Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg2000;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define output path
            string outputPath = Path.Combine("Output", "sample.jp2");
            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create JPEG2000 options
            Jpeg2000Options options = new Jpeg2000Options();
            options.Irreversible = true; // use irreversible DWT

            // Create a new JPEG2000 image with specified size and options
            using (Jpeg2000Image jpeg2000Image = new Jpeg2000Image(200, 200, options))
            {
                // Draw a red rectangle covering the whole image
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(jpeg2000Image);
                SolidBrush brush = new SolidBrush(Aspose.Imaging.Color.Red);
                graphics.FillRectangle(brush, jpeg2000Image.Bounds);
                // Save the image
                jpeg2000Image.Save(outputPath);
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
 * 1. When a developer needs to generate a JPEG2000 placeholder image with a solid color for testing compression pipelines.
 * 2. When an application must programmatically create a red‑filled JPEG2000 thumbnail for a medical imaging workflow.
 * 3. When a server‑side service has to produce a JPEG2000 banner image on the fly for dynamic PDF reports.
 * 4. When a QA script requires a reproducible JPEG2000 file to validate image‑processing algorithms in C#.
 * 5. When a developer wants to embed a simple graphic into a JPEG2000 file before adding custom metadata for later verification.
 */
