using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.MagicWand;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output directories
            string inputRoot = "InputImages";
            string outputRoot = "Masks";

            // Ensure the base output directory exists
            Directory.CreateDirectory(outputRoot);

            // Find all JPEG files in subfolders
            var jpegFiles = Directory.GetFiles(inputRoot, "*.*", SearchOption.AllDirectories)
                .Where(f => f.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                            f.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase));

            foreach (var inputPath in jpegFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Compute relative path and corresponding output mask path
                string relativePath = Path.GetRelativePath(inputRoot, inputPath);
                string outputPath = Path.Combine(outputRoot, Path.ChangeExtension(relativePath, ".png"));

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the JPEG image
                using (RasterImage image = (RasterImage)Image.Load(inputPath))
                {
                    // Create a mask using MagicWandTool (starting at pixel 0,0)
                    MagicWandTool.Select(image, new MagicWandSettings(0, 0)).Apply();

                    // Save the resulting mask as a PNG with alpha channel
                    image.Save(outputPath, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha });
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}