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
        string inputPath = @"input\sample.wmf";
        string outputPath = @"output\sample_resized.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Desired dimensions
        int newWidth = 200;
        int newHeight = 200;

        // Load the WMF image, resize, and save as PNG
        using (Image image = Image.Load(inputPath))
        {
            // Cast to WmfImage to access Resize method
            WmfImage wmfImage = (WmfImage)image;

            // Resize using nearest neighbour resampling
            wmfImage.Resize(newWidth, newHeight, Aspose.Imaging.ResizeType.NearestNeighbourResample);

            // Save the resized image as PNG
            wmfImage.Save(outputPath, new PngOptions());
        }
    }
}