using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input/input.png";
        string outputPath = "output/output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Configure Deconvolution filter with 5x5 kernel and sigma 1.0
                var deconvOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussWienerFilterOptions();
                deconvOptions.Size = 5;   // 5x5 kernel
                deconvOptions.Sigma = 1.0; // sigma value

                raster.Filter(raster.Bounds, deconvOptions);
                raster.Save(outputPath, new PngOptions());
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
 * 1. When a developer needs to sharpen a scanned document PNG by reducing blur caused by camera shake, they can apply a 5×5 Gauss‑Wiener deconvolution filter with sigma 1.0 before saving the image.
 * 2. When processing medical X‑ray PNG files that contain subtle noise, using a 5×5 kernel and sigma 1.0 deconvolution helps enhance edge details while preserving diagnostic information.
 * 3. When preparing product photos for an e‑commerce website, a C# routine can deblur PNG images with a 5×5 deconvolution filter (sigma 1.0) to improve visual clarity without over‑sharpening.
 * 4. When restoring old scanned photographs stored as PNG, applying a 5×5 Gauss‑Wiener filter with sigma 1.0 in Aspose.Imaging can reduce motion blur and make the image look cleaner.
 * 5. When building an automated image‑processing pipeline that receives PNG uploads, developers can use the 5×5 kernel and sigma 1.0 deconvolution filter to standardize sharpness across all incoming files.
 */