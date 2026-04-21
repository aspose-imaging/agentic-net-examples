using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "input.eps";
        string outputPath = "output.tiff";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Load the EPS image, resize it, and save as TIFF
        using (var image = Image.Load(inputPath))
        {
            // Resize to 1024x768 using Mitchell interpolation
            image.Resize(1024, 768, ResizeType.Mitchell);

            // Prepare TIFF save options
            var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

            // Save the resized image as TIFF
            image.Save(outputPath, tiffOptions);
        }
    }
}