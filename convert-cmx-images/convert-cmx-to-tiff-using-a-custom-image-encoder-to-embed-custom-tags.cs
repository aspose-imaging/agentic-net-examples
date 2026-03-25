using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Input\sample.cmx";
        string outputPath = @"C:\Output\sample.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the CMX file
        using (Image cmxImage = Image.Load(inputPath))
        {
            // Configure TIFF options with a custom tag (ImageDescription)
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            tiffOptions.ImageDescription = "Converted from CMX with custom tag";

            // Save as TIFF using the configured options
            cmxImage.Save(outputPath, tiffOptions);
        }
    }
}