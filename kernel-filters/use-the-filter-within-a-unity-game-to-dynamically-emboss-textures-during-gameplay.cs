// HOW-TO: Apply Emboss Filter to PNG Texture in Unity C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class EmbossTextureProcessor
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "Assets/Textures/input.png";
        string outputPath = "Assets/Textures/output_emboss.png";

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

            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering
                RasterImage rasterImage = (RasterImage)image;

                // Apply the 3x3 emboss kernel to the whole image
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
 * 1. When you need to add a stylized raised‑edge effect to a PNG sprite at runtime in a Unity game, this code shows how to emboss the texture using Aspose.Imaging.
 * 2. When you want to preprocess game assets during development by converting flat textures into embossed versions for a hand‑painted aesthetic, the example demonstrates the required C# steps.
 * 3. When a procedural terrain generator requires dynamic embossing of height‑map images to enhance visual depth, you can apply the same filter to the generated PNG files.
 * 4. When creating a UI overlay that highlights icons with a 3‑D embossed look, this snippet provides a quick way to apply the effect without external tools.
 * 5. When debugging visual shaders and need a reference image with clear edge contrast, the code lets you generate an embossed PNG to compare against shader output.
 */
