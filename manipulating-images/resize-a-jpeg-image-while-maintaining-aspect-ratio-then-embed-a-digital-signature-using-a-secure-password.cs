using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.jpg";
            string outputPath = "output.jpg";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists (null-safe)
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Load the JPEG image
            using (Image image = Image.Load(inputPath))
            {
                // Desired width while preserving aspect ratio
                int targetWidth = 800;
                double aspectRatio = (double)image.Height / image.Width;
                int newWidth = targetWidth;
                int newHeight = (int)(targetWidth * aspectRatio);

                // Resize the image
                image.Resize(newWidth, newHeight);

                // Save the resized image as JPEG
                JpegOptions jpegOptions = new JpegOptions();
                image.Save(outputPath, jpegOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}