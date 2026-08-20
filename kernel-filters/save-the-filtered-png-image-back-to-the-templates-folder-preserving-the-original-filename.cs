// HOW-TO: Save Processed PNG Back To Original File In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input path
            string inputPath = @"templates\sample.png";

            // Verify the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Example processing: set a PNG save option (filter type)
                PngOptions saveOptions = new PngOptions
                {
                    FilterType = Aspose.Imaging.FileFormats.Png.PngFilterType.Adaptive
                };

                // Preserve original filename and folder for output
                string outputPath = inputPath;

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the processed image
                image.Save(outputPath, saveOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to apply an adaptive PNG filter to a template image and overwrite the original file without changing its name.
 * 2. When a web application generates PNG assets in a “templates” folder and must update them in‑place after applying compression settings.
 * 3. When an automated build script processes design mockups and must preserve the original file path while saving the optimized PNG.
 * 4. When a desktop tool modifies PNG metadata or color depth and you want to save the changes directly back to the source file.
 * 5. When you are creating a batch job that iterates through PNG templates, applies Aspose.Imaging options, and writes each result to the same location.
 */
