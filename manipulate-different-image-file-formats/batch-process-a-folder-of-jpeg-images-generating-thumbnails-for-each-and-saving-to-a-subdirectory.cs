using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output directories
        string inputDirectory = "Input";
        string outputDirectory = Path.Combine("Output", "Thumbnails");

        // Ensure input and output directories exist
        if (!Directory.Exists(inputDirectory))
        {
            Directory.CreateDirectory(inputDirectory);
            Console.WriteLine($"Input directory created at: {inputDirectory}. Add JPEG files and rerun.");
            return;
        }

        if (!Directory.Exists(outputDirectory))
        {
            Directory.CreateDirectory(outputDirectory);
        }

        // Get all JPEG files in the input directory
        string[] files = Directory.GetFiles(inputDirectory, "*.*", SearchOption.TopDirectoryOnly);
        foreach (string filePath in files)
        {
            // Process only .jpg or .jpeg extensions
            string extension = Path.GetExtension(filePath).ToLowerInvariant();
            if (extension != ".jpg" && extension != ".jpeg")
                continue;

            // Validate input file existence
            if (!File.Exists(filePath))
            {
                Console.Error.WriteLine($"File not found: {filePath}");
                return;
            }

            // Build output thumbnail path
            string outputPath = Path.Combine(outputDirectory,
                Path.GetFileNameWithoutExtension(filePath) + "_thumb.jpg");

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image, create thumbnail, and save
            using (Image image = Image.Load(filePath))
            {
                RasterImage raster = (RasterImage)image;
                if (!raster.IsCached)
                    raster.CacheData();

                // Define thumbnail width and compute proportional height
                int thumbWidth = 150;
                int thumbHeight = (int)(raster.Height * (thumbWidth / (double)raster.Width));

                raster.Resize(thumbWidth, thumbHeight);

                JpegOptions jpegOptions = new JpegOptions
                {
                    Quality = 80
                };

                raster.Save(outputPath, jpegOptions);
            }
        }
    }
}