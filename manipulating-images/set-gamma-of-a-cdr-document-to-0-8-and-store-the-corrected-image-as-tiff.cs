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
            // Hardcoded input and output paths
            string inputPath = "input.cdr";
            string outputPath = "output.tif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CDR document
            using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
            {
                // Rasterize CDR to TIFF in memory
                using (MemoryStream ms = new MemoryStream())
                {
                    var rasterizeOptions = new TiffOptions(TiffExpectedFormat.Default)
                    {
                        VectorRasterizationOptions = new CdrRasterizationOptions
                        {
                            PageWidth = cdr.Width,
                            PageHeight = cdr.Height
                        }
                    };
                    cdr.Save(ms, rasterizeOptions);
                    ms.Position = 0;

                    // Load the rasterized TIFF image
                    using (TiffImage tiff = (TiffImage)Image.Load(ms))
                    {
                        // Apply gamma correction
                        tiff.AdjustGamma(0.8f);

                        // Save the corrected image as TIFF
                        tiff.Save(outputPath);
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