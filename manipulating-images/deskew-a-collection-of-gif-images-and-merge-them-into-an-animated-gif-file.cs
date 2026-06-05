using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.Sources;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath1 = "input1.gif";
            string inputPath2 = "input2.gif";
            string inputPath3 = "input3.gif";
            string outputPath = "output.gif";

            // Validate input files
            if (!File.Exists(inputPath1)) { Console.Error.WriteLine($"File not found: {inputPath1}"); return; }
            if (!File.Exists(inputPath2)) { Console.Error.WriteLine($"File not found: {inputPath2}"); return; }
            if (!File.Exists(inputPath3)) { Console.Error.WriteLine($"File not found: {inputPath3}"); return; }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the first GIF to obtain canvas size
            using (RasterImage firstImg = (RasterImage)Image.Load(inputPath1))
            {
                // Deskew the image
                firstImg.NormalizeAngle(false, Aspose.Imaging.Color.White);
                int width = firstImg.Width;
                int height = firstImg.Height;

                // Create bound output GIF
                Source src = new FileCreateSource(outputPath, false);
                GifOptions gifOptions = new GifOptions() { Source = src };
                using (GifImage canvas = (GifImage)Image.Create(gifOptions, width, height))
                {
                    // Add the first (deskewed) image as a frame
                    canvas.AddPage(firstImg);

                    // Process and add the second GIF
                    using (RasterImage img2 = (RasterImage)Image.Load(inputPath2))
                    {
                        img2.NormalizeAngle(false, Aspose.Imaging.Color.White);
                        canvas.AddPage(img2);
                    }

                    // Process and add the third GIF
                    using (RasterImage img3 = (RasterImage)Image.Load(inputPath3))
                    {
                        img3.NormalizeAngle(false, Aspose.Imaging.Color.White);
                        canvas.AddPage(img3);
                    }

                    // Set infinite looping (0 means infinite in Aspose.Imaging)
                    canvas.LoopsCount = 0;

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