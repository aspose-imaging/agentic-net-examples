using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg2000;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageLoadOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"c:\temp\sample.jp2";
        string outputPath = @"c:\temp\sample.output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Configure load options to limit memory usage
        var loadOptions = new Jpeg2000LoadOptions
        {
            BufferSizeHint = 50,               // Limit internal buffers to 50 MB
            ConcurrentImageProcessing = false // Disable concurrent processing to reduce memory pressure
        };

        // Load the JPEG2000 image with the specified options
        using (Image img = Image.Load(inputPath, loadOptions))
        {
            // Cast to Jpeg2000Image for type‑specific operations (if needed)
            var jpeg2000Image = img as Jpeg2000Image;
            if (jpeg2000Image == null)
            {
                Console.Error.WriteLine("Failed to load JPEG2000 image.");
                return;
            }

            // Save the image as PNG using default PNG options
            jpeg2000Image.Save(outputPath, new PngOptions());
        }
    }
}