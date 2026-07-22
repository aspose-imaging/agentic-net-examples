using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\input.tif";
            string outputPath = @"C:\temp\output.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TIFF image
            using (Image image = Image.Load(inputPath))
            {
                // Save as JPEG with default options
                image.Save(outputPath, new JpegOptions());
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
 * 1. When a developer needs to batch‑convert scanned TIFF documents to JPEG for web preview using C# and Aspose.Imaging.
 * 2. When an application must reduce storage costs by loading a high‑resolution TIFF image and saving it as a JPEG with default compression via Image.Load and JpegOptions.
 * 3. When a legacy system outputs TIFF files and a modern .NET service has to deliver them as JPEG to browsers, requiring file existence checks and directory creation.
 * 4. When a photo‑management tool imports TIFF photos and stores them as JPEG for mobile compatibility, leveraging Aspose.Imaging's Image.Save method.
 * 5. When an automated workflow validates the presence of a TIFF file, ensures the output folder exists, and converts the image to JPEG using C# and Aspose.Imaging default settings.
 */