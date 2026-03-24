using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.BigTiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        // Hardcoded input JPG file paths
        string[] inputPaths = new string[]
        {
            @"C:\Images\image1.jpg",
            @"C:\Images\image2.jpg",
            @"C:\Images\image3.jpg"
        };

        // Hardcoded output BigTIFF file path
        string outputPath = @"C:\Images\combined_output.bigtiff";

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

        // Load each JPG, convert to TiffFrame, and collect frames
        List<TiffFrame> frames = new List<TiffFrame>();
        foreach (string inputPath in inputPaths)
        {
            using (Image img = Image.Load(inputPath))
            {
                // Preserve metadata by copying it to the frame later if needed
                // Create a TiffFrame from the loaded raster image
                TiffFrame frame = new TiffFrame((RasterImage)img);
                frames.Add(frame);
                // Do not dispose the frame here; it will be managed by BigTiffImage
            }
        }

        // Create a BigTiffImage from the collected frames
        using (BigTiffImage bigTiff = new BigTiffImage(frames.ToArray()))
        {
            // Configure BigTIFF save options
            BigTiffOptions options = new BigTiffOptions(TiffExpectedFormat.Default);
            options.KeepMetadata = true; // Preserve original metadata

            // Save the combined image as a BigTIFF file
            bigTiff.Save(outputPath, options);
        }
    }
}