using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tga;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.tga";
            string outputPath = "output.bmp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the TGA image
            using (TgaImage tgaImage = (TgaImage)Image.Load(inputPath))
            {
                // Preserve original bit depth and resolution
                int bitsPerPixel = tgaImage.BitsPerPixel;
                double horizontalResolution = tgaImage.HorizontalResolution;
                double verticalResolution = tgaImage.VerticalResolution;

                // Create a BMP image from the TGA raster data
                using (BmpImage bmpImage = new BmpImage(
                    tgaImage,
                    (ushort)bitsPerPixel,
                    BitmapCompression.Rgb,
                    horizontalResolution,
                    verticalResolution))
                {
                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the BMP image, preserving alpha channel if present
                    bmpImage.Save(outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}