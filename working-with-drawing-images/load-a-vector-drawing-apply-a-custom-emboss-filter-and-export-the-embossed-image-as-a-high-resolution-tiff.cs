using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string tempPngPath = "temp.png";
            string outputPath = "output.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Rasterize SVG to a high‑resolution PNG
            using (Image svgImage = Image.Load(inputPath))
            {
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size,
                    BackgroundColor = Color.White,
                    SmoothingMode = SmoothingMode.AntiAlias,
                    TextRenderingHint = TextRenderingHint.AntiAlias,
                    ScaleX = 2.0f, // increase resolution
                    ScaleY = 2.0f
                };

                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                svgImage.Save(tempPngPath, pngOptions);
            }

            // Load the rasterized image and apply emboss filter
            using (RasterImage raster = (RasterImage)Image.Load(tempPngPath))
            {
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                raster.Save(outputPath, tiffOptions);
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
 * 1. When a publishing system needs to convert SVG logos into high‑resolution embossed TIFFs for print‑ready catalogs, developers can use this code to rasterize the vector, apply an emboss filter, and save the result.
 * 2. When an e‑commerce platform wants to generate stylized product mockups by embossing vector artwork and delivering TIFF files for high‑quality brochures, this C# routine handles the SVG‑to‑PNG rasterization and TIFF export.
 * 3. When a GIS application must overlay embossed vector map symbols onto raster layers and store them as lossless TIFF images for archival, the code provides the necessary SVG loading, convolution embossing, and high‑resolution output.
 * 4. When a digital archiving workflow requires converting technical diagrams in SVG format into embossed TIFF files for OCR‑friendly scanning, developers can employ this snippet to rasterize, emboss, and save the images at double scale.
 * 5. When a desktop publishing tool needs to programmatically add a tactile emboss effect to vector illustrations before exporting them as high‑resolution TIFF files for laser engraving, this example demonstrates the complete process in C# using Aspose.Imaging.
 */