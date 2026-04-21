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
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Resize to 800x600 using Bicubic (CubicConvolution) resampling
                image.Resize(800, 600, ResizeType.CubicConvolution);

                // Prepare JPEG save options (default quality)
                JpegOptions jpegOptions = new JpegOptions
                {
                    Quality = 100
                };

                // Save as JPEG
                image.Save(outputPath, jpegOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}