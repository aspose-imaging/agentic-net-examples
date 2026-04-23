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
            // Input CDR files (hardcoded)
            string cdrPath1 = "input1.cdr";
            string cdrPath2 = "input2.cdr";
            string cdrPath3 = "input3.cdr";

            // Output multipage TIFF (hardcoded)
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

            // Prepare list for TIFF frames
            var frames = new System.Collections.Generic.List<TiffFrame>();

            // Process each CDR file
            string[] cdrPaths = { cdrPath1, cdrPath2, cdrPath3 };
            foreach (var cdrPath in cdrPaths)
            {
                // Load CDR vector image
                using (CdrImage cdr = (CdrImage)Image.Load(cdrPath))
                {
                    // Rasterize CDR to PNG in memory (default rasterization)
                    using (var ms = new MemoryStream())
                    {
                        var pngOptions = new PngOptions();
                        pngOptions.Source = new StreamSource(ms);
                        cdr.Save(ms, pngOptions);
                        ms.Position = 0;

                        // Load raster image from memory stream
                        using (RasterImage raster = (RasterImage)Image.Load(ms))
                        {
                            // Create a TIFF frame from the raster image
                            var frame = new TiffFrame(raster);
                            frames.Add(frame);
                        }
                    }
                }
            }

            // Create TIFF options for the multipage file
            var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            tiffOptions.Source = new FileCreateSource(outputPath, false);
            tiffOptions.Photometric = TiffPhotometrics.Rgb;
            tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };

            // Create multipage TIFF from frames
            using (var tiffImage = new TiffImage(frames.ToArray()))
            {
                tiffImage.Save(outputPath, tiffOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}