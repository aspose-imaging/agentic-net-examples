using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/multipage.svg";
            string outputDir = "Output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDir);

            using (Image image = Image.Load(inputPath))
            {
                var multipage = image as IMultipageImage;
                if (multipage == null)
                {
                    string outputPath = Path.Combine(outputDir, "page_1.png");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    var pngOptions = new PngOptions
                    {
                        ResolutionSettings = new ResolutionSetting(300, 300),
                        VectorRasterizationOptions = new VectorRasterizationOptions
                        {
                            BackgroundColor = Color.White,
                            PageWidth = image.Width,
                            PageHeight = image.Height
                        }
                    };

                    image.Save(outputPath, pngOptions);
                }
                else
                {
                    int pageCount = multipage.PageCount;
                    for (int i = 0; i < pageCount; i++)
                    {
                        string outputPath = Path.Combine(outputDir, $"page_{i + 1}.png");
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        var pngOptions = new PngOptions
                        {
                            ResolutionSettings = new ResolutionSetting(300, 300),
                            VectorRasterizationOptions = new VectorRasterizationOptions
                            {
                                BackgroundColor = Color.White,
                                PageWidth = image.Width,
                                PageHeight = image.Height
                            },
                            MultiPageOptions = new MultiPageOptions(new IntRange(i, 1))
                        };

                        image.Save(outputPath, pngOptions);
                    }
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
 * 1. When a web application must generate high‑resolution printable assets from a multi‑page SVG diagram, a developer can use this C# code with Aspose.Imaging to export each page as a 300 DPI PNG file.
 * 2. When an e‑learning platform needs to convert multi‑page vector illustrations into raster images for offline PDF packaging, the code converts each SVG page to a 300 DPI PNG suitable for embedding.
 * 3. When a desktop publishing workflow requires extracting individual pages from a multi‑page SVG logo set and saving them as PNG thumbnails at 300 DPI for preview galleries, this snippet automates the process.
 * 4. When a reporting service must transform SVG charts into high‑quality PNG images for inclusion in printed reports, the code iterates through the SVG pages and saves them with 300 DPI resolution using Aspose.Imaging for .NET.
 * 5. When a mobile app backend needs to serve rasterized PNG versions of each page of a multi‑page SVG map at 300 DPI for devices that cannot render SVG, the provided C# example performs the conversion efficiently.
 */