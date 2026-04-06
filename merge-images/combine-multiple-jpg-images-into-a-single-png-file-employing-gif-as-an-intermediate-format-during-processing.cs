using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;

class Program
{
    static void Main()
    {
        // Hardcoded input JPG files
        string[] inputPaths = new string[]
        {
            @"C:\Images\image1.jpg",
            @"C:\Images\image2.jpg",
            @"C:\Images\image3.jpg"
        };

        // Verify each input file exists
        foreach (var inputPath in inputPaths)
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
        }

        // Hardcoded intermediate GIF and final PNG output paths
        string intermediatePath = @"C:\Images\combined.gif";
        string outputPath = @"C:\Images\combined.png";

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(intermediatePath));
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load JPG images as RasterImage objects
        RasterImage[] rasterImages = new RasterImage[inputPaths.Length];
        for (int i = 0; i < inputPaths.Length; i++)
        {
            rasterImages[i] = (RasterImage)Image.Load(inputPaths[i]);
        }

        // Create a multipage GIF using the first raster as the initial frame
        using (var gifImage = new GifImage(new GifFrameBlock(rasterImages[0])))
        {
            // Add remaining rasters as pages
            for (int i = 1; i < rasterImages.Length; i++)
            {
                gifImage.AddPage(rasterImages[i]);
            }

            // Save the GIF to the intermediate file
            gifImage.Save(intermediatePath);
        }

        // Dispose the raster images (they are no longer needed)
        foreach (var raster in rasterImages)
        {
            raster.Dispose();
        }

        // Load the intermediate GIF and save it as a PNG
        using (Image gif = Image.Load(intermediatePath))
        {
            gif.Save(outputPath, new PngOptions());
        }
    }
}