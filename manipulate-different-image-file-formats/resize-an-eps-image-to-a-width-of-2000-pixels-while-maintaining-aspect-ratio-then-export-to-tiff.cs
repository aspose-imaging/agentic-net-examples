using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.eps";
        string outputPath = "output.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load EPS image, resize proportionally, and save as TIFF
        using (var image = (Aspose.Imaging.FileFormats.Eps.EpsImage)Image.Load(inputPath))
        {
            int targetWidth = 2000;
            double scale = (double)targetWidth / image.Width;
            int targetHeight = (int)Math.Round(image.Height * scale);

            // Resize using nearest neighbour resampling
            image.Resize(targetWidth, targetHeight, ResizeType.NearestNeighbourResample);

            // Save to TIFF with default options
            var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            image.Save(outputPath, tiffOptions);
        }
    }
}