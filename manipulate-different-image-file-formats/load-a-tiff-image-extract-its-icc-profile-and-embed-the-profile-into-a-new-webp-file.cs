using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "Input\\sample.tif";
        string outputPath = "Output\\sample.webp";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the TIFF image
        using (Image tiffImage = Image.Load(inputPath))
        {
            // Cast to RasterImage to access pixel data
            RasterImage raster = tiffImage as RasterImage;
            if (raster == null)
            {
                Console.Error.WriteLine("The loaded image is not a raster image.");
                return;
            }

            // Create WebP options and preserve metadata (including ICC profile)
            WebPOptions webpOptions = new WebPOptions
            {
                KeepMetadata = true
            };

            // Create a WebP image from the raster image
            using (WebPImage webpImage = new WebPImage(raster))
            {
                // Save the WebP image with the specified options
                webpImage.Save(outputPath, webpOptions);
            }
        }
    }
}