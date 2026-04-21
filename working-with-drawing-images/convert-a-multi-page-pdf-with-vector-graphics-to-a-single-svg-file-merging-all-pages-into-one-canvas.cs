using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "Input/multipage.pdf";
        string outputPath = "Output/merged.svg";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PDF document
        using (Image pdfImage = Image.Load(inputPath))
        {
            // Cast to multipage interface
            IMultipageImage multipage = pdfImage as IMultipageImage;
            if (multipage == null || multipage.Pages == null)
            {
                Console.Error.WriteLine("The input file does not contain multiple pages.");
                return;
            }

            // Collect page sizes
            List<Size> pageSizes = new List<Size>();
            foreach (var page in multipage.Pages)
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

            // Prepare SVG options
            SvgOptions svgOptions = new SvgOptions
            {
                TextAsShapes = true
            };

            // Create an empty SVG canvas
            using (SvgImage canvas = new SvgImage(svgOptions, canvasWidth, canvasHeight))
            {
                // Graphics object for drawing
                Graphics graphics = new Graphics(canvas);

                int offsetY = 0;
                foreach (var page in multipage.Pages)
                {
                    // Rasterize the current page to PNG in memory
                    using (MemoryStream ms = new MemoryStream())
                    {
                        PngOptions pngOpts = new PngOptions
                        {
                            VectorRasterizationOptions = new SvgRasterizationOptions
                            {
                                PageSize = page.Size
                            }
                        };
                        page.Save(ms, pngOpts);
                        ms.Position = 0;

                        // Load rasterized image
                        using (RasterImage raster = (RasterImage)Image.Load(ms))
                        {
                            // Draw raster image onto SVG canvas
                            graphics.DrawImage(raster, new Point(0, offsetY));
                        }
                    }

                    offsetY += page.Height;
                }

                // Save the merged SVG
                canvas.Save(outputPath, svgOptions);
            }
        }
    }
}