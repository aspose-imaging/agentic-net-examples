using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.png";
            string outputPath = @"C:\Images\output_resized_signed.png";
            string password = "StrongPassword123!";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Resize to 1024x768 using Bicubic (CubicConvolution) resampling
                image.Resize(1024, 768, ResizeType.CubicConvolution);

                // Embed digital signature with the provided password
                // The loaded image is a RasterImage (PngImage), so cast to access the method
                if (image is RasterImage rasterImage)
                {
                    rasterImage.EmbedDigitalSignature(password);
                }

                // Save the processed image as PNG
                var pngOptions = new PngOptions();
                image.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}