using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        try
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

            // Load the CDR document
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access Dither method
                RasterImage raster = (RasterImage)image;

                // Apply Floyd‑Steinberg dithering with 1‑bit palette
                raster.Dither(DitheringMethod.FloydSteinbergDithering, 1);

                // Save the dithered image as TIFF
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
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
 * 1. When a developer needs to convert a CorelDRAW CDR illustration into a 1‑bit black‑and‑white TIFF for high‑contrast printing, they can use this code to apply Floyd‑Steinberg dithering before saving.
 * 2. When preparing archival copies of vector artwork in a lossless TIFF format while preserving fine details through dithering, this C# snippet using Aspose.Imaging handles the CDR to TIFF conversion.
 * 3. When an application must generate low‑resolution preview images of CDR files for web thumbnails that require a binary palette, the code demonstrates how to dither and export as TIFF.
 * 4. When integrating a document processing pipeline that receives CDR files and needs to output printer‑ready TIFFs with halftone simulation, developers can employ this raster‑image dithering approach.
 * 5. When automating batch conversion of multiple CDR designs into TIFF files with consistent 1‑bit dithering for fax transmission, the example shows the necessary file checks, raster conversion, and saving steps in .NET.
 */