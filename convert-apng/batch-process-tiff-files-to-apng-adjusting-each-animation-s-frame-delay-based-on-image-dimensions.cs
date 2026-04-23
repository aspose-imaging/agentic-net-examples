using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded list of input TIFF files (relative paths)
            string[] inputFiles = { "input1.tif", "input2.tif" };

            foreach (var inputPath in inputFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Load the TIFF image
                using (Image image = Image.Load(inputPath))
                {
                    // Compute frame delay based on image dimensions (example: average of width and height)
                    uint frameDelay = (uint)((image.Width + image.Height) / 2);

                    // Determine output APNG path (same name with .apng extension)
                    string outputPath = Path.ChangeExtension(inputPath, ".apng");

                    // Ensure the output directory exists (guard against null directory)
                    string outputDir = Path.GetDirectoryName(outputPath);
                    if (!string.IsNullOrWhiteSpace(outputDir))
                    {
                        Directory.CreateDirectory(outputDir);
                    }

                    // Save as APNG with the calculated default frame time
                    image.Save(outputPath, new ApngOptions { DefaultFrameTime = frameDelay });
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}