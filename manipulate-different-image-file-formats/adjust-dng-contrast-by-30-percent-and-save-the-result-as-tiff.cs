using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dng;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.dng";
        string outputPath = "output.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load DNG image, adjust contrast, and save as TIFF
        using (Image image = Image.Load(inputPath))
        {
            DngImage dngImage = (DngImage)image;

            // Adjust contrast by 30 (range -100 to 100)
            dngImage.AdjustContrast(30f);

            // Save the result as TIFF
            using (TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default))
            {
                dngImage.Save(outputPath, tiffOptions);
            }
        }
    }
}