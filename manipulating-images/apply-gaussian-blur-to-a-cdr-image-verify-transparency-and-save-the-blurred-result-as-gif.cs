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
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.cdr";
            string outputPath = @"C:\Images\sample_blurred.gif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR image
            using (Image cdrImg = Image.Load(inputPath))
            {
                // Cast to CdrImage to access pages
                CdrImage cdrImage = (CdrImage)cdrImg;

                // Export the first page to a raster image via an in‑memory PNG
                using (var tempStream = new MemoryStream())
                {
                    // Save the first page as PNG into the memory stream
                    cdrImage.Pages[0].Save(tempStream, new PngOptions());

                    // Reset stream position for reading
                    tempStream.Position = 0;

                    // Load the raster image from the memory stream
                    using (Image rasterImg = Image.Load(tempStream))
                    {
                        var raster = (RasterImage)rasterImg;

                        // Apply Gaussian blur (radius 5, sigma 4.0) to the whole image
                        raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                        // Verify transparency
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

                        Console.WriteLine(hasTransparency
                            ? "The image contains transparent pixels."
                            : "The image is fully opaque.");

                        // Save the blurred raster image as GIF
                        var gifOptions = new GifOptions
                        {
                            // Enable palette correction for better color fidelity
                            DoPaletteCorrection = true
                        };
                        raster.Save(outputPath, gifOptions);
                    }
                }
            }

            Console.WriteLine($"Blurred GIF saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}