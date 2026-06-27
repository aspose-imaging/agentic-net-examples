using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "sample.cdr";
        string outputPath = "output/sample.bmp";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    var pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = new CdrRasterizationOptions
                        {
                            PageWidth = cdr.Width,
                            PageHeight = cdr.Height
                        }
                    };
                    cdr.Save(ms, pngOptions);
                    ms.Position = 0;

                    using (RasterImage raster = (RasterImage)Image.Load(ms))
                    {
                        raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));
                        var bmpOptions = new BmpOptions();
                        raster.Save(outputPath, bmpOptions);
                    }
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
 * 1. When a developer needs to convert a CorelDRAW (CDR) illustration into a BMP thumbnail while softening edges with a Gaussian blur for a web gallery preview.
 * 2. When an automation script must batch‑process CDR files, apply a 5‑pixel radius Gaussian blur to reduce detail, and save the results as BMPs for legacy Windows applications.
 * 3. When integrating a design‑to‑print workflow that requires rasterizing vector CDR pages, applying a blur effect for background shading, and exporting the final bitmap in BMP format for a printing device that only accepts BMP files.
 * 4. When creating a desktop application that loads user‑provided CorelDRAW artwork, adds a subtle blur to meet branding guidelines, and stores the processed image as a BMP for further pixel‑level analysis.
 * 5. When building a C# utility that reads CDR files, applies a Gaussian blur filter to simulate a soft‑focus effect, and outputs BMP files for use in a game engine that only supports BMP textures.
 */