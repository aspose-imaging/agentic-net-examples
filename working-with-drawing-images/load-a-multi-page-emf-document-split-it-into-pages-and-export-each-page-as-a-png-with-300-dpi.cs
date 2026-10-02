// HOW-TO: Extract Each Page From Multi‑Page EMF And Save As 300 DPI PNG In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.emf";
            string outputDirectory = "output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDirectory);

            using (Image image = Image.Load(inputPath))
            {
                if (image is IMultipageImage multipageImage)
                {
                    int pageCount = multipageImage.PageCount;
                    for (int i = 0; i < pageCount; i++)
                    {
                        string outputPath = Path.Combine(outputDirectory, $"page_{i + 1}.png");
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        var vectorOptions = new VectorRasterizationOptions
                        {
                            PageWidth = image.Width,
                            PageHeight = image.Height,
                            BackgroundColor = Color.White
                        };

                        var pngOptions = new PngOptions
                        {
                            VectorRasterizationOptions = vectorOptions,
                            MultiPageOptions = new MultiPageOptions(new IntRange(i, i))
                        };

                        image.Save(outputPath, pngOptions);
                    }
                }
                else
                {
                    string outputPath = Path.Combine(outputDirectory, "page_1.png");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    var vectorOptions = new VectorRasterizationOptions
                    {
                        PageWidth = image.Width,
                        PageHeight = image.Height,
                        BackgroundColor = Color.White
                    };

                    var pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = vectorOptions
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
 * 1. When you need to convert a multi‑page vector EMF report into separate high‑resolution PNG images for web preview.
 * 2. When generating thumbnail previews of each page of a multi‑page EMF diagram for a document management system.
 * 3. When preparing printable PNG assets from each page of an EMF file at 300 DPI for inclusion in marketing materials.
 * 4. When extracting individual pages from a multi‑page EMF to feed into a machine‑learning pipeline that requires raster images.
 * 5. When automating the batch conversion of EMF drawings into PNGs for archival storage while preserving page separation.
 */
