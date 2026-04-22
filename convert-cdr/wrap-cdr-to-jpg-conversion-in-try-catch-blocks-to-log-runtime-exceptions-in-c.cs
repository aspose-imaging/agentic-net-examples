using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Global exception handling to prevent crashes
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\Images\sample.cdr";
            string outputPath = @"C:\Images\output.jpg";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Conversion specific exception handling
            try
            {
                // Load the CDR file
                using (Image image = Image.Load(inputPath))
                {
                    // Set JPEG save options (default settings)
                    JpegOptions jpegOptions = new JpegOptions();

                    // Save the image as JPEG
                    image.Save(outputPath, jpegOptions);
                }
            }
            catch (Exception ex)
            {
                // Log any errors that occur during conversion
                Console.Error.WriteLine($"Conversion error: {ex.Message}");
            }
        }
        catch (Exception ex)
        {
            // Log any unexpected errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}