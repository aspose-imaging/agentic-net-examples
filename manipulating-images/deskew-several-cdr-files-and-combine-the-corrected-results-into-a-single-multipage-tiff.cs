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
    static void Main()
    {
        // Hard‑coded input CDR files
        string cdrPath1 = @"C:\temp\input1.cdr";
        string cdrPath2 = @"C:\temp\input2.cdr";
        string cdrPath3 = @"C:\temp\input3.cdr";

        // Verify each input exists
        if (!File.Exists(cdrPath1)) { Console.Error.WriteLine($"File not found: {cdrPath1}"); return; }
        if (!File.Exists(cdrPath2)) { Console.Error.WriteLine($"File not found: {cdrPath2}"); return; }
        if (!File.Exists(cdrPath3)) { Console.Error.WriteLine($"File not found: {cdrPath3}"); return; }

        // Output multipage TIFF
        string outputPath = @"C:\temp\deskewed_output.tif";

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Collect frames after deskewing each CDR
        List<TiffFrame> frames = new List<TiffFrame>();

        // Process each CDR file
        foreach (string cdrPath in new[] { cdrPath1, cdrPath2, cdrPath3 })
        {
            // Load vector CDR image
            using (CdrImage cdr = (CdrImage)Image.Load(cdrPath))
            {
                // Rasterize CDR to a memory stream (PNG)
                using (MemoryStream ms = new MemoryStream())
                {
                    var pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = new VectorRasterizationOptions
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
                        // Deskew the raster image
                        raster.NormalizeAngle(false, Color.LightGray);

                        // Create a TIFF frame from the deskewed raster image
                        var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                        TiffFrame frame = new TiffFrame(tiffOptions, raster.Width, raster.Height);
                        frame.SavePixels(frame.Bounds, raster.LoadPixels(raster.Bounds));
                        frames.Add(frame);
                    }
                }
            }
        }

        // Build multipage TIFF from collected frames
        if (frames.Count == 0) { Console.Error.WriteLine("No frames were created."); return; }

        // Save options bound to the output file
        var saveOptions = new TiffOptions(TiffExpectedFormat.Default)
        {
            Source = new FileCreateSource(outputPath, false)
        };

        // Create TIFF image with the first frame, then add remaining frames
        using (TiffImage tiffImage = new TiffImage(frames[0]))
        {
            for (int i = 1; i < frames.Count; i++)
            {
                tiffImage.AddFrame(frames[i]);
            }

            // Save the multipage TIFF
            tiffImage.Save(outputPath, saveOptions);
        }
    }
}