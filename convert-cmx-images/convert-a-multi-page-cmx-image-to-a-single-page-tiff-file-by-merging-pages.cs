using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.cmx";
            string outputPath = "output.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir);

            // Load CMX multipage vector image
            using (Aspose.Imaging.FileFormats.Cmx.CmxImage cmxImage = (Aspose.Imaging.FileFormats.Cmx.CmxImage)Image.Load(inputPath))
            {
                int canvasWidth = cmxImage.Width;
                int canvasHeight = cmxImage.Height;

                // Prepare TIFF options for the output file
                Source fileSource = new FileCreateSource(outputPath, false);
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    Source = fileSource,
                    Photometric = TiffPhotometrics.Rgb,
                    BitsPerSample = new ushort[] { 8, 8, 8 }
                };

                // Create a raster canvas bound to the output TIFF file
                using (RasterImage canvas = (RasterImage)Image.Create(tiffOptions, canvasWidth, canvasHeight))
                {
                    // Iterate each page of the CMX image, rasterize and merge onto the canvas
                    foreach (var page in cmxImage.Pages)
                    {
                        using (var ms = new MemoryStream())
                        {
                            // Rasterize the page to PNG in memory
                            PngOptions pngOpts = new PngOptions { Source = new StreamSource(ms) };
                            page.Save(ms, pngOpts);
                            ms.Position = 0;

                            // Load the rasterized page
                            using (RasterImage pageRaster = (RasterImage)Image.Load(ms))
                            {
                                // Overlay the page onto the canvas at (0,0)
                                var bounds = new Rectangle(0, 0, pageRaster.Width, pageRaster.Height);
                                canvas.SaveArgb32Pixels(bounds, pageRaster.LoadArgb32Pixels(pageRaster.Bounds));
                            }
                        }
                    }

                    // Save the merged single-page TIFF
                    canvas.Save();
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
 * 1. When an engineering firm needs to archive multi‑page CorelDRAW CMX drawings as a single, searchable TIFF file for long‑term document management.
 * 2. When a printing service must combine several CMX vector pages into one high‑resolution TIFF to send to a RIP (Raster Image Processor) that only accepts single‑page TIFFs.
 * 3. When a legal department wants to merge multiple CMX schematics into a single TIFF for inclusion in electronic case files that require non‑editable image formats.
 * 4. When a GIS application requires converting multi‑page CMX map layers into one raster TIFF to overlay on satellite imagery.
 * 5. When a medical device manufacturer needs to consolidate CMX design sheets into a single TIFF for compliance reporting that mandates flat‑image formats.
 */