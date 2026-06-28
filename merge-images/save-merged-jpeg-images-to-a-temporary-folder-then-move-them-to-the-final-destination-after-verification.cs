using System;
using System.IO;
using System.Collections.Generic;
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
            // Hardcoded input JPEG file paths
            string[] inputPaths = new string[]
            {
                "input1.jpg",
                "input2.jpg",
                "input3.jpg"
            };

            // Verify each input file exists
            foreach (string path in inputPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            // Temporary and final output paths
            string tempOutputPath = "temp\\merged.jpg";
            string finalOutputPath = "output\\merged.jpg";

            // Ensure directories exist for temporary and final outputs
            Directory.CreateDirectory(Path.GetDirectoryName(tempOutputPath));
            Directory.CreateDirectory(Path.GetDirectoryName(finalOutputPath));

            // Collect sizes of all input images
            List<Size> sizes = new List<Size>();
            foreach (string path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    sizes.Add(img.Size);
                }
            }

            // Calculate canvas dimensions for horizontal merge
            int newWidth = 0;
            int newHeight = 0;
            foreach (Size sz in sizes)
            {
                newWidth += sz.Width;
                if (sz.Height > newHeight) newHeight = sz.Height;
            }

            // Create JPEG options with bound source
            Source source = new FileCreateSource(tempOutputPath, false);
            JpegOptions jpegOptions = new JpegOptions()
            {
                Source = source,
                Quality = 90
            };

            // Create bound JPEG canvas
            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, newWidth, newHeight))
            {
                int offsetX = 0;
                foreach (string path in inputPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(path))
                    {
                        Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetX += img.Width;
                    }
                }

                // Save the bound image
                canvas.Save();
            }

            // Verify temporary file and move to final destination
            if (File.Exists(tempOutputPath) && new FileInfo(tempOutputPath).Length > 0)
            {
                if (File.Exists(finalOutputPath))
                {
                    File.Delete(finalOutputPath);
                }
                File.Move(tempOutputPath, finalOutputPath);
                Console.WriteLine($"Merged image saved to: {finalOutputPath}");
            }
            else
            {
                Console.Error.WriteLine("Failed to create the merged image.");
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
 * 1. When building a web service that combines multiple product photos into a single promotional banner, a developer can merge the JPEGs in a temporary folder, verify the output, and then move the final image to the public assets directory.
 * 2. When automating the creation of a printable photo collage for a wedding album, the code can stitch the JPEG files horizontally, store the intermediate result securely, and only publish the verified collage to the client‑facing folder.
 * 3. When generating a composite satellite image from several high‑resolution JPEG tiles in a GIS application, the temporary save allows the system to confirm dimensions and quality before moving the merged file to the analysis workspace.
 * 4. When implementing a batch job that assembles scanned document pages into a single JPEG for archival, the temporary location ensures that any corrupted input is detected before the final file is placed in the secure archive folder.
 * 5. When creating a dynamic thumbnail strip for an e‑commerce site, the merged JPEG can be written to a temp directory, validated for correct width and height, and then transferred to the CDN folder for fast delivery.
 */