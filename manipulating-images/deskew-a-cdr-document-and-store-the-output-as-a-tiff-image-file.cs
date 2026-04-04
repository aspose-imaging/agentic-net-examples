using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.cdr";
        string outputPath = "output.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the CDR document and save it as a TIFF image (intermediate step)
        using (Image cdrImage = Image.Load(inputPath))
        {
            var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            cdrImage.Save(outputPath, tiffOptions);
        }

        // Load the generated TIFF as a raster image to perform deskew
        using (RasterImage raster = (RasterImage)Image.Load(outputPath))
        {
            // Deskew without resizing, using LightGray as background color
            raster.NormalizeAngle(false, Color.LightGray);
            // Overwrite the TIFF with the deskewed image
            raster.Save(outputPath);
        }
    }
}