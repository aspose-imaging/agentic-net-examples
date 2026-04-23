using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.gif";
            string outputPath = "output.gif";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a memory stream to hold the GIF data
            using (MemoryStream memoryStream = new MemoryStream())
            {
                // Load the GIF image
                using (GifImage image = (GifImage)Aspose.Imaging.Image.Load(inputPath))
                {
                    // Rotate 30 degrees, resize proportionally, black background
                    image.Rotate(30f, true, Aspose.Imaging.Color.Black);

                    // Save the rotated image to the memory stream in GIF format
                    GifOptions saveOptions = new GifOptions();
                    image.Save(memoryStream, saveOptions);
                }

                // Optionally write the memory stream to a file for verification
                memoryStream.Position = 0;
                using (FileStream fileStream = new FileStream(outputPath, FileMode.Create))
                {
                    memoryStream.CopyTo(fileStream);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}