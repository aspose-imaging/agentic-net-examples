using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Read the input file into a memory stream
            byte[] fileBytes = File.ReadAllBytes(inputPath);
            using (MemoryStream memoryStream = new MemoryStream(fileBytes))
            {
                // Load the PNG image from the memory stream
                using (Image image = Image.Load(memoryStream))
                {
                    // Flip the image vertically
                    image.RotateFlip(RotateFlipType.RotateNoneFlipY);

                    // Prepare the stream for writing the modified image
                    memoryStream.SetLength(0);
                    memoryStream.Position = 0;

                    // Save the flipped image back into the same memory stream
                    image.Save(memoryStream, new PngOptions());
                }

                // Write the modified stream to the output file
                memoryStream.Position = 0;
                using (FileStream outputFile = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                {
                    memoryStream.CopyTo(outputFile);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}