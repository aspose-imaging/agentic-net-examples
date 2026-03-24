using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.BigTiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input JPEG paths
        string[] inputPaths = new string[]
        {
            @"C:\Images\input1.jpg",
            @"C:\Images\input2.jpg",
            @"C:\Images\input3.jpg"
        };

        // Hardcoded output PNG path
        string outputPath = @"C:\Images\output.png";

        // Validate input files
        foreach (string path in inputPaths)
        {
            if (!File.Exists(path))
            {
                Console.Error.WriteLine($"File not found: {path}");
                return;
            }
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Collect sizes of all input images
        List<Size> sizes = new List<Size>();
        foreach (string path in inputPaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                sizes.Add(img.Size);
            }
        }

        // Calculate canvas dimensions for horizontal stitching
        int canvasWidth = sizes.Sum(s => s.Width);
        int canvasHeight = sizes.Max(s => s.Height);

        // Temporary path for the intermediate BigTIFF file
        string tempBigTiffPath = Path.Combine(Path.GetDirectoryName(outputPath), "temp_big.tif");
        Directory.CreateDirectory(Path.GetDirectoryName(tempBigTiffPath));

        // Create BigTIFF canvas
        Source bigTiffSource = new FileCreateSource(tempBigTiffPath, false);
        BigTiffOptions bigOptions = new BigTiffOptions(TiffExpectedFormat.Default)
        {
            Source = bigTiffSource
        };

        using (BigTiffImage canvas = (BigTiffImage)Image.Create(bigOptions, canvasWidth, canvasHeight))
        {
            int offsetX = 0;
            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    int[] pixels = img.LoadArgb32Pixels(img.Bounds);
                    Rectangle destRect = new Rectangle(offsetX, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(destRect, pixels);
                    offsetX += img.Width;
                }
            }

            // Save the merged result as PNG
            Source pngSource = new FileCreateSource(outputPath, false);
            PngOptions pngOptions = new PngOptions
            {
                Source = pngSource
            };
            canvas.Save(outputPath, pngOptions);
        }

        // Optionally delete the temporary BigTIFF file
        if (File.Exists(tempBigTiffPath))
        {
            try { File.Delete(tempBigTiffPath); } catch { }
        }
    }
}