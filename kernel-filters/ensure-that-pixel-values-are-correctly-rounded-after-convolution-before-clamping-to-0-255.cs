using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output\\output.png";

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
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));
                PngOptions options = new PngOptions();
                raster.Save(outputPath, options);
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
 * 1. When a developer needs to soften the edges of a PNG logo before embedding it in a web page, they can use this code to apply a Gaussian blur while preserving correct pixel rounding and clamping.
 * 2. When preprocessing scanned documents in a C# application to reduce high‑frequency noise before OCR, the Gaussian blur filter ensures smoother grayscale values without overflow.
 * 3. When generating thumbnail previews of user‑uploaded PNG images for a gallery, applying the blur can create a subtle background effect while guaranteeing pixel values stay within the 0‑255 range.
 * 4. When creating a batch image processing tool that standardizes visual style across PNG assets for a mobile game, the code provides a repeatable way to blur textures with proper rounding of convolution results.
 * 5. When integrating image enhancement into a .NET service that receives PNG files via API, the Gaussian blur filter prepares the images for further analysis by ensuring accurate pixel rounding before saving.
 */