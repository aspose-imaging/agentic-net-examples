// HOW-TO: Apply Median Filter to ODG Image and Save as JPEG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.odg";
            string outputPath = "Output/sample.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Rasterize ODG to PNG
            string tempPngPath = Path.Combine(Path.GetDirectoryName(outputPath), "temp.png");
            Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));

            using (Image vectorImage = Image.Load(inputPath))
            {
                var pngOptions = new PngOptions();
                vectorImage.Save(tempPngPath, pngOptions);
            }

            // Apply median filter and save as JPEG
            using (RasterImage raster = (RasterImage)Image.Load(tempPngPath))
            {
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(3));

                var jpegOptions = new JpegOptions();
                raster.Save(outputPath, jpegOptions);
            }

            // Cleanup temporary file
            if (File.Exists(tempPngPath))
            {
                File.Delete(tempPngPath);
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
 * 1. When you need to reduce noise in an OpenDocument Graphics (ODG) diagram before exporting it as a high‑quality JPEG for web publishing.
 * 2. When converting vector ODG files to raster JPEGs in a batch process and want to apply a median filter to smooth edges.
 * 3. When preparing ODG artwork for inclusion in a PDF or PowerPoint slide and require a denoised JPEG thumbnail.
 * 4. When building an automated document‑to‑image pipeline in C# that must rasterize ODG files, clean them with a median filter, and store them as JPEG files.
 * 5. When creating a photo‑editing tool that imports ODG drawings, applies a 3×3 median filter to remove speckles, and saves the result as a compressed JPEG.
 */
