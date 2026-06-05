using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\sample.cdr";
        string outputPath = @"C:\temp\sample_dithered.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the CDR document
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access Dither method
                RasterImage raster = (RasterImage)image;

                // Apply Floyd‑Steinberg dithering with 1‑bit palette
                raster.Dither(DitheringMethod.FloydSteinbergDithering, 1);

                // Save the dithered image as TIFF
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
 * 1. When a developer needs to convert a CorelDRAW (CDR) illustration into a 1‑bit black‑and‑white TIFF for archival printing on legacy dot‑matrix printers, they can use this code to apply Floyd‑Steinberg dithering and preserve visual detail.
 * 2. When an application must generate low‑color‑depth TIFF thumbnails from CDR files for a web gallery that only supports monochrome images, this snippet provides the required dithering and format conversion.
 * 3. When a document management system requires storing vector CDR assets as compact, searchable TIFF files with binary palettes for compliance with industry standards, the code enables the necessary rasterization and dithering.
 * 4. When a batch‑processing tool needs to prepare CDR artwork for laser‑etched signage that only accepts 1‑bit TIFF inputs, developers can employ this example to automate the dithering and saving steps.
 * 5. When a digital preservation workflow demands converting multi‑color CDR designs into lossless TIFF files with Floyd‑Steinberg dithering to ensure consistent rendering across different operating systems, this code fulfills the requirement.
 */