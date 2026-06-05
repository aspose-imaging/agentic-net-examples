using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = @"C:\Images\source.png";
            string outputPath = @"C:\Images\resized_signed.png";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Secure password for the digital signature
            string password = "StrongPassword123!";

            // Load the PNG image, resize it using Bicubic (CubicConvolution) resampling,
            // embed the digital signature, and save the result.
            using (Image image = Image.Load(inputPath))
            {
                // Resize to 1024x768 with Bicubic resampling
                image.Resize(1024, 768, ResizeType.CubicConvolution);

                // Embed the digital signature (method defined on RasterImage)
                ((RasterImage)image).EmbedDigitalSignature(password);

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