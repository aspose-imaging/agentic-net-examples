using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;

class Program
{
    static void Main(string[] args)
    {
        // Folder containing source JPG images
        string inputFolder = @"C:\Images\JpgFrames";
        // Output GIF file path
        string outputPath = @"C:\Images\Combined.gif";

        // Get all JPG files in the folder
        string[] jpgFiles = Directory.GetFiles(inputFolder, "*.jpg");
        if (jpgFiles.Length == 0)
        {
            Console.WriteLine("No JPG files found in the specified folder.");
            return;
        }

        // Load the first image to create the initial GIF frame
        using (RasterImage firstFrame = (RasterImage)Image.Load(jpgFiles[0]))
        {
            // Create a GIF image using the first frame
            using (GifImage gif = new GifImage(new GifFrameBlock(firstFrame)))
            {
                // Add remaining JPG images as additional frames
                foreach (string filePath in jpgFiles.Skip(1))
                {
                    using (RasterImage frame = (RasterImage)Image.Load(filePath))
                    {
                        gif.AddPage(frame);
                    }
                }

                // Save the animated GIF
                gif.Save(outputPath);
            }
        }

        Console.WriteLine($"Combined GIF saved to: {outputPath}");
    }
}