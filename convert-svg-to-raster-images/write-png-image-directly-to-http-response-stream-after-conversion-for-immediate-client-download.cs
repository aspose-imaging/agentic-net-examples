using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input/sample.jpg";
            string outputPath = "Output/sample_converted.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image, convert to PNG, and write to the HTTP response stream (simulated with MemoryStream)
            using (Image image = Image.Load(inputPath))
            using (var pngOptions = new PngOptions())
            using (var responseStream = new MemoryStream())
            {
                image.Save(responseStream, pngOptions);
                // Simulate sending the response: output the size of the generated PNG
                Console.WriteLine($"PNG image written to response stream. Size: {responseStream.Length} bytes.");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}