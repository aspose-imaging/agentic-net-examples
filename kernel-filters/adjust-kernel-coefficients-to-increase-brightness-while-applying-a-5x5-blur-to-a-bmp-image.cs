using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.bmp";
        string outputPath = "output\\output.bmp";

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
                raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 1.0));
                raster.AdjustBrightness(30);
                raster.Save(outputPath);
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
 * 1. When a developer needs to preprocess scanned BMP documents by softening noise with a 5×5 Gaussian blur and then brightening the image for better OCR accuracy.
 * 2. When an application must automatically enhance legacy BMP screenshots for a web gallery by applying a subtle blur to reduce pixelation and increase overall brightness before saving.
 * 3. When a photo‑editing tool wants to create a “soft focus” effect on BMP portraits, using a 5×5 blur kernel and a brightness boost to maintain a natural look.
 * 4. When a batch‑processing script has to prepare BMP assets for printing, smoothing harsh edges with a Gaussian blur and lifting the luminance to meet print‑ready standards.
 * 5. When a game engine imports BMP textures and needs to reduce visual artifacts with a 5×5 blur while adjusting brightness to match the scene’s lighting conditions.
 */