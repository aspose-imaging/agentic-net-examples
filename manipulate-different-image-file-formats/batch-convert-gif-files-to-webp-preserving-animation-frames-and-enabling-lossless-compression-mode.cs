// HOW-TO: Batch Convert Animated GIFs to Lossless WebP in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputDirectory = @"C:\InputGifs";
        string outputDirectory = @"C:\OutputWebp";

        try
        {
            // Ensure the output directory exists (creates parent directories as needed)
            Directory.CreateDirectory(outputDirectory);

            // Get all GIF files in the input directory
            string[] gifFiles = Directory.GetFiles(inputDirectory, "*.gif");

            foreach (string inputPath in gifFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Build the output file path with .webp extension
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".webp";
                string outputPath = Path.Combine(outputDirectory, outputFileName);

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the GIF (including animation frames) and save as lossless WebP
                using (Image image = Image.Load(inputPath))
                {
                    var webpOptions = new WebPOptions
                    {
                        Lossless = true,
                        Quality = 100 // Maximum quality for lossless mode
                    };

                    image.Save(outputPath, webpOptions);
                }

                Console.WriteLine($"Converted: {inputPath} -> {outputPath}");
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
 * 1. When you need to shrink a collection of animated GIF advertisements for faster web page loading while keeping every frame intact, you can batch convert them to lossless WebP using C#.
 * 2. When preparing assets for a mobile game that requires high‑quality, animation‑preserving textures, this code lets you transform multiple GIF sprites into lossless WebP files in one step.
 * 3. When migrating a legacy e‑learning platform’s animated tutorials from GIF to the more efficient WebP format, the script automates the conversion of all files while preserving animation.
 * 4. When building an automated CI/CD pipeline that optimizes image assets, you can use this code to convert newly added GIFs to lossless WebP before deployment.
 * 5. When creating a digital marketing email campaign and want to reduce attachment size without losing animation quality, the batch converter processes all GIFs to lossless WebP with a single C# routine.
 */
