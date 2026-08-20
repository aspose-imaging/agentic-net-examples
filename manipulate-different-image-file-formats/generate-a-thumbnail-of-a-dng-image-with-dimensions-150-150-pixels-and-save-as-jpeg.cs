// HOW-TO: Create 150x150 JPEG Thumbnail From DNG Image In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dng;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input/sample.dng";
            string outputPath = "output/thumbnail.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load DNG image
            using (DngImage dng = (DngImage)Image.Load(inputPath))
            {
                // Resize to thumbnail dimensions
                dng.Resize(150, 150);

                // Save as JPEG with default options
                JpegOptions jpegOptions = new JpegOptions();
                dng.Save(outputPath, jpegOptions);
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
 * 1. When you need to display a small preview of raw camera files on a web gallery, you can generate a 150 × 150 JPEG thumbnail from a DNG image using Aspose.Imaging in C#.
 * 2. When building a digital asset management system that indexes raw photos, you can create uniform JPEG thumbnails for quick browsing without loading the full DNG files.
 * 3. When optimizing mobile apps that show photo catalogs, you can convert large DNG files to lightweight 150 × 150 JPEG thumbnails to reduce memory usage and network bandwidth.
 * 4. When preparing raw images for e‑commerce product listings, you can automatically generate small JPEG previews from DNG files to meet platform thumbnail size requirements.
 * 5. When automating batch processing of raw photography archives, you can use this code to resize each DNG to a 150 × 150 thumbnail and store it as JPEG for faster search and preview.
 */
