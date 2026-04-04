using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = @"C:\temp\source.tif";
        string outputPath = @"C:\temp\converted.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the TIFF image
        using (Image tiffImage = Image.Load(inputPath))
        {
            // Prepare PNG save options
            var pngOptions = new PngOptions();

            // Save the image as PNG (conversion)
            tiffImage.Save(outputPath, pngOptions);
        }

        // Load the generated PNG image
        using (Image pngImage = Image.Load(outputPath))
        {
            // Cast to PngImage to access HasAlpha property
            var png = (PngImage)pngImage;

            // Log the transparency status
            Console.WriteLine($"PNG image has alpha channel: {png.HasAlpha}");
        }
    }
}