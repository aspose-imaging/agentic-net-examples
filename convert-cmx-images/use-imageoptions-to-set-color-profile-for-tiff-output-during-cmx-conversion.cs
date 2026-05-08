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
            // Hardcoded input and output paths
            string cmxPath = "Input\\canvas.cmx";
            string rasterPath = "Input\\image1.png";
            string outputPath = "Output\\result.tif";

            // Validate input files
            if (!File.Exists(cmxPath))
            {
                Console.Error.WriteLine($"File not found: {cmxPath}");
                return;
            }
            if (!File.Exists(rasterPath))
            {
                Console.Error.WriteLine($"File not found: {rasterPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load CMX canvas to obtain dimensions
            using (CmxImage cmx = (CmxImage)Image.Load(cmxPath))
            {
                int canvasWidth = cmx.Width;
                int canvasHeight = cmx.Height;

                // Load raster image
                using (RasterImage raster = (RasterImage)Image.Load(rasterPath))
                {
                    // Prepare TIFF options (color profile handling not directly supported for TIFF)
                    TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                    tiffOptions.Source = new FileCreateSource(outputPath, false);
                    // Additional TIFF options can be set here if needed (e.g., Compression, Photometric)

                    // Create TIFF image with canvas size
                    using (TiffImage tiffImage = (TiffImage)Image.Create(tiffOptions, canvasWidth, canvasHeight))
                    {
                        // Define destination rectangle (top-left corner)
                        Aspose.Imaging.Rectangle destRect = new Aspose.Imaging.Rectangle(0, 0, raster.Width, raster.Height);

                        // Load pixels from raster image and convert to ARGB int array
                        int[] argbPixels = raster.LoadPixels(raster.Bounds)
                                                .Select(c => c.ToArgb())
                                                .ToArray();

                        // Merge raster pixels onto TIFF canvas
                        tiffImage.SaveArgb32Pixels(destRect, argbPixels);

                        // Save the TIFF image
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