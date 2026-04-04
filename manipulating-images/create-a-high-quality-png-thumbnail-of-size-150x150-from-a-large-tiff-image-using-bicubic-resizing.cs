using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\large.tif";
        string outputPath = @"C:\Images\thumb.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the TIFF image, cast to TiffImage for TIFF‑specific operations
        using (TiffImage image = (TiffImage)Image.Load(inputPath))
        {
            // Resize to 150x150 using bicubic (CubicConvolution) resampling
            image.Resize(150, 150, ResizeType.CubicConvolution);

            // Save the resized image as PNG
            image.Save(outputPath, new PngOptions());
        }
    }
}