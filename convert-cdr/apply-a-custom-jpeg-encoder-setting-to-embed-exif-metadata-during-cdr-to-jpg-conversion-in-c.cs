using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Exif;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.cdr";
            string outputPath = @"C:\Images\sample_output.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR (CorelDRAW) file
            using (Image image = Image.Load(inputPath))
            {
                // Configure JPEG options
                var jpegOptions = new JpegOptions
                {
                    Quality = 90 // example quality setting
                };

                // Create and populate EXIF metadata
                var exifData = new JpegExifData
                {
                    Make = "MyCompany",
                    Model = "CDRtoJPG Converter",
                    Software = "Aspose.Imaging",
                    // Additional EXIF fields can be set here as needed
                };

                // Assign EXIF data to JPEG options
                jpegOptions.ExifData = exifData;

                // Save the image as JPEG with the custom options
                image.Save(outputPath, jpegOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}