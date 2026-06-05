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
        try
        {
            // Hardcoded input CDR file paths
            string cdrPath1 = @"input\file1.cdr";
            string cdrPath2 = @"input\file2.cdr";
            string cdrPath3 = @"input\file3.cdr";

            // Hardcoded output TIFF path (includes directory)
            string outputPath = @"output\result.tif";

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
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // List to hold deskewed raster images
            List<RasterImage> rasterImages = new List<RasterImage>();

            // Process each CDR file
            foreach (string cdrPath in new[] { cdrPath1, cdrPath2, cdrPath3 })
            {
                // Rasterize CDR to PNG in memory
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CdrImage cdr = (CdrImage)Image.Load(cdrPath))
                    {
                        PngOptions pngOptions = new PngOptions();
                        pngOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                        {
                            PageWidth = cdr.Width,
                            PageHeight = cdr.Height,
                            BackgroundColor = Color.White
                        };
                        cdr.Save(ms, pngOptions);
                    }

                    ms.Position = 0;

                    // Load raster image from memory and deskew
                    RasterImage raster = (RasterImage)Image.Load(ms);
                    raster.NormalizeAngle(false, Color.White);
                    rasterImages.Add(raster);
                }
            }

            if (rasterImages.Count == 0)
            {
                Console.Error.WriteLine("No images were processed.");
                return;
            }

            // Prepare TIFF save options
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
            tiffOptions.Source = new FileCreateSource(outputPath, false);
            tiffOptions.BitsPerSample = new ushort[] { 8, 8, 8 };
            tiffOptions.Photometric = TiffPhotometrics.Rgb;

            // Create multipage TIFF using the size of the first raster image
            using (TiffImage tiff = (TiffImage)Image.Create(tiffOptions, rasterImages[0].Width, rasterImages[0].Height))
            {
                // Replace the default first frame with the first raster image
                int[] firstPixels = rasterImages[0].LoadArgb32Pixels(rasterImages[0].Bounds);
                tiff.SaveArgb32Pixels(rasterImages[0].Bounds, firstPixels);

                // Add remaining pages
                for (int i = 1; i < rasterImages.Count; i++)
                {
                    tiff.AddPage(rasterImages[i]);
                }

                // Save the multipage TIFF
                tiff.Save();
            }

            // Dispose raster images
            foreach (var raster in rasterImages)
            {
                raster.Dispose();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}