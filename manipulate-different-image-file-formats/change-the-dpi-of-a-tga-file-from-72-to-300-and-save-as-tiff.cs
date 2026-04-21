using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tga;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "Input\\sample.tga";
        string outputPath = "Output\\sample.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the TGA image
        using (TgaImage tgaImage = (TgaImage)Image.Load(inputPath))
        {
            // Change DPI from 72 to 300
            tgaImage.HorizontalResolution = 300;
            tgaImage.VerticalResolution = 300;

            // Prepare TIFF save options
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

            // Save the image as TIFF with the new DPI
            tgaImage.Save(outputPath, tiffOptions);
        }
    }
}