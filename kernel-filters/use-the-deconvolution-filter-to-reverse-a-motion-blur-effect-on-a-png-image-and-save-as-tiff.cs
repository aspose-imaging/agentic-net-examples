// HOW-TO: Remove Motion Blur from PNG and Save as TIFF Using C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input\\input.png";
        string outputPath = "Output\\output.tiff";

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
                RasterImage raster = (RasterImage)image;

                double[,] motionKernel = new double[,]
                {
                    { 0.25, 0,    0,    0,    0 },
                    { 0,    0.2,  0,    0,    0 },
                    { 0,    0,    0.1,  0,    0 },
                    { 0,    0,    0,    0.2,  0 },
                    { 0,    0,    0,    0,    0.25 }
                };

                var filterOptions = new DeconvolutionFilterOptions(motionKernel);
                raster.Filter(raster.Bounds, filterOptions);

                using (TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default))
                {
                    tiffOptions.Source = new FileCreateSource(outputPath, false);
                    raster.Save(outputPath, tiffOptions);
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
 * 1. When you need to restore a blurred PNG photo taken with camera shake and store the corrected image in a lossless TIFF for archival.
 * 2. When processing scanned documents that suffered motion blur, you can apply a deconvolution filter in C# to sharpen them before converting to TIFF for printing.
 * 3. When building an automated image pipeline that receives PNG assets with motion blur, you can clean them up and output TIFF files for downstream analysis.
 * 4. When a web service must accept blurred PNG uploads, correct them using Aspose.Imaging and return high‑quality TIFFs for client applications.
 * 5. When preparing graphics for scientific publications, you can remove motion blur from PNG microscopy images and save the results as TIFF to meet journal requirements.
 */
