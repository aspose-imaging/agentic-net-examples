using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\sample.gif";
        string outputPath = @"C:\temp\output.gif";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists (unconditional)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the image from the input file
        using (Image image = Image.Load(inputPath))
        {
            // Cast to GifImage to access the Rotate method
            GifImage gifImage = image as GifImage;
            if (gifImage == null)
            {
                Console.Error.WriteLine("The loaded image is not a GIF image.");
                return;
            }

            // Rotate 30 degrees clockwise, resize proportionally, with black background
            gifImage.Rotate(30f, true, Color.Black);

            // Prepare a memory stream to hold the GIF data
            using (MemoryStream memoryStream = new MemoryStream())
            {
                // Save the rotated image to the memory stream using default GIF options
                GifOptions gifOptions = new GifOptions();
                gifImage.Save(memoryStream, gifOptions);

                // Write the memory stream contents to the output file
                memoryStream.Position = 0;
                using (FileStream fileStream = new FileStream(outputPath, FileMode.Create))
                {
                    memoryStream.CopyTo(fileStream);
                }
            }
        }
    }
}