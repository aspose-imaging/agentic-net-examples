using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath1 = "input1.png";
        string inputPath2 = "input2.png";
        string outputPath = "output.png";

        // Validate input files
        if (!File.Exists(inputPath1))
        {
            Console.Error.WriteLine($"File not found: {inputPath1}");
            return;
        }
        if (!File.Exists(inputPath2))
        {
            Console.Error.WriteLine($"File not found: {inputPath2}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load background image from memory stream
        using (MemoryStream bgStream = new MemoryStream(File.ReadAllBytes(inputPath1)))
        using (RasterImage background = (RasterImage)Image.Load(bgStream))
        // Load overlay image from memory stream
        using (MemoryStream overlayStream = new MemoryStream(File.ReadAllBytes(inputPath2)))
        using (RasterImage overlay = (RasterImage)Image.Load(overlayStream))
        {
            // Apply alpha blending (50% opacity)
            background.Blend(new Point(0, 0), overlay, 128);

            // Save blended image to an output memory stream
            using (MemoryStream outStream = new MemoryStream())
            {
                PngOptions pngOptions = new PngOptions();
                background.Save(outStream, pngOptions);

                // Write the memory stream to the output file
                outStream.Position = 0;
                using (FileStream fileOut = new FileStream(outputPath, FileMode.Create))
                {
                    outStream.CopyTo(fileOut);
                }
            }
        }
    }
}