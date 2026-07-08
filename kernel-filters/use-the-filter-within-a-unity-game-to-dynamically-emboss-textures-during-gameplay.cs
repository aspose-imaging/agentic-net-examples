using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Textures\source.png";
        string outputPath = @"C:\Textures\embossed.png";

        // Ensure any runtime exception is reported without crashing
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

            // Load the image using Aspose.Imaging
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering capabilities
                RasterImage rasterImage = (RasterImage)image;

                // Create convolution filter options with the built‑in Emboss 3x3 kernel
                var embossOptions = new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3);

                // Apply the emboss filter to the whole image
                rasterImage.Filter(rasterImage.Bounds, embossOptions);

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
 * 1. When a Unity developer wants to generate a stylized embossed version of a PNG texture at build time to give in‑game objects a raised‑relief appearance without manually editing each file.
 * 2. When an automated asset pipeline needs to apply a 3x3 emboss convolution filter to all source images in a folder before they are imported into Unity, ensuring consistent visual depth across platforms.
 * 3. When a game modding tool written in C# must let players preview an embossed effect on custom textures by loading the image, applying the Aspose.Imaging ConvolutionFilter.Emboss3x3, and saving the result for immediate use in the Unity editor.
 * 4. When a continuous integration script validates that texture assets exist, creates missing output directories, and uses Aspose.Imaging to emboss textures as part of a quality‑assurance step before publishing the Unity build.
 * 5. When a runtime utility in a Unity project needs to catch file‑not‑found or processing exceptions while loading a PNG, applying an emboss filter, and saving the modified raster image to prevent crashes during gameplay.
 */