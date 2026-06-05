using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.tif";
            string outputPath = "output\\output.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TIFF image
            using (TiffImage image = (TiffImage)Image.Load(inputPath))
            {
                // Resize using Lanczos resampling (example: double size)
                int newWidth = image.Width * 2;
                int newHeight = image.Height * 2;
                image.Resize(newWidth, newHeight, ResizeType.LanczosResample);

                // Embed digital signature with a password longer than four characters
                image.EmbedDigitalSignature("secure123");

                // Save the processed image
                image.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}