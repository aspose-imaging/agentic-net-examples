using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.cdr";
        string outputPath = @"C:\Images\sample_blurred.gif";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to apply filters
                RasterImage raster = (RasterImage)image;

                // Apply Gaussian blur (radius 5, sigma 4.0) to the whole image
                raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Verify if the image contains any transparent pixels
                bool hasTransparency = false;
                for (int y = 0; y < raster.Height && !hasTransparency; y++)
                {
                    for (int x = 0; x < raster.Width; x++)
                    {
                        int argb = raster.GetArgb32Pixel(x, y);
                        int alpha = (argb >> 24) & 0xFF;
                        if (alpha != 255)
                        {
                            hasTransparency = true;
                            break;
                        }
                    }
                }

                Console.WriteLine($"Transparency detected: {hasTransparency}");

                // Prepare GIF save options (optional palette correction)
                GifOptions gifOptions = new GifOptions
                {
                    DoPaletteCorrection = true
                };

                // Save the blurred image as GIF
                raster.Save(outputPath, gifOptions);
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
 * 1. When a developer needs to import a CorelDRAW (CDR) illustration, apply a Gaussian blur effect, and export the result as an animated‑compatible GIF while preserving any transparent regions.
 * 2. When a web application must generate blurred thumbnail previews of user‑uploaded CDR files and ensure the thumbnails retain alpha transparency for overlay use.
 * 3. When an e‑commerce platform wants to automatically soften product mock‑ups stored in CDR format and save them as lightweight GIFs for faster page loading.
 * 4. When a digital‑marketing tool requires batch processing of CDR assets to create blurred background images with transparent cut‑outs for email newsletters.
 * 5. When a desktop utility needs to verify whether a blurred CDR image contains any semi‑transparent pixels before converting it to a GIF with palette correction for legacy browsers.
 */