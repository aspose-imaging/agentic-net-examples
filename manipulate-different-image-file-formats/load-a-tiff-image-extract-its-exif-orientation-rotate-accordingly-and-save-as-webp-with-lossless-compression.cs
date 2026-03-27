using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.tif";
        string outputPath = "output.webp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the TIFF image
        using (TiffImage tiff = (TiffImage)Image.Load(inputPath))
        {
            // Extract EXIF orientation (placeholder - actual extraction depends on ExifData implementation)
            int orientation = 1; // Default orientation
            // TODO: Retrieve orientation from tiff.ExifData if needed

            // Rotate based on orientation
            switch (orientation)
            {
                case 3:
                    tiff.Rotate(180f, true, Color.Black);
                    break;
                case 6:
                    tiff.Rotate(90f, true, Color.Black);
                    break;
                case 8:
                    tiff.Rotate(270f, true, Color.Black);
                    break;
                default:
                    // No rotation needed
                    break;
            }

            // Prepare WebP options for lossless compression
            var webpOptions = new WebPOptions
            {
                Lossless = true,
                Source = new FileCreateSource(outputPath, false)
            };

            // Save the image as WebP
            tiff.Save(outputPath, webpOptions);
        }
    }
}