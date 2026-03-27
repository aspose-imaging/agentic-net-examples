using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.tga";
        string outputDir = "output_frames";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(outputDir);

        // Load the TGA sprite sheet
        using (RasterImage spriteSheet = (RasterImage)Image.Load(inputPath))
        {
            int frameWidth = 64;
            int frameHeight = 64;

            int columns = spriteSheet.Width / frameWidth;
            int rows = spriteSheet.Height / frameHeight;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    // Build output file path for the current frame
                    string outputPath = Path.Combine(outputDir, $"frame_{row}_{col}.png");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Create a bound PNG canvas
                    Source source = new FileCreateSource(outputPath, false);
                    PngOptions pngOptions = new PngOptions() { Source = source };
                    using (RasterImage canvas = (RasterImage)Image.Create(pngOptions, frameWidth, frameHeight))
                    {
                        // Define source rectangle within the sprite sheet
                        Rectangle srcRect = new Rectangle(col * frameWidth, row * frameHeight, frameWidth, frameHeight);

                        // Load pixel data from the sprite sheet
                        int[] pixels = spriteSheet.LoadArgb32Pixels(srcRect);

                        // Save pixel data to the new PNG canvas
                        canvas.SaveArgb32Pixels(new Rectangle(0, 0, frameWidth, frameHeight), pixels);

                        // Save the bound image (no path needed)
                        canvas.Save();
                    }
                }
            }
        }
    }
}