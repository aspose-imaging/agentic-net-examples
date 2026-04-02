using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output file paths
        string inputPath1 = @"C:\Images\input1.jpg";
        string inputPath2 = @"C:\Images\input2.jpg";
        string outputPath = @"C:\Images\merged.png";

        // Verify that each input file exists
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

        // Ensure the output directory exists (unconditional call)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the two JPEG images
        using (Image img1 = Image.Load(inputPath1))
        using (Image img2 = Image.Load(inputPath2))
        {
            // Cast to RasterImage to obtain dimensions
            RasterImage raster1 = (RasterImage)img1;
            RasterImage raster2 = (RasterImage)img2;

            // Determine size of the merged image (horizontal concatenation)
            int mergedWidth = raster1.Width + raster2.Width;
            int mergedHeight = Math.Max(raster1.Height, raster2.Height);

            // Create a new blank PNG image with the merged dimensions
            PngOptions createOptions = new PngOptions();
            using (Image mergedImage = Image.Create(createOptions, mergedWidth, mergedHeight))
            {
                // Draw the first source image at (0,0)
                Graphics graphics = new Graphics(mergedImage);
                graphics.DrawImage(raster1, new Rectangle(0, 0, raster1.Width, raster1.Height));

                // Draw the second source image to the right of the first
                graphics.DrawImage(raster2, new Rectangle(raster1.Width, 0, raster2.Width, raster2.Height));

                // Prepare save options with 150 DPI resolution
                PngOptions saveOptions = new PngOptions
                {
                    ResolutionSettings = new ResolutionSetting(150.0, 150.0)
                };

                // Save the merged image as PNG
                mergedImage.Save(outputPath, saveOptions);
            }
        }
    }
}