using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\large.tif";
            string outputDirectory = @"C:\Images\WebPOutput";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Load the multi‑page TIFF image
            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                // Process each page sequentially to keep memory usage low
                for (int pageIndex = 0; pageIndex < tiffImage.PageCount; pageIndex++)
                {
                    // Retrieve the current page (loaded on demand)
                    using (Image page = tiffImage.Pages[pageIndex])
                    {
                        // Build output file path for the current page
                        string outputPath = Path.Combine(outputDirectory, $"page_{pageIndex}.webp");

                        // Ensure the directory for the output file exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the page as WebP
                        var webpOptions = new WebPOptions(); // default options; adjust if needed
                        page.Save(outputPath, webpOptions);
                    }

                    // Force garbage collection to release page resources promptly
                    GC.Collect();
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}