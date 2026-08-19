// HOW-TO: Merge Multi‑Page CMX Into Single‑Page TIFF Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.cmx";
            string outputPath = "output.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (CmxImage cmx = (CmxImage)Image.Load(inputPath))
            {
                int canvasWidth = cmx.Width;
                int canvasHeight = cmx.Height;

                Source fileSource = new FileCreateSource(outputPath, false);
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default) { Source = fileSource };

                using (RasterImage canvas = (RasterImage)Image.Create(tiffOptions, canvasWidth, canvasHeight))
                {
                    foreach (CmxImagePage page in cmx.Pages)
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            PngOptions pngOptions = new PngOptions { Source = new StreamSource(memoryStream) };
                            page.Save(memoryStream, pngOptions);
                            memoryStream.Position = 0;

                            using (RasterImage pageRaster = (RasterImage)Image.Load(memoryStream))
                            {
                                var bounds = new Rectangle(0, 0, pageRaster.Width, pageRaster.Height);
                                canvas.SaveArgb32Pixels(bounds, pageRaster.LoadArgb32Pixels(pageRaster.Bounds));
                            }
                        }
                    }

                    canvas.Save();
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
 * 1. When you need to archive legacy CorelDRAW CMX drawings as a single TIFF file for long‑term storage or compliance.
 * 2. When a printing workflow requires converting each page of a multi‑page CMX document into one combined TIFF image for batch printing.
 * 3. When a document management system only accepts TIFF files, and you must merge multiple CMX pages into a single uploadable image.
 * 4. When you want to generate a preview thumbnail of a multi‑page CMX file by flattening all pages into one high‑resolution TIFF.
 * 5. When integrating legacy CMX assets into a .NET application that processes TIFF images, you need to programmatically transform and merge the pages.
 */
