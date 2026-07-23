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

            // Load the CDR document
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access Dither method
                RasterImage rasterImage = (RasterImage)image;

                // Apply Floyd‑Steinberg dithering with 1‑bit palette
                rasterImage.Dither(DitheringMethod.FloydSteinbergDithering, 1);

                // Prepare TIFF saving options
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    BitsPerSample = new ushort[] { 1, 1, 1 }, // 1‑bit per channel
                    Compression = TiffCompressions.None,
                    Photometric = TiffPhotometrics.MinIsWhite
                };

                // Save the dithered image as TIFF
                rasterImage.Save(outputPath, tiffOptions);
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
 * 1. When a developer needs to convert a CorelDRAW (CDR) illustration into a high‑contrast 1‑bit TIFF for laser printing or archival, they can use this code to dither and save the image.
 * 2. When a workflow requires generating black‑and‑white TIFF previews of vector designs for inclusion in PDF reports, the dithering routine ensures the preview matches the original shading.
 * 3. When an e‑commerce platform must create low‑size, monochrome thumbnails of product artwork stored as CDR files for fast web loading, this code produces the compressed TIFF.
 * 4. When a document management system must store scanned‑style copies of CDR logos in a format compatible with legacy fax machines, applying Floyd‑Steinberg dithering and saving as TIFF meets the requirement.
 * 5. When a batch‑processing tool needs to prepare CDR graphics for inclusion in a GIS raster dataset that only accepts 1‑bit TIFF layers, the code provides the necessary conversion and dithering step.
 */