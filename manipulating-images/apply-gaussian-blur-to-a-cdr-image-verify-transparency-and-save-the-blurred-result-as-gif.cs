using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.cdr";
        string outputPath = @"C:\Images\sample_blur.gif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the CDR image
            using (CdrImage cdrImage = (CdrImage)Image.Load(inputPath))
            {
                // Rasterize the vector CDR image into a PNG stored in memory
                using (MemoryStream rasterStream = new MemoryStream())
                {
                    var pngOptions = new PngOptions();
                    cdrImage.Save(rasterStream, pngOptions);
                    rasterStream.Position = 0;

                    // Load the rasterized image as a RasterImage
                    using (RasterImage rasterImage = (RasterImage)Image.Load(rasterStream))
                    {
                        // Apply Gaussian blur to the entire image
                        rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                        // Verify if the image contains any transparent pixels
                        bool hasTransparency = false;
                        for (int y = 0; y < rasterImage.Height && !hasTransparency; y++)
                        {
                            for (int x = 0; x < rasterImage.Width; x++)
                            {
                                int argb = rasterImage.GetArgb32Pixel(x, y);
                                byte alpha = (byte)(argb >> 24);
                                if (alpha < 255)
                                {
                                    hasTransparency = true;
                                    break;
                                }
                            }
                        }

                        // (Optional) Output transparency check result
                        Console.WriteLine($"Image contains transparency: {hasTransparency}");

                        // Save the blurred image as GIF with palette correction
                        var gifOptions = new GifOptions
                        {
                            DoPaletteCorrection = true
                        };
                        rasterImage.Save(outputPath, gifOptions);
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
 * 1. When a designer needs to automatically apply a soft Gaussian blur to a CorelDRAW (CDR) illustration, convert it to a raster format, verify that any alpha channel is preserved, and deliver the result as a lightweight GIF for web preview.
 * 2. When an e‑commerce platform must generate blurred thumbnail previews of product vector assets stored as CDR files while ensuring transparent backgrounds remain intact before saving them as GIFs for faster page loads.
 * 3. When a marketing automation script has to batch‑process CDR logos, apply a consistent blur effect, detect any remaining transparent pixels, and export the final images as GIFs for email campaigns.
 * 4. When a desktop application needs to let users import a CDR file, apply a Gaussian blur filter with specific radius and sigma values, confirm that the image’s transparency is unchanged, and save the output as an animated‑compatible GIF.
 * 5. When a content management system integrates Aspose.Imaging to transform vector CDR artwork into blurred GIF assets while programmatically checking for alpha channel data to avoid unwanted opaque backgrounds.
 */