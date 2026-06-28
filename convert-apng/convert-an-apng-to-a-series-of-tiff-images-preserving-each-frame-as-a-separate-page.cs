using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.apng";
        string outputPath = "output.tif";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the APNG image
            using (Image loadedImage = Image.Load(inputPath))
            {
                // Cast to ApngImage to access frames
                ApngImage apngImage = (ApngImage)loadedImage;

                // Prepare TIFF options (default format)
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
                tiffOptions.Photometric = TiffPhotometrics.Rgb;
                tiffOptions.Compression = TiffCompressions.Lzw;

                // Create the first TIFF frame from the first APNG frame
                RasterImage firstRaster = (RasterImage)apngImage.Pages[0];
                TiffFrame firstTiffFrame = new TiffFrame(firstRaster);

                // Create a multi‑page TIFF image with the first frame
                using (TiffImage tiffImage = new TiffImage(firstTiffFrame))
                {
                    // Add remaining frames as additional pages
                    for (int i = 1; i < apngImage.PageCount; i++)
                    {
                        RasterImage raster = (RasterImage)apngImage.Pages[i];
                        TiffFrame tiffFrame = new TiffFrame(raster);
                        tiffImage.AddFrame(tiffFrame);
                    }

                    // Save the multi‑page TIFF
                    tiffImage.Save(outputPath);
                }
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
 * 1. When a developer must archive every frame of an animated PNG (APNG) as separate pages in a losslessly compressed multi‑page TIFF for long‑term document storage, this code provides a straightforward C# solution using Aspose.Imaging.
 * 2. When a workflow requires converting APNG animations into individual TIFF pages to feed legacy printing systems that only accept multi‑page TIFF files, the example demonstrates how to preserve frame order and color fidelity.
 * 3. When an image‑processing pipeline needs to extract raster data from each APNG frame and apply LZW compression in a single TIFF document for efficient bandwidth transfer, the code shows the necessary C# operations.
 * 4. When a developer is building a digital asset management tool that indexes each animation frame as a searchable TIFF page, this snippet illustrates how to load the APNG, iterate its pages, and create a multi‑page TIFF with Aspose.Imaging.
 * 5. When a compliance‑driven application must convert animated web graphics into a standardized, non‑animated format for audit trails, the example provides a ready‑to‑use method to transform APNG frames into a single TIFF file in .NET.
 */