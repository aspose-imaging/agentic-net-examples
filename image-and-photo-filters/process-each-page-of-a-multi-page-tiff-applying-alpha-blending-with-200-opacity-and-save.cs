using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.tif";
            string outputPath = "output.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (TiffImage tiff = (TiffImage)Image.Load(inputPath))
            {
                foreach (var frame in tiff.Frames)
                {
                    tiff.ActiveFrame = frame;

                    // Create an overlay image filled with white color
                    using (RasterImage overlay = (RasterImage)Image.Create(
                        new BmpOptions { Source = new StreamSource(new MemoryStream()) },
                        frame.Width,
                        frame.Height))
                    {
                        var whitePixels = Enumerable.Repeat(Aspose.Imaging.Color.White, frame.Width * frame.Height).ToArray();
                        overlay.SavePixels(new Rectangle(0, 0, frame.Width, frame.Height), whitePixels);

                        // Blend the overlay onto the current frame with opacity 200
                        ((RasterImage)frame).Blend(new Point(0, 0), overlay, 200);
                    }
                }

                // Save the modified multi‑page TIFF
                var saveOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiff.Save(outputPath, saveOptions);
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
 * 1. When a developer needs to add a semi‑transparent white watermark to every page of a multi‑page TIFF for printing or archival purposes, they can use this C# Aspose.Imaging code to blend a white overlay with 200 opacity onto each frame.
 * 2. When a developer must normalize the brightness of each scanned page in a multi‑page TIFF, blending a white overlay with 200 opacity using Aspose.Imaging ensures a consistent lightening effect across all frames.
 * 3. When a developer prepares a multi‑page TIFF for PDF conversion and requires a uniform background, the code applies alpha blending with 200 opacity to each frame to achieve consistent visual appearance.
 * 4. When a developer implements a document processing pipeline that applies a light white tint to every page of a multi‑page TIFF to meet branding guidelines, this C# example blends a white overlay at 200 opacity on each raster image.
 * 5. When a developer needs to adjust the opacity level of each frame in a multi‑page TIFF before sending it to a third‑party imaging service that expects a specific alpha value, the Aspose.Imaging blend operation with opacity 200 provides the required transformation.
 */