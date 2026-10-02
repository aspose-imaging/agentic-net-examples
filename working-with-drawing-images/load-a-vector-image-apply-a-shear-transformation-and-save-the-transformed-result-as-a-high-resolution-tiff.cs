// HOW-TO: Convert SVG to High Resolution TIFF with 300 DPI in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string outputPath = "output.tif";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image vectorImage = Image.Load(inputPath))
            {
                int width = vectorImage.Width;
                int height = vectorImage.Height;

                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiffOptions.ResolutionSettings = new ResolutionSetting(300, 300);

                using (Image tiffImage = Image.Create(tiffOptions, width, height))
                {
                    Graphics graphics = new Graphics(tiffImage);
                    graphics.DrawImage(vectorImage, new Point(0, 0));

                    tiffImage.Save(outputPath, tiffOptions);
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
 * 1. When you need to rasterize an SVG logo into a 300 dpi TIFF for high‑quality printing.
 * 2. When a desktop application must generate a high‑resolution TIFF preview from a vector diagram.
 * 3. When a reporting tool requires embedding a scalable SVG as a TIFF image with exact dimensions and DPI.
 * 4. When converting vector artwork to a TIFF format for archival storage while preserving resolution settings.
 * 5. When automating batch processing of SVG files into print‑ready TIFF files in a .NET workflow.
 */
