using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input\\sample.jpg";
        string outputPath = "Output\\sample_emboss.tif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to apply filter
                RasterImage raster = (RasterImage)image;

                // 3x3 emboss kernel
                double[,] kernel = new double[,]
                {
                    { -2, -1, 0 },
                    { -1,  1, 1 },
                    {  0,  1, 2 }
                };

                // Apply convolution filter with emboss kernel
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(kernel));

                // Save the result as TIFF
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                image.Save(outputPath, tiffOptions);
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
 * 1. When a developer needs to add a stylized emboss effect to product photos stored as JPEGs before archiving them in lossless TIFF format for high‑quality print catalogs.
 * 2. When an application must automatically enhance scanned documents by applying a 3×3 emboss kernel to highlight edges and then save the result as a TIFF file for OCR preprocessing.
 * 3. When a web service processes user‑uploaded JPEG images, applies a convolution filter for artistic embossing, and returns the transformed image in TIFF to preserve detail for downstream graphics pipelines.
 * 4. When a batch‑processing tool converts a folder of JPEG screenshots into embossed TIFF images to create visually distinct assets for UI mock‑up documentation.
 * 5. When a developer integrates Aspose.Imaging in a C# workflow to apply custom convolution kernels for image sharpening or embossing and needs to export the final output to a TIFF file for archival compliance.
 */