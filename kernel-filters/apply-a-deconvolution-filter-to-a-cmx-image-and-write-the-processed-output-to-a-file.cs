using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.cmx";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        string outputDir = Path.GetDirectoryName(outputPath);
        Directory.CreateDirectory(outputDir ?? ".");

        // Load the CMX image
        using (Image image = Image.Load(inputPath))
        {
            // Attempt to treat the loaded image as a raster image for filtering
            RasterImage rasterImage = image as RasterImage;

            // If the image is not raster (CMX is vector), render it to a temporary raster format
            if (rasterImage == null)
            {
                string tempPath = Path.Combine(Path.GetTempPath(), "temp.png");
                image.Save(tempPath);
                using (Image tempImg = Image.Load(tempPath))
                {
                    rasterImage = tempImg as RasterImage;
                }
                // Clean up the temporary file
                File.Delete(tempPath);
            }

            // Apply a Gauss‑Wiener deconvolution filter if we have a raster image
            if (rasterImage != null)
            {
                rasterImage.Filter(rasterImage.Bounds, new GaussWienerFilterOptions(5, 4.0));
                rasterImage.Save(outputPath);
            }
        }
    }
}