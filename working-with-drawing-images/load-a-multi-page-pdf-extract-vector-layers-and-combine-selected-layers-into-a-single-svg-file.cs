// HOW-TO: Extract Selected PDF Pages and Merge into Single SVG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.pdf";
            string outputPath = "output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir);

            // Load PDF
            using (Image pdfImage = Image.Load(inputPath))
            {
                if (pdfImage is IMultipageImage multipagePdf)
                {
                    // Define selected page indices (0‑based)
                    int[] selectedPages = new int[] { 0, 2 };

                    List<RasterImage> pageRasters = new List<RasterImage>();
                    List<string> tempFiles = new List<string>();

                    foreach (int pageIndex in selectedPages)
                    {
                        if (pageIndex < 0 || pageIndex >= multipagePdf.PageCount)
                            continue;

                        string tempPngPath = $"temp_page_{pageIndex}.png";
                        tempFiles.Add(tempPngPath);

                        // Export selected page to PNG
                        PngOptions pngOptions = new PngOptions();
                        pngOptions.MultiPageOptions = new MultiPageOptions(new IntRange(pageIndex, 1));
                        pdfImage.Save(tempPngPath, pngOptions);

                        // Load PNG as raster image
                        RasterImage raster = (RasterImage)Image.Load(tempPngPath);
                        pageRasters.Add(raster);
                    }

                    // Calculate combined canvas size (vertical stacking)
                    int canvasWidth = 0;
                    int canvasHeight = 0;
                    foreach (var raster in pageRasters)
                    {
                        if (raster.Width > canvasWidth) canvasWidth = raster.Width;
                        canvasHeight += raster.Height;
                    }

                    // Create blank canvas
                    BmpOptions bmpOptions = new BmpOptions();
                    using (RasterImage canvas = (RasterImage)Image.Create(bmpOptions, canvasWidth, canvasHeight))
                    {
                        int offsetY = 0;
                        foreach (var raster in pageRasters)
                        {
                            Rectangle destRect = new Rectangle(0, offsetY, raster.Width, raster.Height);
                            canvas.SaveArgb32Pixels(destRect, raster.LoadArgb32Pixels(raster.Bounds));
                            offsetY += raster.Height;
                            raster.Dispose();
                        }

                        // Save combined canvas as SVG
                        SvgOptions svgOptions = new SvgOptions();
                        canvas.Save(outputPath, svgOptions);
                    }

                    // Clean up temporary PNG files
                    foreach (var tempFile in tempFiles)
                    {
                        if (File.Exists(tempFile))
                        {
                            try { File.Delete(tempFile); } catch { }
                        }
                    }
                }
                else
                {
                    Console.Error.WriteLine("The loaded file is not a multipage PDF.");
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
 * 1. When you need to convert specific pages of a multi‑page PDF into a scalable SVG for web graphics or print layouts.
 * 2. When you want to isolate vector layers from a PDF and combine them into one SVG file to reduce file size and simplify editing.
 * 3. When an application must programmatically generate SVG assets from chosen PDF pages for use in responsive UI components.
 * 4. When you are building a batch process that extracts only certain PDF pages and creates a single SVG to feed into a GIS or CAD workflow.
 * 5. When you need to preserve vector quality while exporting selected PDF content to SVG for high‑resolution marketing materials.
 */
