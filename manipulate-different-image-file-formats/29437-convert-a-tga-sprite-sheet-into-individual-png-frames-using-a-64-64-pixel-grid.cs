using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "sprite.tga";
            string outputDirectory = "Frames";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (unconditional per rules)
            Directory.CreateDirectory(outputDirectory);

            // Load the TGA sprite sheet as a raster image
            using (RasterImage sheet = (RasterImage)Image.Load(inputPath))
            {
                const int frameWidth = 64;
                const int frameHeight = 64;

                int columns = sheet.Width / frameWidth;
                int rows = sheet.Height / frameHeight;

                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < columns; col++)
                    {
                        // Build output file path for the current frame
                        string outputPath = Path.Combine(outputDirectory, $"frame_{row}_{col}.png");

                        // Ensure the directory for this output file exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Define the region to extract
                        var region = new Rectangle(col * frameWidth, row * frameHeight, frameWidth, frameHeight);

                        // Save the region as a PNG file
                        sheet.Save(outputPath, new PngOptions(), region);
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