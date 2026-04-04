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
        // Hardcoded input CDR files
        string cdrPath1 = "input1.cdr";
        string cdrPath2 = "input2.cdr";
        string cdrPath3 = "input3.cdr";

        // Hardcoded output multipage TIFF
        string outputPath = "output.tif";

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

        // Load first CDR to obtain canvas size
        int canvasWidth, canvasHeight;
        using (CdrImage firstCdr = (CdrImage)Image.Load(cdrPath1))
        {
            canvasWidth = firstCdr.Width;
            canvasHeight = firstCdr.Height;
        }

        // Prepare TIFF options for the multipage TIFF
        TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
        tiffOptions.Source = new FileCreateSource(outputPath, false);
        tiffOptions.Photometric = TiffPhotometrics.Rgb;
        tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };

        // Create the multipage TIFF canvas
        using (TiffImage tiff = (TiffImage)Image.Create(tiffOptions, canvasWidth, canvasHeight))
        {
            // Array of input paths for iteration
            string[] cdrPaths = { cdrPath1, cdrPath2, cdrPath3 };
            float gammaValue = 2.2f; // Desired gamma correction

            foreach (string cdrPath in cdrPaths)
            {
                // Rasterize CDR to PNG in memory
                using (CdrImage cdr = (CdrImage)Image.Load(cdrPath))
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

                    // Load raster image, apply gamma, and add as a page
                    using (RasterImage raster = (RasterImage)Image.Load(ms))
                    {
                        raster.AdjustGamma(gammaValue);
                        tiff.AddPage(raster);
                    }
                }
            }

            // Save the multipage TIFF (output path already bound)
            tiff.Save();
        }
    }
}