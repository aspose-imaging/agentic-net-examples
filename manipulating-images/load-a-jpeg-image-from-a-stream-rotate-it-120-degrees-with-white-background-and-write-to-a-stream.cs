using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

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

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load JPEG image from a file stream
            using (FileStream inputStream = File.OpenRead(inputPath))
            using (JpegImage jpegImage = new JpegImage(inputStream))
            {
                // Rotate 120 degrees with white background, resizing proportionally
                jpegImage.Rotate(120f, true, Color.White);

                // Prepare JPEG save options
                JpegOptions jpegOptions = new JpegOptions();

                // Save rotated image to an output stream
                using (FileStream outputStream = File.Open(outputPath, FileMode.Create))
                {
                    jpegImage.Save(outputStream, jpegOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}