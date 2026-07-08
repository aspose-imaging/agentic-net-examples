using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg2000;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.jp2";
            string outputPath = "output.jpg";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);

            // Load JPEG2000 image
            using (Jpeg2000Image jpeg2000Image = (Jpeg2000Image)Image.Load(inputPath))
            {
                // Set memory buffer hint (1 MB)
                jpeg2000Image.BufferSizeHint = 1 * 1024 * 1024;

                // Define full image rectangle
                Rectangle rect = new Rectangle(0, 0, jpeg2000Image.Width, jpeg2000Image.Height);

                // Load ARGB32 pixels
                int[] pixels = jpeg2000Image.LoadArgb32Pixels(rect);

                // Invert colors
                for (int i = 0; i < pixels.Length; i++)
                {
                    int argb = pixels[i];
                    int a = (argb >> 24) & 0xFF;
                    int r = 255 - ((argb >> 16) & 0xFF);
                    int g = 255 - ((argb >> 8) & 0xFF);
                    int b = 255 - (argb & 0xFF);
                    pixels[i] = (a << 24) | (r << 16) | (g << 8) | b;
                }

                // Save modified pixels back
                jpeg2000Image.SaveArgb32Pixels(rect, pixels);

                // Save as JPEG with 85% quality
                JpegOptions jpegOptions = new JpegOptions
                {
                    Quality = 85
                };
                jpeg2000Image.Save(outputPath, jpegOptions);
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
 * 1. When a developer needs to convert high‑resolution JPEG2000 medical scans to smaller JPEG files for web preview while preserving color fidelity, they can load the JP2 image, apply pixel‑level processing, and save it as JPEG with 85 % quality using Aspose.Imaging for .NET.
 * 2. When an application must batch‑process satellite imagery stored in JPEG2000 format, invert the colors for false‑color analysis, and output compressed JPEGs for quick sharing, this C# code demonstrates the required steps.
 * 3. When a digital asset management system requires on‑the‑fly conversion of uploaded JP2 files to JPEG with a specific quality setting and limited memory usage (1 MB buffer), the example shows how to set BufferSizeHint and perform the conversion.
 * 4. When a developer is building a photo‑editing tool that needs to read JPEG2000 pictures, apply custom pixel transformations such as color inversion, and then export the result as a JPEG with adjustable compression, the code provides a ready‑to‑use pattern.
 * 5. When an e‑commerce platform wants to generate lightweight JPEG thumbnails from large JPEG2000 product images while controlling memory consumption and output quality, this snippet illustrates the complete workflow in C# with Aspose.Imaging.
 */