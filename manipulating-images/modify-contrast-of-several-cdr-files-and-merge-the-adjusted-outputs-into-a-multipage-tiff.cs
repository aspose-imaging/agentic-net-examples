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
            // Hardcoded input CDR files
            string[] inputPaths = {
                "input1.cdr",
                "input2.cdr",
                "input3.cdr"
            };

            // Hardcoded output TIFF file
            string outputPath = "output\\merged.tif";

            // Verify input files exist
            foreach (var inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Collect raster frames from each CDR
            List<TiffFrame> frames = new List<TiffFrame>();

            foreach (var cdrPath in inputPaths)
            {
                using (CdrImage cdr = (CdrImage)Image.Load(cdrPath))
                {
                    // Rasterize CDR to PNG in memory
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

                        // Load raster image from memory
                        using (RasterImage raster = (RasterImage)Image.Load(ms))
                        {
                            // Create a TIFF frame from the raster image
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

            // Create TIFF image with appropriate options
            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default)
            {
                Source = new FileCreateSource(outputPath, false),
                Photometric = TiffPhotometrics.Rgb,
                BitsPerSample = new ushort[] { 8, 8, 8 }
            };

            // Use dimensions of the first frame for the canvas
            using (TiffImage tiff = (TiffImage)Image.Create(tiffOptions, frames[0].Width, frames[0].Height))
            {
                // Remove the default empty frame
                tiff.RemoveFrame(0);

                // Add all processed frames
                foreach (var frame in frames)
                {
                    tiff.AddFrame(frame);
                }

                // Save the multipage TIFF
                tiff.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}