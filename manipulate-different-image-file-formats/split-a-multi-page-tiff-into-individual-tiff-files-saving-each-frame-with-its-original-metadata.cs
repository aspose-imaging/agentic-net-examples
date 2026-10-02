// HOW-TO: Split Multi‑Page TIFF Into Separate Files While Preserving Metadata In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input/multipage.tif";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (TiffImage tiff = (TiffImage)Image.Load(inputPath))
            {
                int frameIndex = 0;
                foreach (TiffFrame frame in tiff.Frames)
                {
                    tiff.ActiveFrame = frame;

                    string outputPath = $"output/frame_{frameIndex + 1}.tif";
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    TiffOptions outOptions = tiff.GetOriginalOptions() as TiffOptions ?? new TiffOptions(TiffExpectedFormat.Default);
                    outOptions.Source = new FileCreateSource(outputPath, false);

                    using (TiffImage outImage = (TiffImage)Image.Create(outOptions, frame.Width, frame.Height))
                    {
                        RasterImage raster = (RasterImage)tiff;
                        var pixels = raster.LoadPixels(frame.Bounds);
                        outImage.SavePixels(outImage.Bounds, pixels);
                        outImage.Save();
                    }

                    frameIndex++;
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
 * 1. When you need to extract each page of a scanned multi‑page TIFF invoice into its own file for individual processing or archiving.
 * 2. When a medical imaging system must separate each frame of a multi‑frame TIFF X‑ray series into separate TIFFs while keeping original tags.
 * 3. When a document management workflow requires splitting a large TIFF document into single‑page TIFFs to upload them to a content‑management system.
 * 4. When a GIS application needs to isolate each raster layer stored in a multi‑page TIFF map into separate files without losing georeference metadata.
 * 5. When a batch conversion tool must break down a multi‑page TIFF into individual pages before applying per‑page transformations or OCR.
 */
