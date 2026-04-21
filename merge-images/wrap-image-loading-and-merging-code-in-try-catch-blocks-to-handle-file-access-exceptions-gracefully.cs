using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath1 = @"C:\temp\input1.png";
        string inputPath2 = @"C:\temp\input2.png";
        string inputPath3 = @"C:\temp\input3.png";
        string outputPath = @"C:\temp\merged.png";

        // Verify input files exist
        if (!File.Exists(inputPath1))
        {
            Console.Error.WriteLine($"File not found: {inputPath1}");
            return;
        }
        if (!File.Exists(inputPath2))
        {
            Console.Error.WriteLine($"File not found: {inputPath2}");
            return;
        }
        if (!File.Exists(inputPath3))
        {
            Console.Error.WriteLine($"File not found: {inputPath3}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Collect sizes of all input images
            List<Aspose.Imaging.Size> sizes = new List<Aspose.Imaging.Size>();
            using (RasterImage img1 = (RasterImage)Image.Load(inputPath1))
            {
                sizes.Add(new Aspose.Imaging.Size(img1.Width, img1.Height));
            }
            using (RasterImage img2 = (RasterImage)Image.Load(inputPath2))
            {
                sizes.Add(new Aspose.Imaging.Size(img2.Width, img2.Height));
            }
            using (RasterImage img3 = (RasterImage)Image.Load(inputPath3))
            {
                sizes.Add(new Aspose.Imaging.Size(img3.Width, img3.Height));
            }

            // Calculate canvas dimensions for horizontal merge
            int newWidth = sizes[0].Width + sizes[1].Width + sizes[2].Width;
            int newHeight = Math.Max(Math.Max(sizes[0].Height, sizes[1].Height), sizes[2].Height);

            // Create output canvas bound to the output file
            Source outSource = new FileCreateSource(outputPath, false);
            PngOptions pngOptions = new PngOptions() { Source = outSource };
            using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, newWidth, newHeight))
            {
                int offsetX = 0;
                foreach (string path in new[] { inputPath1, inputPath2, inputPath3 })
                {
                    using (RasterImage img = (RasterImage)Image.Load(path))
                    {
                        Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetX += img.Width;
                    }
                }
                // Save the bound image
                canvas.Save();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}