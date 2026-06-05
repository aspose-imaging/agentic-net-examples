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
            // Hard‑coded input and output paths
            string inputPath = "input.png";
            string outputPath = "output.apng";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates it if necessary)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the source image (any format, including a single‑frame APNG)
            using (Image image = Image.Load(inputPath))
            {
                // Save the image as APNG. When the source contains only one static frame,
                // the resulting file remains a valid APNG with a single frame,
                // preserving backward compatibility.
                image.Save(outputPath, new ApngOptions());
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}