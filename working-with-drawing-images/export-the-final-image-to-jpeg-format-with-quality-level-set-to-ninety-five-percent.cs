// HOW-TO: Convert TIFF to JPEG with 95% Quality Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace ImageConversion
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.tif";
                string outputPath = "output\\final.jpg";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    JpegOptions jpegOptions = new JpegOptions();
                    jpegOptions.Quality = 95;
                    image.Save(outputPath, jpegOptions);
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to generate web‑ready JPEG previews from high‑resolution TIFF scans while preserving most visual detail.
 * 2. When an application must automatically convert uploaded TIFF documents to compressed JPEG files for email attachment size limits.
 * 3. When a batch‑processing service creates thumbnail JPEGs from TIFF images and requires a specific 95 percent quality setting.
 * 4. When a digital‑archive system stores original TIFF files but serves JPEG copies to browsers with controlled compression.
 * 5. When a C# program integrates Aspose.Imaging to replace legacy command‑line tools for TIFF‑to‑JPEG conversion with precise quality control.
 */
