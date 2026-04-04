using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output paths
        string inputPath = "Input/sample.bmp";
        string outputPath = "Output/readOnly.bmp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Open a read‑only file stream (will cause save to fail)
        using (FileStream stream = new FileStream(outputPath, FileMode.OpenOrCreate, FileAccess.Read))
        {
            try
            {
                // Load the source image
                using (Image image = Image.Load(inputPath))
                {
                    // Prepare BMP save options
                    BmpOptions options = new BmpOptions();

                    // Attempt to save to the read‑only stream
                    image.Save(stream, options);
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during saving
                Console.Error.WriteLine($"Error saving image: {ex.Message}");
            }
        }
    }
}