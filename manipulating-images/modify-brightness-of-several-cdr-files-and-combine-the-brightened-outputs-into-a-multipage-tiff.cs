using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input CDR file paths
            string cdrPath1 = @"C:\Images\file1.cdr";
            string cdrPath2 = @"C:\Images\file2.cdr";
            string cdrPath3 = @"C:\Images\file3.cdr";

            // Hardcoded output multipage TIFF path
            string outputPath = @"C:\Images\combined.tif";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Validate input files
            if (!File.Exists(cdrPath1)) { Console.Error.WriteLine($"File not found: {cdrPath1}"); return; }
            if (!File.Exists(cdrPath2)) { Console.Error.WriteLine($"File not found: {cdrPath2}"); return; }
            if (!File.Exists(cdrPath3)) { Console.Error.WriteLine($"File not found: {cdrPath3}"); return; }

            // Array of input paths for iteration
            string[] inputPaths = new[] { cdrPath1, cdrPath2, cdrPath3 };

            TiffImage finalTiff = null;
            TiffOptions finalOptions = null;

            foreach (var cdrPath in inputPaths)
            {
                // Load CDR vector image
                using (CdrImage cdr = (CdrImage)Image.Load(cdrPath))
                {
                    // Rasterize CDR to a TIFF image in memory
                    using (MemoryStream ms = new MemoryStream())
                    {
                        TiffOptions rasterOptions = new TiffOptions(TiffExpectedFormat.Default);
                        rasterOptions.VectorRasterizationOptions = new CdrRasterizationOptions
                        {
                            PageWidth = cdr.Width,
                            PageHeight = cdr.Height
                        };
                        cdr.Save(ms, rasterOptions);
                        ms.Position = 0;

                        // Load rasterized TIFF
                        using (TiffImage rasterTiff = (TiffImage)Image.Load(ms))
                        {
                            // Adjust brightness (example value: +40)
                            rasterTiff.AdjustBrightness(40);

                            // Create final multipage TIFF on first iteration
                            if (finalTiff == null)
                            {
                                finalOptions = new TiffOptions(TiffExpectedFormat.Default);
                                finalOptions.Source = new FileCreateSource(outputPath, false);
                                finalOptions.Photometric = TiffPhotometrics.Rgb;
                                finalOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
                                finalTiff = (TiffImage)Image.Create(finalOptions, rasterTiff.Width, rasterTiff.Height);
                            }

                            // Add the processed page to the multipage TIFF
                            finalTiff.AddPage(rasterTiff);
                        }
                    }
                }
            }

            // Save the multipage TIFF (output is already bound to the source)
            finalTiff?.Save();
            finalTiff?.Dispose();
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}