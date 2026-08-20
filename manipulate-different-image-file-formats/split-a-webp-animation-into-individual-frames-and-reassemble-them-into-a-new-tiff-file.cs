// HOW-TO: Extract WebP Animation Frames and Create Multipage TIFF in C# (Aspose.Imaging for .NET)
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
            string inputPath = @"C:\temp\animation.webp";
            string outputPath = @"C:\temp\result.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (WebPImage webP = new WebPImage(inputPath))
            {
                IMultipageImage multipage = webP as IMultipageImage;
                if (multipage == null || multipage.PageCount == 0)
                {
                    Console.Error.WriteLine("The WebP image does not contain any frames.");
                    return;
                }

                int frameCount = multipage.PageCount;

                RasterImage firstFrame = (RasterImage)webP.Pages[0];
                int width = firstFrame.Width;
                int height = firstFrame.Height;

                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiffOptions.Source = new FileCreateSource(outputPath, false);

                using (Image tiffBase = Image.Create(tiffOptions, width, height))
                {
                    TiffImage tiff = (TiffImage)tiffBase;

                    tiff.SavePixels(tiff.ActiveFrame.Bounds, firstFrame.LoadPixels(firstFrame.Bounds));

                    for (int i = 1; i < frameCount; i++)
                    {
                        RasterImage frame = (RasterImage)webP.Pages[i];
                        tiff.AddFrame(new TiffFrame(tiffOptions, width, height));
                        tiff.Frames[i].SavePixels(tiff.Frames[i].Bounds, frame.LoadPixels(frame.Bounds));
                    }

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
 * 1. When you need to convert an animated WebP advertisement into a multi‑page TIFF for archival or printing.
 * 2. When a web service must break down a WebP animation into individual frames to generate a PDF or document.
 * 3. When a desktop application processes user‑uploaded WebP animations and stores them as TIFF stacks for further analysis.
 * 4. When a batch job converts a collection of animated WebP files into TIFF sequences for compatibility with legacy imaging tools.
 * 5. When you want to extract each frame of a WebP animation to edit them separately and then re‑assemble into a single TIFF file.
 */
