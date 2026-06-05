using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Jpeg2000;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"c:\temp\input.png";
            string outputPath = @"c:\temp\output.jp2";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the bitmap source (PNG in this example)
            using (PngImage pngImage = (PngImage)Image.Load(inputPath))
            {
                // Create JPEG2000 image from the loaded PNG image
                using (Jpeg2000Image jpeg2000Image = new Jpeg2000Image(pngImage))
                {
                    // Configure JPEG2000 options for lossless compression (default)
                    Jpeg2000Options options = new Jpeg2000Options();
                    // Irreversible = false by default, which uses lossless DWT 5-3

                    // Save the JPEG2000 image
                    jpeg2000Image.Save(outputPath, options);
                }
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
 * 1. When a developer needs to convert high‑resolution PNG screenshots to lossless JPEG2000 files for archival storage while preserving exact pixel data.
 * 2. When an application must generate JPEG2000 assets from bitmap images for a medical imaging system that requires lossless compression to meet DICOM standards.
 * 3. When a web service processes user‑uploaded PNG graphics and needs to deliver them as compact, lossless JPEG2000 files to reduce bandwidth without sacrificing quality.
 * 4. When a batch‑processing tool automates the migration of legacy PNG assets to JPEG2000 format for a digital publishing workflow that mandates lossless image preservation.
 * 5. When a C# program integrates Aspose.Imaging to create JPEG2000 images from bitmap sources for a GIS application that relies on lossless wavelet compression for accurate map rendering.
 */