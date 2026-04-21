using System;
using System.IO;
using System.Collections.Generic;
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
            string cdrPath1 = "input1.cdr";
            string cdrPath2 = "input2.cdr";
            string cdrPath3 = "input3.cdr";

            // Hardcoded output TIFF path
            string outputPath = "output\\merged.tif";

            // Validate input files
            if (!File.Exists(cdrPath1))
            {
                Console.Error.WriteLine($"File not found: {cdrPath1}");
                return;
            }
            if (!File.Exists(cdrPath2))
            {
                Console.Error.WriteLine($"File not found: {cdrPath2}");
                return;
            }
            if (!File.Exists(cdrPath3))
            {
                Console.Error.WriteLine($"File not found: {cdrPath3}");
                return;
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrWhiteSpace(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // List to hold TIFF frames
            List<TiffFrame> frames = new List<TiffFrame>();

            // Process each CDR file
            string[] cdrPaths = { cdrPath1, cdrPath2, cdrPath3 };
            foreach (string cdrPath in cdrPaths)
            {
                using (CdrImage cdr = (CdrImage)Image.Load(cdrPath))
                {
                    // Rasterize CDR to PNG in memory
                    using (MemoryStream ms = new MemoryStream())
                    {
                        PngOptions pngOptions = new PngOptions();
                        pngOptions.Source = new StreamSource(ms);
                        pngOptions.VectorRasterizationOptions = new CdrRasterizationOptions
                        {
                            PageWidth = cdr.Width,
                            PageHeight = cdr.Height
                        };

                        cdr.Save(ms, pngOptions);
                        ms.Position = 0;

                        // Load rasterized image
                        using (RasterImage raster = (RasterImage)Image.Load(ms))
                        {
                            // Create TIFF frame from raster
                            TiffOptions frameOptions = new TiffOptions(TiffExpectedFormat.Default);
                            TiffFrame frame = new TiffFrame(raster, frameOptions);
                            frames.Add(frame);
                        }
                    }
                }
            }

            // Create multipage TIFF from frames
            if (frames.Count > 0)
            {
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                using (TiffImage tiffImage = new TiffImage(frames[0]))
                {
                    for (int i = 1; i < frames.Count; i++)
                    {
                        tiffImage.AddFrame(frames[i]);
                    }

                    tiffImage.Save(outputPath, tiffOptions);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}