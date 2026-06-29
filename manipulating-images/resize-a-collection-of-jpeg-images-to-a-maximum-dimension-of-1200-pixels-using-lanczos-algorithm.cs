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
            string inputDir = @"C:\Images\Input\";
            string outputDir = @"C:\Images\Output\";

            // Get all JPEG files in the input directory
            string[] inputFiles = Directory.GetFiles(inputDir, "*.jpg");

            foreach (string inputPath in inputFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the JPEG image
                using (Image image = Image.Load(inputPath))
                {
                    // Determine scaling factor to keep the maximum dimension at 1200 pixels
                    double scale = 1.0;
                    if (image.Width > image.Height && image.Width > 1200)
                    {
                        scale = 1200.0 / image.Width;
                    }
                    else if (image.Height >= image.Width && image.Height > 1200)
                    {
                        scale = 1200.0 / image.Height;
                    }

                    // Calculate new dimensions
                    int newWidth = (int)Math.Round(image.Width * scale);
                    int newHeight = (int)Math.Round(image.Height * scale);

                    // Resize using Lanczos algorithm if scaling is needed
                    if (scale < 1.0)
                    {
                        image.Resize(newWidth, newHeight, ResizeType.LanczosResample);
                    }

                    // Prepare output path
                    string outputPath = Path.Combine(outputDir, Path.GetFileName(inputPath));

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the resized image (preserving JPEG format)
                    image.Save(outputPath);
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
 * 1. When a developer needs to batch‑resize a folder of JPEG photos to a maximum width or height of 1200 px for faster web page loading, they can use this Aspose.Imaging C# code with the Lanczos algorithm.
 * 2. When preparing product catalog images for an e‑commerce platform, the code helps ensure all JPEG files are uniformly scaled down to 1200 px while preserving quality through Lanczos resampling.
 * 3. When automating the creation of thumbnail galleries for a photo‑sharing site, the snippet processes every JPEG in a directory, resizing each to fit within 1200 px before saving to an output folder.
 * 4. When a mobile app backend must compress user‑uploaded JPEGs to meet a 1200‑pixel dimension limit for storage efficiency, developers can employ this C# routine to resize images on the server side.
 * 5. When migrating legacy JPEG assets to a content‑delivery network, the program quickly normalizes image dimensions to 1200 px using Aspose.Imaging’s ResizeType.LanczosResample, ensuring consistent display across devices.
 */