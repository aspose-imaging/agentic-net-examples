using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.tif";
        string outputPath = @"C:\Images\output_resized_signed.tif";

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
            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                // Define new dimensions (example: half the original size)
                int newWidth = tiffImage.Width / 2;
                int newHeight = tiffImage.Height / 2;

                // Resize using Lanczos resampling
                tiffImage.Resize(newWidth, newHeight, ResizeType.LanczosResample);

                // Embed a digital signature with a password longer than four characters
                tiffImage.EmbedDigitalSignature("StrongPass123");

                // Save the processed image
                tiffImage.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}