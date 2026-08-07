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
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.jpg";
            string outputPath = "output.tif";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the JPEG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for pixel-level operations
                RasterImage raster = (RasterImage)image;

                // Apply emboss filter using a 3x3 kernel
                raster.Filter(
                    raster.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                        Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3));

                // Prepare TIFF save options
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

                // Save the processed image as TIFF
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
 * 1. When a developer needs to add a classic emboss effect to user‑uploaded JPEG photos before archiving them as lossless TIFF files for print‑ready workflows.
 * 2. When an application must convert scanned JPEG images into high‑resolution TIFFs while applying a 3×3 convolution emboss filter to enhance edge detail for document analysis.
 * 3. When a batch‑processing service processes product catalog JPEG images, applies an emboss filter to create a stylized preview, and saves the result in TIFF format for downstream graphics pipelines.
 * 4. When a medical imaging tool imports JPEG scans, uses Aspose.Imaging’s RasterImage to apply a 3×3 emboss convolution for visual emphasis, and exports the processed image as a TIFF for compliance with DICOM storage standards.
 * 5. When a developer builds a C# utility that validates the existence of an input JPEG, applies a 3×3 emboss filter via Aspose.Imaging, and outputs a TIFF to ensure compatibility with legacy systems that only accept TIFF files.
 */