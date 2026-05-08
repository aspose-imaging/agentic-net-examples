using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.tif";
            string outputPath = "thumbnail.webp";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TIFF image
            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                // Create a thumbnail (max width 150 pixels, preserve aspect ratio)
                int thumbWidth = 150;
                int thumbHeight = (int)(tiffImage.Height * ((float)thumbWidth / tiffImage.Width));

                tiffImage.Resize(thumbWidth, thumbHeight, ResizeType.NearestNeighbourResample);

                // Save the thumbnail as a WebP file
                tiffImage.Save(outputPath, new WebPOptions());
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}