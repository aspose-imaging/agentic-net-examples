// HOW-TO: Convert Multi‑Page PDF Maps to High‑Resolution TIFF Files in C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input\\maps.pdf";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDirectory = "Output";
            Directory.CreateDirectory(outputDirectory);

            using (Image pdfImage = Image.Load(inputPath))
            {
                if (pdfImage is IMultipageImage multipage)
                {
                    int pageCount = multipage.PageCount;
                    for (int i = 0; i < pageCount; i++)
                    {
                        string outputPath = Path.Combine(outputDirectory, $"page_{i + 1}.tif");
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.TiffLzwRgb);
                        tiffOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                        {
                            BackgroundColor = Color.White,
                            PageWidth = 3000,
                            PageHeight = 3000
                        };
                        tiffOptions.MultiPageOptions = new MultiPageOptions(new IntRange(i, 1));

                        pdfImage.Save(outputPath, tiffOptions);
                    }
                }
                else
                {
                    Console.Error.WriteLine("The loaded file is not a multipage image.");
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
 * 1. When a GIS analyst needs to extract each page of a vector‑based PDF map into a separate high‑resolution TIFF for raster‑based spatial analysis.
 * 2. When a developer wants to batch‑convert multi‑page engineering PDFs into individual LZW‑compressed TIFF files for long‑term archival.
 * 3. When a mapping application requires converting PDF map layers to TIFF images with a white background and fixed pixel dimensions for efficient rendering.
 * 4. When a data‑processing pipeline must rasterize vector PDF pages at 3000 × 3000 pixels to feed a machine‑learning model that expects TIFF input.
 * 5. When an automated reporting system needs to split a PDF document into per‑page TIFF files for high‑quality printing or distribution.
 */
