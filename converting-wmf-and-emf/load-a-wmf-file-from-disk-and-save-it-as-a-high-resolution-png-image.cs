using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.wmf";
        string outputPath = "output.png";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load WMF image, resize for higher resolution, and save as PNG
        using (WmfImage wmfImage = (WmfImage)Image.Load(inputPath))
        {
            // Increase dimensions (e.g., 3x) for higher resolution output
            int newWidth = wmfImage.Width * 3;
            int newHeight = wmfImage.Height * 3;
            wmfImage.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);

            // Set PNG save options
            PngOptions pngOptions = new PngOptions();

            // Save the rasterized PNG
            wmfImage.Save(outputPath, pngOptions);
        }
    }
}