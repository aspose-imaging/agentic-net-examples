using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.cdr";
        string outputPath = "output.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the CDR vector image
        using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
        {
            // Rasterize CDR to PNG in memory
            using (MemoryStream ms = new MemoryStream())
            {
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = new CdrRasterizationOptions
                    {
                        PageWidth = cdr.Width,
                        PageHeight = cdr.Height
                    }
                };
                cdr.Save(ms, pngOptions);
                ms.Position = 0;

                // Load rasterized image
                using (RasterImage raster = (RasterImage)Image.Load(ms))
                {
                    // Resize to 1024x768 using nearest neighbour resampling
                    raster.Resize(1024, 768, ResizeType.NearestNeighbourResample);

                    // Save as JPEG
                    var jpegOptions = new JpegOptions();
                    raster.Save(outputPath, jpegOptions);
                }
            }
        }
    }
}