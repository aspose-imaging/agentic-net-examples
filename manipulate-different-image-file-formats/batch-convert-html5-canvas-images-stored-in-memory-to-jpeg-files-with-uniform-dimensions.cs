// HOW-TO: Batch Convert HTML5 Canvas Files to Uniform JPEG Images in C# (Aspose.Imaging for .NET)
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
            // Hard‑coded input and output directories
            string inputDir = @"C:\Images\Input";
            string outputDir = @"C:\Images\Output";

            // Ensure the output base directory exists
            Directory.CreateDirectory(outputDir);

            // List of HTML5 Canvas files to process (hard‑coded)
            string[] inputFiles = new string[]
            {
                Path.Combine(inputDir, "canvas1.html"),
                Path.Combine(inputDir, "canvas2.html"),
                Path.Combine(inputDir, "canvas3.html")
            };

            // Desired uniform dimensions for all JPEGs
            int targetWidth = 800;
            int targetHeight = 600;

            foreach (string inputPath in inputFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the Canvas image (Aspose.Imaging supports loading from HTML5 Canvas files)
                using (Image image = Image.Load(inputPath))
                {
                    // Resize to the uniform dimensions if necessary
                    if (image.Width != targetWidth || image.Height != targetHeight)
                    {
                        image.Resize(targetWidth, targetHeight);
                    }

                    // Prepare output file path
                    string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".jpg";
                    string outputPath = Path.Combine(outputDir, outputFileName);

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Configure JPEG save options
                    JpegOptions jpegOptions = new JpegOptions
                    {
                        Quality = 90
                    };

                    // Save the image as JPEG
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
 * 1. When you need to generate thumbnail JPEGs from a set of HTML5 Canvas drawings stored as .html files for a web gallery.
 * 2. When an e‑learning platform must convert user‑created canvas sketches into uniformly sized JPEGs for PDF report generation.
 * 3. When a marketing automation tool processes batch canvas advertisements and requires consistent JPEG dimensions for email campaigns.
 * 4. When a legacy system only accepts JPEG images, and you must transform canvas‑based graphics into the required format while resizing them to a standard size.
 * 5. When a desktop application needs to archive canvas artwork by converting multiple HTML5 Canvas files to JPEGs with the same width and height for storage efficiency.
 */
