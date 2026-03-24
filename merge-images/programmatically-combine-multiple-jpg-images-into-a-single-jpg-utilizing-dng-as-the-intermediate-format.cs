using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input JPG files
        string[] inputPaths = new string[]
        {
            @"C:\Images\img1.jpg",
            @"C:\Images\img2.jpg",
            @"C:\Images\img3.jpg"
        };

        // Hardcoded output JPG file
        string outputPath = @"C:\Images\combined.jpg";

        // Verify input files exist
        foreach (string inputPath in inputPaths)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Convert each JPG to a temporary DNG file
        List<string> dngPaths = new List<string>();
        foreach (string inputPath in inputPaths)
        {
            string tempDngPath = Path.Combine(Path.GetTempPath(),
                Path.GetFileNameWithoutExtension(inputPath) + ".dng");

            // Ensure temp directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(tempDngPath));

            using (Image jpgImage = Image.Load(inputPath))
            {
                // Save as DNG (Aspose infers format from extension)
                jpgImage.Save(tempDngPath);
            }

            dngPaths.Add(tempDngPath);
        }

        // Collect sizes of all DNG images
        List<Size> sizes = new List<Size>();
        foreach (string dngPath in dngPaths)
        {
            using (Image dngImage = Image.Load(dngPath))
            {
                sizes.Add(dngImage.Size);
            }
        }

        // Calculate canvas dimensions for horizontal stitching
        int canvasWidth = 0;
        int canvasHeight = 0;
        foreach (Size sz in sizes)
        {
            canvasWidth += sz.Width;
            if (sz.Height > canvasHeight)
                canvasHeight = sz.Height;
        }

        // Prepare JPEG options for the output canvas
        Source outSource = new FileCreateSource(outputPath, false);
        JpegOptions jpegOptions = new JpegOptions()
        {
            Source = outSource,
            Quality = 90
        };

        // Create the output JPEG canvas and merge images
        using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
        {
            int offsetX = 0;
            foreach (string dngPath in dngPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(dngPath))
                {
                    Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                    canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                    offsetX += img.Width;
                }
            }

            // Save the bound image (outputPath is already bound via Source)
            canvas.Save();
        }

        // Cleanup temporary DNG files
        foreach (string dngPath in dngPaths)
        {
            try { File.Delete(dngPath); } catch { /* ignore */ }
        }
    }
}