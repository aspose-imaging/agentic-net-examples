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
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.png";
            string outputPath = @"C:\Images\output.MotionWiener.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering methods
                RasterImage rasterImage = (RasterImage)image;

                // Configure MotionWiener filter: size=10, sigma=1.0, angle=0 (horizontal)
                var filterOptions = new MotionWienerFilterOptions(10, 1.0, 0.0);

                // Apply the filter to the entire image
                rasterImage.Filter(rasterImage.Bounds, filterOptions);

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
 * 1. When a developer needs to reduce horizontal motion blur in a PNG frame extracted from a video before publishing it on a website, they can use this Aspose.Imaging C# code to apply a Motion‑Wiener filter with a horizontal vector.
 * 2. When an automated video‑to‑image pipeline must clean up noisy PNG screenshots captured during live streaming, the code can be integrated to sharpen the images by filtering horizontally.
 * 3. When a forensic analyst wants to enhance a single PNG image taken from surveillance footage to reveal details obscured by camera shake along the X‑axis, the MotionWiener filter in C# provides a quick solution.
 * 4. When a game developer generates PNG textures from recorded gameplay and needs to remove motion artifacts caused by fast horizontal panning, this snippet applies the filter directly to the raster image.
 * 5. When a batch processing tool for digital archives must improve the visual quality of horizontally blurred PNG frames before archiving, the provided Aspose.Imaging filter code can be scheduled to run on each file.
 */