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
            // Hardcoded input and output paths
            string inputPath = "input.jpg";
            string outputPath = "output.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load JPEG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage for filtering
                RasterImage raster = (RasterImage)image;

                // Apply emboss filter using 3x3 kernel
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

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
 * 1. When a developer needs to convert a high‑resolution JPEG photograph to a lossless TIFF while adding a 3×3 emboss effect for printing or archival purposes.
 * 2. When an e‑commerce platform wants to generate stylized product thumbnails by applying an emboss filter to uploaded JPEG images before storing them as TIFF files for downstream workflows.
 * 3. When a medical imaging application requires preprocessing of JPEG scans with edge‑enhancement (emboss) and saving the result in TIFF to maintain compatibility with DICOM converters.
 * 4. When a desktop publishing tool automates batch processing of user‑provided JPEG artwork, applying a 3×3 convolution emboss kernel and exporting the output as TIFF for high‑quality layout rendering.
 * 5. When a developer builds a document management system that needs to preserve original image quality by converting JPEGs to TIFF after applying an emboss filter to highlight texture details for visual inspection.
 */