using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input/multipage.tif";
            string outputPath = "Output/animated.apng";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the multi‑page TIFF
            using (Image tiffImage = Image.Load(inputPath))
            {
                // Cast to multipage interface
                if (tiffImage is IMultipageImage multipageImage)
                {
                    int pageCount = multipageImage.PageCount;
                    if (pageCount == 0)
                    {
                        Console.Error.WriteLine("No pages found in the TIFF image.");
                        return;
                    }

                    // Obtain dimensions from the first page
                    RasterImage firstPage = (RasterImage)multipageImage.Pages[0];
                    int width = firstPage.Width;
                    int height = firstPage.Height;

                    // Prepare APNG creation options
                    ApngOptions apngOptions = new ApngOptions
                    {
                        Source = new FileCreateSource(outputPath, false),
                        ColorType = PngColorType.TruecolorWithAlpha
                    };

                    // Create the APNG image canvas
                    using (ApngImage apngImage = (ApngImage)Image.Create(apngOptions, width, height))
                    {
                        // Remove the default empty frame
                        apngImage.RemoveAllFrames();

                        // Add each TIFF page as a frame with a unique delay
                        for (int i = 0; i < pageCount; i++)
                        {
                            RasterImage page = (RasterImage)multipageImage.Pages[i];
                            // Example: delay increases by 100 ms per page
                            uint frameDelay = (uint)((i + 1) * 100);
                            apngImage.AddFrame(page, frameDelay);
                        }

                        // Save the resulting APNG
                        apngImage.Save();
                    }
                }
                else
                {
                    Console.Error.WriteLine("The loaded image is not a multipage image.");
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
 * 1. When a developer needs to convert a multi‑page TIFF into an animated PNG (APNG) for web display, preserving each page as a separate frame with custom timing.
 * 2. When building a .NET application that generates animated product catalogs from scanned TIFF pages, assigning different frame delays to highlight each product.
 * 3. When creating a medical imaging viewer that transforms multi‑slice TIFF scans into an APNG slideshow with variable pause intervals between slices.
 * 4. When automating the production of animated instructional graphics by turning multi‑page TIFF tutorials into APNG files with per‑step delays.
 * 5. When developing a reporting tool that exports multi‑page TIFF charts as an animated PNG, allowing each chart page to appear for a specific duration in the final animation.
 */