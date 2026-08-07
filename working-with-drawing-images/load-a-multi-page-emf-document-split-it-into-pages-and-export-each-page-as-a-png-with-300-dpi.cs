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
            string inputPath = "input.emf";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (Image image = Image.Load(inputPath))
            {
                IMultipageImage multipage = image as IMultipageImage;
                int pageCount = multipage != null ? multipage.PageCount : 1;

                for (int i = 0; i < pageCount; i++)
                {
                    string outputPath = $"output/page_{i + 1}.png";
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    PngOptions pngOptions = new PngOptions
                    {
                        ResolutionSettings = new ResolutionSetting(300, 300),
                        MultiPageOptions = new MultiPageOptions(new IntRange(i, i + 1))
                    };

                    if (image is VectorImage)
                    {
                        var vectorOptions = new VectorRasterizationOptions
                        {
                            BackgroundColor = Color.White,
                            PageWidth = image.Width,
                            PageHeight = image.Height,
                            TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                            SmoothingMode = SmoothingMode.None
                        };
                        pngOptions.VectorRasterizationOptions = vectorOptions;
                    }

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
 * 1. When a developer must convert multi‑page EMF documents such as engineering drawings into high‑resolution 300 DPI PNG files for web display or PDF generation, this code splits each page and rasterizes it automatically.
 * 2. When an application needs to extract individual pages from a multi‑page vector chart saved as EMF and save them as PNG thumbnails for a document management system, the example provides a ready‑to‑use C# solution.
 * 3. When a reporting tool generates multi‑page EMF reports and the client requires printable PNG assets at 300 DPI for marketing materials, the code can batch‑process and export each page separately.
 * 4. When a migration project moves legacy EMF assets into a modern image repository that only accepts PNG images, this snippet efficiently splits the EMF file and preserves detail by rasterizing each page at 300 DPI.
 * 5. When a GIS or CAD integration needs to display each sheet of a multi‑page EMF map as a high‑quality PNG overlay in a web‑based viewer, the code handles page extraction and resolution settings in C# with Aspose.Imaging.
 */