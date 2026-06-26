using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/multipage.tif";
            string outputPath = "Output/animation.apng";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                TiffImage tiffImage = (TiffImage)image;

                int canvasWidth = tiffImage.Frames[0].Width;
                int canvasHeight = tiffImage.Frames[0].Height;

                ApngOptions apngOptions = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    ColorType = PngColorType.TruecolorWithAlpha
                };

                using (ApngImage apngImage = (ApngImage)Image.Create(apngOptions, canvasWidth, canvasHeight))
                {
                    apngImage.RemoveAllFrames();

                    for (int i = 0; i < tiffImage.Frames.Length; i++)
                    {
                        tiffImage.ActiveFrame = tiffImage.Frames[i];
                        RasterImage rasterFrame = (RasterImage)tiffImage;
                        apngImage.AddFrame(rasterFrame);

                        ApngFrame apngFrame = (ApngFrame)apngImage.Pages[apngImage.PageCount - 1];

                        double dpi = tiffImage.HorizontalResolution > 0 ? tiffImage.HorizontalResolution : 72.0;
                        uint frameDuration = (uint)Math.Max(10, Math.Round(1000.0 / dpi));

                        apngFrame.FrameTime = (int)frameDuration;
                    }

                    apngImage.Save();
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
 * 1. When a medical imaging application needs to turn a multi‑page DICOM‑exported TIFF scan into an animated PNG for web‑based patient reports, preserving the scan’s DPI‑based timing.
 * 2. When a GIS system exports layered satellite imagery as a multi‑page TIFF and wants to create an APNG slideshow where higher‑resolution tiles stay on screen longer.
 * 3. When an e‑learning platform receives scanned lecture slides in a multi‑page TIFF and must generate an animated PNG that respects each slide’s original DPI to control slide display speed.
 * 4. When a digital archiving tool converts scanned historical documents stored as multi‑page TIFFs into APNG animations, using the DPI of each page to set frame durations for smooth scrolling.
 * 5. When a printing workflow creates proof animations from multi‑page TIFF proofs, converting them to APNG while using each page’s resolution to determine how long each frame appears in the preview.
 */