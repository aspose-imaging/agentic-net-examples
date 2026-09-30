// HOW-TO: Flatten Multipage CMX into Single Page PDF Using C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/sample.cmx";
        string outputPath = "Output/output.pdf";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Aspose.Imaging.Image cmxImage = Aspose.Imaging.Image.Load(inputPath))
            {
                var multipage = cmxImage as Aspose.Imaging.IMultipageImage;
                if (multipage == null)
                {
                    Console.Error.WriteLine("Input image is not a multipage CMX image.");
                    return;
                }

                List<Aspose.Imaging.Size> pageSizes = new List<Aspose.Imaging.Size>();
                List<Aspose.Imaging.RasterImage> rasterPages = new List<Aspose.Imaging.RasterImage>();

                for (int i = 0; i < multipage.PageCount; i++)
                {
                    Aspose.Imaging.Image page = multipage.Pages[i];
                    using (var ms = new MemoryStream())
                    {
                        page.Save(ms, new PngOptions());
                        ms.Position = 0;
                        Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(ms);
                        rasterPages.Add(raster);
                        pageSizes.Add(raster.Size);
                    }
                }

                int canvasWidth = pageSizes.Max(s => s.Width);
                int canvasHeight = pageSizes.Sum(s => s.Height);

                PdfOptions pdfOptions = new PdfOptions();

                using (Aspose.Imaging.RasterImage canvas = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Create(pdfOptions, canvasWidth, canvasHeight))
                {
                    Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(canvas);
                    int offsetY = 0;
                    foreach (var raster in rasterPages)
                    {
                        graphics.DrawImage(raster, new Aspose.Imaging.Point(0, offsetY));
                        offsetY += raster.Height;
                        raster.Dispose();
                    }

                    canvas.Save(outputPath, pdfOptions);
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
 * 1. When you need to archive a multi‑page Corel Metafile (CMX) as a single, compact PDF for easy sharing or storage.
 * 2. When generating a printable PDF that combines all CMX pages onto one sheet for quick visual review.
 * 3. When converting legacy CMX design files into a single‑page PDF to embed in technical documentation or reports.
 * 4. When creating a PDF preview of a CMX drawing set without preserving individual page boundaries, simplifying navigation.
 * 5. When automating batch processing of CMX files to produce flattened single‑page PDFs for compliance or record‑keeping purposes.
 */
