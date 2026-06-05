using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.dng";
        string outputPath = "output.tif";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                raster.AdjustContrast(30f);

                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
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
 * 1. When a photographer needs to batch‑process raw DNG files to increase contrast by 30 % and archive the results as lossless TIFFs for print production.
 * 2. When a scientific imaging application must enhance the visual detail of raw sensor data (DNG) before converting it to a widely supported TIFF format for analysis in third‑party tools.
 * 3. When a mobile app backend receives raw camera captures (DNG) and must apply a contrast boost and store the images as TIFF to preserve quality for later editing.
 * 4. When an e‑commerce platform wants to automatically improve product photo contrast from raw DNG uploads and save them as TIFF files for high‑resolution catalog listings.
 * 5. When a digital archiving system needs to normalize contrast across legacy DNG scans and convert them to TIFF to ensure long‑term compatibility with archival standards.
 */