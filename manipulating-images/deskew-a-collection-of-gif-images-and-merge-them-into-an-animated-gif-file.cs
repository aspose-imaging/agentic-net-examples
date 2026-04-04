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
        // Hardcoded input GIF paths
        string[] inputPaths = { "input1.gif", "input2.gif", "input3.gif" };
        // Hardcoded output GIF path
        string outputPath = "output.gif";

        // Verify each input file exists
        foreach (var path in inputPaths)
        {
            if (!File.Exists(path))
            {
                Console.Error.WriteLine($"File not found: {path}");
                return;
            }
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Load the first GIF to create the output canvas
        using (GifImage firstGif = (GifImage)Image.Load(inputPaths[0]))
        {
            // Deskew the first GIF
            firstGif.NormalizeAngle(false, Color.White);

            // Create the output GIF with the size of the first frame
            using (GifImage outputGif = new GifImage(new GifFrameBlock((ushort)firstGif.Width, (ushort)firstGif.Height)))
            {
                // Add all frames from the first GIF
                foreach (var page in firstGif.Pages)
                {
                    outputGif.AddPage((RasterImage)page);
                }

                // Process remaining GIFs
                for (int i = 1; i < inputPaths.Length; i++)
                {
                    using (GifImage gif = (GifImage)Image.Load(inputPaths[i]))
                    {
                        // Deskew each GIF
                        gif.NormalizeAngle(false, Color.White);

                        // Add all frames from the current GIF
                        foreach (var page in gif.Pages)
                        {
                            outputGif.AddPage((RasterImage)page);
                        }
                    }
                }

                // Prepare GIF save options (infinite loop)
                GifOptions options = new GifOptions
                {
                    LoopsCount = 0
                };

                // Save the merged animated GIF
                outputGif.Save(outputPath, options);
            }
        }
    }
}