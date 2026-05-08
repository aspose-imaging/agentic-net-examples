using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "sample.cmx";
            string outputPath = "output.pdf";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrWhiteSpace(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Load CMX image
            using (CmxImage cmx = (CmxImage)Image.Load(inputPath))
            {
                // First pass: determine canvas size by rasterizing each page to get dimensions
                List<Size> pageSizes = new List<Size>();
                foreach (Image page in cmx.Pages)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        page.Save(ms, new PngOptions());
                        ms.Position = 0;
                        using (RasterImage raster = (RasterImage)Image.Load(ms))
                        {
                            pageSizes.Add(raster.Size);
                        }
                    }
                }

                int canvasWidth = pageSizes.Max(s => s.Width);
                int canvasHeight = pageSizes.Sum(s => s.Height);

                // Create raster canvas (JPEG) to hold all pages vertically
                JpegOptions jpegOptions = new JpegOptions() { Quality = 100 };
                using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
                {
                    int offsetY = 0;
                    // Second pass: rasterize each page again and copy pixels onto the canvas
                    foreach (Image page in cmx.Pages)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            page.Save(ms, new PngOptions());
                            ms.Position = 0;
                            using (RasterImage raster = (RasterImage)Image.Load(ms))
                            {
                                Rectangle bounds = new Rectangle(0, offsetY, raster.Width, raster.Height);
                                canvas.SaveArgb32Pixels(bounds, raster.LoadArgb32Pixels(raster.Bounds));
                                offsetY += raster.Height;
                            }
                        }
                    }

                    // Save the combined canvas as a single‑page PDF
                    PdfOptions pdfOptions = new PdfOptions();
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