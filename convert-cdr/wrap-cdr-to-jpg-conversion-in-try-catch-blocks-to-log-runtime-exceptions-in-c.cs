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

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists (creates if missing)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the CDR file using Aspose.Imaging
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
            // Log any runtime exceptions that occur during conversion
            Console.Error.WriteLine($"Error converting CDR to JPG: {ex.Message}");
        }
    }
}