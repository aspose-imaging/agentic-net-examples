using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        string cdrPath1 = "input1.cdr";
        string cdrPath2 = "input2.cdr";
        string cdrPath3 = "input3.cdr";

        if (!File.Exists(cdrPath1)) { Console.Error.WriteLine($"File not found: {cdrPath1}"); return; }
        if (!File.Exists(cdrPath2)) { Console.Error.WriteLine($"File not found: {cdrPath2}"); return; }
        if (!File.Exists(cdrPath3)) { Console.Error.WriteLine($"File not found: {cdrPath3}"); return; }

        string outputPath = "output\\merged.tif";

        List<TiffFrame> frames = new List<TiffFrame>();

        string[] cdrPaths = { cdrPath1, cdrPath2, cdrPath3 };
        foreach (string cdrPath in cdrPaths)
        {
            using (CdrImage cdr = (CdrImage)Image.Load(cdrPath))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    PngOptions pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = new VectorRasterizationOptions
                        {
                            PageWidth = cdr.Width,
                            PageHeight = cdr.Height
                        }
                    };
                    cdr.Save(ms, pngOptions);
                    ms.Position = 0;

                    using (RasterImage raster = (RasterImage)Image.Load(ms))
                    {
                        raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 5.0));

                        TiffFrame frame = new TiffFrame(raster);
                        frames.Add(frame);
                    }
                }
            }
        }

        TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
        {
            Photometric = TiffPhotometrics.Rgb,
            BitsPerSample = new ushort[] { 8, 8, 8 },
            Compression = TiffCompressions.Lzw
        };

        string outputDir = Path.GetDirectoryName(outputPath);
        if (!string.IsNullOrWhiteSpace(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        using (TiffImage tiffImage = new TiffImage(frames.ToArray()))
        {
            tiffImage.Save(outputPath, tiffOptions);
        }
    }
}