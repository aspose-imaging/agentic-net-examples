using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageLoadOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.jp2";
        string outputPath = @"C:\Images\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load JPEG2000 image with a 4 MB buffer size hint
        var loadOptions = new Jpeg2000LoadOptions
        {
            BufferSizeHint = 4 // Buffer size in megabytes
        };

        using (Image image = Image.Load(inputPath, loadOptions))
        {
            // Save the loaded image as PNG
            image.Save(outputPath, new PngOptions());
        }
    }
}