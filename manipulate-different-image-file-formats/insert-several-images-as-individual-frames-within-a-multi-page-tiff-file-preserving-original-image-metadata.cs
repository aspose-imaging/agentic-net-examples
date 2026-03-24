using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input image paths
        string[] inputPaths = new string[]
        {
            "input1.jpg",
            "input2.png",
            "input3.bmp"
        };

        // Hardcoded output TIFF path
        string outputPath = "output.tif";

        // Verify each input file exists
        foreach (string inputPath in inputPaths)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Collect frames from input images
        List<TiffFrame> frames = new List<TiffFrame>();
        foreach (string inputPath in inputPaths)
        {
            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                // Create a frame from the raster image (metadata is retained within the raster)
                TiffFrame frame = new TiffFrame(raster);
                frames.Add(frame);
            }
        }

        // Create a multi‑page TIFF image from the collected frames
        using (TiffImage tiffImage = new TiffImage(frames.ToArray()))
        {
            // Save the TIFF image to the specified output path
            tiffImage.Save(outputPath);
        }
    }
}