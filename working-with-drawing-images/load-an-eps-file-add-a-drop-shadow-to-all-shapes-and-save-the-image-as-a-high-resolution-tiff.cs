// HOW-TO: Add Drop Shadow to EPS Shapes and Save as High‑Resolution TIFF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.eps";
            string outputPath = "output.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Temporary raster file path
            string tempPngPath = "temp.png";
            Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));

            // Load EPS and export to a high‑resolution PNG
            using (var epsImage = (EpsImage)Image.Load(inputPath))
            {
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = new EpsRasterizationOptions
                    {
                        // Double the original size for higher resolution
                        PageWidth = epsImage.Width * 2,
                        PageHeight = epsImage.Height * 2
                    }
                };
                epsImage.Save(tempPngPath, pngOptions);
            }

            // Load the rasterized PNG
            using (RasterImage raster = (RasterImage)Image.Load(tempPngPath))
            {
                int shadowOffset = 10; // Offset for drop shadow
                int canvasWidth = raster.Width + shadowOffset;
                int canvasHeight = raster.Height + shadowOffset;

                // Prepare TIFF options with direct file binding
                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                // Create a blank TIFF canvas
                using (Image tiffCanvas = Image.Create(tiffOptions, canvasWidth, canvasHeight))
                {
                    var graphics = new Graphics(tiffCanvas);
                    graphics.Clear(Color.White); // White background

                    // Draw semi‑transparent black rectangle as shadow
                    using (var shadowBrush = new SolidBrush(Color.FromArgb(128, Color.Black)))
                    {
                        graphics.FillRectangle(shadowBrush, shadowOffset, shadowOffset, raster.Width, raster.Height);
                    }

                    // Draw the raster image on top of the shadow
                    graphics.DrawImage(raster, 0, 0);

                    // Save the final TIFF image
                    tiffCanvas.Save();
                }
            }

            // Clean up temporary file
            if (File.Exists(tempPngPath))
            {
                File.Delete(tempPngPath);
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
 * 1. When you need to convert vector EPS artwork into a print‑ready high‑resolution TIFF while applying a drop‑shadow effect to all graphic elements.
 * 2. When a desktop publishing workflow requires rasterizing EPS logos, enhancing them with a shadow, and exporting them for inclusion in high‑quality PDFs or print jobs.
 * 3. When an e‑commerce platform must generate product images from EPS designs with a consistent shadow style for catalog thumbnails saved as TIFF files.
 * 4. When a reporting tool has to embed EPS diagrams into TIFF reports and wants the diagrams to appear with depth by adding a drop shadow automatically.
 * 5. When automating batch processing of EPS files to produce shadowed, high‑resolution TIFF assets for archival or digital asset management systems.
 */
