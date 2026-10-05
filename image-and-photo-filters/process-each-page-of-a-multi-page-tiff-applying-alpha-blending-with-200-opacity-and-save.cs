// HOW-TO: Apply Alpha Blending to Each Page of a Multi‑Page TIFF in C# (Aspose.Imaging for .NET)
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
        try
        {
            string inputPath = "input/multipage.tif";
            string outputPath = "output/processed.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (TiffImage tiff = (TiffImage)Image.Load(inputPath))
            {
                foreach (TiffFrame frame in tiff.Frames)
                {
                    tiff.ActiveFrame = frame;
                    using (RasterImage raster = (RasterImage)frame)
                    {
                        raster.Blend(new Point(0, 0), raster, 200);
                    }
                }

                TiffOptions saveOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiff.Save(outputPath, saveOptions);
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
 * 1. When you need to add a semi‑transparent watermark to every page of a scanned document stored as a multi‑page TIFF before archiving it.
 * 2. When you want to uniformly adjust the opacity of all frames in a multi‑page TIFF to blend with a background color for printing on colored paper.
 * 3. When a medical imaging application must apply a consistent alpha overlay to each slice of a multi‑page TIFF scan for visual analysis.
 * 4. When you are converting a multi‑page TIFF into a format that requires pre‑blended layers, such as preparing images for PDF generation with Aspose.Imaging.
 * 5. When you need to programmatically process each frame of a multi‑page TIFF to ensure the same opacity level for use in a web viewer that supports transparent images.
 */
