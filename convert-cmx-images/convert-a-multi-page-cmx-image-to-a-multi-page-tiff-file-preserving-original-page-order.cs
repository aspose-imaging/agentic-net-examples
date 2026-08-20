// HOW-TO: Convert Multi‑Page CMX to Multi‑Page TIFF in C# with Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.cmx";
        string outputPath = "output.tif";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image image = Image.Load(inputPath))
            {
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

                if (image is VectorImage)
                {
                    tiffOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height,
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = SmoothingMode.None
                    };
                }

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
 * 1. When you need to archive a multi‑page CMX design as a single TIFF document for long‑term storage or printing.
 * 2. When a workflow requires converting vector‑based CMX pages to raster TIFF pages while preserving the original page sequence.
 * 3. When integrating Aspose.Imaging into a C# application to batch‑process CMX files into TIFFs for compatibility with legacy imaging systems.
 * 4. When you must ensure each CMX page is rasterized with a white background and no smoothing before saving as TIFF.
 * 5. When an automated service must validate the existence of the source CMX file, create output directories, and handle errors during the conversion to TIFF.
 */
