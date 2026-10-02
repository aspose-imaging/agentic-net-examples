// HOW-TO: Combine Multiple Magic Wand Masks and Apply to TIFF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;
using Aspose.Imaging.MagicWand;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.tif";
        string outputPath = "output.tif";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                var settings1 = new MagicWandSettings(100, 100);
                var settings2 = new MagicWandSettings(200, 200);

                MagicWandTool.Select(image, settings1)
                    .Union(MagicWandTool.Select(image, settings2))
                    .Apply();

                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiffOptions.Source = new FileCreateSource(outputPath, false);
                image.Save(outputPath, tiffOptions);
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
 * 1. When you need to merge selections from two different points in a scanned document and apply the combined mask to a TIFF file using Aspose.Imaging in C#.
 * 2. When you want to programmatically remove or highlight overlapping regions in a multi‑page TIFF by uniting two magic wand selections.
 * 3. When you are building an automated preprocessing step that creates a single mask from separate color thresholds before saving the result as a TIFF image.
 * 4. When you must apply a composite selection to a raster image for batch editing of large TIFF files in a .NET application.
 * 5. When you need to combine region‑of‑interest masks generated at different coordinates and export the masked TIFF for further analysis or archiving.
 */
