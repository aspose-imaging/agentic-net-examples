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
            // Hardcoded input and output directories
            string inputFolder = @"C:\Images\Input";
            string outputFolder = @"C:\Images\Output";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputFolder);

            // Get all GIF files in the input folder
            string[] gifFiles = Directory.GetFiles(inputFolder, "*.gif");

            foreach (string inputPath in gifFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the GIF image
                using (Image image = Image.Load(inputPath))
                {
                    // Record original file size
                    long originalSize = new FileInfo(inputPath).Length;

                    // Configure lossy compression options
                    GifOptions saveOptions = new GifOptions
                    {
                        // Recommended value for good lossy compression
                        MaxDiff = 80
                    };

                    // Prepare output path
                    string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + "_compressed.gif";
                    string outputPath = Path.Combine(outputFolder, outputFileName);

                    // Ensure the output directory exists (unconditional as required)
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the compressed GIF
                    image.Save(outputPath, saveOptions);

                    // Record compressed file size
                    long compressedSize = new FileInfo(outputPath).Length;

                    // Log sizes for analysis
                    Console.WriteLine($"{inputPath}: original {originalSize} bytes, compressed {compressedSize} bytes.");
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
 * 1. When a web developer needs to reduce the bandwidth of animated GIFs for a high‑traffic website, they can batch compress the files with Aspose.Imaging for .NET and log original versus compressed sizes to quantify the performance gain.
 * 2. When a mobile app team wants to shrink GIF assets to meet app store size limits, they can run this C# script to compress all GIFs in a folder and record file size reductions for release notes.
 * 3. When an e‑learning platform must optimize thousands of instructional GIFs for faster page loads, they can use the code to apply lossy compression with GifOptions.MaxDiff and capture size metrics for QA reporting.
 * 4. When a digital marketing agency prepares email campaigns and needs to ensure GIF attachments stay under a specific size threshold, they can batch process the images and log size comparisons to verify compliance.
 * 5. When a DevOps engineer automates a CI/CD pipeline that packages GIF resources, they can integrate this script to compress the images and output original and compressed file sizes for continuous performance monitoring.
 */