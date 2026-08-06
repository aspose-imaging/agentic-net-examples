using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.cmx";
            string outputPath = "output.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir);

            // Load CMX image
            using (CmxImage cmx = (CmxImage)Image.Load(inputPath))
            {
                // Cache all pages to avoid repeated loading
                foreach (Image page in cmx.Pages)
                {
                    page.CacheData();
                }

                // Determine canvas size (stack pages vertically)
                int maxWidth = 0;
                int totalHeight = 0;
                foreach (Image page in cmx.Pages)
                {
                    if (page.Width > maxWidth) maxWidth = page.Width;
                    totalHeight += page.Height;
                }

                // Create an unbound raster canvas (JPEG format)
                using (RasterImage canvas = (RasterImage)Image.Create(new JpegOptions(), maxWidth, totalHeight))
                {
                    int offsetY = 0;
                    foreach (Image page in cmx.Pages)
                    {
                        // Render page to a temporary PNG in memory
                        using (MemoryStream ms = new MemoryStream())
                        {
                            page.Save(ms, new PngOptions());
                            ms.Position = 0;
                            using (RasterImage pageRaster = (RasterImage)Image.Load(ms))
                            {
                                // Copy page pixels onto canvas
                                Rectangle bounds = new Rectangle(0, offsetY, pageRaster.Width, pageRaster.Height);
                                canvas.SaveArgb32Pixels(bounds, pageRaster.LoadArgb32Pixels(pageRaster.Bounds));
                                offsetY += pageRaster.Height;
                            }
                        }
                    }

                    // Save the combined canvas as a single‑page PDF
                    canvas.Save(outputPath, new PdfOptions());
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
 * 1. When a printing company receives multi‑page CorelDRAW CMX files and must deliver a single‑page PDF proof to a client for quick review.
 * 2. When an archival system needs to store legacy CMX artwork as a compact PDF where all layers are flattened onto one page for easy indexing.
 * 3. When a web application generates a downloadable PDF catalog from a CMX design that contains several pages, merging them into one continuous page for seamless scrolling.
 * 4. When a document management workflow requires converting multi‑page CMX drawings into a single‑page PDF to embed in a larger report without preserving individual page boundaries.
 * 5. When an automated batch process consolidates CMX files into a single‑page PDF for compliance audits, ensuring all pages are rasterized and flattened for consistent rendering.
 */