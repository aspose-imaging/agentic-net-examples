// HOW-TO: Convert Multi‑Page CMX to Single Page PDF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
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
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Temporary raster canvas file path
            string tempCanvasPath = Path.Combine(Path.GetDirectoryName(outputPath), "temp_canvas.jpg");
            Directory.CreateDirectory(Path.GetDirectoryName(tempCanvasPath));

            // Load CMX image
            using (CmxImage cmx = (CmxImage)Image.Load(inputPath))
            {
                // Determine canvas size (stack pages vertically)
                int canvasWidth = 0;
                int canvasHeight = 0;
                foreach (Image page in cmx.Pages)
                {
                    if (page.Width > canvasWidth) canvasWidth = page.Width;
                    canvasHeight += page.Height;
                }

                // Create raster canvas bound to temporary file
                Source canvasSource = new FileCreateSource(tempCanvasPath, false);
                JpegOptions canvasOptions = new JpegOptions { Source = canvasSource, Quality = 100 };
                using (RasterImage canvas = (RasterImage)Image.Create(canvasOptions, canvasWidth, canvasHeight))
                {
                    int offsetY = 0;
                    foreach (Image page in cmx.Pages)
                    {
                        // Rasterize current page to a memory stream
                        using (MemoryStream ms = new MemoryStream())
                        {
                            JpegOptions pageOptions = new JpegOptions { Source = new StreamSource(ms) };
                            pageOptions.VectorRasterizationOptions = new CmxRasterizationOptions
                            {
                                BackgroundColor = Aspose.Imaging.Color.White
                            };
                            page.Save(ms, pageOptions);
                            ms.Position = 0;

                            // Load rasterized page
                            using (RasterImage pageRaster = (RasterImage)Image.Load(ms))
                            {
                                // Copy page pixels onto canvas
                                Aspose.Imaging.Rectangle bounds = new Aspose.Imaging.Rectangle(0, offsetY, pageRaster.Width, pageRaster.Height);
                                canvas.SaveArgb32Pixels(bounds, pageRaster.LoadArgb32Pixels(pageRaster.Bounds));
                                offsetY += pageRaster.Height;
                            }
                        }
                    }

                    // Save the raster canvas to the temporary file
                    canvas.Save();
                }
            }

            // Load the completed raster canvas and save as PDF
            using (RasterImage finalImage = (RasterImage)Image.Load(tempCanvasPath))
            {
                PdfOptions pdfOptions = new PdfOptions();
                finalImage.Save(outputPath, pdfOptions);
            }

            // Optionally delete temporary canvas file
            if (File.Exists(tempCanvasPath))
            {
                File.Delete(tempCanvasPath);
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
 * 1. When you need to archive legacy CorelDRAW CMX drawings as a single PDF for easy sharing with clients who only view PDFs.
 * 2. When a print workflow requires merging all pages of a multi‑page CMX file into one PDF page to fit a fixed‑size form or label.
 * 3. When an automated document conversion service must transform CMX files into searchable PDFs without preserving individual page boundaries.
 * 4. When a batch processing tool has to generate a compact PDF preview of a CMX file for web display, stacking pages vertically to keep the layout intact.
 * 5. When integrating Aspose.Imaging into a C# application that consolidates multiple CMX pages into a single PDF report for regulatory compliance documentation.
 */
