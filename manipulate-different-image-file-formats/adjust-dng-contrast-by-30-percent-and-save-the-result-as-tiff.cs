using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Dng;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.dng";
            string outputPath = "output.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                DngImage dngImage = (DngImage)image;
                RasterImage raster = (RasterImage)dngImage;

                // Increase contrast by 30%
                raster.AdjustContrast(30f);

                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                raster.Save(outputPath, tiffOptions);
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
 * 1. When a photographer needs to batch‑process raw DNG files, increase their contrast by 30 % using C# and Aspose.Imaging, and save the enhanced images as lossless TIFFs for high‑quality print production.
 * 2. When a scientific imaging application must improve the visual contrast of raw sensor data stored in DNG format before converting it to TIFF for analysis in GIS or medical software.
 * 3. When a mobile‑app backend receives raw DNG uploads, applies a 30 % contrast boost with Aspose.Imaging in .NET, and archives the resulting TIFF files for regulatory compliance.
 * 4. When a digital asset management system automates the conversion of high‑dynamic‑range DNG images to TIFF while adjusting contrast to meet publishing standards using C# image processing code.
 * 5. When a developer integrates Aspose.Imaging into a C# workflow to normalize contrast of raw camera files and generate TIFFs for downstream machine‑learning pipelines.
 */