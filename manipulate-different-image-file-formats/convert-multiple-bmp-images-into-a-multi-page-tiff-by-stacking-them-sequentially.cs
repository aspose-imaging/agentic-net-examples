using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input BMP file paths
            string[] inputPaths = new string[]
            {
                @"C:\Images\image1.bmp",
                @"C:\Images\image2.bmp",
                @"C:\Images\image3.bmp"
            };

            // Hardcoded output TIFF file path
            string outputPath = @"C:\Images\output.tif";

            // Verify each input file exists
            foreach (var inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load BMP images and convert each to a TiffFrame
            var frames = new List<TiffFrame>();
            foreach (var inputPath in inputPaths)
            {
                using (Image bmpImage = Image.Load(inputPath))
                {
                    // Ensure the loaded image is a raster image
                    var raster = bmpImage as RasterImage;
                    if (raster == null)
                    {
                        Console.Error.WriteLine($"Unsupported image format: {inputPath}");
                        return;
                    }

                    // Create a TiffFrame from the raster image
                    var frame = new TiffFrame(raster);
                    frames.Add(frame);
                }
            }

            // Create a multi‑page TIFF image from the collected frames
            using (TiffImage tiffImage = new TiffImage(frames.ToArray()))
            {
                // Save the resulting TIFF
                tiffImage.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}