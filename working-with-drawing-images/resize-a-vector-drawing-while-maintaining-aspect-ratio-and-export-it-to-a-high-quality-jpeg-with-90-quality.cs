using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = @"C:\Images\input.svg";
        string outputPath = @"C:\Images\output.jpg";

        try
        {
            // Verify that the source file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the vector image (SVG, EPS, CDR, etc.)
            using (Image image = Image.Load(inputPath))
            {
                // Desired width – height will be calculated to keep aspect ratio
                int targetWidth = 800;
                int targetHeight = (int)(image.Height * (targetWidth / (double)image.Width));

                // Resize using a high‑quality resampling filter
                image.Resize(targetWidth, targetHeight, ResizeType.LanczosResample);

                // Configure JPEG export options (90 % quality)
                var jpegOptions = new JpegOptions
                {
                    Quality = 90
                };

                // Save the rasterized image as JPEG
                image.Save(outputPath, jpegOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}