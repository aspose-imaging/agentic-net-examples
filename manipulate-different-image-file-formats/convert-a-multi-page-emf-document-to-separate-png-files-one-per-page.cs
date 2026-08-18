// HOW-TO: Convert Multi‑Page EMF To Individual PNG Images In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.emf";
            string outputDir = "output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (Image image = Image.Load(inputPath))
            {
                if (image is IMultipageImage multipageImage)
                {
                    int pageCount = multipageImage.PageCount;
                    for (int i = 0; i < pageCount; i++)
                    {
                        string outputPath = Path.Combine(outputDir, $"page_{i + 1}.png");
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                        var options = new PngOptions
                        {
                            MultiPageOptions = new MultiPageOptions(new IntRange(i, 1)),
                            VectorRasterizationOptions = new VectorRasterizationOptions
                            {
                                BackgroundColor = Color.White,
                                PageWidth = image.Width,
                                PageHeight = image.Height
                            }
                        };
                        image.Save(outputPath, options);
                    }
                }
                else
                {
                    string outputPath = Path.Combine(outputDir, "page_1.png");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                    var options = new PngOptions
                    {
                        VectorRasterizationOptions = new VectorRasterizationOptions
                        {
                            BackgroundColor = Color.White,
                            PageWidth = image.Width,
                            PageHeight = image.Height
                        }
                    };
                    image.Save(outputPath, options);
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
 * 1. When you need to extract each page of a vector‑based EMF report as separate PNG files for web display.
 * 2. When converting a multi‑page engineering diagram stored in EMF into raster PNG thumbnails for a document management system.
 * 3. When generating printable PNG assets from each page of a multi‑page EMF logo pack for inclusion in marketing materials.
 * 4. When processing batch EMF files to create per‑page PNG images for use in a slide‑show or presentation software.
 * 5. When automating the conversion of EMF pages to PNGs to feed an image‑processing pipeline that only accepts raster formats.
 */
