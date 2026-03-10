using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;

class JpgToPdfViaSvg
{
    static void Main()
    {
        // Paths of source JPG files
        string[] jpgFiles = { "image1.jpg", "image2.jpg", "image3.jpg" };
        // Destination PDF file
        string outputPdf = "merged.pdf";

        // Store generated SVG pages
        List<SvgImage> svgPages = new List<SvgImage>();

        foreach (var jpgPath in jpgFiles)
        {
            // Load the JPG as a raster image
            using (RasterImage raster = (RasterImage)Image.Load(jpgPath))
            {
                // Create an SVG canvas with the same dimensions as the raster image
                var graphics = new SvgGraphics2D(raster.Width, raster.Height, 96);

                // Draw the raster image onto the SVG canvas
                graphics.DrawImage(raster, new Point(0, 0), new Size(raster.Width, raster.Height));

                // Finalize SVG recording and obtain the SvgImage instance
                SvgImage svg = graphics.EndRecording();

                // Keep the SVG page for later PDF assembly
                svgPages.Add(svg);
            }
        }

        // Configure PDF options to treat each SVG as a separate page
        var pdfOptions = new PdfOptions
        {
            MultiPageOptions = new MultiPageOptions(new IntRange(0, svgPages.Count - 1))
        };

        // Save all SVG pages into a single PDF file.
        // The first SVG acts as the base image; additional pages are taken from the list.
        using (SvgImage firstPage = svgPages[0])
        {
            firstPage.Save(outputPdf, pdfOptions);
        }

        // Dispose any remaining SVG pages
        for (int i = 1; i < svgPages.Count; i++)
        {
            svgPages[i].Dispose();
        }
    }
}