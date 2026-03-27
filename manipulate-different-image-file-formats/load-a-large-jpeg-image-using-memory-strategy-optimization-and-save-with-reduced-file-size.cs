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
        string inputPath = @"C:\Images\large_input.jpg";
        string outputPath = @"C:\Images\output\large_output.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the JPEG image with memory‑strategy optimization
        var loadOptions = new LoadOptions { BufferSizeHint = 10 * 1024 * 1024 }; // 10 MB buffer

        using (Image image = Image.Load(inputPath, loadOptions))
        {
            // Configure JPEG save options to reduce file size
            var jpegOptions = new JpegOptions
            {
                Quality = 75, // Reduce quality to lower size
                CompressionType = JpegCompressionMode.Progressive,
                ColorType = JpegCompressionColorMode.Grayscale,
                BufferSizeHint = 5 * 1024 * 1024 // 5 MB buffer for saving
            };

            // Save the image with the specified options
            image.Save(outputPath, jpegOptions);
        }
    }
}