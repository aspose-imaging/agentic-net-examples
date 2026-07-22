using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Emf.Graphics;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.emf";
        string outputPath = @"C:\Images\sample_blurred.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EMF image
            using (Image emfImage = Image.Load(inputPath))
            {
                // Rasterize EMF to a PNG in memory
                using (var memoryStream = new MemoryStream())
                {
                    var pngOptions = new PngOptions();

                    // Set vector rasterization options for EMF rendering
                    var rasterizationOptions = new EmfRasterizationOptions
                    {
                        PageSize = emfImage.Size,
                        BackgroundColor = Aspose.Imaging.Color.White
                    };
                    pngOptions.VectorRasterizationOptions = rasterizationOptions;

                    // Save rasterized image to memory stream
                    emfImage.Save(memoryStream, pngOptions);
                    memoryStream.Position = 0;

                    // Load the rasterized image as a RasterImage
                    using (RasterImage rasterImage = (RasterImage)Image.Load(memoryStream))
                    {
                        // Apply Gaussian blur with radius 5 and sigma 4.0
                        rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                        // Save the blurred image as PNG
                        rasterImage.Save(outputPath);
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
 * 1. When a developer needs to generate a soft‑focused preview thumbnail of a vector‑based EMF logo for a web gallery, they can rasterize the EMF, apply a Gaussian blur with radius five, and save it as a PNG.
 * 2. When creating print‑ready marketing materials that require a subtle background blur behind vector illustrations, the code can blur the EMF artwork and export the result as a high‑quality PNG for inclusion in PDFs.
 * 3. When building a document‑conversion service that converts legacy EMF diagrams to blurred PNG images for use in mobile apps, this snippet handles the rasterization, blur filter, and PNG output in C#.
 * 4. When implementing a UI feature that shows a blurred version of a vector icon while loading the original, developers can use the code to process the EMF file, apply a Gaussian blur radius of five, and deliver a PNG placeholder.
 * 5. When preparing assets for a machine‑learning dataset that requires blurred raster images derived from vector EMF files, the example provides a straightforward way to apply a Gaussian blur and save the result as PNG using Aspose.Imaging for .NET.
 */