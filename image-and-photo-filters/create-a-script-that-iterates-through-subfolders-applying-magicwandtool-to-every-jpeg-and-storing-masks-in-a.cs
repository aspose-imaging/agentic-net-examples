// HOW-TO: Generate Grayscale Mask PNGs from JPEGs in Subfolders Using MagicWand in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputRoot = "InputImages";
            string outputRoot = "Masks";

            Directory.CreateDirectory(outputRoot);

            var jpegFiles = Directory.GetFiles(inputRoot, "*.*", SearchOption.AllDirectories)
                .Where(f => f.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                            f.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase));

            foreach (var inputPath in jpegFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string relativePath = Path.GetRelativePath(inputRoot, inputPath);
                string outputPath = Path.Combine(outputRoot, Path.ChangeExtension(relativePath, ".png"));
                string outputDir = Path.GetDirectoryName(outputPath);
                if (!string.IsNullOrEmpty(outputDir))
                {
                    Directory.CreateDirectory(outputDir);
                }

                using (RasterImage image = (RasterImage)Image.Load(inputPath))
                {
                    MagicWandTool.Select(image, new MagicWandSettings(0, 0)).Apply();

                    PngOptions pngOptions = new PngOptions
                    {
                        ColorType = PngColorType.Grayscale
                    };

                    image.Save(outputPath, pngOptions);
                }
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
 * 1. When you need to automatically create selection masks for a large collection of JPEG photos stored in nested folders, such as preparing assets for background removal.
 * 2. When you want to batch‑process product images to extract their foreground objects and save the masks as grayscale PNG files for later compositing.
 * 3. When a machine‑learning pipeline requires binary masks for training data and the source images are organized in multiple subdirectories.
 * 4. When you are building a web service that receives JPEG uploads and must generate corresponding mask images for image‑editing tools.
 * 5. When you have to archive image masks separately from the original pictures while preserving the original folder hierarchy for easy reference.
 */
