using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\multi.tif";
            string outputPath = "Output\\result.apng";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image tiffImage = Image.Load(inputPath))
            {
                if (tiffImage is IMultipageImage multipage)
                {
                    Image firstPage = multipage.Pages[0];
                    int width = firstPage.Width;
                    int height = firstPage.Height;

                    ApngOptions apngOptions = new ApngOptions
                    {
                        Source = new FileCreateSource(outputPath, false)
                    };

                    using (ApngImage apng = (ApngImage)Image.Create(apngOptions, width, height))
                    {
                        apng.RemoveAllFrames();

                        for (int i = 0; i < multipage.PageCount; i++)
                        {
                            Image page = multipage.Pages[i];
                            RasterImage rasterPage = (RasterImage)page;
                            uint delay = (uint)((i + 1) * 100); // unique delay per frame
                            apng.AddFrame(rasterPage, delay);
                        }

                        apng.Save();
                    }
                }
                else
                {
                    Console.Error.WriteLine("The input image is not a multipage image.");
                    return;
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
 * 1. When creating animated product catalogs that need to display each high‑resolution TIFF page for a different duration in a web‑friendly APNG file.
 * 2. When converting scanned multi‑page documents into an animated PNG where each page’s display time reflects its importance, using C# and Aspose.Imaging.
 * 3. When building a medical imaging viewer that turns a multi‑slice TIFF series into an APNG animation with custom frame delays to highlight varying scan intervals.
 * 4. When generating time‑lapse visualizations from satellite imagery stored as a multi‑page TIFF, assigning increasing delays per frame before exporting to APNG.
 * 5. When developing an e‑learning module that animates step‑by‑step diagrams stored in a TIFF stack, setting unique delays for each step and saving the result as an APNG for cross‑platform playback.
 */