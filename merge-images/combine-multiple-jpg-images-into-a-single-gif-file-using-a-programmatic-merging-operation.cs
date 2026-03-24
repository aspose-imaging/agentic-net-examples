using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;

class Program
{
    static void Main()
    {
        // Hardcoded input JPG file paths
        string[] inputPaths = {
            "image1.jpg",
            "image2.jpg",
            "image3.jpg"
        };

        // Hardcoded output GIF path
        string outputPath = "merged.gif";

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

        // Load the first image and create the initial GIF frame
        using (RasterImage firstImg = (RasterImage)Image.Load(inputPaths[0]))
        {
            GifFrameBlock firstBlock = new GifFrameBlock(firstImg);
            using (GifImage gif = new GifImage(firstBlock))
            {
                // Add remaining images as additional frames
                for (int i = 1; i < inputPaths.Length; i++)
                {
                    using (RasterImage img = (RasterImage)Image.Load(inputPaths[i]))
                    {
                        gif.AddPage(img);
                    }
                }

                // Save the resulting animated GIF
                gif.Save(outputPath);
            }
        }
    }
}