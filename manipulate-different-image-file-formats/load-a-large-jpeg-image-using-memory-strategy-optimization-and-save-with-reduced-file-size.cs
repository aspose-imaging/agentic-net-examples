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
        string inputPath = "input\\large.jpg";
        string outputPath = "output\\large_compressed.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the JPEG image with memory‑usage optimization
        var loadOptions = new LoadOptions { BufferSizeHint = 100 }; // limit internal buffers to 100 MB

        using (Image image = Image.Load(inputPath, loadOptions))
        {
            // Set JPEG options to reduce file size
            var jpegOptions = new JpegOptions
            {
                Quality = 70, // lower quality for smaller size
                CompressionType = JpegCompressionMode.Progressive
            };

            // Save the image using the configured options
            image.Save(outputPath, jpegOptions);
        }
    }
}