// HOW-TO: Merge Multi‑Page PDF Vector Graphics into a Single SVG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\document.pdf";
            string outputPath = "Output\\merged.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image pdfImage = Image.Load(inputPath))
            {
                if (!(pdfImage is IMultipageImage multipage))
                {
                    Console.Error.WriteLine("The input file is not a multipage image.");
                    return;
                }

                List<Size> pageSizes = new List<Size>();
                foreach (Image page in multipage.Pages)
                {
                    pageSizes.Add(new Size(page.Width, page.Height));
                }

                int canvasWidth = 0;
                int canvasHeight = 0;
                foreach (Size sz in pageSizes)
                {
                    if (sz.Width > canvasWidth) canvasWidth = sz.Width;
                    canvasHeight += sz.Height;
                }

                Source canvasSource = new FileCreateSource("temp_canvas.png", false);
                PngOptions canvasOptions = new PngOptions { Source = canvasSource };
                using (RasterImage canvas = (RasterImage)Image.Create(canvasOptions, canvasWidth, canvasHeight))
                {
                    Graphics graphics = new Graphics(canvas);
                    graphics.Clear(Color.White);

                    int offsetY = 0;
                    for (int i = 0; i < multipage.PageCount; i++)
                    {
                        Image page = multipage.Pages[i];
                        using (MemoryStream ms = new MemoryStream())
                        {
                            page.Save(ms, new PngOptions());
                            ms.Position = 0;
                            using (RasterImage pageRaster = (RasterImage)Image.Load(ms))
                            {
                                Rectangle destRect = new Rectangle(0, offsetY, pageRaster.Width, pageRaster.Height);
                                canvas.SaveArgb32Pixels(destRect, pageRaster.LoadArgb32Pixels(pageRaster.Bounds));
                                offsetY += pageRaster.Height;
                            }
                        }
                    }

                    SvgOptions svgOptions = new SvgOptions();
                    canvas.Save(outputPath, svgOptions);
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
 * 1. When you need to embed all pages of a PDF brochure as one scalable SVG graphic for responsive web design.
 * 2. When you want to combine vector‑based PDF reports into a single SVG file for printing on large format printers.
 * 3. When an application must convert multi‑page PDF invoices into one SVG canvas to overlay annotations programmatically.
 * 4. When a document management system requires merging PDF pages into a single SVG to reduce file handling complexity.
 * 5. When generating a single SVG sprite from a PDF catalog to improve loading performance in a C# desktop application.
 */
