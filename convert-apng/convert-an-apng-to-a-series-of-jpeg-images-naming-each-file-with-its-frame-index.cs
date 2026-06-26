using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Input APNG file (relative path)
            string inputPath = "Input\\animation.apng";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Output directory for JPEG frames
            string outputDirectory = "Output";
            Directory.CreateDirectory(outputDirectory);

            // Load the APNG image
            using (ApngImage apng = (ApngImage)Image.Load(inputPath))
            {
                // Iterate through each frame
                for (int i = 0; i < apng.PageCount; i++)
                {
                    // Get the frame as ApngFrame
                    using (ApngFrame frame = (ApngFrame)apng.Pages[i])
                    {
                        // Build output file path with frame index
                        string outputPath = Path.Combine(outputDirectory, $"frame_{i}.jpg");

                        // Ensure the output directory exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the frame as JPEG
                        frame.Save(outputPath, new JpegOptions());
                    }
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
 * 1. When a developer needs to extract each frame from an animated PNG (APNG) and store them as separate JPEG files for use in a web gallery or thumbnail preview, this code provides a straightforward C# solution using Aspose.Imaging.
 * 2. When a video editing pipeline requires converting animation frames from an APNG into JPEG images to be imported into a timeline or compositing tool, the code can automate the frame‑by‑frame extraction in .NET.
 * 3. When an e‑commerce platform wants to generate product image sequences from an APNG animation and save them as JPEGs with indexed filenames for SEO‑friendly URLs, this snippet handles the conversion efficiently.
 * 4. When a mobile app backend must preprocess user‑uploaded APNG stickers by splitting them into individual JPEG frames for caching or offline display, the provided C# example demonstrates how to achieve it with Aspose.Imaging.
 * 5. When a data‑analysis script needs to analyze each frame of an APNG by converting them to JPEG format for pixel‑level processing in machine‑learning models, this code extracts and names the frames automatically.
 */