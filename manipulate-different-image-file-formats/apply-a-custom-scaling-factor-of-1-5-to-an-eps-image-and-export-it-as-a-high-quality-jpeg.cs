using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.eps";
        string outputPath = "output.jpg";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load EPS image
            using (var image = (EpsImage)Image.Load(inputPath))
            {
                // Calculate new dimensions with scaling factor 1.5
                int newWidth = (int)(image.Width * 1.5);
                int newHeight = (int)(image.Height * 1.5);

                // Resize using a high-quality resampling method
                image.Resize(newWidth, newHeight, ResizeType.LanczosResample);

                // Configure high-quality JPEG options
                var jpegOptions = new JpegOptions
                {
                    Quality = 100 // Maximum quality
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