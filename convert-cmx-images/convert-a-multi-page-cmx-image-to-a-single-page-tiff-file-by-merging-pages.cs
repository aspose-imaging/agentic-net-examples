using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
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
            int canvasWidth = cmx.Width;
            int canvasHeight = cmx.Height;

            // Create a temporary raster canvas (PNG) to merge pages
            Source canvasSource = new FileCreateSource("tempCanvas.png", false);
            PngOptions canvasOptions = new PngOptions { Source = canvasSource };
            using (RasterImage canvas = (RasterImage)Image.Create(canvasOptions, canvasWidth, canvasHeight))
            {
                foreach (CmxImagePage page in cmx.Pages)
                {
                    using (var ms = new MemoryStream())
                    {
                        // Render the page to a PNG in memory
                        PngOptions pageOptions = new PngOptions { Source = new StreamSource(ms) };
                        page.Save(ms, pageOptions);
                        ms.Position = 0;

                        using (RasterImage pageRaster = (RasterImage)Image.Load(ms))
                        {
                            // Merge the page onto the canvas at (0,0)
                            canvas.SaveArgb32Pixels(
                                new Rectangle(0, 0, pageRaster.Width, pageRaster.Height),
                                pageRaster.LoadArgb32Pixels(pageRaster.Bounds));
                        }
                    }
                }

                // Save the merged canvas as a single‑page TIFF
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    Source = new FileCreateSource(outputPath, false)
                };
                canvas.Save(outputPath, tiffOptions);
            }
        }
    }
}