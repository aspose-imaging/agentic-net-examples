using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tga;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.tga";
        string outputPath = "output.tga";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the TGA image, apply motion blur, and save the result
        using (Image image = Image.Load(inputPath))
        {
            // Cast to TgaImage to access format-specific members
            TgaImage tgaImage = (TgaImage)image;

            // Apply motion blur using MotionWienerFilterOptions (length, smooth, angle)
            tgaImage.Filter(
                tgaImage.Bounds,
                new Aspose.Imaging.ImageFilters.FilterOptions.MotionWienerFilterOptions(10, 1.0, 90.0));

            // Save the processed image as TGA
            tgaImage.Save(outputPath, new TgaOptions());
        }
    }
}