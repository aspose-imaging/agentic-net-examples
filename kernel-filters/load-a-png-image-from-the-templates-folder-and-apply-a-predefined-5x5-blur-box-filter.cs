using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output paths
            string inputPath = "templates/input.png";
            string outputPath = "output/blurred.png";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering capabilities
                RasterImage rasterImage = (RasterImage)image;

                // Apply a 5×5 box blur (approximated with a Gaussian blur of radius 5)
                rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 0));

                // Save the processed image
                rasterImage.Save(outputPath);
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
 * 1. When generating thumbnail previews for a web gallery, a developer can load PNG assets from a templates folder and apply a 5×5 Gaussian blur to create a soft‑focus placeholder before the full‑resolution image loads.
 * 2. When preprocessing scanned documents in a C# batch job, applying a 5×5 box blur to PNG files helps reduce high‑frequency noise before OCR is performed.
 * 3. When building a photo‑editing application that offers a “soft‑focus” filter, the code can load user‑selected PNG images and use Aspose.Imaging’s GaussianBlurFilterOptions with a radius of 5 to achieve the effect.
 * 4. When preparing PNG icons for a mobile app, developers may blur the edges with a 5×5 filter to create a subtle glow that improves visual consistency across different screen densities.
 * 5. When creating anonymized medical images for research, a C# routine can load PNG scans from a templates directory and apply a 5×5 blur to obscure patient details while preserving overall anatomy.
 */