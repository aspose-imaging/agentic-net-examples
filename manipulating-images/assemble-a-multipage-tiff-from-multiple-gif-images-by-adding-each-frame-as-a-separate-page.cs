// HOW-TO: Assemble Multipage TIFF From Several GIF Images Using Aspose.Imaging C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string gifPath1 = "Input/gif1.gif";
            string gifPath2 = "Input/gif2.gif";
            string gifPath3 = "Input/gif3.gif";
            string outputPath = "Output/multipage.tif";

            if (!File.Exists(gifPath1)) { Console.Error.WriteLine($"File not found: {gifPath1}"); return; }
            if (!File.Exists(gifPath2)) { Console.Error.WriteLine($"File not found: {gifPath2}"); return; }
            if (!File.Exists(gifPath3)) { Console.Error.WriteLine($"File not found: {gifPath3}"); return; }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (GifImage firstGif = (GifImage)Image.Load(gifPath1))
            {
                int width = firstGif.Width;
                int height = firstGif.Height;

                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                using (TiffImage tiff = (TiffImage)Image.Create(tiffOptions, width, height))
                {
                    int pageIndex = 0;
                    string[] gifPaths = new[] { gifPath1, gifPath2, gifPath3 };
                    foreach (var gifPath in gifPaths)
                    {
                        using (GifImage gif = (GifImage)Image.Load(gifPath))
                        {
                            for (int i = 0; i < gif.PageCount; i++)
                            {
                                using (MemoryStream ms = new MemoryStream())
                                {
                                    PngOptions pngOptions = new PngOptions();
                                    pngOptions.MultiPageOptions = new MultiPageOptions(new IntRange(i, i + 1));
                                    gif.Save(ms, pngOptions);
                                    ms.Position = 0;
                                    using (Image frameImg = Image.Load(ms))
                                    {
                                        if (frameImg.Width != width || frameImg.Height != height)
                                        {
                                            frameImg.Resize(width, height, ResizeType.NearestNeighbourResample);
                                        }

                                        if (pageIndex == 0)
                                        {
                                            ((RasterImage)tiff).SavePixels(tiff.Bounds, ((RasterImage)frameImg).LoadPixels(frameImg.Bounds));
                                        }
                                        else
                                        {
                                            tiff.AddFrame(new TiffFrame(tiffOptions, width, height));
                                            tiff.ActiveFrame = tiff.Frames[pageIndex];
                                            ((RasterImage)tiff).SavePixels(tiff.Bounds, ((RasterImage)frameImg).LoadPixels(frameImg.Bounds));
                                        }
                                        pageIndex++;
                                    }
                                }
                            }
                        }
                    }

                    tiff.Save(outputPath);
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
 * 1. When you need to combine animated GIF frames into a single multi‑page TIFF for archival or printing.
 * 2. When a document workflow requires converting multiple GIF files into one TIFF to embed in a PDF.
 * 3. When you want to preserve each GIF frame as a separate page in a TIFF for medical imaging or scanning applications.
 * 4. When a web service must deliver a batch of GIFs as a single TIFF file to reduce network requests.
 * 5. When an automated script must generate a multi‑page TIFF from user‑uploaded GIFs for further image analysis.
 */
