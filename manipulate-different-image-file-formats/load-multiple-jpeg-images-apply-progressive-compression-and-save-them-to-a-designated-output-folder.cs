// HOW-TO: Batch Convert JPEGs to Progressive JPEGs in C# with Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputFolder = @"C:\Images\Input";
        string outputFolder = @"C:\Images\Output";

        try
        {
            // Get all JPEG files in the input folder
            string[] inputFiles = Directory.GetFiles(inputFolder, "*.jpg");

            foreach (string inputPath in inputFiles)
            {
                // Verify that the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Prepare the output file path
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + "_progressive.jpg";
                string outputPath = Path.Combine(outputFolder, outputFileName);

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the image
                using (Image image = Image.Load(inputPath))
                {
                    // Set JPEG options for progressive compression
                    JpegOptions saveOptions = new JpegOptions
                    {
                        CompressionType = JpegCompressionMode.Progressive,
                        Quality = 100 // Adjust quality as needed (1-100)
                    };

                    // Save the image with the specified options
                    image.Save(outputPath, saveOptions);
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
 * 1. When you need to reduce file size for web delivery by converting a folder of JPEG photos to progressive JPEGs using C#.
 * 2. When you want to automate the preparation of image assets for a photo‑gallery website, applying progressive compression to improve loading speed.
 * 3. When a desktop application must process user‑uploaded JPEGs in bulk and save optimized progressive versions to a specific output directory.
 * 4. When you are migrating legacy JPEG files to a format that supports incremental rendering for better user experience on slow connections.
 * 5. When you need to ensure all JPEG images in a batch are saved with a consistent quality setting while enabling progressive encoding for smoother display.
 */
