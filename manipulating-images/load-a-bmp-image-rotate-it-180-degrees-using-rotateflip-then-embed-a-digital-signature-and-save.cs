using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats; // For specific image types if needed

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.bmp";
        string outputPath = @"C:\temp\output_rotated_signed.bmp";
        string password = "myPassword";

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

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Rotate the image 180 degrees (no flip)
                image.RotateFlip(RotateFlipType.Rotate180FlipNone);

                // Embed a digital signature using the provided password
                // The EmbedDigitalSignature method is defined on RasterCachedImage
                if (image is RasterCachedImage rasterImage)
                {
                    rasterImage.EmbedDigitalSignature(password);
                }
                else if (image is RasterCachedMultipageImage rasterMultiPageImage)
                {
                    // For multipage images, embed signature on each page
                    rasterMultiPageImage.EmbedDigitalSignature(password);
                }
                else
                {
                    // If the image type does not support digital signatures, report and continue
                    Console.Error.WriteLine("The loaded image type does not support digital signature embedding.");
                }

                // Save the processed image to the output path
                image.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}