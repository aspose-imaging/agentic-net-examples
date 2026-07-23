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
            // Hardcoded list of input image files
            string[] inputFiles = new[]
            {
                @"C:\Images\image1.jpg",
                @"C:\Images\image2.png",
                @"C:\Images\image3.bmp"
            };

            foreach (string inputPath in inputFiles)
            {
                // Verify that the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the output file path (same folder, prefixed with "resized_", PNG format)
                string outputPath = Path.Combine(
                    Path.GetDirectoryName(inputPath),
                    "resized_" + Path.GetFileNameWithoutExtension(inputPath) + ".png");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the image, resize width to 400 pixels while preserving aspect ratio, and save as PNG
                using (Image image = Image.Load(inputPath))
                {
                    image.ResizeWidthProportionally(400, ResizeType.NearestNeighbourResample);
                    image.Save(outputPath, new PngOptions());
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
 * 1. When a developer needs to generate web‑ready thumbnails from a mixed set of JPEG, PNG, and BMP files by resizing each image to a fixed width of 400 px while keeping the original height proportionally and outputting PNG files for consistent compression.
 * 2. When an e‑commerce platform must batch‑process product photos stored locally, converting them to a uniform 400‑pixel width PNG to ensure fast page loads and consistent image quality across browsers.
 * 3. When a content management system needs to prepare user‑uploaded images for email newsletters, automatically resizing them to 400 px wide, preserving aspect ratio, and saving as PNG to avoid lossy artifacts.
 * 4. When a desktop application that archives scanned documents must normalize the width of scanned JPEG, PNG, and BMP images to 400 px before storing them as lossless PNG files for archival compliance.
 * 5. When a developer builds a batch image‑conversion utility in C# that scans a folder, checks file existence, resizes each image to a 400‑pixel width using nearest‑neighbour resampling, and saves the results as PNG for downstream processing.
 */