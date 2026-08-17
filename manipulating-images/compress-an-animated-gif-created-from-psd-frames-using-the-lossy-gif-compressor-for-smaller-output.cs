// HOW-TO: Compress Animated GIF Created from PSD Frames Using Lossy GIF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;

class Program
{
    static void Main()
    {
        // Hard‑coded input directory containing PSD frames and output file path
        string inputDirectory = @"C:\Temp\psd_frames";
        string outputPath = @"C:\Temp\output\animated_lossy.gif";

        try
        {
            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Get all PSD files in the input directory
            string[] psdFiles = Directory.GetFiles(inputDirectory, "*.psd");
            if (psdFiles.Length == 0)
            {
                Console.Error.WriteLine($"No PSD files found in: {inputDirectory}");
                return;
            }

            // Verify each input file exists (safety rule)
            foreach (string file in psdFiles)
            {
                if (!File.Exists(file))
                {
                    Console.Error.WriteLine($"File not found: {file}");
                    return;
                }
            }

            // Load the first frame and create the GifImage
            using (RasterImage firstRaster = (RasterImage)Image.Load(psdFiles[0]))
            using (GifFrameBlock firstBlock = new GifFrameBlock(firstRaster))
            using (GifImage gifImage = new GifImage(firstBlock))
            {
                // Add remaining frames
                for (int i = 1; i < psdFiles.Length; i++)
                {
                    using (RasterImage raster = (RasterImage)Image.Load(psdFiles[i]))
                    using (GifFrameBlock block = new GifFrameBlock(raster))
                    {
                        gifImage.AddBlock(block);
                    }
                }

                // Configure lossy compression options
                var saveOptions = new GifOptions
                {
                    MaxDiff = 80,               // Enable lossy compression (recommended value)
                    DoPaletteCorrection = true // Improve palette quality
                };

                // Save the animated GIF with the specified options
                gifImage.Save(outputPath, saveOptions);
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
 * 1. When you need to generate a lightweight animated GIF from a series of Photoshop PSD layers for web pages.
 * 2. When you want to reduce the file size of an animation without converting the source files to another format.
 * 3. When you must ensure all PSD frames exist before building the GIF to avoid runtime errors.
 * 4. When you need to apply Aspose.Imaging’s lossy GIF compression to meet strict bandwidth or email attachment limits.
 * 5. When you are automating a batch process that reads PSD files from a folder and outputs a compressed animated GIF in a .NET application.
 */
