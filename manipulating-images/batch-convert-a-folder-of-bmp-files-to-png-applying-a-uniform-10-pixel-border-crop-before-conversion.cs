using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Define base, input, and output directories
        string baseDir = Directory.GetCurrentDirectory();
        string inputDirectory = Path.Combine(baseDir, "Input");
        string outputDirectory = Path.Combine(baseDir, "Output");

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

        // Get all BMP files in the input directory
        string[] files = Directory.GetFiles(inputDirectory, "*.bmp");

        foreach (string inputPath in files)
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Prepare output path
            string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
            string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".png");

            // Ensure output directory for this file exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the BMP image
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                // Cast to RasterImage for cropping
                Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)image;

                // Cache data for performance
                if (!raster.IsCached)
                    raster.CacheData();

                // Define crop rectangle (10-pixel border on each side)
                int cropX = 10;
                int cropY = 10;
                int cropWidth = raster.Width - 20;
                int cropHeight = raster.Height - 20;

                // Skip if image is too small to crop
                if (cropWidth <= 0 || cropHeight <= 0)
                {
                    Console.Error.WriteLine($"Image too small to crop: {inputPath}");
                    continue;
                }

                Aspose.Imaging.Rectangle cropRect = new Aspose.Imaging.Rectangle(cropX, cropY, cropWidth, cropHeight);
                raster.Crop(cropRect);

                // Save as PNG with default options
                using (var options = new PngOptions())
                {
                    image.Save(outputPath, options);
                }
            }
        }
    }
}