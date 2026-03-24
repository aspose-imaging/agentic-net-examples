using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input TIFF file paths
        string[] inputPaths = new string[]
        {
            @"c:\temp\input1.tif",
            @"c:\temp\input2.tif",
            @"c:\temp\input3.tif"
        };

        // Hardcoded output TIFF file path
        string outputPath = @"c:\temp\combined.tif";

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

        // Load each TIFF image and extract its frame
        List<TiffFrame> frames = new List<TiffFrame>();
        foreach (string inputPath in inputPaths)
        {
            using (Image img = Image.Load(inputPath))
            {
                // Cast to RasterImage (TiffImage derives from RasterImage)
                RasterImage raster = img as RasterImage;
                if (raster == null)
                {
                    Console.Error.WriteLine($"Unable to process image: {inputPath}");
                    return;
                }

                // Create a TiffFrame from the raster image (preserves metadata and color profile)
                TiffFrame frame = new TiffFrame(raster);
                frames.Add(frame);
            }
        }

        if (frames.Count == 0)
        {
            Console.Error.WriteLine("No frames were loaded.");
            return;
        }

        // Create a new multi‑page TIFF image using the first frame
        using (TiffImage tiffImage = new TiffImage(frames[0]))
        {
            // Add remaining frames
            for (int i = 1; i < frames.Count; i++)
            {
                tiffImage.AddFrame(frames[i]);
            }

            // Save the combined TIFF
            tiffImage.Save(outputPath);
        }
    }
}