using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = "input.apng";
        string outputPath = "output.tif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        try
        {
            // Load the APNG image
            using (ApngImage apng = (ApngImage)Image.Load(inputPath))
            {
                // Collect all frames as RasterImage objects
                List<RasterImage> frames = new List<RasterImage>();
                for (int i = 0; i < apng.PageCount; i++)
                {
                    // Each page is a RasterImage; clone it to keep it independent
                    RasterImage frame = (RasterImage)apng.Pages[i];
                    frames.Add(frame);
                }

                // Prepare TIFF options (default format)
                TiffOptions tiffOptions = new TiffOptions(Aspose.Imaging.FileFormats.Tiff.Enums.TiffExpectedFormat.Default);

                // Create a TIFF image using the dimensions of the first frame
                using (TiffImage tiffImage = (TiffImage)Image.Create(tiffOptions, frames[0].Width, frames[0].Height))
                {
                    // Add the first frame
                    tiffImage.AddFrame(new TiffFrame(frames[0]));

                    // Add remaining frames
                    for (int i = 1; i < frames.Count; i++)
                    {
                        tiffImage.AddFrame(new TiffFrame(frames[i]));
                    }

                    // Save the multi‑page TIFF
                    tiffImage.Save(outputPath);
                }

                // Dispose all raster frames after the TIFF has been saved
                foreach (var frame in frames)
                {
                    frame.Dispose();
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}