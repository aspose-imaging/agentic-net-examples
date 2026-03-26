using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hard‑coded input and output paths
        string svgPath = @"C:\Images\input.svg";
        string overlayPath = @"C:\Images\overlay.png";
        string outputPath = @"C:\Images\result.png";
        string tempPngPath = @"C:\Images\temp_rasterized.png";

        // Validate input files
        if (!File.Exists(svgPath))
        {
            Console.Error.WriteLine($"File not found: {svgPath}");
            return;
        }
        if (!File.Exists(overlayPath))
        {
            Console.Error.WriteLine($"File not found: {overlayPath}");
            return;
        }

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
        Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));

        // Rasterize SVG to a temporary PNG file
        using (Image svgImage = Image.Load(svgPath))
        {
            PngOptions pngOptions = new PngOptions
            {
                VectorRasterizationOptions = new SvgRasterizationOptions { PageSize = svgImage.Size }
            };
            svgImage.Save(tempPngPath, pngOptions);
        }

        // Load the rasterized SVG as the base image
        using (RasterImage baseImg = (RasterImage)Image.Load(tempPngPath))
        {
            // Create the output PNG canvas bound to the output file
            Source outSource = new FileCreateSource(outputPath, false);
            PngOptions outOptions = new PngOptions { Source = outSource };
            using (RasterImage canvas = (RasterImage)Image.Create(outOptions, baseImg.Width, baseImg.Height))
            {
                // Copy base image pixels onto the canvas
                canvas.SaveArgb32Pixels(
                    new Rectangle(0, 0, baseImg.Width, baseImg.Height),
                    baseImg.LoadArgb32Pixels(baseImg.Bounds));

                // Load the overlay image
                using (RasterImage overlayImg = (RasterImage)Image.Load(overlayPath))
                {
                    // Define overlay position (top‑left corner)
                    int overlayX = 0;
                    int overlayY = 0;

                    // Ensure overlay fits within the canvas
                    int drawWidth = Math.Min(overlayImg.Width, canvas.Width - overlayX);
                    int drawHeight = Math.Min(overlayImg.Height, canvas.Height - overlayY);

                    // Overlay the image pixels
                    canvas.SaveArgb32Pixels(
                        new Rectangle(overlayX, overlayY, drawWidth, drawHeight),
                        overlayImg.LoadArgb32Pixels(new Rectangle(0, 0, drawWidth, drawHeight)));
                }

                // Save the bound canvas (no need to pass options again)
                canvas.Save();
            }
        }

        // Optionally delete the temporary rasterized file
        try { File.Delete(tempPngPath); } catch { /* ignore */ }
    }
}