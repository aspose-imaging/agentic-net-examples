// HOW-TO: Convert OTG to BMP and Apply Otsu Threshold in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.otg";
        string bmpOutputPath = "output.bmp";
        string binaryOutputPath = "output_binary.bmp";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(bmpOutputPath) ?? string.Empty);
            Directory.CreateDirectory(Path.GetDirectoryName(binaryOutputPath) ?? string.Empty);

            // Load the OTG image
            using (Image otgImage = Image.Load(inputPath))
            {
                // Prepare rasterization options for OTG to BMP conversion
                OtgRasterizationOptions otgRasterOptions = new OtgRasterizationOptions
                {
                    PageSize = otgImage.Size // preserve original size
                };

                // Set BMP save options and attach rasterization options
                BmpOptions bmpOptions = new BmpOptions
                {
                    VectorRasterizationOptions = otgRasterOptions
                };

                // Save as BMP
                otgImage.Save(bmpOutputPath, bmpOptions);
            }

            // Load the generated BMP as a raster image
            using (Image bmpImage = Image.Load(bmpOutputPath))
            {
                // Cast to RasterImage to access BinarizeOtsu
                if (bmpImage is RasterImage rasterImage)
                {
                    // Apply Otsu thresholding to create a binary image
                    rasterImage.BinarizeOtsu();

                    // Save the binary BMP
                    rasterImage.Save(binaryOutputPath, new BmpOptions());
                }
                else
                {
                    Console.Error.WriteLine("Loaded image is not a raster image.");
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
 * 1. When you need to rasterize a vector OTG diagram into a BMP for legacy Windows applications.
 * 2. When you want to generate a high‑contrast black‑and‑white version of a BMP for OCR preprocessing.
 * 3. When you must preserve the original page size while converting OTG files to a bitmap format for printing.
 * 4. When you need to automate batch conversion of OTG assets to binary BMPs for machine‑vision pipelines.
 * 5. When you are integrating Aspose.Imaging into a C# service that extracts binary masks from vector drawings.
 */
