using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.pdf";
        string outputPath = "output.svg";

        // Verify input file exists
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

        // Load PDF and rasterize each page to PNG in memory
        List<RasterImage> rasterPages = new List<RasterImage>();
        List<Size> pageSizes = new List<Size>();

        using (Image pdfImage = Image.Load(inputPath))
        {
            IMultipageImage multipage = pdfImage as IMultipageImage;
            if (multipage != null)
            {
                for (int i = 0; i < multipage.PageCount; i++)
                {
                    Image page = multipage.Pages[i];
                    using (MemoryStream ms = new MemoryStream())
                    {
                        PngOptions pngOpts = new PngOptions();
                        page.Save(ms, pngOpts);
                        ms.Position = 0;
                        RasterImage raster = (RasterImage)Image.Load(ms);
                        rasterPages.Add(raster);
                        pageSizes.Add(new Size(raster.Width, raster.Height));
                    }
                    page.Dispose();
                }
            }
            else
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    PngOptions pngOpts = new PngOptions();
                    pdfImage.Save(ms, pngOpts);
                    ms.Position = 0;
                    RasterImage raster = (RasterImage)Image.Load(ms);
                    rasterPages.Add(raster);
                    pageSizes.Add(new Size(raster.Width, raster.Height));
                }
            }
        }

        // Calculate canvas size for vertical stacking
        int canvasWidth = 0;
        int canvasHeight = 0;
        foreach (var sz in pageSizes)
        {
            if (sz.Width > canvasWidth) canvasWidth = sz.Width;
            canvasHeight += sz.Height;
        }

        // Create SVG canvas
        SvgGraphics2D graphics = new SvgGraphics2D(canvasWidth, canvasHeight, 96);

        // Draw each raster page onto the SVG canvas
        int offsetY = 0;
        for (int i = 0; i < rasterPages.Count; i++)
        {
            RasterImage raster = rasterPages[i];
            graphics.DrawImage(raster, new Point(0, offsetY), new Size(raster.Width, raster.Height));
            offsetY += raster.Height;
            raster.Dispose();
        }

        // Finalize SVG and save
        using (SvgImage finalSvg = graphics.EndRecording())
        {
            finalSvg.Save(outputPath);
        }
    }
}