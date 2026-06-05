using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.cmx";
            string outputPath = "output.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the multi‑page CMX image
            using (CmxImage cmx = (CmxImage)Image.Load(inputPath))
            {
                // Determine canvas size from the CMX image
                int canvasWidth = cmx.Width;
                int canvasHeight = cmx.Height;

                // Prepare TIFF save options with a bound file source
                Source tiffSource = new FileCreateSource(outputPath, false);
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default) { Source = tiffSource };

                // Create a raster canvas for the final single‑page TIFF
                using (RasterImage canvas = (RasterImage)Image.Create(tiffOptions, canvasWidth, canvasHeight))
                {
                    // Iterate over each CMX page, rasterize it, and merge onto the canvas
                    foreach (var page in cmx.Pages)
                    {
                        // Rasterize the vector page to a PNG stored in memory
                        using (var memoryStream = new MemoryStream())
                        {
                            PngOptions pngOptions = new PngOptions { Source = new StreamSource(memoryStream) };
                            page.Save(memoryStream, pngOptions);
                            memoryStream.Position = 0;

                            // Load the rasterized page
                            using (RasterImage pageRaster = (RasterImage)Image.Load(memoryStream))
                            {
                                // Merge the page onto the canvas at (0,0)
                                Rectangle bounds = new Rectangle(0, 0, pageRaster.Width, pageRaster.Height);
                                canvas.SaveArgb32Pixels(bounds, pageRaster.LoadArgb32Pixels(pageRaster.Bounds));
                            }
                        }
                    }

                    // Save the merged single‑page TIFF
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