using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hard‑coded input and output locations
            string inputDirectory = "Input";
            string outputPath = "Output/merged.jpg";

            // Ensure input directory exists (create if missing)
            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add JPEG files and rerun.");
                return;
            }

            // Ensure output directory exists (create if missing)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Gather JPEG files from the input directory
            string[] inputFiles = Directory.GetFiles(inputDirectory, "*.jpg");
            if (inputFiles.Length == 0)
            {
                Console.WriteLine("No JPEG files found in the input directory.");
                return;
            }

            // Verify each input file exists
            foreach (string file in inputFiles)
            {
                if (!File.Exists(file))
                {
                    Console.Error.WriteLine($"File not found: {file}");
                    return;
                }
            }

            // Collect sizes of all images
            List<Size> sizes = new List<Size>();
            foreach (string file in inputFiles)
            {
                using (RasterImage img = (RasterImage)Image.Load(file))
                {
                    sizes.Add(img.Size);
                }
            }

            // Calculate canvas dimensions (horizontal layout, vertical centering)
            int canvasWidth = sizes.Sum(s => s.Width);
            int canvasHeight = sizes.Max(s => s.Height);

            // Prepare JPEG options with bound output source
            JpegOptions jpegOptions = new JpegOptions
            {
                Source = new FileCreateSource(outputPath, false),
                Quality = 100
            };

            // Create the canvas image
            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
            {
                int offsetX = 0;
                foreach (string file in inputFiles)
                {
                    using (RasterImage img = (RasterImage)Image.Load(file))
                    {
                        // Center the image vertically on the canvas
                        int offsetY = (canvasHeight - img.Height) / 2;
                        Rectangle bounds = new Rectangle(offsetX, offsetY, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetX += img.Width;
                    }
                }

                // Save the bound canvas (no path needed because source is already set)
                canvas.Save();
            }

            Console.WriteLine($"Merged image saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to generate a single JPEG banner that combines multiple product photos side‑by‑side with each picture vertically centered on a common canvas for an e‑commerce catalog.
 * 2. When an application must create a social‑media collage where user‑uploaded JPEG images are stitched horizontally and centered to maintain a balanced layout before posting to Instagram or Facebook.
 * 3. When a reporting tool has to produce a printable photo strip PDF where individual JPEG snapshots are merged into one horizontally aligned image with vertical centering to ensure consistent margins.
 * 4. When a game developer wants to build a sprite sheet from separate JPEG assets, aligning each sprite in the middle of its column while concatenating them horizontally for efficient texture loading.
 * 5. When an email‑marketing system needs to embed a single merged JPEG containing several promotional images side‑by‑side, each centered vertically, to reduce the number of HTTP requests and improve load speed.
 */