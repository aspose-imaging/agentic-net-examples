using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.wmf";
        string outputPath = @"C:\Images\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load WMF image, resize, and save as PNG
        using (WmfImage wmf = (WmfImage)Image.Load(inputPath))
        {
            // Desired dimensions
            int newWidth = 800;
            int newHeight = 600;

            // Resize with high-quality Lanczos resampling
            wmf.Resize(newWidth, newHeight, ResizeType.LanczosResample);

            // PNG save options
            PngOptions pngOptions = new PngOptions();

            // Save the resized image as PNG
            wmf.Save(outputPath, pngOptions);
        }
    }
}