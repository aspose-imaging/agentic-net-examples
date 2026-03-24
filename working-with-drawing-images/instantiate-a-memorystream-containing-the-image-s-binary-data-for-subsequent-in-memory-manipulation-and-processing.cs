using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\sample.bmp";
        string outputPath = @"C:\temp\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load the image from the file
        using (Image image = Image.Load(inputPath))
        {
            // Prepare PNG save options
            PngOptions pngOptions = new PngOptions();

            // Create a MemoryStream to hold the image data in memory
            using (MemoryStream memoryStream = new MemoryStream())
            {
                // Save the image into the MemoryStream using the specified options
                image.Save(memoryStream, pngOptions);

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Write the MemoryStream contents to the output file
                memoryStream.Position = 0; // Reset stream position before reading
                using (FileStream fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                {
                    memoryStream.CopyTo(fileStream);
                }
            }
        }
    }
}