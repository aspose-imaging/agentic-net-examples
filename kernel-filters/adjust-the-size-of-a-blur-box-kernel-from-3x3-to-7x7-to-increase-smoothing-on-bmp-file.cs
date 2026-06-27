using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.bmp";
        string outputPath = "output.bmp";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                var blurOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions();
                blurOptions.Size = 7;
                blurOptions.Sigma = 2.0;

                raster.Filter(raster.Bounds, blurOptions);

                raster.Save(outputPath, new BmpOptions());
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
 * 1. When preparing scanned BMP documents for OCR, a developer may increase the Gaussian blur kernel to 7x7 to reduce noise and improve text recognition.
 * 2. When generating thumbnail previews of BMP screenshots, a developer can apply a larger 7x7 blur kernel to smooth edges and create a consistent visual style.
 * 3. When preprocessing BMP images for a machine‑learning pipeline that requires low‑frequency features, a developer may use a 7x7 Gaussian blur to suppress fine details.
 * 4. When creating background textures from BMP photos for a game UI, a developer might enlarge the blur kernel to 7x7 to produce a softer, less distracting backdrop.
 * 5. When sanitizing user‑uploaded BMP files to obscure sensitive details, a developer can apply a 7x7 Gaussian blur to ensure stronger smoothing before storage.
 */