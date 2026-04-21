using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.gif";
            string outputPath = "output.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (GifImage gif = (GifImage)Image.Load(inputPath))
            {
                // Ensure there is at least one frame
                if (gif.PageCount > 0)
                {
                    // Set the first frame as active
                    gif.ActiveFrame = (GifFrameBlock)gif.Pages[0];

                    // Deskew the active frame
                    Aspose.Imaging.RasterImage frame = (Aspose.Imaging.RasterImage)gif.ActiveFrame;
                    frame.NormalizeAngle(false, Aspose.Imaging.Color.LightGray);
                }

                // Save the corrected GIF
                gif.Save(outputPath, new GifOptions());
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}