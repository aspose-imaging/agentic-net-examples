using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Jpeg2000;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "Input/source.png";
        string outputPath = "Output/result.jp2";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PNG image
        using (PngImage pngImage = (PngImage)Image.Load(inputPath))
        {
            // Convert to JPEG2000 using the raster image constructor
            using (Jpeg2000Image jpeg2000Image = new Jpeg2000Image(pngImage))
            {
                // Configure JPEG2000 options for lossless compression and memory limit
                Jpeg2000Options options = new Jpeg2000Options
                {
                    // Irreversible = false (default) ensures lossless DWT 5-3 compression
                    Irreversible = false,
                    // Set memory buffer limit (e.g., 50 MB)
                    BufferSizeHint = 50
                };

                // Save the JPEG2000 image with the specified options
                jpeg2000Image.Save(outputPath, options);
            }
        }
    }
}