using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.jpg";
            string outputPath = "output.jpg";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the JPEG image
            using (JpegImage jpeg = (JpegImage)Aspose.Imaging.Image.Load(inputPath))
            {
                // Create a thumbnail image (100x100) in memory
                PngOptions thumbOptions = new PngOptions();
                using (Aspose.Imaging.Image thumbImg = Aspose.Imaging.Image.Create(thumbOptions, 100, 100))
                {
                    // Fill the thumbnail with a solid red color
                    Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics((Aspose.Imaging.RasterImage)thumbImg);
                    Aspose.Imaging.Brushes.SolidBrush brush = new Aspose.Imaging.Brushes.SolidBrush(Aspose.Imaging.Color.Red);
                    graphics.FillRectangle(brush, ((Aspose.Imaging.RasterImage)thumbImg).Bounds);
                    // Do NOT dispose graphics (Graphics does not implement IDisposable)

                    // Assign thumbnail to EXIF segment if EXIF data exists
                    if (jpeg.ExifData != null)
                    {
                        jpeg.ExifData.Thumbnail = (Aspose.Imaging.RasterImage)thumbImg;
                    }

                    // Ensure JFIF segment exists and assign thumbnail
                    if (jpeg.Jfif == null)
                    {
                        jpeg.Jfif = new JFIFData();
                    }
                    jpeg.Jfif.Thumbnail = (Aspose.Imaging.RasterImage)thumbImg;

                    // Save the modified JPEG image
                    jpeg.Save(outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}