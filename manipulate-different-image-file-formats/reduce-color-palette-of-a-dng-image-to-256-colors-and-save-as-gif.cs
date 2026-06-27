using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dng;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = @"C:\temp\input.dng";
        string outputPath = @"C:\temp\output.gif";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the DNG image
            using (Image image = Image.Load(inputPath))
            {
                // DngImage derives from RasterImage, so we can treat it as RasterImage
                RasterImage raster = (RasterImage)image;

                // Generate a 256‑color palette from the raster image
                IColorPalette palette = ColorPaletteHelper.GetCloseImagePalette(raster, 256);

                // Prepare GIF save options with the generated palette
                GifOptions gifOptions = new GifOptions
                {
                    Palette = palette,
                    // Disable automatic palette correction because we already provide a palette
                    DoPaletteCorrection = false
                };

                // Save the image as GIF using the specified options
                image.Save(outputPath, gifOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to convert high‑resolution raw DNG photos into lightweight 256‑color GIFs for web previews or email attachments, they can use this code to generate an optimal palette and save the result.
 * 2. When building an automated pipeline that ingests raw camera files and creates animated GIF thumbnails for a digital asset management system, this snippet provides the necessary color reduction and format conversion.
 * 3. When a mobile app must display raw DNG images on devices that only support GIF with limited colors, the code enables on‑the‑fly palette generation and saving in a compatible format.
 * 4. When a photographer’s portfolio website requires batch processing of DNG files into GIFs to reduce bandwidth while preserving visual fidelity, the example demonstrates how to create a 256‑color palette and export each image.
 * 5. When integrating Aspose.Imaging into a C# desktop tool that lets users export raw images as GIFs with a custom 256‑color palette, this code handles loading, palette creation, and saving in a single workflow.
 */