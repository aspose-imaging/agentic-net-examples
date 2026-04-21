using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "input.jpg";
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

            // Load JPEG image from a file stream
            using (FileStream inputStream = File.OpenRead(inputPath))
            using (JpegImage jpegImage = new JpegImage(inputStream))
            {
                // Rotate 120 degrees clockwise, resize proportionally, white background
                jpegImage.Rotate(120f, true, Aspose.Imaging.Color.White);

                // Save the rotated image to an output stream with default JPEG options
                using (FileStream outputStream = File.Open(outputPath, FileMode.Create))
                {
                    jpegImage.Save(outputStream, new JpegOptions());
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}