using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputFolder = @"C:\Images\Input";
            string outputFolder = @"C:\Images\Output";

            // Retrieve all JPEG files from the input folder
            string[] inputFiles = Directory.GetFiles(inputFolder, "*.jpg");

            foreach (string inputPath in inputFiles)
            {
                // Verify that the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the corresponding output file path
                string fileName = Path.GetFileName(inputPath);
                string outputPath = Path.Combine(outputFolder, fileName);

                // Ensure the output directory exists (unconditional per requirement)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the image
                using (Image image = Image.Load(inputPath))
                {
                    // Configure progressive JPEG save options
                    JpegOptions saveOptions = new JpegOptions
                    {
                        CompressionType = Aspose.Imaging.FileFormats.Jpeg.JpegCompressionMode.Progressive,
                        Quality = 100
                    };

                    // Save the image with the specified options
                    image.Save(outputPath, saveOptions);
                }
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to batch‑process a folder of JPEG photos to create progressive JPEGs for faster web page loading using C# and Aspose.Imaging.
 * 2. When an e‑commerce platform must convert product images to progressive JPEG format to improve perceived loading speed on mobile browsers while preserving full quality.
 * 3. When a digital asset management system requires automated conversion of legacy JPEG files into progressive JPEGs for efficient storage and streaming in a .NET application.
 * 4. When a content delivery pipeline needs to generate progressive JPEG versions of marketing banners before uploading them to a CDN, using Image.Load and JpegOptions in C#.
 * 5. When a photo‑sharing website wants to re‑encode user‑uploaded JPEGs as progressive JPEGs in bulk to reduce bandwidth consumption without changing the original filenames, leveraging Aspose.Imaging’s JPEG compression mode.
 */