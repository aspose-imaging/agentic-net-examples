using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input image path
            string inputPath = @"C:\Images\sample.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Define output directory (will be used for all resized images)
            string outputDir = @"C:\Images\Resized";

            // List of resize types to evaluate
            ResizeType[] resizeTypes = new ResizeType[]
            {
                ResizeType.NearestNeighbourResample,
                ResizeType.BilinearResample,
                ResizeType.LanczosResample,
                ResizeType.HighQualityResample,
                ResizeType.CatmullRom,
                ResizeType.Mitchell
            };

            // Target dimensions for resizing
            int targetWidth = 800;
            int targetHeight = 600;

            // Store file sizes for comparison
            Dictionary<ResizeType, long> fileSizes = new Dictionary<ResizeType, long>();

            // Process each resize type
            foreach (ResizeType rtype in resizeTypes)
            {
                // Load the image
                using (Image image = Image.Load(inputPath))
                {
                    // Perform resizing with the specific resize type
                    image.Resize(targetWidth, targetHeight, rtype);

                    // Build output file path
                    string outputPath = Path.Combine(outputDir, $"sample_{rtype}.jpg");

                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save as JPEG
                    image.Save(outputPath, new JpegOptions());

                    // Record file size
                    long size = new FileInfo(outputPath).Length;
                    fileSizes[rtype] = size;
                }
            }

            // Output size comparison
            Console.WriteLine("Resize Type -> JPEG File Size (bytes)");
            foreach (var kvp in fileSizes)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
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
 * 1. When a developer needs to generate multiple thumbnail versions of a product photo for an e‑commerce site and wants to evaluate which ResizeType (NearestNeighbour, Bilinear, Lanczos, etc.) yields the smallest JPEG file while preserving acceptable visual quality.
 * 2. When a mobile app team must pre‑process user‑uploaded pictures to a fixed 800×600 resolution and compare the impact of different resampling algorithms on bandwidth consumption for faster image download.
 * 3. When a digital asset management system requires batch conversion of high‑resolution scans to web‑ready JPEGs and the developer wants to benchmark HighQualityResample versus CatmullRom to choose the optimal trade‑off between file size and detail retention.
 * 4. When an automated CI/CD pipeline includes image optimization steps and the build script needs to resize screenshots using Mitchell, Lanczos, and other ResizeType options to verify which algorithm meets the size limit for documentation PDFs.
 * 5. When a content delivery network (CDN) integration needs to store several versions of the same banner image with different resampling methods so that analytics can determine which ResizeType produces the best compression ratio for JPEG delivery across browsers.
 */