using System;
using System.IO;
using System.Collections.Generic;
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
            // Hardcoded input and output paths
            string inputPath = "input.cmx";
            string outputPath = "output.tif";

            // Validate input file existence
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
                // Prepare vector rasterization options (white background)
                var vectorOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Color.White,
                    PageWidth = cmx.Width,
                    PageHeight = cmx.Height
                };

                // Collect rasterized pages
                List<RasterImage> rasterPages = new List<RasterImage>();
                for (int i = 0; i < cmx.PageCount; i++)
                {
                    // Export only the current page to a PNG in memory
                    PngOptions pngOptions = new PngOptions
                    {
                        Source = new StreamSource(new MemoryStream()),
                        VectorRasterizationOptions = vectorOptions,
                        MultiPageOptions = new MultiPageOptions(new IntRange(i, 1))
                    };

                    using (MemoryStream ms = new MemoryStream())
                    {
                        cmx.Save(ms, pngOptions);
                        ms.Position = 0;
                        RasterImage raster = (RasterImage)Image.Load(ms);
                        rasterPages.Add(raster);
                    }
                }

                // Determine canvas size (vertical stacking)
                int canvasWidth = 0;
                int canvasHeight = 0;
                foreach (var page in rasterPages)
                {
                    if (page.Width > canvasWidth) canvasWidth = page.Width;
                    canvasHeight += page.Height;
                }

                // Create TIFF canvas bound to the output file
                Source fileSource = new FileCreateSource(outputPath, false);
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    Source = fileSource,
                    Photometric = TiffPhotometrics.Rgb,
                    BitsPerSample = new ushort[] { 8, 8, 8 }
                };

                using (RasterImage canvas = (RasterImage)Image.Create(tiffOptions, canvasWidth, canvasHeight))
                {
                    // Merge pages vertically
                    int offsetY = 0;
                    foreach (var page in rasterPages)
                    {
                        var bounds = new Rectangle(0, offsetY, page.Width, page.Height);
                        canvas.SaveArgb32Pixels(bounds, page.LoadArgb32Pixels(page.Bounds));
                        offsetY += page.Height;
                        page.Dispose();
                    }

                    // Save the merged TIFF (already bound to file source)
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