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
        string inputPath = @"C:\temp\sample.jp2";
        string outputPath = @"C:\temp\sample.output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Set buffer size hint to 4 MB
        var loadOptions = new Jpeg2000LoadOptions { BufferSizeHint = 4 };

        // Load JPEG2000 image with custom buffer size
        using (Image image = Image.Load(inputPath, loadOptions))
        {
            // Save the image as PNG
            image.Save(outputPath, new PngOptions());
        }
    }
}