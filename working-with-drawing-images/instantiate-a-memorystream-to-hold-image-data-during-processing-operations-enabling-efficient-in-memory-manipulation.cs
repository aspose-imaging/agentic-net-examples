using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hard‑coded input and output paths
        string inputPath = @"C:\temp\sample.bmp";
        string outputPath = @"C:\temp\output.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists (creates it unconditionally)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the image from disk
        using (Image image = Image.Load(inputPath))
        {
            // Example processing: rotate the image 180 degrees
            image.RotateFlip(RotateFlipType.Rotate180FlipNone);

            // Prepare a memory stream to hold the processed image data
            using (MemoryStream memoryStream = new MemoryStream())
            {
                // Define PNG save options (default settings)
                PngOptions pngOptions = new PngOptions();

                // Save the image into the memory stream
                image.Save(memoryStream, pngOptions);

                // Reset stream position before reading
                memoryStream.Position = 0;

                // Write the memory stream contents to the output file
                using (FileStream fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                {
                    memoryStream.CopyTo(fileStream);
                }
            }
        }
    }
}