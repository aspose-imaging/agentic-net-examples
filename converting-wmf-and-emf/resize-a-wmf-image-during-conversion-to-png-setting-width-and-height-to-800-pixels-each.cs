using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\sample.wmf";
        string outputPath = @"C:\Images\Resized\sample.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the WMF image, resize it, and save as PNG
        using (WmfImage wmfImage = (WmfImage)Image.Load(inputPath))
        {
            // Resize to 800x800 using nearest neighbour resampling
            wmfImage.Resize(800, 800, ResizeType.NearestNeighbourResample);

            // Save the resized image as PNG
            wmfImage.Save(outputPath, new PngOptions());
        }
    }
}