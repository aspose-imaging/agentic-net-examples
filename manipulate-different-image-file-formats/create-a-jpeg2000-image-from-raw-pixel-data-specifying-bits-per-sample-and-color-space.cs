// HOW-TO: Create JPEG2000 Image From Raw Pixels With Specified Bit Depth In C# (Aspose.Imaging for .NET)
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
            // Output file path (hardcoded)
            string outputPath = "output.jp2";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Image dimensions and bits per sample
            int width = 100;
            int height = 100;
            int bitsPerSample = 8; // bits count per pixel

            // Create a JPEG2000 image with specified bits per sample
            using (Jpeg2000Image jpeg2000Image = new Jpeg2000Image(width, height, bitsPerSample))
            {
                // Draw onto the image
                Graphics graphics = new Graphics(jpeg2000Image);
                using (SolidBrush brush = new SolidBrush(Color.Red))
                {
                    graphics.FillRectangle(brush, jpeg2000Image.Bounds);
                }

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
 * 1. When you need to generate a JPEG2000 file from generated pixel data in a C# application, such as creating a thumbnail or preview for a medical imaging workflow.
 * 2. When you must control the bit depth of each sample (e.g., 8‑bit or 16‑bit) to meet compression or quality requirements for archival image storage.
 * 3. When you want to programmatically fill a JPEG2000 canvas with a solid color or custom graphics before saving, using Aspose.Imaging’s drawing API.
 * 4. When integrating image generation into a server‑side service that outputs JPEG2000 files for web or cloud delivery, ensuring the output directory is created automatically.
 * 5. When testing or prototyping color space handling by creating a JPEG2000 image with a known bits‑per‑sample value to verify downstream processing pipelines.
 */
