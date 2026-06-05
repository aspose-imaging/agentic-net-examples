using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image (preserves alpha channel)
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Apply Emboss3x3 convolution filter while preserving alpha
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

                // Set PNG save options to keep alpha channel
                PngOptions options = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha
                };

                // Save the processed image
                raster.Save(outputPath, options);
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
 * 1. When a web developer wants to add a subtle embossed effect to UI icons while keeping their transparent backgrounds intact for responsive design.
 * 2. When a game artist needs to process PNG sprites with an emboss filter but must retain the alpha channel so the characters blend correctly with the game scene.
 * 3. When a marketing team prepares product thumbnails with a 3‑x‑3 emboss effect and requires the images to remain transparent for overlay on various promotional backgrounds.
 * 4. When a mobile app developer generates embossed PNG assets for button states and must preserve transparency to avoid visual artifacts on different screen sizes.
 * 5. When a PDF generation service applies an emboss filter to PNG logos before embedding them in documents, ensuring the logo’s transparent background remains unchanged.
 */