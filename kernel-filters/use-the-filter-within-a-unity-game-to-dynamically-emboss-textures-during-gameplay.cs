using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Textures\input.png";
            string outputPath = @"C:\Textures\output_emboss.png";

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
                // Cast to RasterImage to access filtering methods
                RasterImage rasterImage = (RasterImage)image;

                // Create emboss filter options using the 3x3 emboss kernel
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
 * 1. When a Unity game needs to apply a real‑time emboss effect to PNG textures loaded from disk, a developer can use this C# code with Aspose.Imaging to read the image, run a 3×3 convolution emboss filter, and save the modified texture for use in the game.
 * 2. When an asset pipeline requires batch processing of texture assets to give them a stylized raised‑edge look before they are imported into a C#‑based game engine, this example shows how to load each image, apply the Emboss3x3 filter, and output a new PNG file.
 * 3. When a developer wants to dynamically generate embossed UI icons on the fly in a Windows application, they can employ the RasterImage.Filter method with ConvolutionFilterOptions to transform a source PNG into an embossed version without external tools.
 * 4. When an AR/VR application needs to pre‑process high‑resolution JPEG or BMP textures to add depth cues by embossing them during a build step, the code demonstrates how to verify file existence, create output directories, and apply the convolution filter using Aspose.Imaging in C#.
 * 5. When a game modding tool must allow users to preview an emboss effect on their custom texture files, this snippet provides a straightforward way to load the user‑selected image, apply the 3×3 emboss kernel, and save the result for immediate visual feedback.
 */