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
            // Define input and output paths
            string inputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Input");
            string outputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            string outputPath = Path.Combine(outputDirectory, "merged_cmyk.jpg");

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Get JPEG files from input directory
            string[] inputFiles = Directory.GetFiles(inputDirectory, "*.jpg");

            if (inputFiles.Length == 0)
            {
                Console.Error.WriteLine("No JPEG files found in input directory.");
                return;
            }

            // Validate each input file exists
            foreach (string file in inputFiles)
            {
                if (!File.Exists(file))
                {
                    Console.Error.WriteLine($"File not found: {file}");
                    return;
                }
            }

            // Collect image sizes
            List<Size> sizes = new List<Size>();
            foreach (string file in inputFiles)
            {
                using (JpegImage img = (JpegImage)Image.Load(file))
                {
                    sizes.Add(new Size(img.Width, img.Height));
                }
            }

            // Calculate canvas dimensions for vertical merge
            int canvasWidth = sizes.Max(s => s.Width);
            int canvasHeight = sizes.Sum(s => s.Height);

            // Create output source and JPEG options (CMYK)
            Source outputSource = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions()
            {
                Source = outputSource,
                Quality = 100,
                ColorType = JpegCompressionColorMode.Cmyk
            };

            // Create canvas image
            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
            {
                int offsetY = 0;
                foreach (string file in inputFiles)
                {
                    using (JpegImage img = (JpegImage)Image.Load(file))
                    {
                        // Center image horizontally if narrower than canvas
                        int offsetX = (canvasWidth - img.Width) / 2;
                        Rectangle destRect = new Rectangle(offsetX, offsetY, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(destRect, img.LoadArgb32Pixels(img.Bounds));
                        offsetY += img.Height;
                    }
                }

                // Save the bound canvas (already bound to outputSource)
                canvas.Save();
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
 * 1. When a print shop needs to combine multiple product photos into a single CMYK‑encoded JPEG brochure page, this code converts each JPEG to CMYK and merges them vertically for accurate color reproduction.
 * 2. When an e‑commerce platform prepares a catalog thumbnail that stacks several product images, converting to CMYK ensures the final merged JPEG matches the colors used in printed marketing materials.
 * 3. When a marketing team creates a vertical banner from separate JPEG assets and must deliver a CMYK JPEG to a professional printer, this routine automates the color‑space conversion and stitching process.
 * 4. When a digital asset management system batches user‑uploaded JPEGs for archival printing, the code guarantees each image is in CMYK before they are vertically concatenated into a single file.
 * 5. When a photo‑editing application offers a “Combine Images for Print” feature, it can use this code to transform each source JPEG to CMYK and produce a vertically merged JPEG ready for high‑quality press output.
 */