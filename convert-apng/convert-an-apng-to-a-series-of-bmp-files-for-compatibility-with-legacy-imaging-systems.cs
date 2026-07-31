using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.apng";
            string outputDirectory = "output";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists (creates even if null)
            Directory.CreateDirectory(outputDirectory);

            // Load the APNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to ApngImage to access frames/pages
                ApngImage apngImage = (ApngImage)image;

                int frameCount = apngImage.PageCount;

                // Iterate through each frame and save as BMP
                for (int i = 0; i < frameCount; i++)
                {
                    // Get the current frame
                    Image frame = apngImage.Pages[i];

                    // Build output file path
                    string outputPath = Path.Combine(outputDirectory, $"frame_{i:D4}.bmp");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the frame as BMP using BmpOptions
                    frame.Save(outputPath, new BmpOptions());
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
 * 1. When a developer needs to extract each frame of an animated PNG (APNG) and save them as individual BMP files for a legacy Windows application that only supports BMP images.
 * 2. When a C# program must preprocess animation assets by converting APNG frames into BMP format to feed into a third‑party image processing pipeline that does not understand PNG transparency.
 * 3. When an automation script has to generate a series of bitmap thumbnails from an APNG for printing on hardware that only accepts BMP files.
 * 4. When a developer is migrating a digital signage system and must replace APNG animations with static BMP frames because the signage firmware cannot decode animated PNGs.
 * 5. When a batch conversion tool written in .NET uses Aspose.Imaging to split an APNG into separate BMP files to archive each animation frame in a format compatible with older archival standards.
 */