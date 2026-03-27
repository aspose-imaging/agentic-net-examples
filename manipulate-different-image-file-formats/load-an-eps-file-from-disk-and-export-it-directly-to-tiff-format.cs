using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.eps";
        string outputPath = "output\\output.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load EPS image and save as TIFF
        using (Image image = Image.Load(inputPath))
        {
            var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            image.Save(outputPath, tiffOptions);
        }
    }
}