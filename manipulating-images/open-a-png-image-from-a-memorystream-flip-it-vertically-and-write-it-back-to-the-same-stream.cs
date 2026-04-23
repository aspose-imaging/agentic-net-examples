using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "input.png";
        string outputPath = "output.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG file into a memory stream
            using (MemoryStream memoryStream = new MemoryStream())
            {
                // Read file bytes into the stream
                byte[] fileBytes = File.ReadAllBytes(inputPath);
                memoryStream.Write(fileBytes, 0, fileBytes.Length);
                memoryStream.Position = 0; // Reset for reading

                // Load image from the memory stream
                using (Image image = Image.Load(memoryStream))
                {
                    // Flip the image vertically
                    image.RotateFlip(RotateFlipType.RotateNoneFlipY);

                    // Prepare the stream for saving (clear previous data)
                    memoryStream.SetLength(0);
                    memoryStream.Position = 0;

                    // Save the modified image back into the same memory stream as PNG
                    image.Save(memoryStream, new PngOptions());
                }

                // Write the resulting stream to the output file
                memoryStream.Position = 0;
                using (FileStream outFile = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                {
                    memoryStream.CopyTo(outFile);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}