using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to APNG (multi‑page PNG)
                ApngImage apng = image as ApngImage;
                if (apng == null)
                {
                    Console.Error.WriteLine("The input file is not a multi‑page PNG.");
                    return;
                }

                // Iterate over pages
                for (int i = 0; i < apng.Pages.Length; i++)
                {
                    // Apply filter only to even pages (2,4,...) -> (i + 1) % 2 == 0
                    if ((i + 1) % 2 == 0)
                    {
                        // Each page is a RasterImage
                        RasterImage raster = apng.Pages[i] as RasterImage;
                        if (raster != null)
                        {
                            // Apply Sharpen filter with kernel size 5 and sigma 4.0
                            raster.Filter(raster.Bounds, new SharpenFilterOptions(5, 4.0));
                        }
                    }
                }

                // Save the modified APNG
                apng.Save(outputPath);
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
 * 1. When creating an animated PNG where every second frame needs extra visual sharpness to highlight key actions, a developer can iterate through the APNG pages and apply a 5x5 sharpen filter to the even frames before saving.
 * 2. When processing a multi‑page PNG export from a design tool and wanting to enhance only the even‑numbered pages for a print‑ready PDF conversion, the code can selectively sharpen those pages.
 * 3. When building a C# image‑processing pipeline that adds emphasis to alternate slides in a presentation saved as an APNG, the developer can use this loop to apply a SharpenFilterOptions(5, 4.0) to every even slide.
 * 4. When optimizing a sprite sheet stored as a multi‑frame PNG and needing to improve the clarity of every second sprite for a game engine, the code lets you filter only the even sprite images.
 * 5. When automating quality‑control for a batch of animated PNGs where even frames contain text overlays that must be more legible, the developer can programmatically sharpen those frames using Aspose.Imaging in .NET.
 */