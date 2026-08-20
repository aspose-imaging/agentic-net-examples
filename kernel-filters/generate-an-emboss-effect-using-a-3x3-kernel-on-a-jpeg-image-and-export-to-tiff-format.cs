// HOW-TO: Apply 3x3 Emboss Filter to JPEG and Save as TIFF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            string outputPath = "output\\output.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Apply emboss filter using a 3x3 kernel
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

                // Save the result as TIFF
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
 * 1. When a developer needs to add a classic emboss effect to user‑uploaded JPEG photos before archiving them as lossless TIFF files for printing or long‑term storage.
 * 2. When an application must convert scanned JPEG images into TIFF while applying a 3x3 convolution filter to highlight edges for document analysis.
 * 3. When a batch‑processing tool requires automated embossing of product images in JPEG format and saving the results in TIFF to preserve quality for catalog generation.
 * 4. When a photo‑editing service wants to apply a quick emboss transformation using Aspose.Imaging’s ConvolutionFilter.Emboss3x3 and output the edited image as a TIFF for compatibility with desktop publishing software.
 * 5. When a developer is building a workflow that reads JPEG assets, applies a 3x3 kernel effect for artistic styling, and stores the final images as TIFF to maintain pixel data for further processing.
 */
