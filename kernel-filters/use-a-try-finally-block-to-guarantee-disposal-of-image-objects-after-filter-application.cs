using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input\\sample.png";
        string outputPath = "output\\filtered.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            Image image = Image.Load(inputPath);
            try
            {
                RasterImage raster = (RasterImage)image;
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));
                raster.Save(outputPath, new PngOptions());
            }
            finally
            {
                image.Dispose();
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
 * 1. When a developer needs to blur sensitive areas in user‑uploaded PNG images before saving them to a server, they can load the file, apply a Gaussian blur filter with Aspose.Imaging, and use a try‑finally block to guarantee the image is disposed.
 * 2. When building a batch processor that reduces noise in scanned PNG documents prior to OCR, the code loads each raster image, applies a Gaussian blur (radius 5, sigma 4.0), saves the result, and ensures proper disposal with try‑finally.
 * 3. When generating blurred background thumbnails for a photo‑gallery application, a developer can use this pattern to load the original PNG, apply the blur filter, save the thumbnail, and automatically release resources.
 * 4. When creating a server‑side image‑filter API that receives PNG files, applies a configurable Gaussian blur, and returns the filtered image, the try‑finally construct guarantees that the Image object is always disposed after processing.
 * 5. When writing an automated test that verifies the visual impact of a Gaussian blur on PNG assets, the script can load the image, apply the filter, save the output, and rely on try‑finally to prevent memory leaks.
 */