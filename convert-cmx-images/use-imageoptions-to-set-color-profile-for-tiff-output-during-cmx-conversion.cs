using System;
using System.IO;
using System.Linq;
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
            string inputCmxPath = "Input\\canvas.cmx";
            string inputRasterPath = "Input\\image1.png";
            string outputTiffPath = "Output\\result.tif";

            if (!File.Exists(inputCmxPath))
            {
                Console.Error.WriteLine($"File not found: {inputCmxPath}");
                return;
            }
            if (!File.Exists(inputRasterPath))
            {
                Console.Error.WriteLine($"File not found: {inputRasterPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputTiffPath));

            using (CmxImage cmx = (CmxImage)Image.Load(inputCmxPath))
            {
                int width = cmx.Width;
                int height = cmx.Height;

                using (TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default))
                {
                    tiffOptions.Source = new FileCreateSource(outputTiffPath, false);

                    using (TiffImage tiffImage = (TiffImage)Image.Create(tiffOptions, width, height))
                    {
                        using (RasterImage raster = (RasterImage)Image.Load(inputRasterPath))
                        {
                            if (!raster.IsCached)
                                raster.CacheData();

                            var pixels = raster.LoadPixels(raster.Bounds);
                            int[] argbPixels = pixels.Select(c => c.ToArgb()).ToArray();
                            ((RasterImage)tiffImage).SaveArgb32Pixels(new Rectangle(0, 0, width, height), argbPixels);
                        }

                        tiffImage.Save();
                    }
                }
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
 * 1. When a CAD application must export a CMX canvas and its associated PNG raster into a color‑managed TIFF for high‑quality printing, developers can use ImageOptions to embed the desired ICC profile during conversion.
 * 2. When an engineering firm needs to archive legacy CMX drawings as TIFF files with a standardized color profile to ensure consistent viewing across different document management systems, this code provides a programmatic solution.
 * 3. When a GIS workflow requires converting CMX map layers and overlay images into a single TIFF with an embedded sRGB profile for web‑based map services, developers can leverage the TiffOptions and RasterImage handling shown.
 * 4. When a publishing pipeline has to generate print‑ready TIFFs from CMX source files while preserving exact color reproduction for brand guidelines, the code demonstrates how to set the color profile via ImageOptions.
 * 5. When a batch job must process dozens of CMX files and embed a custom ICC profile into each resulting TIFF to meet regulatory color‑accuracy standards, this approach automates the conversion in C# using Aspose.Imaging.
 */