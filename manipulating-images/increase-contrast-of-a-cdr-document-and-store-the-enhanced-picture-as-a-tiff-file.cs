using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath = @"C:\temp\sample.cdr";
        string outputPath = @"C:\temp\sample_contrast.tif";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the CDR document, adjust contrast, and save as TIFF
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access AdjustContrast
            RasterImage raster = (RasterImage)image;

            // Increase contrast (value in range [-100, 100])
            raster.AdjustContrast(50f);

            // Save the result as a TIFF file with default options
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            raster.Save(outputPath, tiffOptions);
        }
    }
}