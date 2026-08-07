using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input/input.tif";
        string outputPath = "output/output.tif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                TiffOptions options = new TiffOptions(TiffExpectedFormat.Default);
                image.Save(outputPath, options);
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
 * 1. When a developer needs to hide confidential sections of a multi‑page TIFF document by merging two region masks and applying the combined mask to protect sensitive data.
 * 2. When an application must overlay watermarks only on specific areas of a scanned TIFF image by uniting masks created from different coordinates and applying the result.
 * 3. When a GIS system requires clipping satellite TIFF imagery to a complex polygon defined by multiple points, using mask union to generate the final clipping region.
 * 4. When a medical imaging tool wants to isolate and analyze overlapping anatomical structures in a TIFF X‑ray by combining masks from separate points of interest.
 * 5. When an e‑commerce platform wants to remove background artifacts from product photos stored as TIFF files by merging masks of foreground and background regions before saving.
 */