using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg2000;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output file path
            string outputPath = "output.jp2";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Create JPEG2000 options
            Jpeg2000Options options = new Jpeg2000Options
            {
                Irreversible = true,
                Codec = Aspose.Imaging.FileFormats.Jpeg2000.Jpeg2000Codec.J2K
            };

            // Create a new JPEG2000 image, draw a red rectangle
            using (Jpeg2000Image image = new Jpeg2000Image(100, 100, options))
            {
                Graphics graphics = new Graphics(image);
                SolidBrush brush = new SolidBrush(Color.Red);
                graphics.FillRectangle(brush, image.Bounds);
                image.Save(outputPath);
            }

            // Load the saved image and verify it exists
            string inputPath = outputPath;
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (Jpeg2000Image loaded = new Jpeg2000Image(inputPath))
            {
                Console.WriteLine("Image loaded successfully.");
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
 * 1. When a developer needs to programmatically generate a JPEG2000 image with a solid red rectangle as a placeholder or test graphic using Aspose.Imaging in C#.
 * 2. When a developer wants to create a lossy JPEG2000 file for high‑resolution satellite or medical imagery preprocessing before uploading it to a GIS or DICOM system.
 * 3. When a developer must verify that a JPEG2000 image saved with Jpeg2000Options can be successfully loaded again without corruption as part of an automated batch‑processing workflow.
 * 4. When a developer is building a document conversion service that embeds simple graphics into JPEG2000 files to meet archival or industry‑specific file‑format requirements.
 * 5. When a developer needs to test the integration of Aspose.Imaging’s Jpeg2000Options and Graphics API to ensure correct rendering of shapes before scaling images for print or web delivery.
 */