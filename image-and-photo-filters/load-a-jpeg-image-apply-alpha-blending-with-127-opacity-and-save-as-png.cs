using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.jpg";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the JPEG image
            using (JpegImage jpegImage = new JpegImage(inputPath))
            {
                // Create a blank background image with the same dimensions
                using (RasterImage background = (RasterImage)Image.Create(new PngOptions(), jpegImage.Width, jpegImage.Height))
                {
                    // Blend the JPEG onto the background with 127 (≈50%) opacity
                    background.Blend(new Aspose.Imaging.Point(0, 0), jpegImage, 127);

                    // Save the result as PNG
                    background.Save(outputPath, new PngOptions());
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}