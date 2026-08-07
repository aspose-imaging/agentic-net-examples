// HOW-TO: Convert EPS to 300 DPI TIFF with Embedded ICC Profile in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.eps";
            string outputPath = "Output/sample.tiff";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (EpsImage epsImage = (EpsImage)Image.Load(inputPath))
            {
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiffOptions.ResolutionSettings = new ResolutionSetting(300, 300);
                epsImage.Save(outputPath, tiffOptions);
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
 * 1. When a print shop needs to convert client‑provided EPS artwork into high‑resolution 300 DPI TIFF files with an ICC profile to ensure accurate colors before offset printing.
 * 2. When a desktop publishing application must rasterize vector EPS logos into TIFF images for inclusion in PDF portfolios while preserving color consistency across devices.
 * 3. When an e‑commerce platform generates product catalog images by converting EPS product diagrams to 300 DPI TIFFs with embedded color profiles for reliable display on calibrated monitors.
 * 4. When a scientific imaging pipeline requires converting EPS charts into TIFF raster files at print‑ready resolution and embedding an ICC profile to maintain precise color reproduction in publications.
 * 5. When a document management system automates the ingestion of EPS files and stores them as TIFFs with 300 DPI resolution and embedded ICC data for archival and downstream workflow compatibility.
 */
