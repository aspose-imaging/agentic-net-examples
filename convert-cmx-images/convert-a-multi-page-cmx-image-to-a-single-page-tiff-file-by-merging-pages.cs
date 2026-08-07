using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

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

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (CmxImage cmx = (CmxImage)Image.Load(inputPath))
            {
                // Assume all pages have the same dimensions; use the first page size for the canvas.
                var firstPage = (CmxImagePage)cmx.Pages[0];
                int canvasWidth = firstPage.Width;
                int canvasHeight = firstPage.Height;

                // Prepare TIFF save options.
                Source tiffSource = new FileCreateSource(outputPath, false);
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    Source = tiffSource,
                    Photometric = TiffPhotometrics.Rgb,
                    BitsPerSample = new ushort[] { 8, 8, 8 }
                };

                // Create a raster canvas bound to the output file.
                using (RasterImage canvas = (RasterImage)Image.Create(tiffOptions, canvasWidth, canvasHeight))
                {
                    foreach (CmxImagePage page in cmx.Pages)
                    {
                        // Render each CMX page to a PNG in memory.
                        using (var memoryStream = new MemoryStream())
                        {
                            PngOptions pngOptions = new PngOptions
                            {
                                Source = new StreamSource(memoryStream)
                            };
                            page.Save(memoryStream, pngOptions);
                            memoryStream.Position = 0;

                            // Load the rendered PNG as a raster image.
                            using (RasterImage raster = (RasterImage)Image.Load(memoryStream))
                            {
                                // Merge the raster page onto the canvas at (0,0).
                                canvas.SaveArgb32Pixels(
                                    new Rectangle(0, 0, raster.Width, raster.Height),
                                    raster.LoadArgb32Pixels(raster.Bounds));
                            }
                        }
                    }

                    // Save the bound TIFF image.
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
 * 1. When a printing workflow requires consolidating multi‑page CMX drawings into a single‑page TIFF for archival or downstream raster processing.
 * 2. When a CAD system needs to export a multi‑page CMX design as a high‑resolution TIFF to be imported into a GIS application that only accepts TIFF.
 * 3. When an automated document conversion service must merge each page of a CMX file into one TIFF image for batch uploading to a cloud storage that supports TIFF.
 * 4. When a quality‑control tool has to render every page of a CMX blueprint into a single raster canvas so that pixel‑level inspection can be performed on a TIFF file.
 * 5. When a legacy imaging pipeline expects a single‑page RGB TIFF but the source assets are multi‑page CMX files, requiring on‑the‑fly conversion in C#.
 */