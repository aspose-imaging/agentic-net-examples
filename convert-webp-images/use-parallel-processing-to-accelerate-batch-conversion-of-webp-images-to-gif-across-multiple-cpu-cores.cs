// HOW-TO: Parallel Batch Convert WebP Images to GIF Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
            // Hardcoded input and output directories
            string inputDir = @"C:\Images\Input";
            string outputDir = @"C:\Images\Output";

            // Verify input directory exists
            if (!Directory.Exists(inputDir))
            {
                Console.Error.WriteLine($"Input directory not found: {inputDir}");
                return;
            }

            // Get all WebP files in the input directory
            string[] webpFiles = Directory.GetFiles(inputDir, "*.webp", SearchOption.TopDirectoryOnly);

            // Process each file in parallel
            Parallel.ForEach(webpFiles, webpPath =>
            {
                // Check that the input file exists
                if (!File.Exists(webpPath))
                {
                    Console.Error.WriteLine($"File not found: {webpPath}");
                    return;
                }

                // Determine output file path (same name with .gif extension)
                string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(webpPath) + ".gif");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the WebP image using the provided rule
                using (WebPImage webpImage = new WebPImage(webpPath))
                {
                    // Save as GIF using generic save (no specific rule exists for GIF)
                    webpImage.Save(outputPath, new GifOptions());
                }

                Console.WriteLine($"Converted: {webpPath} -> {outputPath}");
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
 * 1. When you need to quickly generate GIF previews from a large collection of WebP photos on a server, this code converts them in parallel across all CPU cores.
 * 2. When migrating a website’s assets from WebP to GIF for compatibility with older browsers, the parallel batch converter speeds up the migration process.
 * 3. When building an automated image pipeline that processes incoming WebP uploads and stores them as GIFs for downstream analytics, the code handles the conversion concurrently.
 * 4. When creating a desktop utility that lets users select a folder of WebP files and instantly produces GIF versions without freezing the UI, parallel processing keeps the operation responsive.
 * 5. When performing nightly batch jobs that archive WebP screenshots as GIFs for archival systems, the parallel approach reduces total processing time on multi‑core machines.
 */
