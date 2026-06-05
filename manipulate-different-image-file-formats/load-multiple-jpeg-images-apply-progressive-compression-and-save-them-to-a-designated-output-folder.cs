using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output folders
        string inputFolder = @"C:\Images\Input";
        string outputFolder = @"C:\Images\Output";

        try
        {
            // Get all JPEG files in the input folder
            string[] inputFiles = Directory.GetFiles(inputFolder, "*.jpg");

            foreach (string inputPath in inputFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the image
                using (Image image = Image.Load(inputPath))
                {
                    // Configure JPEG save options with progressive compression
                    JpegOptions saveOptions = new JpegOptions
                    {
                        CompressionType = JpegCompressionMode.Progressive,
                        Quality = 100
                    };

                    // Build the output file path
                    string fileName = Path.GetFileNameWithoutExtension(inputPath);
                    string outputPath = Path.Combine(outputFolder, fileName + "_progressive.jpg");

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the image with the specified options
                    image.Save(outputPath, saveOptions);
                }
            }
        }
        catch (Exception ex)
        {
            // Report any unexpected errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a web developer needs to batch‑convert a gallery of high‑resolution JPEG photos into progressive JPEGs to reduce perceived load time on browsers, they can use this code.
 * 2. When an e‑commerce platform wants to automatically generate optimized product images with progressive compression before uploading them to a CDN, the snippet provides the necessary C# workflow.
 * 3. When a digital archivist must preserve a collection of scanned JPEG files while making them web‑friendly by applying lossless progressive encoding, this code handles the bulk processing.
 * 4. When a mobile app backend processes user‑uploaded JPEGs and needs to store smaller, progressively rendered versions for faster preview rendering, the example demonstrates how to achieve it with Aspose.Imaging.
 * 5. When a marketing team automates the preparation of email campaign assets by converting multiple JPEG banners to progressive format to improve email client rendering, the program offers a straightforward solution.
 */