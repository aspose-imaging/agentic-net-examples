// HOW-TO: Adjust Magic Wand Feather Radius Interactively and Save PNG Previews in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
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
            string inputPath = "input.jpg";
            string outputDirectory = "output";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDirectory);

            // Initial point for MagicWand selection (hardcoded)
            int startX = 100;
            int startY = 100;

            int previewIndex = 1;
            while (true)
            {
                Console.Write("Enter feather radius (or press Enter to exit): ");
                string line = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(line))
                {
                    break;
                }

                if (!int.TryParse(line, out int featherRadius) || featherRadius < 0)
                {
                    Console.WriteLine("Invalid radius. Please enter a non‑negative integer.");
                    continue;
                }

                using (RasterImage image = (RasterImage)Image.Load(inputPath))
                {
                    MagicWandTool.Select(image, new MagicWandSettings(startX, startY))
                        .GetFeathered(new FeatheringSettings() { Size = featherRadius })
                        .Apply();

                    string outputPath = Path.Combine(outputDirectory, $"preview_{previewIndex}.png");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                    image.Save(outputPath, new PngOptions());
                    Console.WriteLine($"Preview saved to: {outputPath}");
                }

                previewIndex++;
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
 * 1. When a photo‑editing app needs users to fine‑tune a selection’s softness and instantly view the result as a PNG preview.
 * 2. When an automated workflow must generate multiple mask variations with different feather radii for testing image segmentation quality.
 * 3. When a desktop utility offers real‑time adjustment of Magic Wand selection edges before exporting the refined mask.
 * 4. When a developer builds a UI that lets designers experiment with feather settings to achieve smooth transitions in cut‑out images.
 * 5. When creating sample images for documentation or tutorials that demonstrate how changing feather radius affects the mask appearance.
 */
