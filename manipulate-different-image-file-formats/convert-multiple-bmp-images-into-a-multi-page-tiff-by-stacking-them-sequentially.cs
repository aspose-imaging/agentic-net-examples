using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input BMP files
            string[] inputPaths = {
                @"c:\temp\image1.bmp",
                @"c:\temp\image2.bmp",
                @"c:\temp\image3.bmp"
            };

            // Hardcoded output multi‑page TIFF file
            string outputPath = @"c:\temp\multipage.tif";

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

            // Load each BMP and create a corresponding TiffFrame
            List<TiffFrame> frames = new List<TiffFrame>();
            foreach (string inputPath in inputPaths)
            {
                using (Image bmpImage = Image.Load(inputPath))
                {
                    // The loaded image is a RasterImage; create a frame from it
                    RasterImage raster = bmpImage as RasterImage;
                    if (raster == null)
                    {
                        Console.Error.WriteLine($"Unable to load raster image: {inputPath}");
                        return;
                    }

                    TiffFrame frame = new TiffFrame(raster);
                    frames.Add(frame);
                }
            }

            // Create a TiffImage from the collected frames and save it
            using (TiffImage tiffImage = new TiffImage(frames.ToArray()))
            {
                tiffImage.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}