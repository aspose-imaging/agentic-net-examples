using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
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

            // Get all WebP files in the input directory
            string[] webpFiles = Directory.GetFiles(inputDir, "*.webp");

            // Process each file in parallel
            Parallel.ForEach(webpFiles, inputPath =>
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the output path (same file name with .gif extension)
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileNameWithoutExt + ".gif");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the WebP image and save it as GIF
                using (WebPImage webPImage = new WebPImage(inputPath))
                {
                    webPImage.Save(outputPath, new GifOptions());
                }
            });
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to quickly convert a large collection of WebP product photos to GIF animations for legacy web browsers, using parallel processing to utilize all CPU cores.
 * 2. When an e‑commerce platform must generate GIF thumbnails from user‑uploaded WebP images in bulk to improve compatibility with email newsletters.
 * 3. When a media‑archiving tool has to migrate archived WebP assets to GIF format for integration with older reporting systems, and wants to speed up the job by processing files concurrently.
 * 4. When a content‑management system requires an automated nightly job that transforms newly added WebP graphics into GIFs for use in animated banners, leveraging Aspose.Imaging’s C# API and parallel loops.
 * 5. When a digital‑marketing agency wants to batch‑process thousands of WebP ad creatives into GIFs for social‑media campaigns while minimizing conversion time by distributing the workload across multiple CPU cores.
 */