using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.cmx";
        string outputPath = "output.pdf";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        string outputDir = Path.GetDirectoryName(outputPath);
        Directory.CreateDirectory(outputDir);

        // Load CMX image
        using (Aspose.Imaging.FileFormats.Cmx.CmxImage cmxImage = (Aspose.Imaging.FileFormats.Cmx.CmxImage)Aspose.Imaging.Image.Load(inputPath))
        {
            // Collect page sizes
            List<Aspose.Imaging.Size> pageSizes = new List<Aspose.Imaging.Size>();
            foreach (Aspose.Imaging.Image page in cmxImage.Pages)
            {
                pageSizes.Add(page.Size);
            }

            // Determine canvas dimensions (vertical stacking)
            int canvasWidth = 0;
            int canvasHeight = 0;
            foreach (var sz in pageSizes)
            {
                if (sz.Width > canvasWidth) canvasWidth = sz.Width;
                canvasHeight += sz.Height;
            }

            // Create an unbound raster canvas (JPEG format)
            JpegOptions canvasOptions = new JpegOptions() { Quality = 100 };
            using (Aspose.Imaging.RasterImage canvas = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Create(canvasOptions, canvasWidth, canvasHeight))
            {
                int offsetY = 0;
                foreach (Aspose.Imaging.Image page in cmxImage.Pages)
                {
                    // Rasterize the page to a PNG in memory
                    using (MemoryStream ms = new MemoryStream())
                    {
                        page.Save(ms, new PngOptions());
                        ms.Position = 0;
                        using (Aspose.Imaging.RasterImage pageRaster = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(ms))
                        {
                            // Copy page pixels onto the canvas
                            Aspose.Imaging.Rectangle bounds = new Aspose.Imaging.Rectangle(0, offsetY, pageRaster.Width, pageRaster.Height);
                            canvas.SaveArgb32Pixels(bounds, pageRaster.LoadArgb32Pixels(pageRaster.Bounds));
                            offsetY += pageRaster.Height;
                        }
                    }
                }

                // Save the combined canvas as a single‑page PDF
                PdfOptions pdfOptions = new PdfOptions();
                canvas.Save(outputPath, pdfOptions);
            }
        }
    }
}