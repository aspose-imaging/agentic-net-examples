using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Jpeg2000;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\source.png";
            string outputPath = @"C:\temp\output.jp2";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG source image
            using (PngImage pngImage = new PngImage(inputPath))
            {
                // Configure JPEG2000 options for lossless compression and buffer size hint
                Jpeg2000Options jpegOptions = new Jpeg2000Options
                {
                    Irreversible = false,               // lossless DWT 5-3
                    BufferSizeHint = 4 * 1024 * 1024    // 4 MB buffer limit
                };

                // Create a JPEG2000 image from the PNG raster
                using (Jpeg2000Image jpeg2000Image = new Jpeg2000Image(pngImage))
                {
                    // Save the JPEG2000 image with the specified options
                    jpeg2000Image.Save(outputPath, jpegOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}