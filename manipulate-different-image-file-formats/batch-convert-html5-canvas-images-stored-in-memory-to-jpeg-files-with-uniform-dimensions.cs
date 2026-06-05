using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input and output directories (relative paths)
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            // Ensure input directory exists
            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Get all files in the input directory
            string[] files = Directory.GetFiles(inputDirectory);

            // Target dimensions for all output JPEG images
            const int targetWidth = 800;
            const int targetHeight = 600;

            foreach (string inputPath in files)
            {
                // Validate input file existence
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Prepare output path with .jpg extension
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".jpg");

                // Ensure the output directory for this file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the source image
                using (Image image = Image.Load(inputPath))
                {
                    // Resize to uniform dimensions using nearest neighbour resampling
                    image.Resize(targetWidth, targetHeight, ResizeType.NearestNeighbourResample);

                    // Configure JPEG save options
                    JpegOptions jpegOptions = new JpegOptions
                    {
                        Quality = 90
                    };

                    // Save the resized image as JPEG
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
 * 1. When a web application needs to export user‑drawn HTML5 Canvas sketches from a server‑side cache to standardized 800 × 600 JPEG files for download or sharing, a developer can use this C# batch conversion code with Aspose.Imaging.
 * 2. When an e‑commerce platform must generate product‑preview images from dynamically created canvas graphics and store them as uniform‑size JPEGs for faster page loads, this code automates the resizing and format conversion.
 * 3. When a reporting tool has to archive daily canvas‑based dashboards as JPEG screenshots with consistent dimensions for compliance records, the Aspose.Imaging C# routine batches the conversion and saves them to a designated folder.
 * 4. When a machine‑learning pipeline requires a dataset of canvas‑generated images all resized to the same width and height before training, developers can employ this code to bulk convert the in‑memory PNG/WEBP files to JPEGs.
 * 5. When an email marketing system needs to embed canvas‑created promotional banners as JPEG attachments that meet size limits, the developer can run this C# script to resize and convert the images in one pass.
 */