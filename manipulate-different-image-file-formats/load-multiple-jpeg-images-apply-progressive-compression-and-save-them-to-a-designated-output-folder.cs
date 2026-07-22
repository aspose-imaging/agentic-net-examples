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
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + "_prog.jpg";
                string outputPath = Path.Combine(outputFolder, outputFileName);

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the image, apply progressive JPEG compression, and save
                using (Image image = Image.Load(inputPath))
                {
                    JpegOptions saveOptions = new JpegOptions
                    {
                        CompressionType = Aspose.Imaging.FileFormats.Jpeg.JpegCompressionMode.Progressive,
                        Quality = 100 // Adjust quality as needed (1-100)
                    };

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
 * 1. When a developer needs to batch‑convert a folder of JPEG photos into progressive JPEGs to reduce page load times for a website, this code can automate the process using Aspose.Imaging for .NET.
 * 2. When an e‑commerce platform must generate progressive JPEG thumbnails for product images to improve perceived loading speed on mobile devices, the sample shows how to load, compress, and save them in C#.
 * 3. When a digital asset management system requires re‑encoding existing JPEG assets with progressive compression to meet archival standards, the code demonstrates bulk processing with JpegOptions.
 * 4. When a photo‑sharing app wants to shrink bandwidth usage by converting user‑uploaded JPEGs to progressive format while preserving quality, this example illustrates the necessary file‑system and image‑processing steps.
 * 5. When a developer is preparing a set of marketing banners for email campaigns and needs to ensure they are saved as progressive JPEGs for better compatibility with email clients, the snippet provides a ready‑to‑use C# solution.
 */