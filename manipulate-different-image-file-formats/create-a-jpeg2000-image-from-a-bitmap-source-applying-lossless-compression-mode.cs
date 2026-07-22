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
            string inputPath = "C:\\temp\\source.bmp";
            string outputPath = "C:\\temp\\output.jp2";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the bitmap source
            using (Image sourceImage = Image.Load(inputPath))
            {
                // Configure JPEG2000 options for lossless compression (default)
                Jpeg2000Options options = new Jpeg2000Options();

                // Save as JPEG2000 using the configured options
                sourceImage.Save(outputPath, options);
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
 * 1. When a developer needs to convert legacy BMP files to a compact, lossless JPEG2000 format for archival storage while preserving pixel fidelity.
 * 2. When an application must generate JPEG2000 images from bitmap assets to meet medical imaging standards that require lossless compression.
 * 3. When a batch processing tool has to ensure that scanned documents are saved as JPEG2000 files to reduce disk usage without sacrificing quality.
 * 4. When a C# service needs to prepare high‑resolution graphics for web delivery using JPEG2000’s lossless mode to maintain exact colors for branding assets.
 * 5. When a developer wants to integrate Aspose.Imaging into a workflow that validates input files, creates missing directories, and saves the image as a JPEG2000 file with default lossless settings.
 */