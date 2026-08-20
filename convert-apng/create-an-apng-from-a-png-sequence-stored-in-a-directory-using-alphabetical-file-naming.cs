// HOW-TO: Create Animated PNG From Alphabetically Sorted PNG Frames In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input directory containing PNG frames and output APNG path
        string inputDirectory = @"C:\Images\Frames";
        string outputPath = @"C:\Images\output.apng";

        try
        {
            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Get PNG files sorted alphabetically
            string[] pngFiles = Directory.GetFiles(inputDirectory, "*.png")
                                          .OrderBy(f => f)
                                          .ToArray();

            // Verify each input file exists
            foreach (string file in pngFiles)
            {
                if (!File.Exists(file))
                {
                    Console.Error.WriteLine($"File not found: {file}");
                    return;
                }
            }

            if (pngFiles.Length == 0)
            {
                Console.Error.WriteLine("No PNG files found in the input directory.");
                return;
            }

            // Load the first image to obtain dimensions
            using (RasterImage firstImage = (RasterImage)Image.Load(pngFiles[0]))
            {
                int width = firstImage.Width;
                int height = firstImage.Height;

                // Create APNG options with bound output source
                ApngOptions createOptions = new ApngOptions
                {
                    Source = new FileCreateSource(outputPath, false),
                    ColorType = PngColorType.TruecolorWithAlpha
                };

                // Create the APNG canvas
                using (ApngImage apngImage = (ApngImage)Image.Create(createOptions, width, height))
                {
                    // Remove the default empty frame
                    apngImage.RemoveAllFrames();

                    // Add each PNG as a frame
                    foreach (string pngPath in pngFiles)
                    {
                        using (RasterImage frame = (RasterImage)Image.Load(pngPath))
                        {
                            apngImage.AddFrame(frame);
                        }
                    }

                    // Save the APNG (bound image, so just call Save())
                    apngImage.Save();
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
 * 1. When you need to generate a lightweight animated image for a web banner from a series of PNG files that are named in alphabetical order.
 * 2. When you want to combine frame‑by‑frame screenshots of a UI test into a single APNG for documentation or bug reporting.
 * 3. When you have a folder of PNG assets exported from a design tool and must programmatically create an animated PNG to embed in a mobile app.
 * 4. When an automated build process must produce an APNG from rendered PNG frames to visualize simulation results without manual editing.
 * 5. When you need to batch‑convert a sequence of PNG icons into an animated PNG for use in a game’s loading screen, preserving transparency.
 */
