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
        string outputPath = @"C:\Images\output.gif";

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
                // The CDR format is vector; to apply raster filters we need a RasterImage.
                // Attempt to cast; if the cast fails, the image must be rasterized first.
                if (image is RasterImage rasterImage)
                {
                    // Apply Gaussian blur to the whole image (radius 5, sigma 4.0)
                    rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                    // Verify transparency: check if any pixel has alpha != 255
                    bool hasTransparency = false;
                    for (int y = 0; y < rasterImage.Height && !hasTransparency; y++)
                    {
                        for (int x = 0; x < rasterImage.Width; x++)
                        {
                            int argb = rasterImage.GetArgb32Pixel(x, y);
                            int alpha = (argb >> 24) & 0xFF;
                            if (alpha != 255)
                            {
                                hasTransparency = true;
                                break;
                            }
                        }
                    }

                    Console.WriteLine(hasTransparency
                        ? "Image contains transparent pixels."
                        : "Image is fully opaque.");

                    // Prepare GIF save options (enable palette correction for better colors)
                    GifOptions gifOptions = new GifOptions
                    {
                        DoPaletteCorrection = true
                    };

                    // Save the blurred image as GIF
                    rasterImage.Save(outputPath, gifOptions);
                }
                else
                {
                    Console.Error.WriteLine("Loaded image is not a raster image and cannot be processed with raster filters.");
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
 * 1. When a developer needs to generate a blurred preview of a CorelDRAW (CDR) illustration for a web gallery while preserving any alpha channel information before converting it to a GIF.
 * 2. When an application must programmatically verify that a vector‑to‑raster conversion of a CDR file retains transparency so that the resulting GIF can be overlaid on different backgrounds without unwanted opaque edges.
 * 3. When a batch‑processing tool has to apply a consistent Gaussian blur (radius 5, sigma 4.0) to multiple CDR assets and then export them as lightweight GIF files for email newsletters.
 * 4. When a UI designer wants to create a soft‑focus effect on a logo stored in CDR format, check for any semi‑transparent pixels, and output the result as a GIF that can be used in HTML5 canvases.
 * 5. When a migration script needs to rasterize CDR drawings, apply a blur filter for privacy masking, confirm the presence of transparency, and save the final image as a GIF for compatibility with legacy systems.
 */