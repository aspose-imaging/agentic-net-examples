using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.jpg";
            string outputPath = @"C:\Images\output_resized.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the JPEG image
            using (JpegImage jpegImage = new JpegImage(inputPath))
            {
                const int maxWidth = 1200;

                // Resize only if the image is wider than the maximum width
                if (jpegImage.Width > maxWidth)
                {
                    int newWidth = maxWidth;
                    int newHeight = (int)Math.Round(jpegImage.Height * (newWidth / (double)jpegImage.Width));

                    // Perform the resize using the default resampling method
                    jpegImage.Resize(newWidth, newHeight);
                }

                // Save the resized image
                jpegImage.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}