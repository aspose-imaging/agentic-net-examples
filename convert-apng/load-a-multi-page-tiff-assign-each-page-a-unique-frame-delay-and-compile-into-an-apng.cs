// HOW-TO: Convert Multi‑Page TIFF to Animated APNG with Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/multipage.tif";
            string outputPath = "Output/animated.apng";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image tiffImage = Image.Load(inputPath))
            {
                TiffImage tiff = (TiffImage)tiffImage;
                if (tiff.PageCount == 0)
                {
                    Console.Error.WriteLine("No pages found in the TIFF image.");
                    return;
                }

                // Get dimensions from the first page
                int width, height;
                using (RasterImage firstRaster = (RasterImage)tiff.Frames[0])
                {
                    width = firstRaster.Width;
                    height = firstRaster.Height;
                }

                ApngOptions apngOptions = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                using (ApngImage apng = (ApngImage)Image.Create(apngOptions, width, height))
                {
                    for (int i = 0; i < tiff.PageCount; i++)
                    {
                        using (RasterImage raster = (RasterImage)tiff.Frames[i])
                        {
                            apng.AddFrame(raster);
                        }
                    }

                    apng.Save();
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
 * 1. When you need to turn a scanned multi‑page TIFF document into a lightweight animated PNG for quick web preview.
 * 2. When you want to generate an APNG sprite sheet from each page of a TIFF to display step‑by‑step instructions in a desktop application.
 * 3. When a reporting tool must combine several TIFF chart pages into a single animated image for inclusion in email newsletters.
 * 4. When you are building a C# service that converts multi‑page medical imaging TIFFs into APNGs with custom frame delays for patient portals.
 * 5. When you need to programmatically create an animated PNG from TIFF frames to embed in a mobile app without using external tools.
 */
