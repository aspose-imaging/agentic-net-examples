using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.tif";
        string outputPath = "output.tif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        try
        {
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 5.0));

                bool hasAlpha = ((TiffImage)image).HasAlpha;
                Console.WriteLine($"HasAlpha after blur: {hasAlpha}");

                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                image.Save(outputPath, tiffOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to verify whether a TIFF file retains its alpha channel after applying a Gaussian blur filter for downstream compositing.
 * 2. When an imaging pipeline must process high‑resolution scanned documents, blur them for noise reduction, and confirm the presence of transparency before saving as a new TIFF.
 * 3. When building a C# application that conditionally applies further image operations only if the blurred TIFF still contains an alpha channel.
 * 4. When integrating Aspose.Imaging into a batch conversion tool that blurs TIFF images and logs whether each output file preserves its alpha channel for quality control.
 * 5. When troubleshooting a GIS or medical imaging workflow to ensure that applying a Gaussian blur does not unintentionally strip the alpha channel from multi‑page TIFF datasets.
 */