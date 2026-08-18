// HOW-TO: Create Fixed Size BMP Thumbnails for Gallery Display in C# (Aspose.Imaging for .NET)
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
            // Define input and output directories (relative to the current directory)
            string inputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Input");
            string outputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Output");

            // Ensure directories exist
            Directory.CreateDirectory(inputDirectory);
            Directory.CreateDirectory(outputDirectory);

            // Get all BMP files in the input directory
            string[] files = Directory.GetFiles(inputDirectory, "*.bmp");

            foreach (string inputPath in files)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Prepare output path (append "_thumb" to the file name)
                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + "_thumb.bmp");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the BMP image
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to RasterImage for resizing
                    RasterImage raster = (RasterImage)image;

                    // Cache data for better performance
                    if (!raster.IsCached)
                        raster.CacheData();

                    // Fixed thumbnail size
                    const int thumbWidth = 150;
                    const int thumbHeight = 150;

                    // Resize using nearest neighbour resampling
                    raster.Resize(thumbWidth, thumbHeight, ResizeType.NearestNeighbourResample);

                    // Save the thumbnail as BMP
                    BmpOptions bmpOptions = new BmpOptions();
                    image.Save(outputPath, bmpOptions);
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
 * 1. When building an online photo gallery that needs fast‑loading preview images from high‑resolution BMP files.
 * 2. When generating thumbnail sprites for a Windows desktop application that displays BMP icons in a grid.
 * 3. When creating printable catalog pages where each BMP product image must be reduced to a uniform 150×150 pixel preview.
 * 4. When optimizing a content management system that stores BMP uploads and requires cached, same‑size thumbnails for thumbnail browsers.
 * 5. When developing a batch processing tool that automatically resizes BMP scans to a fixed thumbnail size before uploading to a cloud storage service.
 */
