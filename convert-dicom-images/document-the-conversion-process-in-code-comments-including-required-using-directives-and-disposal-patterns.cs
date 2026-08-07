using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = Path.Combine("Input", "sample.jpg");
        string outputPath = Path.Combine("Output", "sample.tif");

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Configure TIFF save options (using default format)
                using (TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default))
                {
                    // Save the image as a TIFF file
                    image.Save(outputPath, tiffOptions);
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
 * 1. When a developer needs to convert user‑uploaded JPEG photos to lossless TIFF files for archival storage using C# and Aspose.Imaging.
 * 2. When an application must ensure that image files are saved in a format compatible with printing workflows, such as converting JPEG to TIFF before sending to a print service.
 * 3. When a document management system requires batch conversion of JPEG scans to TIFF files, and the code provides a simple per‑file conversion pattern.
 * 4. When a medical imaging solution needs to transform diagnostic JPEG images into TIFF format to meet regulatory compliance and preserve image fidelity.
 * 5. When a web service processes incoming image payloads and must store them as TIFF files on disk while handling missing files and directory creation gracefully.
 */