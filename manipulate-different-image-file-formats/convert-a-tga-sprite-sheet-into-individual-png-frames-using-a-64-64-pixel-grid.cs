using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "sprite.tga";
            string outputDir = "Frames";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDir);

            using (Aspose.Imaging.RasterImage sprite = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
            {
                int frameWidth = 64;
                int frameHeight = 64;
                int cols = sprite.Width / frameWidth;
                int rows = sprite.Height / frameHeight;
                int frameIndex = 0;

                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        int offsetX = col * frameWidth;
                        int offsetY = row * frameHeight;

                        string outputPath = Path.Combine(outputDir, $"frame_{frameIndex}.png");
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        using (Aspose.Imaging.RasterImage frame = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Create(new PngOptions(), frameWidth, frameHeight))
                        {
                            int[] pixels = sprite.LoadArgb32Pixels(new Aspose.Imaging.Rectangle(offsetX, offsetY, frameWidth, frameHeight));
                            frame.SaveArgb32Pixels(new Aspose.Imaging.Rectangle(0, 0, frameWidth, frameHeight), pixels);
                            frame.Save(outputPath);
                        }

                        frameIndex++;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}