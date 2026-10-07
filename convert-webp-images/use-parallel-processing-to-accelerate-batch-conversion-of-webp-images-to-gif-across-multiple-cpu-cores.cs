// HOW-TO: Parallel Batch Convert WebP Images to GIF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

namespace WebpToGifBatch
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Hardcoded input and output directories
                string inputDirectory = "input";
                string outputDirectory = "output";

                // Get all WebP files in the input directory
                string[] webpFiles = Directory.GetFiles(inputDirectory, "*.webp");

                // Process files in parallel
                Parallel.ForEach(webpFiles, webpPath =>
                {
                    // Verify input file exists
                    if (!File.Exists(webpPath))
                    {
                        Console.Error.WriteLine($"File not found: {webpPath}");
                        return;
                    }

                    // Determine output file path
                    string outputFileName = Path.GetFileNameWithoutExtension(webpPath) + ".gif";
                    string outputPath = Path.Combine(outputDirectory, outputFileName);

                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Load WebP image
                    using (WebPImage webpImage = new WebPImage(webpPath))
                    {
                        // Save as GIF
                        GifOptions gifOptions = new GifOptions();
                        webpImage.Save(outputPath, gifOptions);
                    }
                });
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to quickly convert a large folder of WebP photos to animated GIFs using all CPU cores.
 * 2. When you want to automate image format migration for a website that only supports GIF animations.
 * 3. When you have to process user‑uploaded WebP files on a server and store them as GIFs for compatibility with older browsers.
 * 4. When you are building a desktop tool that batch‑converts product screenshots from WebP to GIF for marketing assets.
 * 5. When you need to integrate parallel image conversion into a CI pipeline to reduce build time for assets.
 */
