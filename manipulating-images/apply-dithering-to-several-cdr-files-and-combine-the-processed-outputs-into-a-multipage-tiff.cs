using System;
using System.IO;
using System.Collections.Generic;
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
        // Hardcoded input CDR file paths
        string cdrPath1 = "input1.cdr";
        string cdrPath2 = "input2.cdr";
        string cdrPath3 = "input3.cdr";

        // Hardcoded output TIFF path
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

        // List to hold TIFF frames
        List<TiffFrame> frames = new List<TiffFrame>();

        // Process each CDR file
        string[] cdrPaths = new[] { cdrPath1, cdrPath2, cdrPath3 };
        foreach (string cdrPath in cdrPaths)
        {
            // Load CDR vector image
            using (CdrImage cdr = (CdrImage)Image.Load(cdrPath))
            {
                // Prepare rasterization options
                var rasterOptions = new VectorRasterizationOptions
                {
                    PageWidth = cdr.Width,
                    PageHeight = cdr.Height,
                    TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                    SmoothingMode = SmoothingMode.None
                };

                // Rasterize to PNG in memory
                using (MemoryStream ms = new MemoryStream())
                {
                    var pngOptions = new PngOptions { VectorRasterizationOptions = rasterOptions };
                    cdr.Save(ms, pngOptions);
                    ms.Position = 0;

                    // Load raster image
                    using (RasterImage raster = (RasterImage)Image.Load(ms))
                    {
                        // Simple threshold dithering (black & white)
                        Color[] pixels = raster.LoadPixels(raster.Bounds);
                        Color[] bwPixels = new Color[pixels.Length];
                        for (int i = 0; i < pixels.Length; i++)
                        {
                            Color c = pixels[i];
                            int lum = (int)(0.299 * c.R + 0.587 * c.G + 0.114 * c.B);
                            bwPixels[i] = lum > 128 ? Color.White : Color.Black;
                        }
                        raster.SavePixels(raster.Bounds, bwPixels);

                        // Create TIFF frame from the processed raster image
                        TiffFrame frame = new TiffFrame(raster);
                        frames.Add(frame);
                    }
                }
            }
        }

        if (frames.Count == 0)
        {
            Console.Error.WriteLine("No frames were created.");
            return;
        }

        // Prepare TIFF options for multipage output
        var tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
        {
            Source = new FileCreateSource(outputPath, false),
            Photometric = TiffPhotometrics.Rgb,
            BitsPerSample = new ushort[] { 8, 8, 8 }
        };

        // Create TIFF image with the first frame
        using (TiffImage tiffImage = (TiffImage)Image.Create(tiffOptions, frames[0].Width, frames[0].Height))
        {
            // Add the first frame (already present as the default frame)
            tiffImage.ActiveFrame = frames[0];

            // Add remaining frames
            for (int i = 1; i < frames.Count; i++)
            {
                tiffImage.AddFrame(frames[i]);
            }

            // Save the multipage TIFF
            tiffImage.Save();
        }

        // Dispose frames that are no longer needed
        foreach (var frame in frames)
        {
            frame.Dispose();
        }
    }
}