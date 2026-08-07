// HOW-TO: Split WebP Animation into Frames and Create Multi‑Page TIFF in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.webp";
            string outputPath = "output.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (WebPImage webp = new WebPImage(inputPath))
            {
                IMultipageImage multipage = webp as IMultipageImage;
                if (multipage == null || multipage.PageCount == 0)
                {
                    Console.Error.WriteLine("No frames found in the WebP animation.");
                    return;
                }

                // Assume all frames have the same dimensions as the first frame
                RasterImage firstFrame = (RasterImage)multipage.Pages[0];
                int width = firstFrame.Width;
                int height = firstFrame.Height;

                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiffOptions.Source = new FileCreateSource(outputPath, false);

                using (TiffImage tiff = (TiffImage)Image.Create(tiffOptions, width, height))
                {
                    // Copy first frame pixels to the base image
                    tiff.SavePixels(tiff.Bounds, firstFrame.LoadPixels(firstFrame.Bounds));

                    // Process remaining frames
                    for (int i = 1; i < multipage.PageCount; i++)
                    {
                        RasterImage frame = (RasterImage)multipage.Pages[i];
                        tiff.AddFrame(new TiffFrame(tiffOptions, width, height));
                        TiffFrame tiffFrame = tiff.Frames[i];
                        tiffFrame.SavePixels(tiffFrame.Bounds, frame.LoadPixels(frame.Bounds));
                    }

                    // Save the assembled TIFF file
                    tiff.Save();
                }
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
 * 1. When you need to extract each frame from an animated WebP to process or edit them individually before archiving them as a single multi‑page TIFF document.
 * 2. When a web application must convert user‑uploaded animated WebP stickers into a TIFF file that can be opened in legacy desktop publishing tools.
 * 3. When a batch job has to transform a series of WebP animations into TIFF stacks for printing or archival workflows that only accept TIFF.
 * 4. When you want to programmatically generate a multi‑page TIFF report by combining frames of a WebP animation with other raster images using C# and Aspose.Imaging.
 * 5. When an image‑processing pipeline requires converting WebP animation frames to a TIFF format to leverage TIFF‑specific features such as lossless compression or multi‑layer support.
 */
