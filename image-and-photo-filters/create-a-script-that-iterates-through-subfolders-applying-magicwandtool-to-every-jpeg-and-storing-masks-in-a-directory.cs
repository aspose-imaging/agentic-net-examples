using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.MagicWand;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output root directories
            string inputRoot = "InputImages";
            string outputRoot = "Masks";

            // Ensure the output root directory exists
            Directory.CreateDirectory(outputRoot);

            // Get all JPEG files recursively
            string[] jpegFiles = Directory.GetFiles(inputRoot, "*.jpg", SearchOption.AllDirectories);

            foreach (string inputPath in jpegFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Compute relative path and corresponding output mask path (PNG)
                string relativePath = Path.GetRelativePath(inputRoot, inputPath);
                string outputPath = Path.Combine(outputRoot, Path.ChangeExtension(relativePath, ".png"));

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the image as a raster image
                using (Aspose.Imaging.RasterImage image = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
                {
                    // Apply MagicWandTool selection at (0,0) with default settings and apply the mask
                    MagicWandTool.Select(image, new MagicWandSettings(0, 0)).Apply();

                    // Save the resulting mask as a PNG with alpha channel
                    image.Save(outputPath, new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha
                    });
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}