// HOW-TO: Batch Convert JPEGs To Progressive Compression In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputFolder = "InputImages";
            string outputFolder = "OutputImages";

            if (!Directory.Exists(inputFolder))
            {
                Directory.CreateDirectory(inputFolder);
                Console.WriteLine($"Input directory created at: {inputFolder}. Add files and rerun.");
                return;
            }

            Directory.CreateDirectory(outputFolder);

            var jpegFiles = Directory.GetFiles(inputFolder, "*.*")
                .Where(f => f.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) || f.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase))
                .ToArray();

            foreach (var inputPath in jpegFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputFolder, fileName + ".jpg");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    JpegOptions jpegOptions = new JpegOptions
                    {
                        CompressionType = JpegCompressionMode.Progressive,
                        Quality = 90
                    };
                    image.Save(outputPath, jpegOptions);
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
 * 1. When you need to reduce file size of a large collection of JPEG photos for faster web page loading by converting them to progressive JPEGs using C#.
 * 2. When an e‑commerce platform wants to batch‑process product images to enable progressive rendering on browsers while maintaining quality.
 * 3. When a digital asset management system must archive thousands of JPEG files with progressive compression to save storage space.
 * 4. When a mobile app backend needs to prepare user‑uploaded JPEGs for progressive download to improve perceived performance on slow networks.
 * 5. When a photo‑editing workflow requires automatically applying a specific JPEG quality level and progressive mode to all images in a folder via Aspose.Imaging.
 */
