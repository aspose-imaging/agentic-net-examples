using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg2000;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.jp2";
        string outputPath = "output.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set a memory buffer limit of 4 MB
            var loadOptions = new LoadOptions { BufferSizeHint = 4 };

            // Load the JPEG2000 image with the custom buffer size
            using (Image image = Image.Load(inputPath, loadOptions))
            {
                // Optional: cast to Jpeg2000Image if specific JPEG2000 features are needed
                Jpeg2000Image jp2Image = image as Jpeg2000Image;

                // Save the loaded image as PNG
                var pngOptions = new PngOptions();
                image.Save(outputPath, pngOptions);
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
 * 1. When processing large JPEG2000 satellite imagery on a server with limited RAM, a developer can load the image using a 4 MB buffer to prevent excessive memory usage before converting it to PNG for web delivery.
 * 2. When building a desktop application that batch‑converts high‑resolution medical scans from JPEG2000 to PNG on low‑end machines, setting BufferSizeHint to 4 MB ensures the app stays responsive.
 * 3. When integrating Aspose.Imaging into a cloud function that receives JPEG2000 uploads and must quickly generate PNG thumbnails, using a small buffer size reduces the function’s memory footprint and cost.
 * 4. When developing an automated archival workflow that validates the existence of input files and creates PNG versions of JPEG2000 assets while running inside a container with strict memory limits, the custom buffer helps avoid out‑of‑memory errors.
 * 5. When writing a C# utility that reads JPEG2000 images from a network share, checks the file path, and saves them as PNG for downstream processing, limiting the load buffer to 4 MB protects the utility from spikes in memory consumption.
 */