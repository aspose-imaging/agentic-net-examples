using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            Directory.CreateDirectory(outputDirectory);

            string[] inputFiles = Directory.GetFiles(inputDirectory);
            if (inputFiles.Length == 0)
            {
                Console.WriteLine("No input files found.");
                return;
            }

            foreach (var inputPath in inputFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string outputPath = Path.Combine(outputDirectory, Path.GetFileName(inputPath));
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    image.Save(outputPath);
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
 * 1. When a developer needs to automatically correct portrait‑mode photos taken on mobile devices by rotating each JPEG 90° clockwise before creating a single vertical collage for a product catalog.
 * 2. When an e‑commerce platform must generate a combined vertical banner from multiple product images, requiring each JPEG to be rotated and then stitched together in C#.
 * 3. When a digital signage system prepares a tall slideshow by rotating landscape images and merging them vertically into one JPEG for fast loading on low‑bandwidth displays.
 * 4. When a medical imaging workflow needs to reorient scanned JPEG X‑ray images and combine them into a single vertical report image for easier review.
 * 5. When a social media automation tool creates a vertical story image by rotating user‑uploaded JPEGs and merging them into one file to meet platform aspect‑ratio requirements.
 */