using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input CDR file paths
            string[] inputPaths = {
                "input1.cdr",
                "input2.cdr",
                "input3.cdr"
            };

            // Hardcoded output TIFF path
            string outputPath = "output.tif";

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
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrWhiteSpace(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            TiffImage tiffImage = null;
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

            foreach (string cdrPath in inputPaths)
            {
                // Load CDR canvas
                using (CdrImage cdr = (CdrImage)Image.Load(cdrPath))
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

                        // Load rasterized PNG as RasterImage
                        using (RasterImage raster = (RasterImage)Image.Load(ms))
                        {
                            // Adjust brightness (example value: 50)
                            raster.AdjustBrightness(50);

                            if (tiffImage == null)
                            {
                                // First frame creates the TIFF image
                                tiffImage = (TiffImage)Image.Create(tiffOptions, raster.Width, raster.Height);
                                tiffImage.SavePixels(tiffImage.Bounds, raster.LoadPixels(raster.Bounds));
                            }
                            else
                            {
                                // Add subsequent frames
                                tiffImage.AddFrame(new TiffFrame(tiffOptions, raster.Width, raster.Height));
                                tiffImage.ActiveFrame.SavePixels(tiffImage.ActiveFrame.Bounds, raster.LoadPixels(raster.Bounds));
                            }
                        }
                    }
                }
            }

            if (tiffImage != null)
            {
                // Save the multipage TIFF
                tiffImage.Save(outputPath, tiffOptions);
                tiffImage.Dispose();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}