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
            // Hardcoded input and output directories
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            // Ensure input directory exists; create if missing and exit
            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            // Get all JPEG files in the input directory
            string[] inputFiles = Directory.GetFiles(inputDirectory, "*.jpg");
            foreach (string inputPath in inputFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build output thumbnail path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + "_thumb.jpg");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the JPEG image
                using (Image image = Image.Load(inputPath))
                {
                    // Process only raster images
                    if (image is RasterImage raster)
                    {
                        // Cache data for better performance
                        if (!raster.IsCached)
                            raster.CacheData();

                        // Resize to thumbnail size (e.g., 150x150) using nearest neighbour resampling
                        raster.Resize(150, 150, ResizeType.NearestNeighbourResample);

                        // Set JPEG save options (quality 75)
                        JpegOptions jpegOptions = new JpegOptions
                        {
                            Quality = 75
                        };

                        // Save the thumbnail
                        raster.Save(outputPath, jpegOptions);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}