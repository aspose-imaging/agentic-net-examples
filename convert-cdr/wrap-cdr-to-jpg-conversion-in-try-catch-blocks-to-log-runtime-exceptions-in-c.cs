using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.cdr";
        string outputPath = @"C:\Images\output.jpg";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR file
            using (Image image = Image.Load(inputPath))
            {
                // Configure JPEG save options
                var jpegOptions = new JpegOptions
                {
                    Quality = 90 // Adjust quality as needed
                };

                // Save the image as JPEG
                image.Save(outputPath, jpegOptions);
            }
        }
        catch (Exception ex)
        {
            // Log any runtime exceptions
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}