using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image vectorImage = Image.Load(inputPath))
            {
                // Set up rasterization options for SVG to PNG conversion
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions();
                rasterOptions.PageSize = vectorImage.Size;

                PngOptions pngOptions = new PngOptions();
                pngOptions.VectorRasterizationOptions = rasterOptions;

                // Rasterize SVG into a memory stream
                using (MemoryStream ms = new MemoryStream())
                {
                    vectorImage.Save(ms, pngOptions);
                    ms.Position = 0;

                    // Load the rasterized image
                    using (RasterImage raster = (RasterImage)Image.Load(ms))
                    {
                        int size = 7;          // odd kernel size
                        double sigma = 2.8;    // desired sigma

                        // Apply Gaussian blur with the specified kernel size and sigma
                        raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(size, sigma));

                        // Save the blurred raster image
                        raster.Save(outputPath, new PngOptions());
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
 * 1. When a web application needs to generate a soft‑focused thumbnail of an SVG logo by rasterizing it to PNG and applying a Gaussian blur with sigma 2.8 for consistent visual branding.
 * 2. When an e‑learning platform converts vector diagrams (SVG) to raster images and adds a subtle blur to reduce sharp edges before embedding them in PDF lesson slides.
 * 3. When a mobile game engine imports SVG assets, rasterizes them to PNG, and uses a Gaussian kernel (size 7, sigma 2.8) to create a depth‑of‑field effect for background elements.
 * 4. When a reporting tool automatically produces PNG charts from SVG templates and applies a Gaussian blur to smooth out anti‑aliasing artifacts for print‑ready output.
 * 5. When a document processing service needs to preprocess SVG illustrations by rasterizing them to PNG and applying a Gaussian blur with sigma 2.8 to improve OCR accuracy on subsequent text extraction.
 */