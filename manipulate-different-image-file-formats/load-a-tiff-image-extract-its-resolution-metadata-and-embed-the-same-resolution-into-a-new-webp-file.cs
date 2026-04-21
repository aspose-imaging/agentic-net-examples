using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.tif";
        string outputPath = @"C:\Images\output.webp";

        // Ensure any runtime exception is reported cleanly
        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TIFF image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to TiffImage to access resolution properties
                TiffImage tiffImage = (TiffImage)image;

                // Extract horizontal and vertical resolution
                double horizontalResolution = tiffImage.HorizontalResolution;
                double verticalResolution = tiffImage.VerticalResolution;

                // Apply the same resolution to the image (ensures it is stored in the output)
                tiffImage.SetResolution(horizontalResolution, verticalResolution);

                // Prepare WebP save options
                WebPOptions webpOptions = new WebPOptions
                {
                    // Example: lossless compression; adjust as needed
                    Lossless = true
                };

                // Save the image as WebP with the embedded resolution
                image.Save(outputPath, webpOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}