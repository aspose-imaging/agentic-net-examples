using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output\\result.bmp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            // Load the source image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Create a mask for the blue selection (adjust coordinates as needed)
                ImageBitMask blueMask = MagicWandTool.Select(
                    image,
                    new MagicWandSettings(100, 100) { Threshold = 30 });

                // Create a mask for the green selection (adjust coordinates as needed)
                ImageBitMask greenMask = MagicWandTool.Select(
                    image,
                    new MagicWandSettings(200, 200) { Threshold = 30 });

                // Subtract the green mask from the blue mask
                ImageBitMask resultMask = blueMask.Subtract(greenMask);

                // Apply the resulting mask to the image
                resultMask.Apply();

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the processed image as BMP
                image.Save(outputPath, new BmpOptions());
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
 * 1. When a developer needs to isolate a blue region of a product photo while removing overlapping green highlights, they can use this code to subtract the green selection and save the result as a BMP for downstream printing.
 * 2. When preparing assets for a GIS application that requires BMP layers, a developer can remove green vegetation masks from blue water bodies using the magic wand subtraction technique.
 * 3. When creating a game sprite sheet where blue armor must be displayed without green glow effects, this code lets the developer subtract the green mask and export the cleaned sprite as BMP.
 * 4. When generating medical imaging reports that need a blue tissue region isolated from surrounding green staining, a developer can apply the subtraction and save the output in BMP format for compatibility with legacy analysis tools.
 * 5. When automating batch processing of scanned engineering diagrams to extract blue circuit lines while discarding green annotations, the code provides a C# solution to subtract the green selection and output BMP files for archival.
 */