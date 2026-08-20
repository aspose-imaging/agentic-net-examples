// HOW-TO: Apply 200 Opacity Alpha Blend to Each Frame of Multi‑Page TIFF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = @"c:\temp\input.tif";
        string outputPath = @"c:\temp\output.tif";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (TiffImage tiff = (TiffImage)Image.Load(inputPath))
            {
                for (int i = 0; i < tiff.Frames.Length; i++)
                {
                    RasterImage frame = (RasterImage)tiff.Frames[i];
                    frame.Blend(new Point(0, 0), frame, 200);
                }

                tiff.Save(outputPath);
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
 * 1. When you need to make every page of a scanned multi‑page TIFF semi‑transparent for overlaying on a background document in a C# application.
 * 2. When generating watermarked PDF previews by blending each TIFF frame with a logo at 200 opacity using Aspose.Imaging.
 * 3. When creating a layered animation from a multi‑page TIFF where each frame must share the same alpha level before exporting.
 * 4. When processing archival TIFF files to uniformly reduce their opacity for visual comparison in a .NET image‑processing pipeline.
 * 5. When integrating a document‑management system that requires all pages of uploaded TIFFs to be blended with a specific opacity for consistent UI rendering.
 */
