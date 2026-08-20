// HOW-TO: Convert DNG to 256-Color GIF in C# with Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Dng;

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
                // DngImage derives from RasterImage, so we can cast
                RasterImage raster = (RasterImage)image;

                // Generate a 256‑color palette from the raster image
                IColorPalette palette = ColorPaletteHelper.GetCloseImagePalette(raster, 256);

                // Prepare GIF save options with the custom palette
                GifOptions gifOptions = new GifOptions
                {
                    Palette = palette,
                    DoPaletteCorrection = false   // palette already supplied
                };

                // Save the image as GIF using the palette
                raster.Save(outputPath, gifOptions);
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
 * 1. When you need to display raw camera files (DNG) on the web, you can reduce them to a 256‑color GIF to ensure fast loading while preserving visual detail.
 * 2. When an application must generate animated or static GIF previews from high‑resolution raw images without exceeding the GIF 256‑color limit, this code creates the required palette and saves the result.
 * 3. When a batch‑processing tool has to convert a collection of DNG photos into lightweight GIFs for email attachments, the palette reduction guarantees the output meets size constraints.
 * 4. When integrating Aspose.Imaging into a C# service that archives raw images as GIFs for archival systems that only accept indexed‑color formats, this snippet handles the conversion automatically.
 * 5. When a developer wants to programmatically create a GIF thumbnail from a DNG file while controlling the exact color count, the code generates a custom 256‑color palette and saves the image in one step.
 */
