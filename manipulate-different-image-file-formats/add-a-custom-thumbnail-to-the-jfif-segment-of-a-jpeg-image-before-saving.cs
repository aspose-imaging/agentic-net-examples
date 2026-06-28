using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.jpg";
            string outputPath = "output/output.jpg";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the JPEG image
            using (JpegImage jpegImage = new JpegImage(inputPath))
            {
                // Create a thumbnail raster image (100x100 pixels)
                PngOptions thumbOptions = new PngOptions();
                using (RasterImage thumb = (RasterImage)Image.Create(thumbOptions, 100, 100))
                {
                    // Fill the thumbnail with a solid red color
                    Graphics graphics = new Graphics(thumb);
                    using (SolidBrush brush = new SolidBrush(Color.Red))
                    {
                        graphics.FillRectangle(brush, thumb.Bounds);
                    }

                    // Prepare JFIF data and assign the thumbnail
                    JFIFData jfif = new JFIFData();
                    jfif.Thumbnail = thumb;
                    jpegImage.Jfif = jfif;

                    // Save the modified JPEG image
                    jpegImage.Save(outputPath);
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
 * 1. When a developer needs to embed a branded preview image (e.g., a red logo thumbnail) directly into the JFIF segment of a JPEG file for faster preview in file explorers or digital asset management systems.
 * 2. When an e‑commerce platform wants to generate lightweight thumbnail previews for product photos without creating separate thumbnail files, by inserting a 100 × 100 pixel JPEG thumbnail using Aspose.Imaging in C#.
 * 3. When a photo‑sharing application must preserve a custom thumbnail in the JPEG metadata so that mobile devices display a consistent preview before the full image is downloaded.
 * 4. When a document‑generation workflow requires adding a color‑coded thumbnail to scanned JPEG pages to indicate processing status (e.g., red for pending) directly in the image file.
 * 5. When a developer is building a batch image‑processing tool that adds a solid‑color thumbnail to legacy JPEGs to improve compatibility with older image viewers that rely on the JFIF thumbnail field.
 */