using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        // Hardcoded input JPEG files
        string[] inputPaths = new string[]
        {
            @"C:\Images\input1.jpg",
            @"C:\Images\input2.jpg",
            @"C:\Images\input3.jpg"
        };

        // Hardcoded output PNG file
        string outputPath = @"C:\Images\combined.png";

        // Verify each input file exists
        foreach (string inputPath in inputPaths)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load JPEGs, convert each to a TiffFrame, and collect frames
        List<TiffFrame> frames = new List<TiffFrame>();
        foreach (string inputPath in inputPaths)
        {
            using (Image img = Image.Load(inputPath))
            {
                // Cast to RasterImage for the TiffFrame constructor
                RasterImage raster = img as RasterImage;
                if (raster != null)
                {
                    TiffFrame frame = new TiffFrame(raster);
                    frames.Add(frame);
                }
                else
                {
                    Console.Error.WriteLine($"Unable to process image as raster: {inputPath}");
                    return;
                }
            }
        }

        // Create a multi‑frame TIFF image from the collected frames
        using (TiffImage tiffImage = new TiffImage(frames.ToArray()))
        {
            // Save the TIFF image directly as PNG (TIFF used as intermediate format)
            tiffImage.Save(outputPath, new PngOptions());
        }
    }
}