using System;
using System.IO;
using System.Collections.Generic;
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
                "input1.cdr",
                "input2.cdr",
                "input3.cdr"
            };

            // Hardcoded output TIFF file
            string outputPath = "output.tif";

            // Verify each input file exists
            foreach (var path in inputPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrWhiteSpace(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            Aspose.Imaging.FileFormats.Tiff.TiffImage tiffImage = null;
            bool firstPage = true;

            foreach (var cdrPath in inputPaths)
            {
                // Load CDR vector image
                using (var cdr = (Aspose.Imaging.FileFormats.Cdr.CdrImage)Aspose.Imaging.Image.Load(cdrPath))
                {
                    // Rasterize CDR to PNG in memory
                    var pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = new VectorRasterizationOptions
                        {
                            PageWidth = cdr.Width,
                            PageHeight = cdr.Height
                        }
                    };

                    using (var ms = new MemoryStream())
                    {
                        cdr.Save(ms, pngOptions);
                        ms.Position = 0;

                        // Load rasterized image
                        using (var raster = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(ms))
                        {
                            // Deskew the raster image
                            raster.NormalizeAngle(false, Aspose.Imaging.Color.White);

                            if (firstPage)
                            {
                                // Create the multipage TIFF with the first page dimensions
                                var tiffCreateOptions = new TiffOptions(TiffExpectedFormat.Default)
                                {
                                    Source = new FileCreateSource(outputPath, false),
                                    Photometric = TiffPhotometrics.Rgb,
                                    BitsPerSample = new ushort[] { 8, 8, 8 }
                                };

                                tiffImage = (Aspose.Imaging.FileFormats.Tiff.TiffImage)Aspose.Imaging.Image.Create(tiffCreateOptions, raster.Width, raster.Height);

                                // Copy pixels of the first page into the TIFF canvas
                                tiffImage.SaveArgb32Pixels(tiffImage.Bounds, raster.LoadArgb32Pixels(tiffImage.Bounds));

                                firstPage = false;
                            }
                            else
                            {
                                // Add subsequent pages directly
                                tiffImage.AddPage(raster);
                            }
                        }
                    }
                }
            }

            // Save the multipage TIFF (source is already bound to outputPath)
            tiffImage?.Save();
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}