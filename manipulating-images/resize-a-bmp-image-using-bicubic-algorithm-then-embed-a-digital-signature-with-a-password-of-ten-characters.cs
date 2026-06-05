using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.bmp";
        string outputPath = "output.bmp";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists (null-safe)
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
                Directory.CreateDirectory(outputDir);

            // Load BMP as RasterImage
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Example resize: reduce dimensions by half using Bicubic (CubicConvolution) algorithm
                int newWidth = image.Width / 2;
                int newHeight = image.Height / 2;
                image.Resize(newWidth, newHeight, ResizeType.CubicConvolution);

                // Embed digital signature with a 10‑character password
                string password = "TenCharPwd";
                image.EmbedDigitalSignature(password);

                // Save the processed image as BMP
                image.Save(outputPath, new BmpOptions());
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}