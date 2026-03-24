using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input JPEG files
        string[] inputPaths = new string[]
        {
            @"C:\Images\input1.jpg",
            @"C:\Images\input2.jpg",
            @"C:\Images\input3.jpg"
        };

        // Hardcoded output JPEG file
        string outputPath = @"C:\Images\combined_output.jpg";

        // Verify each input file exists
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
        List<Aspose.Imaging.Size> sizes = new List<Aspose.Imaging.Size>();
        foreach (string path in inputPaths)
        {
            using (RasterImage img = (RasterImage)Image.Load(path))
            {
                sizes.Add(img.Size);
            }
        }

        // Calculate canvas dimensions for horizontal stitching
        int canvasWidth = 0;
        int canvasHeight = 0;
        foreach (var sz in sizes)
        {
            canvasWidth += sz.Width;
            if (sz.Height > canvasHeight)
                canvasHeight = sz.Height;
        }

        // Temporary BMP file for intermediate canvas
        string tempBmpPath = Path.Combine(Path.GetTempPath(), "temp_canvas.bmp");
        Directory.CreateDirectory(Path.GetDirectoryName(tempBmpPath));

        // Create BMP canvas
        BmpOptions bmpOptions = new BmpOptions();
        bmpOptions.Source = new FileCreateSource(tempBmpPath, false);
        using (RasterImage canvas = (RasterImage)Image.Create(bmpOptions, canvasWidth, canvasHeight))
        {
            // Merge each JPEG onto the canvas horizontally
            int offsetX = 0;
            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    Aspose.Imaging.Rectangle bounds = new Aspose.Imaging.Rectangle(offsetX, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }
            }

            // Save the merged canvas as JPEG
            JpegOptions jpegOptions = new JpegOptions();
            jpegOptions.Source = new FileCreateSource(outputPath, false);
            jpegOptions.Quality = 90;
            canvas.Save(outputPath, jpegOptions);
        }

        // Cleanup temporary BMP file
        if (File.Exists(tempBmpPath))
        {
            try { File.Delete(tempBmpPath); } catch { /* ignore cleanup errors */ }
        }
    }
}