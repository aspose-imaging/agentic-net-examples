using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dng;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.dng";
            string outputPath = "output.jpg";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir);

            // Load DNG image, resize, and save as JPEG
            using (Image image = Image.Load(inputPath))
            {
                DngImage dng = (DngImage)image;
                dng.Resize(150, 150);
                JpegOptions jpegOptions = new JpegOptions
                {
                    Quality = 90
                };
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
 * 1. When a photographer wants to create web‑ready preview thumbnails from high‑resolution DNG raw files using C# and Aspose.Imaging.
 * 2. When an e‑commerce platform needs to generate 150×150 pixel JPEG thumbnails for product images stored as DNG to improve page load speed.
 * 3. When a digital asset management system must automatically convert raw camera files to small JPEG previews for quick browsing in a .NET application.
 * 4. When a mobile app backend processes uploaded DNG photos and needs to store low‑size JPEG thumbnails for display in galleries.
 * 5. When a batch processing script has to validate DNG file existence, resize it, and save a high‑quality JPEG thumbnail for archival or reporting purposes.
 */