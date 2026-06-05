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
        string inputPath = "Assets/Textures/input.png";
        string outputPath = "Assets/Textures/output_emboss.png";

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
            // Load the source image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering functionality
                RasterImage rasterImage = (RasterImage)image;

                // Apply the 3x3 emboss convolution filter to the whole image
                rasterImage.Filter(
                    rasterImage.Bounds,
                    new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3)
                );

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
 * 1. When a Unity game needs to dynamically emboss player‑created PNG textures during gameplay to enhance visual depth without pre‑processing assets.
 * 2. When a developer wants to apply a 3×3 emboss convolution filter to procedural textures in a C# Unity toolchain, saving the result as a new PNG for later use.
 * 3. When an AR application must highlight scanned environment images by embossing them on the fly, using Aspose.Imaging to process the bitmap before rendering.
 * 4. When a level‑design editor built with Unity requires an instant preview of embossed texture variations, loading the source image, applying the filter, and writing the output PNG to the Assets folder.
 * 5. When a server‑side C# service generates embossed thumbnails of user‑uploaded PNG textures for a Unity‑based marketplace, leveraging the ConvolutionFilter.Emboss3x3 option to maintain consistent styling.
 */