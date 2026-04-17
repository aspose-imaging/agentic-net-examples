using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "Input/sample.cdr";
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        string outputPath = "Output/sample.jpg";
        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the CDR file
        using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
        {
            int width = cdr.Width;
            int height = cdr.Height;

            // Configure JPEG options with custom quality and embed EXIF metadata
            JpegOptions jpegOptions = new JpegOptions
            {
                Quality = 90,
                Source = new FileCreateSource(outputPath, false)
            };

            if (cdr.ExifData != null)
            {
                jpegOptions.ExifData = cdr.ExifData;
            }

            // Create a JPEG image bound to the output file
            using (Image jpegImage = Image.Create(jpegOptions, width, height))
            {
                // Save the image (no path needed because the source is already bound)
                jpegImage.Save();
            }
        }
    }
}