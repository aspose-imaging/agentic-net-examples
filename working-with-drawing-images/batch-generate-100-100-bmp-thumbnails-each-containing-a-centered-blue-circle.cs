using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string[] inputPaths = new string[]
            {
                @"C:\Images\input1.png",
                @"C:\Images\input2.jpg",
                @"C:\Images\input3.tif"
            };

            string[] outputPaths = new string[]
            {
                @"C:\Thumbnails\thumb1.bmp",
                @"C:\Thumbnails\thumb2.bmp",
                @"C:\Thumbnails\thumb3.bmp"
            };

            for (int i = 0; i < inputPaths.Length; i++)
            {
                string inputPath = inputPaths[i];
                string outputPath = outputPaths[i];

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Create BMP canvas bound to output file
                BmpOptions bmpOptions = new BmpOptions();
                Source fileSource = new FileCreateSource(outputPath, false);
                bmpOptions.Source = fileSource;

                using (RasterImage canvas = (RasterImage)Image.Create(bmpOptions, 100, 100))
                {
                    // Load and resize source image
                    using (RasterImage srcImage = (RasterImage)Image.Load(inputPath))
                    {
                        srcImage.Resize(100, 100, ResizeType.NearestNeighbourResample);
                        // Draw resized image onto canvas
                        canvas.SaveArgb32Pixels(new Rectangle(0, 0, 100, 100), srcImage.LoadArgb32Pixels(srcImage.Bounds));
                    }

                    // Draw centered blue circle
                    Graphics graphics = new Graphics(canvas);
                    int radius = 40;
                    int centerX = 50;
                    int centerY = 50;
                    int left = centerX - radius;
                    int top = centerY - radius;
                    int diameter = radius * 2;
                    graphics.DrawEllipse(new Pen(Color.Blue, 2), new Rectangle(left, top, diameter, diameter));

                    // Save the bound image
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
 * 1. When a developer needs to create low‑resolution BMP preview icons for a mixed set of PNG, JPEG and TIFF files to display in a Windows file‑explorer style grid, they can use this code to batch generate 100 × 100 thumbnails with a consistent blue circle overlay.
 * 2. When an e‑learning platform wants to embed uniform 100 × 100 BMP thumbnails with a branding element (the centered blue circle) alongside course images of various formats, this snippet automates the resizing and overlay process in C#.
 * 3. When a legacy desktop application only accepts BMP images for its thumbnail pane, developers can employ this routine to convert incoming PNG, JPG or TIF assets into 100 × 100 BMP thumbnails while adding a visual cue (blue circle) for quick identification.
 * 4. When a content‑management system needs to pre‑process uploaded media into small BMP preview files for fast loading on low‑bandwidth devices, the code provides a batch workflow that resizes, saves as BMP, and draws a centered blue circle using Aspose.Imaging.
 * 5. When a QA team requires a reproducible set of 100 × 100 BMP test images with a known graphic element (the blue circle) to validate image‑processing pipelines, this C# example generates the thumbnails from diverse source formats in an automated way.
 */