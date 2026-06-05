using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Dng;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.dng";
        string outputPath = @"C:\temp\output.gif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            // Load the DNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to DngImage (inherits from RasterImage)
                DngImage dngImage = (DngImage)image;
                RasterImage raster = (RasterImage)dngImage;

                // Generate a 256‑color palette from the image
                IColorPalette palette = ColorPaletteHelper.GetCloseImagePalette(raster, 256);

                // Prepare GIF save options with the generated palette
                GifOptions gifOptions = new GifOptions
                {
                    Palette = palette
                };

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the image as GIF using the palette
                dngImage.Save(outputPath, gifOptions);
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
 * 1. When a photographer needs to generate a lightweight preview of a high‑resolution DNG RAW file for quick web viewing, they can reduce the image to a 256‑color palette and save it as a GIF using C# and Aspose.Imaging.
 * 2. When an e‑commerce platform wants to display product photos captured in DNG format on low‑bandwidth mobile devices, converting them to 256‑color GIFs provides fast loading while preserving essential visual details.
 * 3. When a digital archivist must store large collections of RAW DNG images in a space‑efficient format for metadata‑rich catalogs, creating GIF thumbnails with a limited palette helps reduce storage costs.
 * 4. When a developer builds an email marketing tool that embeds RAW camera shots, converting DNG files to 256‑color GIFs ensures compatibility with email clients that only support GIF images.
 * 5. When a scientific imaging application needs to generate quick visual summaries of DNG microscopy data for reporting dashboards, using Aspose.Imaging to palette‑reduce and save as GIF enables fast rendering in C#‑based web apps.
 */