using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input directory and output file path
            string inputDirectory = "Input";
            string outputPath = "Output\\contact_sheet.jpg";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Collect JPEG files from the input directory
            string[] allFiles = Directory.GetFiles(inputDirectory);
            List<string> jpegFiles = new List<string>();
            foreach (var file in allFiles)
            {
                string ext = Path.GetExtension(file).ToLowerInvariant();
                if (ext == ".jpg" || ext == ".jpeg")
                {
                    jpegFiles.Add(file);
                }
            }

            // List to hold extracted thumbnails
            List<RasterImage> thumbnails = new List<RasterImage>();
            List<Size> thumbSizes = new List<Size>();

            // Extract EXIF thumbnails
            foreach (var jpegPath in jpegFiles)
            {
                if (!File.Exists(jpegPath))
                {
                    Console.Error.WriteLine($"File not found: {jpegPath}");
                    return;
                }

                using (JpegImage jpegImage = (JpegImage)Image.Load(jpegPath))
                {
                    // Ensure EXIF data exists
                    var exif = jpegImage.ExifData;
                    if (exif != null && exif.Thumbnail != null)
                    {
                        // Load the thumbnail as a RasterImage
                        RasterImage thumb = (RasterImage)exif.Thumbnail;
                        // Keep a reference to the thumbnail for later merging
                        thumbnails.Add(thumb);
                        thumbSizes.Add(thumb.Size);
                    }
                }
            }

            if (thumbnails.Count == 0)
            {
                Console.WriteLine("No EXIF thumbnails found.");
                return;
            }

            // Calculate canvas size (vertical stacking)
            int canvasWidth = 0;
            int canvasHeight = 0;
            foreach (var size in thumbSizes)
            {
                if (size.Width > canvasWidth) canvasWidth = size.Width;
                canvasHeight += size.Height;
            }

            // Prepare JPEG options for the contact sheet
            Source outputSource = new FileCreateSource(outputPath, false);
            JpegOptions jpegOptions = new JpegOptions()
            {
                Source = outputSource,
                Quality = 90
            };

            // Create the canvas bound to the output file
            using (JpegImage canvas = (JpegImage)Image.Create(jpegOptions, canvasWidth, canvasHeight))
            {
                int offsetY = 0;
                for (int i = 0; i < thumbnails.Count; i++)
                {
                    RasterImage thumb = thumbnails[i];
                    Rectangle bounds = new Rectangle(0, offsetY, thumb.Width, thumb.Height);
                    // Copy thumbnail pixels onto the canvas
                    canvas.SaveArgb32Pixels(bounds, thumb.LoadArgb32Pixels(thumb.Bounds));
                    offsetY += thumb.Height;
                }

                // Save the bound canvas
                canvas.Save();
            }

            // Dispose thumbnails
            foreach (var thumb in thumbnails)
            {
                thumb.Dispose();
            }

            Console.WriteLine($"Contact sheet saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}