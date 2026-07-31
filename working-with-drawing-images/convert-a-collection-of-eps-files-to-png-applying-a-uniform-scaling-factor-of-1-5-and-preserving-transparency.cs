using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "InputEps";
            string outputDirectory = "OutputPng";

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add EPS files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] epsFiles = Directory.GetFiles(inputDirectory, "*.eps");

            foreach (string inputPath in epsFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".png");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (EpsImage image = (EpsImage)Image.Load(inputPath))
                {
                    int newWidth = (int)(image.Width * 1.5);
                    int newHeight = (int)(image.Height * 1.5);
                    image.Resize(newWidth, newHeight);
                    image.Save(outputPath, new PngOptions());
                }
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
 * 1. When a developer needs to batch‑convert a folder of EPS vector files to PNG images for a web gallery, applying a uniform 1.5× scaling factor and preserving transparency using Aspose.Imaging in C#.
 * 2. When a C# application must generate high‑resolution PNG previews of EPS logos for a branding portal, resizing each image by 150 % while keeping the alpha channel intact.
 * 3. When an automated build script has to process incoming EPS artwork files and output scaled PNG assets for mobile apps, ensuring the images retain their transparent backgrounds.
 * 4. When a document‑management system requires converting stored EPS diagrams to PNG thumbnails with consistent enlargement and transparent support for seamless UI rendering.
 * 5. When a developer is creating a bulk image‑processing tool that reads EPS files from a directory, enlarges them by 1.5×, and saves them as PNGs with preserved transparency for downstream graphic workflows.
 */