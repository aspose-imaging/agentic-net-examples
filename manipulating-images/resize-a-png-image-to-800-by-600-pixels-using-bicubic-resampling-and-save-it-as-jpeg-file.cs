using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.png";
        string outputPath = @"C:\Images\output.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PNG image
        using (Image image = Image.Load(inputPath))
        {
            // Resize to 800x600 using Bicubic (CubicConvolution) resampling
            image.Resize(800, 600, ResizeType.CubicConvolution);

            // Save as JPEG with default options
            var jpegOptions = new JpegOptions();
            image.Save(outputPath, jpegOptions);
        }
    }
}