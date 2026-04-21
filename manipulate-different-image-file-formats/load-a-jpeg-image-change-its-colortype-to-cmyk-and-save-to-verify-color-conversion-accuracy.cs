using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.jpg";
        string outputPath = @"C:\Images\output.cmyk.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the JPEG image
        using (Image image = Image.Load(inputPath))
        {
            // Prepare JPEG save options with CMYK color type
            var saveOptions = new JpegOptions
            {
                ColorType = JpegCompressionColorMode.Cmyk
                // Additional options (e.g., Quality) can be set here if needed
            };

            // Save the image as CMYK JPEG
            image.Save(outputPath, saveOptions);
        }
    }
}