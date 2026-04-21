using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input CDR files
            string[] inputPaths = {
                @"C:\temp\input1.cdr",
                @"C:\temp\input2.cdr",
                @"C:\temp\input3.cdr"
            };

            // Hardcoded output TIFF file
            string outputPath = @"C:\temp\output.tif";

            // Validate input files
            foreach (string inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // List to hold processed raster images
            var rasterImages = new System.Collections.Generic.List<RasterImage>();

            // Process each CDR file: rasterize, adjust gamma, store raster image
            foreach (string inputPath in inputPaths)
            {
                using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
                {
                    // Rasterize CDR to PNG in memory
                    using (var memoryStream = new MemoryStream())
                    {
                        var pngOptions = new PngOptions
                        {
                            VectorRasterizationOptions = new CdrRasterizationOptions
                            {
                                PageWidth = cdr.Width,
                                PageHeight = cdr.Height
                            }
                        };
                        cdr.Save(memoryStream, pngOptions);
                        memoryStream.Position = 0;

                        // Load rasterized image
                        RasterImage raster = (RasterImage)Image.Load(memoryStream);
                        // Adjust gamma (example value 1.2)
                        raster.AdjustGamma(1.2f);
                        rasterImages.Add(raster);
                    }
                }
            }

            if (rasterImages.Count == 0)
            {
                Console.Error.WriteLine("No images were processed.");
                return;
            }

            // Create multipage TIFF using the first raster image as the base
            RasterImage firstRaster = rasterImages[0];
            using (TiffImage tiff = new TiffImage(new TiffFrame(firstRaster)))
            {
                // Add remaining rasters as pages
                for (int i = 1; i < rasterImages.Count; i++)
                {
                    tiff.AddPage(rasterImages[i]);
                }

                // Save the multipage TIFF
                tiff.Save();
            }

            // Dispose raster images after saving
            foreach (var raster in rasterImages)
            {
                raster.Dispose();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}