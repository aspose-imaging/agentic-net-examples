using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.Sources;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.tif";
        string outputPath = @"C:\Images\output.webp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the multi‑page TIFF
        using (RasterCachedMultipageImage tiffImage = (RasterCachedMultipageImage)Image.Load(inputPath))
        {
            // First pass: determine the size of the final WebP image
            int maxWidth = 0;
            int totalHeight = 0;
            foreach (var pageObj in tiffImage.Pages)
            {
                var page = (RasterImage)pageObj;
                if (page.Width > maxWidth) maxWidth = page.Width;
                totalHeight += page.Height;
                page.Dispose(); // release resources immediately
                GC.Collect();
            }

            // Create a blank WebP image with the calculated dimensions
            var webpOptions = new WebPOptions();
            using (Image webpImage = Image.Create(webpOptions, maxWidth, totalHeight))
            {
                var graphics = new Graphics(webpImage);
                int currentY = 0;

                // Second pass: draw each TIFF page onto the WebP canvas sequentially
                for (int i = 0; i < tiffImage.PageCount; i++)
                {
                    using (RasterImage page = (RasterImage)tiffImage.Pages[i])
                    {
                        graphics.DrawImage(page, new Rectangle(0, currentY, page.Width, page.Height));
                        currentY += page.Height;
                    }
                    // Release page resources and force garbage collection to keep memory low
                    GC.Collect();
                }

                // Save the composed image as WebP
                webpImage.Save(outputPath, webpOptions);
            }
        }
    }
}