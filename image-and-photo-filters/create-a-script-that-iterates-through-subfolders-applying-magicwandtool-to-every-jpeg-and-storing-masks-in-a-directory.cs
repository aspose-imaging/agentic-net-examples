using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main()
    {
        // Hardcoded input and output root directories
        string inputRoot = @"C:\Images\Input";
        string outputRoot = @"C:\Images\Output";

        try
        {
            // Get all JPEG files in subfolders
            string[] files = Directory.GetFiles(inputRoot, "*.*", SearchOption.AllDirectories);
            foreach (string filePath in files)
            {
                string extension = Path.GetExtension(filePath).ToLowerInvariant();
                if (extension != ".jpg" && extension != ".jpeg")
                    continue;

                // Verify input file exists
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    return;
                }

                // Determine output path preserving relative folder structure
                string relativePath = Path.GetRelativePath(inputRoot, filePath);
                string outputPath = Path.Combine(outputRoot, relativePath);

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load image as RasterImage
                using (RasterImage image = (RasterImage)Image.Load(filePath))
                {
                    // Create a mask using MagicWandTool (reference point at (0,0) with default threshold)
                    MagicWandTool
                        .Select(image, new MagicWandSettings(0, 0))
                        .Apply();

                    // Save the masked image as JPEG
                    image.Save(outputPath, new JpegOptions());
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}