using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "input.eps";
        string outputPath = "output.jpg";

        // Verify that the input EPS file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists (creates it if necessary)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the EPS image
        using (Image image = Image.Load(inputPath))
        {
            // Calculate new dimensions applying a scaling factor of 1.5
            int newWidth = (int)(image.Width * 1.5);
            int newHeight = (int)(image.Height * 1.5);

            // Resize the image using a high‑quality interpolation method
            image.Resize(newWidth, newHeight, ResizeType.LanczosResample);

            // Configure JPEG options for high quality output
            var jpegOptions = new JpegOptions
            {
                Quality = 100,                     // Maximum quality
                CompressionType = Aspose.Imaging.FileFormats.Jpeg.JpegCompressionMode.Progressive,
                // Additional high‑quality settings can be added here if needed
            };

            // Save the resized image as a JPEG file
            image.Save(outputPath, jpegOptions);
        }
    }
}