using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\canvas.png";
        string outputPath = @"C:\Images\canvas_gamma.jpg";

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

            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access AdjustGamma
                var rasterImage = (RasterImage)image;

                // Apply gamma correction (2.2)
                rasterImage.AdjustGamma(2.2f);

                // Set JPEG options with quality 90
                var jpegOptions = new JpegOptions
                {
                    Quality = 90
                };

                // Save as JPEG
                rasterImage.Save(outputPath, jpegOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}