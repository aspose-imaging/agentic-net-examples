using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.webp";
            string outputPath = "output.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load animated WebP image
            using (WebPImage webpImage = (WebPImage)Image.Load(inputPath))
            {
                // Create a new grayscale palette (256 colors)
                Aspose.Imaging.Color[] newPalette = new Aspose.Imaging.Color[256];
                for (int i = 0; i < 256; i++)
                {
                    newPalette[i] = Aspose.Imaging.Color.FromArgb(i, i, i);
                }

                // Apply the new palette to the image
                webpImage.Palette = new ColorPalette(newPalette);

                // Save the modified animation as APNG
                webpImage.Save(outputPath, new ApngOptions());
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}